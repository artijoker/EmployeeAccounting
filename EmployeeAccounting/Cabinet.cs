using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace EmployeeAccounting {
    public class Cabinet {
        public int Number { get; }
        public Department Department { get; set; }
        public Cabinet(int number, Department department) {
            Number = number;
            Department = department;
        }

        public static Cabinet FromXElement(XElement element) {

            return new Cabinet(
                (int)element.Element("Number"),
                Department.FromXElement(element.Element("Department"))
                );

        }

        public XElement ToXElement() => new XElement("Cabinet",
            new XElement("Number", Number),
            Department.ToXElement()
            );

        public ListViewItem ToListViewItem() {
            ListViewItem item = new ListViewItem(Number.ToString());
            item.SubItems.Add(Department.Name);
            item.Tag = this;
            return item;
        }
        public override string ToString() => Number.ToString();
        public Cabinet Clone() => new Cabinet(Number, Department);
    }
}
