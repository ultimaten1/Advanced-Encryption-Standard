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
using Group7_Module2.Service;

namespace Group7_Module2
{
    public partial class frmAES : Form
    {
        public frmAES()
        {
            InitializeComponent();
        }

        public string _generatedKey { get; set; }
        public byte[] encrypted {  get; set; }
        public byte[] decrypted { get; set; }
        public byte[] key { get; set; }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            string inputFile = txtInputFile.Text;

            // Thực hiện mã hóa cấu trúc tập tin
            AESFile.EncryptFileStructure(inputFile, key, 100);
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            string inputFile = txtInputFile.Text;

            // Chuyển đổi đường dẫn tương đối thành đường dẫn tuyệt đối
            inputFile = Path.GetFullPath(inputFile);

            // Thực hiện giải mã cấu trúc tập tin
            AESFile.DecryptFileStructure(inputFile, key);
        }

        private void btnGenerateKey_Click(object sender, EventArgs e)
        {
            //string generatedKey = AES.GenerateKey(16);  // Generate a key of 16 bytes
            //key = Encoding.ASCII.GetBytes(generatedKey);  // Convert the string key to byte array

            key = AES.GenerateKey(128); // Generate a key of 16 bytes
            string hexKey = BitConverter.ToString(key).Replace("-", " ");
            txtKey.Text = hexKey; // Display the hexadecimal key in the TextBox
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open file";
            openFileDialog.Filter = "All files (*.*)|*.*";
            openFileDialog.Multiselect = false; // Only selected one file

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                txtInputFile.Text = fileName;
            }
        }
    }
}
