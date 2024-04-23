using System;
using System.IO;
using System.Windows.Forms;

namespace Group7_Module2.Service
{
    public class AESFile
    {
        public static void EncryptFileStructure(string filePath, byte[] key)
        {
            try
            {
                string directoryPath = "./Files";

                string encryptedFilePath = Path.Combine(Path.GetFileName(filePath) + ".encrypted");

                // Create encrypted copy of file structure
                File.Copy(filePath, encryptedFilePath);

                // Encrypt the encrypted file structure
                byte[] encryptedData = File.ReadAllBytes(encryptedFilePath);
                byte[] encryptedResult = AES.EncryptText(encryptedData, key);
                File.WriteAllBytes(encryptedFilePath, encryptedResult);

                MessageBox.Show("File structure encrypted successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        public static void DecryptFileStructure(string filePath, byte[] key)
        {
            try
            {
                string directoryPath = "./Files";

                string decryptedFilePath = Path.Combine(Path.GetFileNameWithoutExtension(filePath));

                // Create decrypted copy of file structure
                File.Copy(filePath, decryptedFilePath);

                // Decrypt the decrypted file structure
                byte[] decryptedData = File.ReadAllBytes(decryptedFilePath);
                byte[] decryptedResult = AES.DecryptText(decryptedData, key);
                File.WriteAllBytes(decryptedFilePath, decryptedResult);

                MessageBox.Show("File structure decrypted successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
