using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace testproj
{
    public partial class TForm : Form
    {
        public TForm()
        {
            InitializeComponent();
        }

        public string data;

        private void TForm_Load(object sender, EventArgs e)
        {
            data = richTextBox1.Text;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            data += DateTime.Now.ToString("HH:mm:ss") + " Сохранение Логов...\n";
            SaveFileDialog svf = new SaveFileDialog();
            svf.Filter = "Text files (*.txt)|*.txt";
            svf.Title = "Logs";
            if (svf.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(svf.FileName);
                sw.Write(data);
                sw.Close();
            }
            data += DateTime.Now.ToString("HH:mm:ss") + " Логи сохранены.\n";
        }
    }
}
