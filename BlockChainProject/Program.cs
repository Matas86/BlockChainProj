using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

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
            
            strB.Append(strB.Length-1);
            Console.WriteLine(strB.Length);
            for (int i = 0; i < 6; i++)
            {

                for (int j = 0; j < strB.Length-1; j++)
                {
                    strB[strB.Length-1 - j] = strB[strB.Length - 2 - j];
                    Console.WriteLine(strB.ToString());
                }
                strB[0] = '0';

            }
            strB.Remove(strB.Length-2, 2);
            Console.WriteLine(strB.ToString());

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
