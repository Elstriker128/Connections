using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Configuration;

namespace Connections
{
    public class Pairs
    {
        public string Name1 { get; private set; }
        public string Name2 { get; private set; }
        public string Full { get; set; }

        public Pairs(string name1, string name2, string full)
        {
            Name1 = name1;
            Name2 = name2;
            Full = full;
        }

        public void Relation(string message)
        {
            this.Full = $"{this.Full}:   {message}";
        }
        public override string ToString()
        {
            string info;
            info = String.Format("{0} {1}", this.Name1, this.Name2);
            return info;
        }
    }
}