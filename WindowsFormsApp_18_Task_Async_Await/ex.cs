using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_18_Task_Async_Await
{
    public partial class ex : Form
    {
        public ex()
        {
            InitializeComponent();
        }
        public async Task ReadFileAsync()
        {
            string filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    try
                    {
                        using (StreamReader sr = new StreamReader(filePath))
                        {
                            string doc = await sr.ReadToEndAsync();
                            textBox1.Text = doc;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"파일을 읽는 중 오류 발생: {ex.Message}");
                    }
                }
            }
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            await ReadFileAsync();
        }
    }
}
