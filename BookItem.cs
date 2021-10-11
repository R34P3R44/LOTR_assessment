//BookItem.cs will be used for an API call to retriev one book

using System;
using System.Collections.Generic;
using System.Text;

namespace LOTRapp
{
    //LOTRItem model with Name and Url.
    public class LOTRItem
    {
        //Defined a constructor method of LOTRItem with same name as class.
        //This will only take a string name and url as argument.
        public LOTRItem(string name, string url)
        {
            Name = name;
        }
        //Implemented properties.
        public string Name { get; set; }
    }
}