using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using BlockChainProject;

namespace BlockChainProject
{
    public class Program
    {
        public List<string> ReadFile(string file)
        {
            List<string> text = new List<string>();
            try
            {
                // Open the text file using a stream reader.
                using (var sr = new StreamReader(file))
                {
                    // Read the stream as a string, and write the string to the console.
                    while (!sr.EndOfStream)
                    {
                        text.Add(sr.ReadLine());

                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return text;
        }
        public void Hashuok()
        {
            Operations testavimui = new Operations();
            //SHR test
            /*Operations testavimui = new Operations();
            string temp = "abc";
            byte[] test = Encoding.UTF8.GetBytes(temp);
            string yourByteString = "";
            foreach (var item in test)
            {
                yourByteString += Convert.ToString(item, 2).PadLeft(8, '0');
                //Console.WriteLine(yourByteString);
            }
            StringBuilder strB = new StringBuilder(yourByteString);
            Console.WriteLine(yourByteString);
            yourByteString = testavimui.SHR(yourByteString, 3);
            Console.WriteLine(yourByteString);*/

            //XOR test
            /*string temp1 = "000111000111";
            string temp2 = "001111100011";
            // ats = 001000100100
            string ats = testavimui.XOR(temp1, temp2);
            Console.WriteLine(ats);
            */


        }
        static void Main(string[] args)
        {
            Program start = new Program();
            //Console.WriteLine("Naudojamas failas 1 : " + args[0]);
            //Console.WriteLine("Naudojamas failas 2 : " + args[0]);
            start.Hashuok();
        }



    }


}
