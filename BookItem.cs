using System;
using System.Collections.Generic;
using System.Text;

namespace LOTRapp
{
    public class LOTRItem
    {
        public LOTRItem(string name, string url)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}