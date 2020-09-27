using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace BlockChainProject
{
    public class Program
    {
        
        
        const long MUST_BE_LESS_THAN = 100;

        string hash(string str)
        {
            long hash = 5381;
            //int c;
            string ats = "";

            foreach (var item in str)
            {
                hash = ((hash << 5) + hash) + item;
                hash += (hash << 3);
                hash = ((hash >> 11) + hash) + item;
                hash += (hash << 33);
                ats += hash;
                hash = ((hash << 4) + hash) + item;
                hash ^= (hash >> 5);
                hash = ((hash << 7) + hash) + item;
                hash += (hash << 8);
                hash ^= (hash >> 9);
                ats += hash;
                hash += (hash << 5);
                hash += (hash << 1);
                hash ^= (hash >> 5);
                hash += (hash << 4);
                ats += hash;

            }
            //6784910539110358513
            //3869334915974166604

            return (ats);
        }

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
            string num = "asd";
            byte[] temp = Encoding.UTF8.GetBytes(num); //pakeicia i byte array
            string hashString = "";
            foreach (byte x in temp)
            {
                hashString += String.Format("{0:x2}", x);
            }

            List<string> lines = ReadFile(filename);
            List<string> hashlines = new List<string>();
            StreamWriter sw = new StreamWriter("ats.txt");
            foreach (var item in lines)
            {

                string tempstr = hash(item);
                tempstr = tempstr.Replace('-', '0');
                hashlines.Add(tempstr.GetHashCode().ToString());

                sw.WriteLine(tempstr.GetHashCode().ToString());

            }
            int collisioncount = CheckCollision(hashlines);
            //Console.WriteLine(hashlines[0]);
            Console.WriteLine("Collision = " + collisioncount.ToString());

        }
        static void Main(string[] args)
        {
            Program start = new Program();
            Console.WriteLine("Naudojamas failas : " + args[0]);
            start.Hashuok(args[0]);
        }



    }


}
