using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InstagramApiSharp;
using InstagramApiSharp.API;
using InstagramApiSharp.Classes;
using InstagramApiSharp.API.Builder;
using InstagramApiSharp.Logger;
using System.IO;


namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private IInstaApi api;
        private UserSessionData user;
        int sıralama=0;


        public Form1()
        {
            InitializeComponent();
        }
        public async void giris()
        {
            string username = "cobann46.5";
            string password = "rado4646";
            user = new UserSessionData
            {
                UserName = username,
                Password = password
            };
            api = InstaApiBuilder.CreateBuilder().SetUser(user).UseLogger(new DebugLogger(LogLevel.Exceptions)).Build();
            var loginRequest = await api.LoginAsync();
            if (loginRequest.Succeeded)
            {
                MessageBox.Show("Başarılı");
            }
            else
            {
                MessageBox.Show(loginRequest.Info.Message);
            }
        }
        public async void pp()
        {
            sıralama++;
            if (sıralama>10)
            {
                sıralama = 1;
            }
            
            var picturePath = $@"C:\Users\Rado\Desktop\pp\{sıralama}.jpg";
            var pictureBytes = File.ReadAllBytes(picturePath);
            await api.AccountProcessor.ChangeProfilePictureAsync(pictureBytes);

        }
            private void Form1_Load(object sender, EventArgs e)
            {
            giris();
            }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pp();
        }
    }
}
