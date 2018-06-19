using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Globalization;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;

namespace JSONHB.Helpers
{
    class Utilities
    {

        public static void SendUDPData(byte[] send_buffer, String tagetIPAddress, Int16 targetPort)
        {
            Boolean exception_thrown = false;
            Socket sending_socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            //IPAddress send_to_address = IPAddress.Parse("172.16.10.96");
            IPAddress send_to_address = IPAddress.Parse(tagetIPAddress);
            //DnsEndPoint DNSaddress = new  DnsEndPoint("udplistener.canadacentral.cloudapp.azure.com",11000);
            IPEndPoint sending_end_point = new IPEndPoint(send_to_address, targetPort);

            try
            {
                // do any background work
                //while (UDPThread != false)
                //{
                // the socket object must have an array of bytes to send.
                // this loads the string entered by the user into an array of bytes.
                //byte[] send_buffer = Encoding.ASCII.GetBytes(text_to_send);
                Console.WriteLine("sending to address: {0} port: {1}", sending_end_point.Address, sending_end_point.Port);
                sending_socket.SendTo(send_buffer, sending_end_point);

                //Thread.Sleep(1000);
                // }
            }
            catch (Exception send_exception)
            {
                exception_thrown = true;
                Console.WriteLine(" Exception {0}", send_exception.Message);
            }
            if (exception_thrown == false)
            {
                Console.WriteLine("Message has been sent to the broadcast address");
            }
            else
            {
                exception_thrown = false;
                Console.WriteLine("The exception indicates the message was not sent.");
            }
        }
        public static byte[] Encrypt(byte[] plainText, byte[] Key, byte[] IV)
        {
            byte[] encrypted; ;
            using (MemoryStream mstream = new MemoryStream())
            {
                using (AesCryptoServiceProvider aesProvider = new AesCryptoServiceProvider())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(mstream,
                        aesProvider.CreateEncryptor(Key, IV), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(plainText, 0, plainText.Length);
                    }
                    encrypted = mstream.ToArray();
                }
            }
            return encrypted;
        }
        //from https://www.dotnetperls.com/random-byte-array
        public static byte[] generateInitVector()
        {
            byte[] IV = new byte[16];
            Random random = new Random();
            random.NextBytes(IV);
            return (IV);
        }

        public static byte[] generateSessionID()
        {
            byte[] sessionID = new byte[4];
            Random random = new Random();
            random.NextBytes(sessionID);
            return (sessionID);
        }


        public static byte[] Decrypt(byte[] encryptedData, byte[] encKey, byte[] initVect)
        {
            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider { Key = encKey, IV = initVect, Padding = PaddingMode.PKCS7 })
            using (ICryptoTransform decryptor = aes.CreateDecryptor(encKey, initVect))
            using (MemoryStream ms = new MemoryStream(encryptedData))
            using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
            {
                var decrypted = new byte[encryptedData.Length];
                var bytesRead = cs.Read(decrypted, 0, encryptedData.Length);
                return decrypted.Take(bytesRead).ToArray();
            }
        }



        public static byte[] StringToByteArray(string hex, int numberBase) //base 10 or 16
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), numberBase))
                             .ToArray();
        }


        public static byte[] Int_To_Hex(ushort number)
        {
            byte[] b = BitConverter.GetBytes(number);
            return b;
        }

        public static byte[] IEEE754_Decimal_To_Hex(String decimal_number)
        {
            //Double f;
            //Double.TryParse(decimal_number, NumberStyles.Any, CultureInfo.InvariantCulture, out f);
            //byte[] b = BitConverter.GetBytes(f);
            Single f;
            Single.TryParse(decimal_number, NumberStyles.Any, CultureInfo.InvariantCulture, out f);
            byte[] b = BitConverter.GetBytes(f);
            //Array.Reverse(b);                   //this would be needed to convert to big endian
            return b;
        }

        public static byte[] IEEE754_Decimal_To_8Byte_Hex(String decimal_number)
        {
            double f;
            double.TryParse(decimal_number, NumberStyles.Any, CultureInfo.InvariantCulture, out f);

            byte[] b = BitConverter.GetBytes(f);
            //Array.Reverse(b);                   //this would be needed to convert to big endian
            return b;
        }

        public static string stringToASCII(string inputString)
        {
            // Convert the string into a byte[].
            byte[] asciiBytes = Encoding.ASCII.GetBytes(inputString);
            string hex = BitConverter.ToString(asciiBytes).Replace("-", "");
            return hex;
        }
        public static byte[] compressData(string JSONData)
        {
            byte[] zipData;
            zipData = Zip(JSONData);

            return zipData;
        }

        public static byte[] compressDataZlib(string JSONData)
        {
            using (Stream originalStream = GenerateStreamFromString(JSONData))
            {
                using (Stream compressedStream = new System.IO.MemoryStream())
                {
                    using (DeflateStream compressionStream = new DeflateStream(compressedStream, CompressionMode.Compress))
                    {
                        originalStream.CopyTo(compressionStream);
                    }
                }
            }
            return null;
        }
        public static Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public static  byte[] ObjectToByteArray(object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
        public static byte[] Zip(string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);

            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new DeflateStream(mso, CompressionMode.Compress))
                {
                    CopyTo(msi, gs);
                }

                //using (var gs = new GZipStream(mso, CompressionMode.Compress))
                //{
                //    //msi.CopyTo(gs);
                //    CopyTo(msi, gs);
                //}

                return mso.ToArray();
            }
        }
        public static string Unzip(byte[] zippedData)
        {
            int byteCount = zippedData.Length;

            using (var msi = new MemoryStream(zippedData))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(msi, CompressionMode.Decompress))
                {
                    gs.CopyTo(mso);
                    //CopyTo(gs, mso);
                }

                return Encoding.UTF8.GetString(mso.ToArray());
            }
        }

        public static void CopyTo(Stream src, Stream dest)
        {
            byte[] bytes = new byte[4096];

            int cnt;

            while ((cnt = src.Read(bytes, 0, bytes.Length)) != 0)
            {
                dest.Write(bytes, 0, cnt);
            }
        }

        //public static string CreateCRC32FromHex(string hexInput)
        //{
        //    // given, a hex string
        //    byte[] input = Utilities.StringToByteArray(hexInput, 16);
        //    uint crc = Crc32.Crc32Algorithm.Compute(input);

        //    string crcHex = crc.ToString("X");
        //    crcHex = LittleEndian(crcHex);

        //    return crcHex;
        //}

        public static string LittleEndian(string num)
        {
            int number = Convert.ToInt32(num, 16);
            byte[] bytes = BitConverter.GetBytes(number);
            string retval = "";
            foreach (byte b in bytes)
                retval += b.ToString("X2");
            return retval;
        }


        //public static byte[] CreateCRC32(byte[][] inputArray)
        //{
        //    byte[] ByteArray = new byte[0];      //array to hold the concatenated array
        //    byte[] CRCArray = new byte[4];

        //    //concatenate the byte arrays for the data fields in the heartbeat
        //    //start from 0 because the SN *is* part of the CRC 
        //    for (int i = 0; i <= 13; i++)
        //    {
        //        ByteArray = Combine(ByteArray, inputArray[i]);
        //    }
        //    uint crc = Crc32.Crc32Algorithm.Compute(ByteArray);
        //    CRCArray = BitConverter.GetBytes(crc);

        //    //Array.Reverse(CRCArray);
        //    Console.WriteLine(BitConverter.ToString(CRCArray));

        //    return CRCArray;
        //}

        //public static byte[] CreateMD5HMAC(byte[][] inputArray, string secretKey)
        //{
        //    byte[] ByteArray = new byte[0];      //array to hold the concatenated array
        //    byte[] hashBytes = new byte[16];
        //    byte[] SecretKeyBytes = Encoding.ASCII.GetBytes(secretKey);

        //    //concatenate the byte arrays for the data fields in the heartbeat
        //    //start from 1 because the SN is not used to create the HMAC
        //    for (int i = 1; i <= 13; i++)
        //    {
        //        ByteArray = Combine(ByteArray, inputArray[i]);
        //    }

        //    // Create HMAC-MD5 Algorithm;
        //    var hmac = new HMACMD5(SecretKeyBytes);

        //    // Compute hash.
        //    hashBytes = hmac.ComputeHash(ByteArray);

        //    // Convert to HEX string.
        //    Console.WriteLine(System.BitConverter.ToString(hashBytes).Replace("-", "").ToLower());

        //    return hashBytes;
        //}
        //public static string createMD5Hash(string InputText)
        //{
        //    string MD5result = "";
        //    byte[] hashBytes = new byte[16];
        //    byte[] input = new byte[InputText.Count()];
        //    input = Encoding.ASCII.GetBytes(InputText);

        //    using (MD5CryptoServiceProvider md5Hash = new MD5CryptoServiceProvider())
        //    {
        //        hashBytes = md5Hash.ComputeHash(input);
        //    }
        //    MD5result = System.BitConverter.ToString(hashBytes).Replace("-", "").ToUpper();

        //    return MD5result;
        //}

        public static byte[] Combine(byte[] first, byte[] second)
        {
            byte[] ret = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);
            return ret;
        }

        public static int CountLinesInFile(string FileName)
        {
            var count = 0;
            try
            {
                count = File.ReadLines(FileName).Count();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return count;
        }

        public static string StringToHex(string inputstring)
        {
            byte[] asciiBytes = Encoding.ASCII.GetBytes(inputstring);
            return BitConverter.ToString(asciiBytes).Replace("-", "");
        }

    }
}
