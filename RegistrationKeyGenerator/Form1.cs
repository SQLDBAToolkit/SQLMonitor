using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace RegistrationKeyGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string GenerateSerialNumber(string numberLincenses, string licenseKey)
        {
            if (numberLincenses.Length > 2)
            {
                numberLincenses = numberLincenses.Substring(0, 2);
            }
            string serialKey = numberLincenses + "-" + licenseKey + "-SQLDBATool";
            
            byte[] key = Encoding.Default.GetBytes(Encrypt(serialKey));

            string serialNumber = BitConverter.ToString(key).Replace("-", "");
            serialNumber = serialNumber.Substring(0, 4) + "-" + Reverse(serialNumber).Substring(4, 8) + "-" + serialNumber.Substring(12, 4);

            return serialNumber;

        }
        string Reverse(string text)
        {
            if (text == null) return null;

            // this was posted by petebob as well 
            char[] array = text.ToCharArray();
            Array.Reverse(array);
            return new String(array);
        }
        string Encrypt(string textToEncrypt)
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

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBoxNumberLicenses.Text.Length > 0)
            {
                if (textBoxLicenseKey.Text.Length > 0)
                {
                    string serialNumber = GenerateSerialNumber(textBoxNumberLicenses.Text, textBoxLicenseKey.Text);
                    textBoxSerialNumber.Text = serialNumber;
                }
            }
        }
    }
}
