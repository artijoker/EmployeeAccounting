using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace EmployeeAccounting {
    public class Department {
        public string Name { get; }
        public Department(string name) => Name = name;

        public static Department FromXElement(XElement element) => new Department((string)element.Element("Name"));

        public XElement ToXElement() => new XElement("Department",new XElement("Name", Name));

        public ListViewItem ToListViewItem() {
            ListViewItem item = new ListViewItem(Name);
            item.Tag = this;
            return item;
        }

        public override string ToString() => Name;
        public Department Clone() => new Department(Name);
    }
}
