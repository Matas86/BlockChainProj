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
        Operations op = new Operations();
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

        public void Hashuok(string file)
        {
            List<string> lines = ReadFile(file);
            List<string> hashedlines = new List<string>();
            foreach (var item in lines)
            {
                List<string> templines = op.Split(item);
                string temp = op.Hash(templines);
                hashedlines.Add(temp);
            }

            
            List<double> similarities = new List<double>();
            int count = 0;
            for (int i = 0; i < hashedlines.Count-1; i++)
            {
                for (int j = i+1; j < hashedlines.Count; j++)
                {
                    similarities.Add(op.CheckSimilarity(hashedlines[i], hashedlines[j]));
                    count++;
                }
            }
            double sum = 0;
            double min = 100;
            double max = 0;
            for (int i = 0; i < similarities.Count; i++)
            {
                sum += similarities[i];
                if (min > similarities[i]) min = similarities[i];
                if (max < similarities[i]) max = similarities[i];
            }
            Console.WriteLine("Naudojamas failas: " + file);
            Console.WriteLine("Maziausias skirtumas: " + (100-Math.Round(max, 2)) + "%");
            Console.WriteLine("Didziausias skirtumas: " + (100-Math.Round(min, 2)) + "%");
            Console.WriteLine("Vidutiniskai hashai yra skirtingi: " + (100-Math.Round(sum/count, 2)) + "%");


        }
        static void Main(string[] args)
        {
            Program start = new Program();
            if (args[0] != null)
            {
                start.Hashuok(args[0]);
            }
            else
            {
                string filename = Console.ReadLine();
                start.Hashuok(filename);
            }
            //start.Hashuok();
        }



    }


}
