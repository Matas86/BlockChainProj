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
        public void Hashuok()
        {
            

            string test1 = "";
            string test2 = "Lietuva";
            string test3 = "lietuva";

            test1 = op.ConvertToBytes(test1);
            test2 = op.ConvertToBytes(test2);
            test3 = op.ConvertToBytes(test3);

            List<string> test1parts = op.Split(test1);
            List<string> test2parts = op.Split(test2);
            List<string> test3parts = op.Split(test3);

            string test1ats = op.Hash(test1parts);
            string test2ats = op.Hash(test2parts);
            string test3ats = op.Hash(test3parts);

            Console.WriteLine(test1ats + "\n" + test2ats + "\n" + test3ats);

            List<double> similarities = new List<double>();
            similarities.Add(op.CheckSimilarity(test2ats, test3ats));


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
                if (temp == "") Console.WriteLine(item);
            }

            
            List<double> similarities = new List<double>();
            int count = 0;
            for (int i = 0; i < hashedlines.Count-1; i++)
            {
                for (int j = i+1; j < hashedlines.Count; j++)
                {
                    //Console.WriteLine(lines[i] + " " + lines[j]);
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

            Console.WriteLine("Didziausias panasumas: " + Math.Round(max, 2) + "%");
            Console.WriteLine("Maziausias panasumas: " + Math.Round(min, 2) + "%");
            Console.WriteLine("Vidutiniskai hashai yra panasus: " + Math.Round(sum/count, 2) + "%");


        }
        static void Main(string[] args)
        {
            Program start = new Program();
            start.Hashuok("konstitucija.txt");
            //start.Hashuok();
        }



    }


}
