using System;
using System.IO;

namespace EncryptString
{
    class Program
    {
        static void Main(string[] args)
        {
            int nullCntr = 100;
            int nextNull = 1;
            bool decrypt = false;
            Random random = new Random();
            FileInfo rdrFile = new FileInfo(args[0]);
            BinaryReader rdr = new BinaryReader(File.Open(args[0], FileMode.Open));
            BinaryWriter wtr = new BinaryWriter(File.Create(args[1]));

            decrypt = (rdr.PeekChar() == 77);

            if (!decrypt)
            {
                wtr.Write((byte)77);
                wtr.Write((byte)90);
            }
            for (int a = 0; a < rdrFile.Length; a++)
            {
                if (!decrypt)
                {
                    if (nextNull == 0 && nullCntr > 0)
                    {
                        wtr.Write(0);
                        nextNull = random.Next(5);
                        nullCntr--;
                    }
                    else
                        nextNull--;
                }
                byte valIn = rdr.ReadByte();
                if ((decrypt && (valIn != 77 && valIn != 90 && valIn != 0)) || !decrypt)
                {
                    byte valOut = (byte)(256 - valIn);
                    wtr.Write(valOut);
                }
            }
            rdr.Close();
            wtr.Close();
            Console.ReadKey();
        }
    }
}
