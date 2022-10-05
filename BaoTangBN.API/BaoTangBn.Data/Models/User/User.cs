using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Data.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(50)]
        [Required] // not null
        public string UserName { get; set; }
        [MaxLength(500)]
        [Required] // not null
        public string Password { get; set; }
        [MaxLength(500)]
        [Required] // not null
        public string PasswordSalt { get; set; }
        [MaxLength(100)]
        [Required] // not null
        public string FullName { get; set; }
        [MaxLength(200)]
        public bool IsActive { get; set; }
        public User()
        {
            this.Roles = new HashSet<Role>();
        }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
