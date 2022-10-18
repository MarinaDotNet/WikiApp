using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiApp
{
    internal class Information
    {
        private string name = "";
        private string category = "";
        private string structure = "";
        private string definition = "";

        public void SetName(string name)
        {
            this.name = name;
        }
        public string GetName()
        {
            return this.name;
        }

        public void SetCategory(string category)
        {
            this.category = category;
        }
        public string GetCategory()
        {
            return this.category;
        }

        public void SetStructure(string structure)
        {
            this.structure = structure;
        }
        public string GetStructure()
        {
            return this.structure;
        }

        public void SetDefinition(string definition)
        {
            this.definition = definition;
        }
        public string GetDefintion()
        {
            return this.definition;
        }
    }
}
