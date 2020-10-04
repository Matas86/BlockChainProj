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
            Operations op = new Operations();

            string test1 = "lietuvalietuvalietuvalietuvalietuvalietuvalietuvalietuvalietuvalietuva";
            string test2 = "Lietuva";

            test1 = op.ConvertToBytes(test1);
            test2 = op.ConvertToBytes(test2);

            List<string> test1parts = op.Split(test1);
            List<string> test2parts = op.Split(test2);

            string test1ats = op.Hash(test1parts);
            Console.WriteLine(test1ats);


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
