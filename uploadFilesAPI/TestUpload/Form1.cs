using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestUpload
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
            var API_UPLOAD = "http://localhost:45320/api/Home/UploadFile";

            using(var dlg = new OpenFileDialog())
            {
                dlg.Multiselect = true;
                if(dlg.ShowDialog() == DialogResult.OK)
                {
                    foreach (var filename in dlg.FileNames)
                    {
                        var client = new WebClient();
                        client.Headers.Add("Content-Type", "binary/octet-stream");                        
                        client.UploadFileAsync(new Uri(API_UPLOAD), filename);                      
                        client.UploadFileCompleted += Client_UploadFileCompleted;
                        client.UploadProgressChanged += Client_UploadProgressChanged;
                    }
                    
                }
            }
        }

        private void Client_UploadProgressChanged(object sender, UploadProgressChangedEventArgs e)
        {
            progressBar1.BeginInvoke(new Action(() => {
                var percent = e.BytesSent * 100 / e.TotalBytesToSend;              
                Console.WriteLine(percent + "");
                    progressBar1.Value = (int)percent;
                    label1.Text = percent.ToString() + "%";
                
                    
            }));
        }

        private void Client_UploadFileCompleted(object sender, UploadFileCompletedEventArgs e)
        {
            var data = Encoding.UTF8.GetString(e.Result);
            var responseData = JsonConvert.DeserializeObject<ResponseData>(data);
            if (responseData.status == "SUCCESS")
            {
                var link = JsonConvert.DeserializeObject<List<string>>( responseData.data);
                pictureBox1.LoadAsync(link.FirstOrDefault());

            }
            else
            {
                MessageBox.Show(responseData.message);
            }
            
        }

        public class ResponseData
        {
            public string status { get; set; }
            public string message { get; set; }
            public string data { get; set; }
        }


    }
}
