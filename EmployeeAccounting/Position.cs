using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace EmployeeAccounting {
    public class Position {
        public string Name { get;}
        public int Salary { get;}
        public Position(string name, int salary) {
            Name = name;
            Salary = salary;
        }

        public static Position FromXElement(XElement element) => new Position(
            (string)element.Element("Name"),
            (int)element.Element("Salary")
            );

        public XElement ToXElement() => new XElement("Position",
            new XElement("Name", Name),
            new XElement("Salary", Salary)
            );

        public ListViewItem ToListViewItem() {
            ListViewItem item = new ListViewItem(Name);
            item.SubItems.Add(Salary.ToString());
            item.Tag = this;
            return item;
        }

        public override string ToString() => Name;
        public Position Clone() => new Position(Name, Salary);

    }
}
