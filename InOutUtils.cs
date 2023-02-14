using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Connections
{
    public class InOutUtils
    {
        public static List<Student> ReadStudents(string filename)
        {
            List<Student> collection = new List<Student>();
            string[] lines = File.ReadAllLines(filename, Encoding.UTF8);
            if (new FileInfo(filename).Length == 0)
            {
                Console.WriteLine("Error: no data input");
            }
            else
            {
                foreach (string line in lines)
                {
                    string[] values = line.Split(' ');
                    string name = values[0];
                    int count = int.Parse(values[1]);
                    string[] knownPeople = new string[count];
                    string fullNames = string.Empty;
                    for (int i = 0; i < count; i++)
                    {
                        knownPeople[i] = values[2+i];
                        fullNames += knownPeople[i] + " ";
                    }
                    fullNames= fullNames.TrimEnd();
                    Student current = new Student(name,count,knownPeople,fullNames);
                    if(!collection.Contains(current))
                    {
                        collection.Add(current);

                    }
                }
            }
            return collection;
        }
        public static List<Pairs> ReadPairs(string filename)
        {
            List<Pairs> names= new List<Pairs>();
            string[] lines = File.ReadAllLines (filename, Encoding.UTF8);
            foreach(string line in lines)
            {
                string[] values = line.Split(' ');
                string name1 = values[0];
                string name2 = values[1];
                string full = line;

                Pairs current = new Pairs(name1, name2, full);
                names.Add(current);
            }
            return names;
        }
        public static void PrintResult(List<Pairs> AllPairs, string filename)
        {
            string[] lines = new string[AllPairs.Count() + 4];
            lines[0] = new string('-', 105);
            for (int i = 0; i < AllPairs.Count(); i++)
            {
                lines[i+1] = AllPairs[i].Full;
            }
            lines[AllPairs.Count() + 1] = new string('-', 105);
            File.AppendAllLines(filename, lines, Encoding.UTF8);
        }
        public static void PrintOriginalData1ToTxt(List<Student> AllStudents, string filename)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            string[] lines = new string[AllStudents.Count() + 4];
            lines[0] = new string('-', 105);
            for (int i = 0; i < AllStudents.Count(); i++)
            {
                lines[i + 1] = AllStudents[i].ToString();
            }
            lines[AllStudents.Count()+1] = new string('-', 105);
            File.AppendAllLines(filename, lines, Encoding.UTF8);
        }
        public static void PrintOriginalData2ToTxt(List<Pairs> AllPairs, string filename)
        {
            string[] lines = new string[AllPairs.Count() + 4];
            lines[0] = new string('-', 105);
            for (int i = 0; i < AllPairs.Count(); i++)
            {
                lines[i + 1] = AllPairs[i].ToString();
            }
            lines[AllPairs.Count() + 1] = new string('-', 105);
            File.AppendAllLines(filename, lines, Encoding.UTF8);
        }
    }
}