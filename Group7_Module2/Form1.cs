using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            string plainText = txtInputText.Text;
            plainText = AES.PadPlaintext(plainText);           
            plainText.Trim();

            byte[] key = Encoding.ASCII.GetBytes(_generatedKey);

            byte[] input = Encoding.ASCII.GetBytes(plainText);
            encrypted = AES.EncryptText(input, key);

            // Chuyển đổi decrypted thành chuỗi plaintext
            string encryptedPlaintext = Encoding.ASCII.GetString(encrypted);

            txtEncryptText.Text = encryptedPlaintext;
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            byte[] key = Encoding.ASCII.GetBytes(_generatedKey);

            decrypted = AES.DecryptText(encrypted, key);

            // Chuyển đổi decrypted thành chuỗi plaintext
            string decryptedPlaintext = Encoding.ASCII.GetString(decrypted);

            txtDecryptText.Text = decryptedPlaintext;
        }

        private void btnGenerateKey_Click(object sender, EventArgs e)
        {
            string generatedKey = AES.GenerateKey(16);
            txtKey.Text = generatedKey;
            _generatedKey = generatedKey;
        }
    }
}
