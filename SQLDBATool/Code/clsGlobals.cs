using LiteDB;
using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace SQLDBATool.Code
{
    class Globals
    {
        private static ConnectionString FConnectionString;
        private static FormSqlDBATool FMasterForm;
        public static ConnectionString ConnectionString { get => FConnectionString; set => FConnectionString = value; }
        public static FormSqlDBATool MasterForm { get => FMasterForm; set => FMasterForm = value; }

        public static int CountStringOccurances(string text, string pattern)
        {
            int count = 0;
            int i = 0;
            while ((i = text.IndexOf(pattern, i)) != -1)
            {
                i += pattern.Length;
                count++;
            }

            return count;
        }
    }

    public class SQLDBAToolSerialNumber : IDisposable
    {
        //private string FSerialNumber;
        //private int FNumberLicenses;
        //private string FLicenseString;
        //private bool FisLicensed = false;
        private clsLicenseInformationController LicenseController;
        private SerialInformation SerialNumber;
        public SQLDBAToolSerialNumber()
        {
            LicenseController = new clsLicenseInformationController();
            SerialNumber = LicenseController.GetSerialInformation();
        }
        public void Dispose()
        {

        }
        public void RefreshRegistrationInformation()
        {
            SerialNumber = LicenseController.GetSerialInformation();
        }
        public bool IsLicensed
        {
            get
            {
                //    if (SerialNumber != null)
                //        return SerialNumber.IsLicensed;
                //    else
                //        return false;

                return true;
            }
        }
        public string NumberLicenses
        {
            get
            {
                if (SerialNumber != null)
                    return SerialNumber.NumLicenses;
                else
                    return "";
            }
        }
        public string LicenseKeyString
        {
            get
            {
                if (SerialNumber != null)
                    return SerialNumber.LicenseKeyString;
                else
                    return "";
            }
        }
        public string LicenseKey
        {
            get
            {
                if (SerialNumber != null)
                    return SerialNumber.LicenseKey;
                else
                    return "";
            }
        }
        public DateTime TrialExpiry { get => SerialNumber.ExpiryDate;}

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

        public bool CheckSerialNumber(string serialNumber, string numberLincenses, string licenseKey)
        {
            bool ret = false;
            string compareSerialNumber = GenerateSerialNumber(numberLincenses, licenseKey);  //serialNumber.Substring(0, 4) + "-" + serialNumber.Substring(4, 8) + "-" + serialNumber.Substring(12, 4); ;

            ret = (serialNumber == compareSerialNumber);
            return ret;
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

        public string RegistrationStatus()
        {
            string ret;

            if (SerialNumber.IsLicensed)
            {
                ret = "Licensed: " + SerialNumber.NumLicenses.ToString();
            }
            else
            {
                ret = "Trial: ";
                if (SerialNumber.ExpiryDate < DateTime.Now)
                    ret = "Expired";
                else
                {
                    TimeSpan t = SerialNumber.ExpiryDate.Subtract(DateTime.Now);
                    int days = (int)Math.Floor(t.TotalDays);
                    int hours = (int)Math.Floor(t.TotalHours - (days * 24));
                    int minutes = (int)Math.Floor(t.TotalMinutes - ((hours * 60) + (days * 24 * 60)));
                    int seconds = (int)Math.Floor(t.TotalSeconds - ((minutes * 60) + (hours * 60 * 60) + (days * 24 * 60 * 60)));
                    if (days > 0)
                        ret += days.ToString("00") + " Days ";
                    ret += hours.ToString("00") + ":" + minutes.ToString("00") + ":" + seconds.ToString("00");
                }
            }

            return ret;
        }
        public void UpdateRegistrationInformation (bool isLicensed, string numberLicenses, string licenseKeyString, string licenseKey, DateTime expiryDate)
        {
            SerialNumber.IsLicensed = isLicensed;
            SerialNumber.NumLicenses = numberLicenses;
            SerialNumber.LicenseKeyString = licenseKeyString;
            SerialNumber.LicenseKey = licenseKey;
            SerialNumber.ExpiryDate = expiryDate;
            LicenseController.UpdateSerialInformation(SerialNumber);
        }
 
    }
    class DBDataGridView : DataGridView
    {
        public DBDataGridView() { DoubleBuffered = true; }
    }
    class DrawingControl
    {
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);

        private const int WM_SETREDRAW = 11;

        public static void SuspendDrawing(Control parent)
        {
            SendMessage(parent.Handle, WM_SETREDRAW, false, 0);
        }

        public static void ResumeDrawing(Control parent)
        {
            SendMessage(parent.Handle, WM_SETREDRAW, true, 0);
            parent.Refresh();
        }
    }
}
