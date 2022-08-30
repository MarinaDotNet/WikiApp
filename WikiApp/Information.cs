using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiApp
{
    internal class Information
    {
        private string name;
        private string category;
        private string structure;
        private string definition;

        public string Name { get => name; set => name = value; }
        public string Category { get => category; set => category = value; }
        public string Structure { get => structure; set => structure = value; }
        public string Definition { get => definition; set => definition = value; }
    }
}
