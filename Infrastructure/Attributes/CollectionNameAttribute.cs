using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Attributes
{
    public class CollectionNameAttribute : Attribute
    {
        public CollectionNameAttribute(string value) 
        {
            Value = value;
        }

        public string Value { get; set; }
    }
}
