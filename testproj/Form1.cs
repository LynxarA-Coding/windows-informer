using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace testproj
{
    public partial class Form1 : Form
    {
        public string data;
        public Form1()
        {
            InitializeComponent();
        }

       public string WindowsInfo()
        {
            var startInfo = new ProcessStartInfo("cmd", "/c systeminfo");
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            startInfo.RedirectStandardOutput = true;

            var proc = new Process();
            proc.StartInfo = startInfo;
            proc.Start();

            var result = proc.StandardOutput.ReadToEnd();

            proc.WaitForExit();
            proc.Dispose();
            data += result;
            return result;
        }

        public string DriverInfo()
        {
            var startInfo = new ProcessStartInfo("cmd", "/c Driverquery");
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            startInfo.RedirectStandardOutput = true;

            var proc = new Process();
            proc.StartInfo = startInfo;
            proc.Start();

            var result = proc.StandardOutput.ReadToEnd();

            proc.WaitForExit();
            proc.Dispose();
            data += result;
            return result;
            
        }

        public string NetInfo()
        {
            var startInfo = new ProcessStartInfo("cmd", "/c ipconfig");
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            startInfo.RedirectStandardOutput = true;

            var proc = new Process();
            proc.StartInfo = startInfo;
            proc.Start();

            var result = proc.StandardOutput.ReadToEnd();

            proc.WaitForExit();
            proc.Dispose();
            data += result;
            return result;
        }

        public string ProcessScanner()
        {
            var startInfo = new ProcessStartInfo("cmd", "/c tasklist");
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            startInfo.RedirectStandardOutput = true;

            var proc = new Process();
            proc.StartInfo = startInfo;
            proc.Start();

            var result = proc.StandardOutput.ReadToEnd();

            proc.WaitForExit();
            proc.Dispose();
            data += result;
            return result;
        }

        public string DirectoryScanner()
        {
            string command = "/c tree " + textBox1.Text + " /F";
            var startInfo = new ProcessStartInfo("cmd", command);
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            startInfo.RedirectStandardOutput = true;

            var proc = new Process();
            proc.StartInfo = startInfo;
            proc.Start();

            var result = proc.StandardOutput.ReadToEnd();

            proc.WaitForExit();
            proc.Dispose();
            data += result;
            return result;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            data = "";
            comboBox1.SelectedItem = "English";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            data = "=====================\nИнформация о Windows:\n=====================\n";
            string result = WindowsInfo();
            TForm dialogScreen = new TForm();
            dialogScreen.richTextBox1.Text = data;
            dialogScreen.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            data = "=====================\nСписок Драйверов:\n=====================\n";
            string result = DriverInfo();
            TForm dialogScreen = new TForm();
            dialogScreen.richTextBox1.Text = data;
            dialogScreen.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string result = "";
            progressBar1.Value = 10;
            result += "=====================\nИнформация о Windows:\n=====================\n" + WindowsInfo();
            progressBar1.Value = 30;
            result += "=====================\nСписок Драйверов:\n=====================\n" + DriverInfo();
            progressBar1.Value = 50;
            result += "=====================\nИнформация о Инт. Соединении:\n=====================\n" + NetInfo();
            progressBar1.Value = 70;
            result += "=====================\nСписок Процессов:\n=====================\n" + ProcessScanner();
            progressBar1.Value = 90;

            progressBar1.Value = 100;
            SaveFileDialog svf = new SaveFileDialog();
            svf.Filter = "Text files (*.txt)|*.txt";
            svf.Title = "Logs";
            if (svf.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(svf.FileName);
                sw.Write(result);
                sw.Close();
            }
            data = result;

            progressBar1.Value = 0;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            data = "=====================\nИнформация о Инт. Соединении:\n=====================\n";
            string result = NetInfo();
            TForm dialogScreen = new TForm();
            dialogScreen.richTextBox1.Text = data;
            dialogScreen.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            data = "=====================\nСписок Процессов:\n=====================\n";
            string result = ProcessScanner();
            TForm dialogScreen = new TForm();
            dialogScreen.richTextBox1.Text = data;
            dialogScreen.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            data = "=====================\nПапки по Директории:\n=====================\n";
            string result = DirectoryScanner();
            TForm dialogScreen = new TForm();
            dialogScreen.richTextBox1.Text = data;
            dialogScreen.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "English")
            {
                button1.Text = "Files in Directory (use \"/\")";
                button2.Text = "Windows Info";
                button3.Text = "Drivers Info";
                button4.Text = "All in One File";
                button5.Text = "Internet Info";
                button6.Text = "Process List";
            }
            else
            {
                button1.Text = "Файлы по директории (используйте \"/\")";
                button2.Text = "Инф. о Windows";
                button3.Text = "Инф. о Драйверах";
                button4.Text = "Все в Один Файл";
                button5.Text = "Инф. о Интернете";
                button6.Text = "Процессы";
            }
        }
    }
}
