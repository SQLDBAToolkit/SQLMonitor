using LiteDB;
using System;
using System.Windows.Forms;
namespace WaitStateEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string waitType = "";
            string waitTypeDescription = "";
            foreach (string row in textBox1.Lines)
            {
                if (row.Contains("\t"))
                {
                    if (waitType.Length > 0)
                    {
                        textBox2.Text = textBox2.Text += "\r\n\"" + waitType + "\"\t\"" + waitTypeDescription + "\"";
                    }
                    waitType = row.Substring(0, row.IndexOf("\t"));
                    waitTypeDescription = row.Substring(row.IndexOf("\t") + 1);
                }
                else
                    waitTypeDescription = waitTypeDescription + "\r\n" + row;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConnectionString connString = new ConnectionString();
            connString.Filename = @"F:\Projects\SQLDBATool\SQLDBATool\Data\SqlDBTool.litedb";
            connString.Connection = ConnectionType.Shared;
            connString.ReadOnly = false;
            using (LiteDatabase db = new LiteDatabase(connString))
            {

                var col = db.GetCollection<WaitStateInformation>("WaitStateInformation");
                string waitType = "";
                string waitTypeDescription = "";
                foreach (string row in textBox1.Lines)
                {
                    if (row.Contains("\t"))
                    {
                        if (waitType.Length > 0)
                        {
                            textBox2.Text = textBox2.Text += "\r\n\"" + waitType + "\"\t\"" + waitTypeDescription + "\"";
                            WaitStateInformation waitStateInformation = new WaitStateInformation();
                            waitStateInformation.WaitType = waitType;
                            waitStateInformation.WaitTypeDescription = waitTypeDescription;
                            col.Insert(waitStateInformation);

                        }
                        waitType = row.Substring(0, row.IndexOf("\t"));
                        waitTypeDescription = row.Substring(row.IndexOf("\t") + 1);

                    }
                    else
                        waitTypeDescription = waitTypeDescription + "\r\n" + row;

                }
                WaitStateInformation waitState = new WaitStateInformation();
                waitState.WaitType = waitType;
                waitState.WaitTypeDescription = waitTypeDescription;
                col.Insert(waitState);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ConnectionString connString = new ConnectionString();
            connString.Filename = @"F:\Projects\SQLDBATool\SQLDBATool\Data\SqlDBTool.litedb";
            connString.Connection = ConnectionType.Shared;
            connString.ReadOnly = false;
            using (LiteDatabase db = new LiteDatabase(connString))
            {

                var col = db.GetCollection<WaitStateInformation>("WaitStateInformation");
                col.EnsureIndex("WaitType", true);
            }
        }
    }

    public class WaitStateInformation
    {
        public int ID { get; set; }
        public string WaitType { get; set; }
        public string WaitTypeDescription { get; set; }

    }
}

