using System;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using System.Text;
namespace EncryptString
{
    class Program
    {
        static void Main(string[] args)
        {
            //int nullCntr = 100;
            //int nextNull = 1;
            //bool decrypt = false;
            //Random random = new Random();
            //FileInfo rdrFile = new FileInfo(args[0]);
            //BinaryReader rdr = new BinaryReader(File.Open(args[0], FileMode.Open));
            //BinaryWriter wtr = new BinaryWriter(File.Create(args[1]));

            //decrypt = (rdr.PeekChar() == 77);

            //if (!decrypt)
            //{
            //    wtr.Write((byte)77);
            //    wtr.Write((byte)90);
            //}
            //for (int a = 0; a < rdrFile.Length; a++)
            //{
            //    if (!decrypt)
            //    {
            //        if (nextNull == 0 && nullCntr > 0)
            //        {
            //            wtr.Write(0);
            //            nextNull = random.Next(5);
            //            nullCntr--;
            //        }
            //        else
            //            nextNull--;
            //    }
            //    byte valIn = rdr.ReadByte();
            //    if ((decrypt && (valIn != 77 && valIn != 90 && valIn != 0)) || !decrypt)
            //    {
            //        byte valOut = (byte)(256 - valIn);
            //        wtr.Write(valOut);
            //    }
            //}
            //rdr.Close();
            //wtr.Close();
            byte[] key = Encoding.Default.GetBytes(Encrypt("1"));
            Console.WriteLine(Encrypt("1"));
            Console.WriteLine(BitConverter.ToString(key).Replace("-", ""));

            Console.ReadKey();
        }

        static string Encrypt(string textToEncrypt)
        {
            try
            {
                string ToReturn = "";
                string publickey = "99yqKn2g";
                string secretkey = "IgBcr4VH";
                byte[] secretkeyByte = { };
                secretkeyByte = System.Text.Encoding.UTF8.GetBytes(secretkey);
                byte[] publickeybyte = { };
                publickeybyte = System.Text.Encoding.UTF8.GetBytes(publickey);
                MemoryStream ms = null;
                CryptoStream cs = null;
                byte[] inputbyteArray = System.Text.Encoding.UTF8.GetBytes(textToEncrypt);
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateEncryptor(publickeybyte, secretkeyByte), CryptoStreamMode.Write);
                    cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                    cs.FlushFinalBlock();
                    ToReturn = Convert.ToBase64String(ms.ToArray());
                }
                return ToReturn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        static string Decrypt(string textToDecrypt)
        {
            try
            {
                string ToReturn = "";
                string publickey = "99yqKn2g";
                string privatekey = "IgBcr4VH";
                byte[] privatekeyByte = { };
                privatekeyByte = System.Text.Encoding.UTF8.GetBytes(privatekey);
                byte[] publickeybyte = { };
                publickeybyte = System.Text.Encoding.UTF8.GetBytes(publickey);
                MemoryStream ms = null;
                CryptoStream cs = null;
                byte[] inputbyteArray = new byte[textToDecrypt.Replace(" ", "+").Length];
                inputbyteArray = Convert.FromBase64String(textToDecrypt.Replace(" ", "+"));
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateDecryptor(publickeybyte, privatekeyByte), CryptoStreamMode.Write);
                    cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                    cs.FlushFinalBlock();
                    Encoding encoding = Encoding.UTF8;
                    ToReturn = encoding.GetString(ms.ToArray());
                }
                return ToReturn;
            }
            catch (Exception ae)
            {
                throw new Exception(ae.Message, ae.InnerException);
            }
        }
    }
}
