using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Group7_Module2.Service
{
    public class AES
    {
        public static readonly byte[] SBox =
        {
            0x63, 0x7C, 0x77, 0x7B, 0xF2, 0x6B, 0x6F, 0xC5, 0x30, 0x01, 0x67, 0x2B, 0xFE, 0xD7, 0xAB, 0x76,
            0xCA, 0x82, 0xC9, 0x7D, 0xFA, 0x59, 0x47, 0xF0, 0xAD, 0xD4, 0xA2, 0xAF, 0x9C, 0xA4, 0x72, 0xC0,
            0xB7, 0xFD, 0x93, 0x26, 0x36, 0x3F, 0xF7, 0xCC, 0x34, 0xA5, 0xE5, 0xF1, 0x71, 0xD8, 0x31, 0x15,
            0x04, 0xC7, 0x23, 0xC3, 0x18, 0x96, 0x05, 0x9A, 0x07, 0x12, 0x80, 0xE2, 0xEB, 0x27, 0xB2, 0x75,
            0x09, 0x83, 0x2C, 0x1A, 0x1B, 0x6E, 0x5A, 0xA0, 0x52, 0x3B, 0xD6, 0xB3, 0x29, 0xE3, 0x2F, 0x84,
            0x53, 0xD1, 0x00, 0xED, 0x20, 0xFC, 0xB1, 0x5B, 0x6A, 0xCB, 0xBE, 0x39, 0x4A, 0x4C, 0x58, 0xCF,
            0xD0, 0xEF, 0xAA, 0xFB, 0x43, 0x4D, 0x33, 0x85, 0x45, 0xF9, 0x02, 0x7F, 0x50, 0x3C, 0x9F, 0xA8,
            0x51, 0xA3, 0x40, 0x8F, 0x92, 0x9D, 0x38, 0xF5, 0xBC, 0xB6, 0xDA, 0x21, 0x10, 0xFF, 0xF3, 0xD2,
            0xCD, 0x0C, 0x13, 0xEC, 0x5F, 0x97, 0x44, 0x17, 0xC4, 0xA7, 0x7E, 0x3D, 0x64, 0x5D, 0x19, 0x73,
            0x60, 0x81, 0x4F, 0xDC, 0x22, 0x2A, 0x90, 0x88, 0x46, 0xEE, 0xB8, 0x14, 0xDE, 0x5E, 0x0B, 0xDB,
            0xE0, 0x32, 0x3A, 0x0A, 0x49, 0x06, 0x24, 0x5C, 0xC2, 0xD3, 0xAC, 0x62, 0x91, 0x95, 0xE4, 0x79,
            0xE7, 0xC8, 0x37, 0x6D, 0x8D, 0xD5, 0x4E, 0xA9, 0x6C, 0x56, 0xF4, 0xEA, 0x65, 0x7A, 0xAE, 0x08,
            0xBA, 0x78, 0x25, 0x2E, 0x1C, 0xA6, 0xB4, 0xC6, 0xE8, 0xDD, 0x74, 0x1F, 0x4B, 0xBD, 0x8B, 0x8A,
            0x70, 0x3E, 0xB5, 0x66, 0x48, 0x03, 0xF6, 0x0E, 0x61, 0x35, 0x57, 0xB9, 0x86, 0xC1, 0x1D, 0x9E,
            0xE1, 0xF8, 0x98, 0x11, 0x69, 0xD9, 0x8E, 0x94, 0x9B, 0x1E, 0x87, 0xE9, 0xCE, 0x55, 0x28, 0xDF,
            0x8C, 0xA1, 0x89, 0x0D, 0xBF, 0xE6, 0x42, 0x68, 0x41, 0x99, 0x2D, 0x0F, 0xB0, 0x54, 0xBB, 0x16
        };

        public static readonly byte[] InvSBox =
        {
            0x52, 0x09, 0x6a, 0xd5, 0x30, 0x36, 0xa5, 0x38, 0xbf, 0x40, 0xa3, 0x9e, 0x81, 0xf3, 0xd7, 0xfb,
            0x7c, 0xe3, 0x39, 0x82, 0x9b, 0x2f, 0xff, 0x87, 0x34, 0x8e, 0x43, 0x44, 0xc4, 0xde, 0xe9, 0xcb,
            0x54, 0x7b, 0x94, 0x32, 0xa6, 0xc2, 0x23, 0x3d, 0xee, 0x4c, 0x95, 0x0b, 0x42, 0xfa, 0xc3, 0x4e,
            0x08, 0x2e, 0xa1, 0x66, 0x28, 0xd9, 0x24, 0xb2, 0x76, 0x5b, 0xa2, 0x49, 0x6d, 0x8b, 0xd1, 0x25,
            0x72, 0xf8, 0xf6, 0x64, 0x86, 0x68, 0x98, 0x16, 0xd4, 0xa4, 0x5c, 0xcc, 0x5d, 0x65, 0xb6, 0x92,
            0x6c, 0x70, 0x48, 0x50, 0xfd, 0xed, 0xb9, 0xda, 0x5e, 0x15, 0x46, 0x57, 0xa7, 0x8d, 0x9d, 0x84,
            0x90, 0xd8, 0xab, 0x00, 0x8c, 0xbc, 0xd3, 0x0a, 0xf7, 0xe4, 0x58, 0x05, 0xb8, 0xb3, 0x45, 0x06,
            0xd0, 0x2c, 0x1e, 0x8f, 0xca, 0x3f, 0x0f, 0x02, 0xc1, 0xaf, 0xbd, 0x03, 0x01, 0x13, 0x8a, 0x6b,
            0x3a, 0x91, 0x11, 0x41, 0x4f, 0x67, 0xdc, 0xea, 0x97, 0xf2, 0xcf, 0xce, 0xf0, 0xb4, 0xe6, 0x73,
            0x96, 0xac, 0x74, 0x22, 0xe7, 0xad, 0x35, 0x85, 0xe2, 0xf9, 0x37, 0xe8, 0x1c, 0x75, 0xdf, 0x6e,
            0x47, 0xf1, 0x1a, 0x71, 0x1d, 0x29, 0xc5, 0x89, 0x6f, 0xb7, 0x62, 0x0e, 0xaa, 0x18, 0xbe, 0x1b,
            0xfc, 0x56, 0x3e, 0x4b, 0xc6, 0xd2, 0x79, 0x20, 0x9a, 0xdb, 0xc0, 0xfe, 0x78, 0xcd, 0x5a, 0xf4,
            0x1f, 0xdd, 0xa8, 0x33, 0x88, 0x07, 0xc7, 0x31, 0xb1, 0x12, 0x10, 0x59, 0x27, 0x80, 0xec, 0x5f,
            0x60, 0x51, 0x7f, 0xa9, 0x19, 0xb5, 0x4a, 0x0d, 0x2d, 0xe5, 0x7a, 0x9f, 0x93, 0xc9, 0x9c, 0xef,
            0xa0, 0xe0, 0x3b, 0x4d, 0xae, 0x2a, 0xf5, 0xb0, 0xc8, 0xeb, 0xbb, 0x3c, 0x83, 0x53, 0x99, 0x61,
            0x17, 0x2b, 0x04, 0x7e, 0xba, 0x77, 0xd6, 0x26, 0xe1, 0x69, 0x14, 0x63, 0x55, 0x21, 0x0c, 0x7d
        };

        public static readonly byte[] Rcon =
        {
            0x00, 0x01, 0x02, 0x04, 0x08, 0x10, 0x20, 0x40, 0x80, 0x1b, 0x36
        };

        public static void PrintByteArray(byte[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i].ToString("X2") + " ");
            }
            Console.WriteLine();
        }

        // Chuyển đổi chuỗi thành mảng byte
        public static byte[] ConvertStringToByteArray(string str)
        {
            byte[] byteArray = new byte[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                byteArray[i] = (byte)str[i];
            }
            return byteArray;
        }

        //public static string PadPlaintext(string plaintext)
        //{
        //    int paddingLength = 16 - (plaintext.Length % 16); // Tính toán số lượng kí tự cần thêm vào
        //    string paddedPlaintext = plaintext.PadRight(plaintext.Length + paddingLength, ' '); // Thêm kí tự "x" vào cuối chuỗi
        //    return paddedPlaintext;
        //}

        public static string PadPlaintext(string plaintext)
        {
            int paddingLength = 16 - (plaintext.Length % 16); // Tính toán số lượng byte cần thêm vào
            char paddingChar = (char)paddingLength; // Sử dụng giá trị padding là độ dài của padding
            string paddedPlaintext = plaintext.PadRight(plaintext.Length + paddingLength, paddingChar); // Thêm padding vào cuối chuỗi
            return paddedPlaintext;
        }


        //public static string GenerateKey(int bytes)
        //{
        //    char[] letters = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'y', 'x', 'z' };
        //    char[] lettersUpper = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'Y', 'X', 'Z' };
        //    char[] numbers = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        //    char[] symbols = new char[] { '!', '@', '#', '$', '%', '&', '*', '=', ']', '[', '/', '+', '~' };
        //    string key = string.Empty;

        //    Random rand = new Random();

        //    for (int i = 0; i < bytes; ++i)
        //    {
        //        int random = rand.Next(4);
        //        if (random == 0)
        //        {
        //            int slot = rand.Next(26);
        //            key += letters[slot];
        //        }
        //        else if (random == 1)
        //        {
        //            int slot = rand.Next(10);
        //            key += numbers[slot];
        //        }
        //        else if (random == 2)
        //        {
        //            int slot = rand.Next(26);
        //            key += lettersUpper[slot];
        //        }
        //        else
        //        {
        //            int slot = rand.Next(13);
        //            key += symbols[slot];
        //        }
        //    }
        //    return key;
        //}

        public static byte[] GenerateKey(int keySize)
        {
            // Tạo đối tượng RNGCryptoServiceProvider
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                // Tạo mảng byte để lưu trữ khóa
                byte[] key = new byte[keySize / 8];

                // Sinh ngẫu nhiên các giá trị cho mảng key
                rng.GetBytes(key);

                // Trả về khóa đã tạo
                return key;
            }
        }

        //public static byte[] EncryptFile(byte[] input, byte[] key)
        //{
        //    int numBlocks = (int)Math.Ceiling((double)input.Length / 16);
        //    List<byte> encryptedBlocks = new List<byte>();

        //    for (int blockIndex = 0; blockIndex < numBlocks; blockIndex++)
        //    {
        //        int startIndex = blockIndex * 16;
        //        int length = Math.Min(16, input.Length - startIndex);
        //        byte[] block = new byte[16];
        //        Array.Copy(input, startIndex, block, 0, length);

        //        byte[] encryptedBlock = EncryptBlock(block, key);
        //        encryptedBlocks.AddRange(encryptedBlock);
        //    }

        //    return encryptedBlocks.ToArray();
        //}

        public static byte[] EncryptFile(byte[] input, byte[] key)
        {
            int numBlocks = (int)Math.Ceiling((double)input.Length / 16);
            List<byte> encryptedBlocks = new List<byte>();

            for (int blockIndex = 0; blockIndex < numBlocks; blockIndex++)
            {
                int startIndex = blockIndex * 16;
                int length = Math.Min(16, input.Length - startIndex);
                byte[] block = new byte[16];
                Array.Copy(input, startIndex, block, 0, length);

                // Add PKCS7 padding to the last block if needed
                if (length < 16)
                {
                    byte paddingLength = (byte)(16 - length);
                    for (int i = length; i < 16; i++)
                    {
                        block[i] = paddingLength;
                    }
                }

                byte[] encryptedBlock = EncryptBlock(block, key);
                encryptedBlocks.AddRange(encryptedBlock);
            }

            return encryptedBlocks.ToArray();
        }

        //public static byte[] DecryptFile(byte[] input, byte[] key)
        //{
        //    int numBlocks = input.Length / 16;
        //    List<byte> decryptedBlocks = new List<byte>();

        //    for (int blockIndex = 0; blockIndex < numBlocks; blockIndex++)
        //    {
        //        int startIndex = blockIndex * 16;
        //        byte[] block = new byte[16];
        //        Array.Copy(input, startIndex, block, 0, 16);

        //        byte[] decryptedBlock = DecryptBlock(block, key);
        //        decryptedBlocks.AddRange(decryptedBlock);
        //    }

        //    return decryptedBlocks.ToArray();
        //}

        public static byte[] DecryptFile(byte[] input, byte[] key)
        {
            int numBlocks = input.Length / 16;
            List<byte> decryptedBlocks = new List<byte>();

            for (int blockIndex = 0; blockIndex < numBlocks; blockIndex++)
            {
                int startIndex = blockIndex * 16;
                if (startIndex + 16 <= input.Length)
                {
                    byte[] block = new byte[16];
                    Array.Copy(input, startIndex, block, 0, 16);

                    byte[] decryptedBlock = DecryptBlock(block, key);
                    decryptedBlocks.AddRange(decryptedBlock);
                }
            }

            // Remove PKCS7 padding from the last block if needed
            if (decryptedBlocks.Count > 0)
            {
                int paddingLength = decryptedBlocks[decryptedBlocks.Count - 1];
                if (paddingLength <= decryptedBlocks.Count)
                {
                    decryptedBlocks.RemoveRange(decryptedBlocks.Count - paddingLength, paddingLength);
                }
            }

            return decryptedBlocks.ToArray();
        }

        private static byte[] EncryptBlock(byte[] block, byte[] key)
        {
            return Encrypt(block, key);
        }

        private static byte[] DecryptBlock(byte[] block, byte[] key)
        {
            return Decrypt(block, key);
        }

        static byte[] Encrypt(byte[] input, byte[] key)
        {
            byte[,] state = new byte[4, 4];
            byte[,] expandedKey = KeyExpansion(key);

            // Copy input to state array
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    state[j, i] = input[i * 4 + j];
                }
            }

            AddRoundKey(state, expandedKey, 0);

            for (int round = 1; round < 10; round++)
            {
                SubBytes(state);
                ShiftRows(state);
                MixColumns(state);
                AddRoundKey(state, expandedKey, round);
            }

            SubBytes(state);
            ShiftRows(state);
            AddRoundKey(state, expandedKey, 10);

            byte[] output = new byte[16];

            // Copy state to output array
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    output[i * 4 + j] = state[j, i];
                }
            }

            return output;
        }

        static byte[] Decrypt(byte[] input, byte[] key)
        {
            byte[,] state = new byte[4, 4];
            byte[,] expandedKey = KeyExpansion(key);

            // Copy input to state array
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    state[j, i] = input[i * 4 + j];
                }
            }

            AddRoundKey(state, expandedKey, 10);

            for (int round = 9; round > 0; round--)
            {
                InvShiftRows(state);
                InvSubBytes(state);
                AddRoundKey(state, expandedKey, round);
                InvMixColumns(state);
            }

            InvShiftRows(state);
            InvSubBytes(state);
            AddRoundKey(state, expandedKey, 0);

            byte[] output = new byte[16];

            // Copy state to output array
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    output[i * 4 + j] = state[j, i];
                }
            }

            return output;
        }

        //public static byte[,] KeyExpansion(byte[] key)
        //{
        //    byte[,] expandedKey = new byte[4, 44];
        //    byte[] temp = new byte[4];
        //    int round = 0;

        //    // Copy key to the first 4 columns of expandedKey
        //    for (int i = 0; i < 4; i++)
        //    {
        //        for (int j = 0; j < 4; j++)
        //        {
        //            expandedKey[j, i] = key[i * 4 + j];
        //        }
        //    }

        //    for (int col = 4; col < 44; col++)
        //    {
        //        if (col % 4 == 0)
        //        {
        //            temp = SubWord(RotWord(expandedKey, col - 1));
        //            temp[0] ^= Rcon[round];
        //            round++;
        //        }
        //        else if (col % 4 == 0 && col % 4 == 4)  // Remove this condition as it is redundant
        //        {
        //            temp = SubWord(expandedKey);  // Remove col - 1 as it's not needed
        //        }

        //        for (int row = 0; row < 4; row++)
        //        {
        //            expandedKey[row, col] = (byte)(expandedKey[row, col - 4] ^ temp[row]);
        //        }
        //    }

        //    return expandedKey;
        //}

        public static byte[,] KeyExpansion(byte[] key)
        {
            byte[,] expandedKey = new byte[4, 44];
            byte[] temp = new byte[4];
            int round = 0;

            // Copy key to the first 4 columns of expandedKey
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    expandedKey[j, i] = key[i * 4 + j];
                }
            }

            for (int col = 4; col < 44; col++)
            {
                if (col % 4 == 0)
                {
                    temp = SubWord(RotWord(expandedKey, col - 1));
                    temp[0] ^= Rcon[round];
                    round++;
                }

                for (int row = 0; row < 4; row++)
                {
                    expandedKey[row, col] = (byte)(expandedKey[row, col - 4] ^ temp[row]);
                }
            }

            return expandedKey;
        }


        public static byte[] SubWord(byte[,] key)
        {
            byte[] temp = new byte[4];

            for (int i = 0; i < 4; i++)
            {
                temp[i] = SBox[key[i / 4, i % 4]];
            }

            return temp;
        }

        public static byte[] SubWord(byte[] key)
        {
            byte[] temp = new byte[4];

            for (int i = 0; i < 4; i++)
            {
                temp[i] = SBox[key[i]];
            }

            return temp;
        }

        public static byte[,] RotWord(byte[,] key, int col)
        {
            byte[,] temp = new byte[1, 4];

            for (int i = 0; i < 4; i++)
            {
                temp[0, i] = key[0, (col + i) % 4];
            }

            return temp;
        }


        public static byte[] RotWord(byte[] key)
        {
            byte[] temp = new byte[4];

            for (int i = 0; i < 4; i++)
            {
                temp[i] = key[(i + 1) % 4];
            }

            return temp;
        }

        public static void SubBytes(byte[,] state)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    state[i, j] = SBox[state[i, j]];
                }
            }
        }

        public static void InvSubBytes(byte[,] state)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    state[i, j] = InvSBox[state[i, j]];
                }
            }
        }

        public static void ShiftRows(byte[,] state)
        {
            byte[] temp = new byte[4];

            for (int row = 1; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    temp[col] = state[row, col];
                }

                for (int col = 0; col < 4; col++)
                {
                    state[row, col] = temp[(col + row) % 4];
                }
            }
        }

        public static void InvShiftRows(byte[,] state)
        {
            byte[] temp = new byte[4];

            for (int row = 1; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    temp[(col + row) % 4] = state[row, col];
                }

                for (int col = 0; col < 4; col++)
                {
                    state[row, col] = temp[col];
                }
            }
        }

        public static void MixColumns(byte[,] state)
        {
            byte[,] temp = new byte[4, 4]
            {
            {0x02, 0x03, 0x01, 0x01},
            {0x01, 0x02, 0x03, 0x01},
            {0x01, 0x01, 0x02, 0x03},
            {0x03, 0x01, 0x01, 0x02}
            };

            byte[,] result = new byte[4, 4];

            for (int col = 0; col < 4; col++)
            {
                for (int row = 0; row < 4; row++)
                {
                    byte sum = 0;

                    for (int i = 0; i < 4; i++)
                    {
                        sum ^= GFMultiply(temp[row, i], state[i, col]);
                    }

                    result[row, col] = sum;
                }
            }

            // Copy result to state
            for (int col = 0; col < 4; col++)
            {
                for (int row = 0; row < 4; row++)
                {
                    state[row, col] = result[row, col];
                }
            }
        }

        public static void InvMixColumns(byte[,] state)
        {
            byte[,] temp = new byte[4, 4]
            {
            {0x0e, 0x0b, 0x0d, 0x09},
            {0x09, 0x0e, 0x0b, 0x0d},
            {0x0d, 0x09, 0x0e, 0x0b},
            {0x0b, 0x0d, 0x09, 0x0e}
            };

            byte[,] result = new byte[4, 4];

            for (int col = 0; col < 4; col++)
            {
                for (int row = 0; row < 4; row++)
                {
                    byte sum = 0;

                    for (int i = 0; i < 4; i++)
                    {
                        sum ^= GFMultiply(temp[row, i], state[i, col]);
                    }

                    result[row, col] = sum;
                }
            }

            // Copy result to state
            for (int col = 0; col < 4; col++)
            {
                for (int row = 0; row < 4; row++)
                {
                    state[row, col] = result[row, col];
                }
            }
        }

        public static void AddRoundKey(byte[,] state, byte[,] key, int round)
        {
            for (int col = 0; col < 4; col++)
            {
                for (int row = 0; row < 4; row++)
                {
                    state[row, col] ^= key[row, col + round * 4];
                }
            }
        }

        public static byte GFMultiply(byte a, byte b)
        {
            byte p = 0;

            for (int i = 0; i < 8; i++)
            {
                if ((b & 1) != 0)
                {
                    p ^= a;
                }

                byte hi_bit_set = (byte)(a & 0x80);
                a <<= 1;

                if (hi_bit_set != 0)
                {
                    a ^= 0x1b; // XOR with the irreducible polynomial x^8 + x^4 + x^3 + x + 1
                }

                b >>= 1;
            }

            return p;
        }
    }
}
