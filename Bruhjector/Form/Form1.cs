using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;
using ManualMapInjection.Injection;
using System.Diagnostics;
using System.Media;
using Dashboard.Properties;
using DiscordRPC;
using Button = DiscordRPC.Button;

namespace Dashboard
{
    public partial class Bruhjector : Form
    {
        public DiscordRpcClient client;
        // фигня делающая приложению круглые рамки
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
         (
               int nLeftRect,
               int nTopRect,
               int nRightRect,
               int nBottomRect,
               int nWidthEllipse,
               int nHeightEllipse

         );
        string username = Environment.UserName;
        public Bruhjector()
        {
            InitializeComponent();
            var runningProcs = from proc in Process.GetProcesses(".") orderby proc.Id select proc;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            label7.Text = username;
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            // discord rpc
            client = new DiscordRpcClient("789858352854204426");
            client.Initialize();
            client.SetPresence(new RichPresence()
            {
                Details = "Injecting dll's",
                State = "Username:" + username,
                Assets = new Assets()
                {
                    LargeImageKey = "123",
                    LargeImageText = "https://yougame.biz/threads/222376/",
                    SmallImageKey = "123"
                }
            });

        }



        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e) // смена темы
        {
            if (guna2ToggleSwitch1.Checked)
            {
                // светлая тема
                this.BackColor = Color.FromArgb(202, 250, 254);
                panel1.BackColor = Color.FromArgb(80, 160, 240);
                panel2.BackColor = Color.FromArgb(80, 160, 240);
                panel4.BackColor = Color.FromArgb(151, 202, 239);
                label1.ForeColor = Color.FromArgb(202, 250, 254);
                rand.ForeColor = Color.FromArgb(201, 233, 240);
                label3.ForeColor = Color.FromArgb(202, 250, 254);
                label4.ForeColor = Color.FromArgb(202, 250, 254);
                label5.ForeColor = Color.FromArgb(202, 250, 254);
                label6.ForeColor = Color.FromArgb(202, 250, 254);
                label7.ForeColor = Color.FromArgb(202, 250, 254);
                label8.ForeColor = Color.FromArgb(202, 250, 254);
                button1.ForeColor = Color.FromArgb(202, 250, 254);
                button1.BackColor = Color.FromArgb(153, 204, 241);
                button2.ForeColor = Color.FromArgb(202, 250, 254);
                button2.BackColor = Color.FromArgb(153, 204, 241);
                button3.ForeColor = Color.FromArgb(202, 250, 254);
                button3.BackColor = Color.FromArgb(82, 162, 242);
                guna2ControlBox1.BackColor = Color.FromArgb(151, 202, 239);
            }
            else
            {
                // тёмная тема
                this.BackColor = Color.FromArgb(46, 51, 73);
                panel1.BackColor = Color.FromArgb(24, 30, 54);
                panel2.BackColor = Color.FromArgb(24, 30, 54);
                panel4.BackColor = Color.FromArgb(37, 42, 64);
                label1.ForeColor = Color.FromArgb(0, 126, 249);
                rand.ForeColor = Color.FromArgb(158, 161, 176);
                label3.ForeColor = Color.FromArgb(0, 126, 249);
                label4.ForeColor = Color.FromArgb(0, 126, 249);
                label5.ForeColor = Color.FromArgb(0, 126, 249);
                label6.ForeColor = Color.FromArgb(0, 126, 249);
                label7.ForeColor = Color.FromArgb(0, 126, 249);
                label8.ForeColor = Color.FromArgb(0, 126, 249);
                button1.ForeColor = Color.FromArgb(0, 126, 249);
                button1.BackColor = Color.FromArgb(39, 44, 66);
                button2.ForeColor = Color.FromArgb(0, 126, 249);
                button2.BackColor = Color.FromArgb(39, 44, 66);
                button3.ForeColor = Color.FromArgb(0, 126, 249);
                button3.BackColor = Color.FromArgb(26, 32, 56);
                guna2ControlBox1.BackColor = Color.FromArgb(37, 42, 64);
            }
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e) // кнопка закрытия
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Длл файл чита|*.dll";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    // изменение текста под имя DLL
                    string nameOfUploadedFile = Path.GetFileName(dialog.FileName);
                    label5.Text = nameOfUploadedFile;

                    // локальные переменные
                    string mainpath = dialog.InitialDirectory + dialog.FileName;
                    string[] tempArray = File.ReadAllLines(dialog.FileName);
                    var runningProcs = from proc in Process.GetProcesses(".") orderby proc.Id select proc;
                    string lines = File.ReadAllText(dialog.FileName);
                    var name = "csgo";
                    var target = Process.GetProcessesByName(name).FirstOrDefault();
                    var path = mainpath;
                    var file = File.ReadAllBytes(path);
                    SoundPlayer sound = new SoundPlayer(Properties.Resources.init1);

                    

                    // Проверка запущен ли процесс csgo
                    if (runningProcs.Count(p => p.ProcessName.Contains("csgo")) > 0)
                    {
                        // сам инжект
                        var injector = new ManualMapInjector(target) { AsyncInjection = true };
                        init.Text = $"hmodule = 0x{injector.Inject(file).ToInt64():x8}";
                        sound.Play();
                        MessageBox.Show(nameOfUploadedFile  + " Succefly Injected!");
                        // discord rpc
                        client.SetPresence(new RichPresence()
                        {
                            Details = "Playing in CS:GO With:",
                            State = nameOfUploadedFile,
                            Assets = new Assets()
                            {
                                LargeImageKey = "123",
                                LargeImageText = "https://yougame.biz/threads/222376/",
                                SmallImageKey = "123"
                            }
                        });
                    }
                    // если не найден процесс csgo
                    else
                    {
                        sound.Play();
                        MessageBox.Show("CS:GO IS NOT RUNNING! \n Click the button <Launch csgo> and try again", "Error");
                        label5.Text = "not selected";
                    }
                }
            }
        }
    

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //локальный переменные
            string temp = Path.GetTempPath();
            string file_exe = Path.GetTempPath() + "\\vac.exe";

            // килл процесса стима
            foreach (var process in Process.GetProcessesByName("steam.exe"))
            {
                process.Kill();
            }

            // сам вак байпасс
            FileStream fs = new FileStream(file_exe, FileMode.Create);
            fs.Write(Resources.vac, 0, Resources.vac.Length);
            fs.Close();
            Process.Start(file_exe);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // запуск кс го
            Process.Start("steam://rungameid/730");
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
