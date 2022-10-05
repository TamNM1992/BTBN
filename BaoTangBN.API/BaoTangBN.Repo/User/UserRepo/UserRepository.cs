using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using BaoTangBn.Data.Models;
using BaoTangBn.Data.Dtos;
using BaoTangBn.Common.Enums;

namespace BaoTangBn.Repo.UserRepo
{

    public class UserRepository : IUserRepository
    {
        private readonly BaoTangBNDataContext _userContext;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public UserRepository(BaoTangBNDataContext context, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _userContext = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public string GenerateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] 
                {
                    new Claim("id", user.Id.ToString()),
                    new Claim("Name", user.FullName)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public bool AddUser(UserDto user)
        {
            try
            {
                
                var salt = BCrypt.Net.BCrypt.GenerateSalt();
                var username = _userContext.User.SingleOrDefault(x=> x.UserName == user.UserName);
                
                if (username != null)
                    return false;

                var userEntity = _mapper.Map<UserDto, User>(user);
                string hashPass = BCrypt.Net.BCrypt.HashPassword(userEntity.Password, salt);
                userEntity.Password = hashPass;
                userEntity.PasswordSalt = salt;
                
                _userContext.User.Add(userEntity);
                _userContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public ActiveResponse GetPasswordHash(string userName)
        {
            var hashPass = _userContext.User.Where(x => x.UserName == userName).FirstOrDefault();

            if (hashPass != null)
            {
                var data = new ActiveResponse(hashPass.Password, " Get Password Hash success");
                return data;
            }
            else
            {
                var data = new ActiveResponse(null, " Get Password Hash fail");
                return data;
            }
        }
        public ActiveResponse GetPasswordSalt(string userName)
        {
            var saltPass = _userContext.User.Where(x => x.UserName == userName).FirstOrDefault();

            if (saltPass != null)
            {
                var data = new ActiveResponse(saltPass.Password, " Get Password Salt success");
                return data;
            }
            else
            {
                var data = new ActiveResponse(null, " Get Password Salt fail");
                return data;
            }
        }
        public AuthenticateResponse Authenticate(AuthenticateRequest request)
        {
            var user = _userContext.User.SingleOrDefault(x => x.UserName == request.UserName);
            
            // authentication successful so generate jwt token
            var token = GenerateJwtToken(user);
            return new AuthenticateResponse(user, token,"Get token complete");
        }

        public IEnumerable<User> GetAll()
        {
            
            return _userContext.User;
        }

        public User GetById(Guid id)
        {
            return _userContext.User.FirstOrDefault(x => x.Id == id);
        }

        public User GetByUserName(string username)
        {
            return _userContext.User.FirstOrDefault(x => x.UserName == username);
        }
    }
}
