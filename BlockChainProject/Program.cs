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

        public int CheckCollision(List<string> hashlines)
        {
            int counter = 0;

            for (int i = 0; i < hashlines.Count; i++)
            {
                for (int j = i; j < hashlines.Count; j++)
                {
                    if (hashlines[i] == hashlines[j])
                    {
                        counter++;
                    }
                }
            }
            return counter - hashlines.Count;
        }
        public void Hashuok(string filename)
        {
            string temp = "abc";

            byte[] abc = Encoding.UTF8.GetBytes(temp);
            string finalstring = "";
            foreach (var item in abc)
            {
                finalstring += Convert.ToString(item, 2).PadLeft(8, '0');
            }

            //string yourByteString = Convert.ToString(abc[0], 2).PadLeft(8, '0');

 
            Console.WriteLine(finalstring);
           // int collisioncount = CheckCollision(hashlines);
            //Console.WriteLine("Collision = " + collisioncount.ToString());

        }
        static void Main(string[] args)
        {
            Program start = new Program();
            Console.WriteLine("Naudojamas failas : " + args[0]);
            start.Hashuok(args[0]);
        }



    }


}
