
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace DES
{
    public class DES
    {
        static readonly int[] IP = {
        58, 50, 42, 34, 26, 18, 10,  2,
        60, 52, 44, 36, 28, 20, 12,  4,
        62, 54, 46, 38, 30, 22, 14,  6,
        64, 56, 48, 40, 32, 24, 16,  8,
        57, 49, 41, 33, 25, 17,  9,  1,
        59, 51, 43, 35, 27, 19, 11,  3,
        61, 53, 45, 37, 29, 21, 13,  5,
        63, 55, 47, 39, 31, 23, 15,  7};

        static readonly int[] keypc1 = {
        57, 49, 41, 33, 25, 17, 9,
        1, 58, 50, 42, 34, 26, 18,
        10, 2, 59, 51, 43, 35, 27,
        19, 11, 3, 60, 52, 44, 36,
        63, 55, 47, 39, 31, 23, 15,
        7, 62, 54, 46, 38, 30, 22,
        14, 6, 61, 53, 45, 37, 29,
        21, 13, 5, 28, 20, 12, 4 };

        static readonly int[] keypc2 = {
            14, 17, 11, 24, 1, 5,
            3, 28, 15, 6, 21, 10,
            23, 19, 12, 4, 26, 8,
            16, 7, 27, 20, 13, 2,
            41, 52, 31, 37, 47, 55,
            30, 40, 51, 45, 33, 48,
            44, 49, 39, 56, 34, 53,
            46, 42, 50, 36, 29, 32 };

        static readonly int[] expansion_box = { 
         32, 1, 2, 3, 4, 5, 4, 5,
         6, 7, 8, 9, 8, 9, 10, 11,
         12, 13, 12, 13, 14, 15, 16, 17,
         16, 17, 18, 19, 20, 21, 20, 21,
         22, 23, 24, 25, 24, 25, 26, 27,
         28, 29, 28, 29, 30, 31, 32, 1};

        static readonly int[][][] sbox = new int[][][]
{
    new int[][]
    {
        new int[] {14, 4, 13, 1, 2, 15, 11, 8, 3, 10, 6, 12, 5, 9, 0, 7},
        new int[] {0, 15, 7, 4, 14, 2, 13, 1, 10, 6, 12, 11, 9, 5, 3, 8},
        new int[] {4, 1, 14, 8, 13, 6, 2, 11, 15, 12, 9, 7, 3, 10, 5, 0},
        new int[] {15, 12, 8, 2, 4, 9, 1, 7, 5, 11, 3, 14, 10, 0, 6, 13}
    },

    new int[][]
    {
        new int[] {15, 1, 8, 14, 6, 11, 3, 4, 9, 7, 2, 13, 12, 0, 5, 10},
        new int[] {3, 13, 4, 7, 15, 2, 8, 14, 12, 0, 1, 10, 6, 9, 11, 5},
        new int[] {0, 14, 7, 11, 10, 4, 13, 1, 5, 8, 12, 6, 9, 3, 2, 15},
        new int[] {13, 8, 10, 1, 3, 15, 4, 2, 11, 6, 7, 12, 0, 5, 14, 9}
    },

    new int[][]
    {
        new int[] {10, 0, 9, 14, 6, 3, 15, 5, 1, 13, 12, 7, 11, 4, 2, 8},
        new int[] {13, 7, 0, 9, 3, 4, 6, 10, 2, 8, 5, 14, 12, 11, 15, 1},
        new int[] {13, 6, 4, 9, 8, 15, 3, 0, 11, 1, 2, 12, 5, 10, 14, 7},
        new int[] {1, 10, 13, 0, 6, 9, 8, 7, 4, 15, 14, 3, 11, 5, 2, 12}
    },

    new int[][]
    {
        new int[] {7, 13, 14, 3, 0, 6, 9, 10, 1, 2, 8, 5, 11, 12, 4, 15},
        new int[] {13, 8, 11, 5, 6, 15, 0, 3, 4, 7, 2, 12, 1, 10, 14, 9},
        new int[] {10, 6, 9, 0, 12, 11, 7, 13, 15, 1, 3, 14, 5, 2, 8, 4},
        new int[] {3, 15, 0, 6, 10, 1, 13, 8, 9, 4, 5, 11, 12, 7, 2, 14}
    },

    new int[][]
    {
        new int[] {2, 12, 4, 1, 7, 10, 11, 6, 8, 5, 3, 15, 13, 0, 14, 9},
        new int[] {14, 11, 2, 12, 4, 7, 13, 1, 5, 0, 15, 10, 3, 9, 8, 6},
        new int[] {4, 2, 1, 11, 10, 13, 7, 8, 15, 9, 12, 5, 6, 3, 0, 14},
        new int[] {11, 8, 12, 7, 1, 14, 2, 13, 6, 15, 0, 9, 10, 4, 5, 3}
    },

    new int[][]
    {
        new int[] {12, 1, 10, 15, 9, 2, 6, 8, 0, 13, 3, 4, 14, 7, 5, 11},
        new int[] {10, 15, 4, 2, 7, 12, 9, 5, 6, 1, 13, 14, 0, 11, 3, 8},
        new int[] {9, 14, 15, 5, 2, 8, 12, 3, 7, 0, 4, 10, 1, 13, 11, 6},
        new int[] {4, 3, 2, 12, 9, 5, 15, 10, 11, 14, 1, 7, 6, 0, 8, 13}
    },

    new int[][]
    {
        new int[] {4, 11, 2, 14, 15, 0, 8, 13, 3, 12, 9, 7, 5, 10, 6, 1},
        new int[] {13, 0, 11, 7, 4, 9, 1, 10, 14, 3, 5, 12, 2, 15, 8, 6},
        new int[] {1, 4, 11, 13, 12, 3, 7, 14, 10, 15, 6, 8, 0, 5, 9, 2},
        new int[] {6, 11, 13, 8, 1, 4, 10, 7, 9, 5, 0, 15, 14, 2, 3, 12}
    },

    new int[][]
    {
        new int[] {13, 2, 8, 4, 6, 15, 11, 1, 10, 9, 3, 14, 5, 0, 12, 7},
        new int[] {1, 15, 13, 8, 10, 3, 7, 4, 12, 5, 6, 11, 0, 14, 9, 2},
        new int[] {7, 11, 4, 1, 9, 12, 14, 2, 0, 6, 10, 13, 15, 3, 5, 8},
        new int[] {2, 1, 14, 7, 4, 10, 8, 13, 15, 12, 9, 0, 3, 5, 6, 11}
    }
};


        readonly static int[] straight_Permutation =
        { 16, 7, 20, 21,
       29, 12, 28, 17,
       1, 15, 23, 26,
       5, 18, 31, 10,
       2, 8, 24, 14,
       32, 27, 3, 9,
       19, 13, 30, 6,
       22, 11, 4, 25};

        static readonly int[] IP_Inverse = {40, 8, 48, 16, 56, 24, 64, 32,
              39, 7, 47, 15, 55, 23, 63, 31,
              38, 6, 46, 14, 54, 22, 62, 30,
              37, 5, 45, 13, 53, 21, 61, 29,
              36, 4, 44, 12, 52, 20, 60, 28,
              35, 3, 43, 11, 51, 19, 59, 27,
              34, 2, 42, 10, 50, 18, 58, 26,
              33, 1, 41, 9, 49, 17, 57, 25 };
        private string XOR(string a, string b)
        {
            string result = "";
            for (int i = 0; i < a.Length; i++)
            {

                if (a[i] == b[i])
                {
                    result += 0;
                }
                else
                {
                    result += 1;
                }
            }
            return result;
        }

        private string[] KeyGenration(string key)
        {
            string keyArray = ToBinary(key);
            //Debugging
            //string keyArray="0001001100110100010101110111100110011011101111001101111111110001";


            string key56bit = "";
            //PC 1
            for (int i = 0; i < keypc1.Length; i++)
            {
                //index in PC1 is starting from 1
                key56bit += keyArray[keypc1[i] - 1].ToString();
            }


            string left = key56bit.Substring(0, 28);
            string right = key56bit.Substring(28, 28);

            string[] keys = new string[16];

            //Have to debug from there. Possible Bug in this code 
            for (int i = 0; i < 16; i++)
            {
                //1,2,9,16 -->1
                int shiftValue;
                if (i == 0 || i == 1 || i == 8 || i == 15)
                {
                    shiftValue = 1;
                }
                else
                {
                    shiftValue = 2;
                }
                left = RotateLeft(left, shiftValue);
                right = RotateLeft(right, shiftValue);

                string str = left + right;
                string permutedStr = "";
                //pc2
                for (int j = 0; j < keypc2.Length; j++)
                {
                    //index in PC2 is starting from 1
                    permutedStr += str[keypc2[j] - 1].ToString();
                }
                keys[i] = permutedStr;
            }


            //Console.WriteLine($"Keys Length:{keys.Length}");
            return keys;
        }

        private static string RotateLeft(string str, int shift)
        {
            shift = shift % str.Length;

            return str.Substring(shift) + str.Substring(0, shift);
        }
        private static byte[] ConvertToByteArray(string str, Encoding encoding)
        {
            return encoding.GetBytes(str);
        }
        static int BinaryToInt(string binary)
        {
            int result = 0;
            foreach (char bit in binary)
            {
                result = (result << 1) + (bit - '0'); // Shift left and add the current bit
            }
            return result;
        }
        public static string ConvertBase64ToBinary(string base64String)
        {
            // Decode the Base64 string to a byte array
            byte[] decodedBytes = Convert.FromBase64String(base64String);

            StringBuilder binaryStringBuilder = new StringBuilder();

            // Convert each byte to its binary representation
            foreach (byte b in decodedBytes)
            {
                binaryStringBuilder.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
            }

            return binaryStringBuilder.ToString();
        }
        static string BinaryToBase64(string binaryStream)
        {
            // Validate that the length of the binary stream is a multiple of 8
            if (binaryStream.Length % 8 != 0)
                throw new ArgumentException("Binary stream length must be a multiple of 8.");

            List<byte> bytes = new List<byte>();

            // Process 8 bits at a time
            for (int i = 0; i < binaryStream.Length; i += 8)
            {
                // Extract an 8-bit chunk
                string byteString = binaryStream.Substring(i, 8);

                // Convert the 8-bit binary string to a byte
                byte byteValue = Convert.ToByte(byteString, 2);
                bytes.Add(byteValue);
            }

            // Convert to Base64
            return Convert.ToBase64String(bytes.ToArray());
        }


        static string IntToBinary(int number)
        {
            // Handle zero case
            if (number == 0)
                return "0000";

            // Initialize result
            string binary = "";

            // Convert to binary
            while (number > 0)
            {
                binary = (number % 2) + binary; // Get the last bit and prepend to the result
                number /= 2;                   // Divide the number by 2
            }
            if (binary.Length < 4)
            {
                int padding = 4 - binary.Length;
                for (int i = 0; i < padding; i++)
                {
                    binary = "0" + binary;
                }
            }

            return binary;
        }

        private static string ToBinary(string text)
        {
            byte[] data = Encoding.UTF8.GetBytes(text);
            return string.Join("", data.Select(byt => Convert.ToString(byt, 2).PadLeft(8, '0')));
            //return string.Join(" ", data.Select(byt => Convert.ToString(byt, 2).PadLeft(8, '0')));
        }
        private static string[] divideBlock(string bits)
        {
            int numberOfBlocks = (int)Math.Ceiling((float)bits.Length / 64);
            string[] blocks = new string[numberOfBlocks];

            for (int i = 0; i < numberOfBlocks; i++)
            {
                int startIndex = i * 64;

                if (startIndex + 64 <= bits.Length)
                {
                    blocks[i] = bits.Substring(startIndex, 64);
                }
                else
                {
                    string remainingBits = bits.Substring(startIndex);
                    blocks[i] = remainingBits.PadRight(64, '0');
                }
            }

            return blocks;
        }


        private static string[] Initial_Permutation(string[] data, int numberOfBlocks)
        {
            string[] temp = new string[numberOfBlocks];

            for (int block = 0; block < numberOfBlocks; block++)
            {
                StringBuilder permutedBlock = new StringBuilder(64);
                //Console.WriteLine("THis is data block:"+ data[block]);
                for (int i = 0; i < 64; i++)
                {
                    int ipIndex = IP[i] - 1;
                    char value = data[block][ipIndex];//Debugging 
                    permutedBlock.Append(data[block][ipIndex]);
                }

                // Convert StringBuilder to string and store in temp
                temp[block] = permutedBlock.ToString();
            }

            return temp;
        }
        private static string[] Final_Permutation(string[] data, int numberOfBlocks)
        {
            //Console.WriteLine(numberOfBlocks);
            string[] temp = new string[numberOfBlocks];

            for (int block = 0; block < numberOfBlocks; block++)
            {
                StringBuilder permutedBlock = new StringBuilder(64);

                for (int i = 0; i < 64; i++)
                {
                    int ipIndex = IP_Inverse[i] - 1;
                    permutedBlock.Append(data[block][ipIndex]);
                }

                // Convert StringBuilder to string and store in temp
                temp[block] = permutedBlock.ToString();
            }

            return temp;
        }

        public string Encryption_Function(string Rn, string Kn)
        {
            string Rn48Bits = "";

            //Expansion to 48bitsk
            for (int i = 0; i < 48; i++)
            {
                Rn48Bits += Rn[expansion_box[i] - 1];
            }
            string XOR_Result = XOR(Rn48Bits, Kn);


            //S_BOX Permutation 
            string S_Box_Result = "";
            for (int i = 0; i < 8; i++)
            {
                int chunkSize = 6;
                string chunk = XOR_Result.Substring(i * chunkSize, 6);

                string rowBin = chunk[0].ToString() + chunk[5];
                int rowIndex = BinaryToInt(rowBin);

                string colBin = chunk.Substring(1, 4);
                int colIndex = BinaryToInt(colBin);

                int value = sbox[i][rowIndex][colIndex];

                string value_bin = IntToBinary(value);
                //Console.WriteLine("BIn Value Len" +value_bin.Length);

                S_Box_Result += value_bin;
            }
            //Console.WriteLine($"The S box result value is {S_Box_Result.Length}");

            //Console.WriteLine("S BOX RESULT "+S_Box_Result.Length);
            string finalResult = "";
            //Straigth P-Box
            for (int i = 0; i < straight_Permutation.Length; i++)
            {
                finalResult += S_Box_Result[straight_Permutation[i] - 1];
            }

            return finalResult;
        }

        public string Encrpyt(string text, string key)
        {

            string[] dataBlocks = divideBlock(ToBinary(text));
            //string[] dataBlocks = ["0000000100100011010001010110011110001001101010111100110111101111
            string test = string.Join("", dataBlocks);
            //Console.WriteLine("Plain: "+ test);

            // Find the number of rows
            int rows = dataBlocks.Length;
            //Console.WriteLine("Number of rows are "+ rows);


            //Inital Permutation
            string[] permutedData = Initial_Permutation(dataBlocks, rows);

            string[] keys = KeyGenration(key);
            //Console.WriteLine("Test");
            //for (int i = 0; i < 16; i++)
            //{
            //    Console.WriteLine($"TestKey{i}=\"{keys[i]}\"");
            //}

            string[] encryptedBlocks = new string[permutedData.Length];
            int iteration = 0;
            foreach (string block in permutedData)
            {
                //Console.WriteLine($"Iteration No.{iteration}");
                string left = block.Substring(0, 32);  
                string right = block.Substring(32);

                for (int i = 0; i < 16; i++)
                {
                    string tempRight = right;
                    string encryption_value = Encryption_Function(right, keys[i]);

                    right = XOR(left, encryption_value);
                    left = tempRight;
                }

                string encryptedValue = right + left;

                //Console.WriteLine(encryptedValue.Length);

                encryptedBlocks[iteration] = encryptedValue;
                //Console.WriteLine($"THis is result of iteration {iteration}: {encryptedValue} and length is this: {encryptedValue.Length}");
                iteration++;
            }
            string[] encryptedData = Final_Permutation(encryptedBlocks, rows);

            // Combining the blocks
            string final = string.Join("", encryptedData);

            // Convert binary back to ASCII for the encrypted output
            string encryptedText = BinaryToBase64(final);

            return encryptedText;
            //return final;
        }
        public string Decrypt(string text, string key)
        {
            Console.WriteLine(text.Length);
            //string[] dataBlocks = divideBlock(ToBinary(text));
            string[] dataBlocks = divideBlock(ConvertBase64ToBinary(text));
            //string[] dataBlocks = ["1000010111101000000100110101010000001111000010101011010000000101"];


            // Find the number of rows
            int rows = dataBlocks.Length;


            //Inital Permutation
            string[] permutedData = Initial_Permutation(dataBlocks, rows);

            string[] keys = KeyGenration(key);
            //Console.WriteLine("Test");
            //for(int i = 0; i < 16; i++)
            //{
            //    Console.WriteLine($"Key number {i} is{keys[i]}");
            //}

            string[] encryptedBlocks = new string[permutedData.Length];
            int iteration = 0;
            foreach (string block in permutedData)
            {
                //Console.WriteLine($"Iteration No.{iteration}");
                string left = block.Substring(0, 32);  
                string right = block.Substring(32);

                for (int i = 15; i >= 0; i--)
                {
                    string tempRight = right;
                    string encryption_value = Encryption_Function(right, keys[i]);

                    right = XOR(left, encryption_value);
                    left = tempRight;
                }

                string encryptedValue = right + left;


                encryptedBlocks[iteration] = encryptedValue;
                iteration++;
            }

            string[] decryptedData = Final_Permutation(encryptedBlocks, rows);

            string final = string.Join("", decryptedData);

            //Console.WriteLine("After decription: " + final);
            // Convert binary back to ASCII for the encrypted output
            string decryptedText = ConvertBinaryToAscii(final);

            return decryptedText;
            //return final;
        }
        public static string ConvertBinaryToAscii(string binaryString)
        {
            // Ensure the binary string length is a multiple of 8 (1 byte per character)
            if (binaryString.Length % 8 != 0)
            {
                throw new ArgumentException("The binary string length must be a multiple of 8.");
            }

            string result = "";

            // Loop through the binary string in chunks of 8 bits (1 byte)
            for (int i = 0; i < binaryString.Length; i += 8)
            {
                // Get the 8 bits (1 byte)
                string byteString = binaryString.Substring(i, 8);

                // Convert the byte (binary string) to an integer
                int byteValue = Convert.ToInt32(byteString, 2);

                // Convert the byte value to an ASCII character
                result += (char)byteValue;
            }

            return result;
        }
    }
}
