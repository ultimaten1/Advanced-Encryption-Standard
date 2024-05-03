using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Group7_Module2.Service
{
    public class AESFile
    {
        public static string filePathExtension = null;

        public static void EncryptFileStructure(string filePath, byte[] key)
        {
            try
            {
                filePathExtension = Path.GetExtension(filePath);
                string encryptedFilePath = Path.Combine(Path.GetFileNameWithoutExtension(filePath) + "_encrypted" + filePathExtension);

                // Đọc dữ liệu từ file
                byte[] fileData = File.ReadAllBytes(filePath);

                if (filePath.EndsWith(".docx") || filePath.EndsWith(".xlsx") || filePath.EndsWith(".pptx"))
                {
                    // Mã hóa dữ liệu
                    byte[] encryptedData = AES.EncryptFile(fileData, key);

                    // Ghi dữ liệu đã mã hóa vào file
                    File.WriteAllBytes(encryptedFilePath, encryptedData);
                }
                else
                {                 
                    // Tìm độ dài của phần header (ví dụ: 100 bytes)
                    int headerLength = 100; // Bạn cần xác định phần này

                    // Tách phần header ra khỏi dữ liệu
                    byte[] headerData = fileData.Take(headerLength).ToArray();
                    byte[] bodyAndFooterData = fileData.Skip(headerLength).ToArray();

                    // Mã hóa phần header
                    byte[] encryptedHeader = AES.EncryptFile(headerData, key);

                    // Kết hợp phần header đã mã hóa với phần body và footer
                    byte[] combinedData = encryptedHeader.Concat(bodyAndFooterData).ToArray();

                    // Ghi dữ liệu đã mã hóa vào file
                    File.WriteAllBytes(encryptedFilePath, combinedData);
                }

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
                string decryptedFilePath = Path.GetFileNameWithoutExtension(filePath);

                if (decryptedFilePath.EndsWith("_encrypted"))
                {
                    decryptedFilePath = decryptedFilePath.Substring(0, decryptedFilePath.Length - 10);
                    decryptedFilePath = decryptedFilePath + "_decrypted";
                }

                decryptedFilePath = decryptedFilePath + filePathExtension;

                // Đọc dữ liệu từ file đã mã hóa
                byte[] fileData = File.ReadAllBytes(filePath);

                if (filePath.EndsWith(".docx") || filePath.EndsWith(".xlsx") || filePath.EndsWith(".pptx"))
                {
                    // Giải mã dữ liệu
                    byte[] decryptedData = AES.DecryptFile(fileData, key);

                    // Ghi dữ liệu đã giải mã vào file
                    File.WriteAllBytes(decryptedFilePath, decryptedData);
                }
                else
                {
                    // Tìm độ dài của phần header (ví dụ: 100 bytes)
                    int headerLength = 100; // Bạn cần xác định phần này

                    // Tách phần header ra khỏi dữ liệu
                    byte[] encryptedHeader = fileData.Take(headerLength).ToArray();
                    byte[] bodyAndFooterData = fileData.Skip(headerLength).ToArray();

                    // Giải mã phần header
                    byte[] decryptedHeader = AES.DecryptFile(encryptedHeader, key);

                    // Kết hợp phần header đã giải mã với phần body và footer
                    byte[] combinedData = decryptedHeader.Concat(bodyAndFooterData).ToArray();

                    // Ghi dữ liệu đã giải mã vào file
                    File.WriteAllBytes(decryptedFilePath, combinedData);
                }           

                MessageBox.Show("File structure decrypted successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}

