using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Connections
{
    public class Student
    {
        public string Name { get; private set; }
        public int KnownCount { get; private set; }
        public string[] KnownStudents { get; private set; }
        public string FullNames { get; set; }

        public Student(string name, int knownCount, string[] knownStudents, string fullNames)
        {
            Name = name;
            KnownCount = knownCount;
            KnownStudents = knownStudents;
            FullNames = fullNames;
        }

        public override string ToString()
        {
            string info;
            info = String.Format("{0} {1} {2}", this.Name, this.KnownCount, this.FullNames);
            return info;
        }
    }
}