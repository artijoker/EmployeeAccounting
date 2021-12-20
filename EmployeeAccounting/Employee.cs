using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace EmployeeAccounting {
    public class Employee {
        
        public string Name { get; }
        public string Surname { get; }
        public string Patronymic { get; }
        public Department Department { get; set; }
        public Position Position { get; set; }
        public Cabinet Cabinet { get; set; }

        public Employee(string name, string surname, string patronymic, Department department, Position position, Cabinet cabinet) {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Department = department;
            Position = position;
            Cabinet = cabinet;
        }

        public static Employee FromXElement(XElement element) {
            return new Employee(
                (string)element.Element("Name"),
                (string)element.Element("Surname"),
                (string)element.Element("Patronymic"),
                Department.FromXElement(element.Element("Department")),
                Position.FromXElement(element.Element("Position")),
                Cabinet.FromXElement(element.Element("Cabinet"))
                );
        }

        public XElement ToXElement() => new XElement("Employee", 
            new XElement("Name", Name),
            new XElement("Surname", Surname),
            new XElement("Patronymic", Patronymic),
            Department.ToXElement(),
            Position.ToXElement(),
            Cabinet.ToXElement()
            );

        public ListViewItem ToListViewItem() {
            ListViewItem item = new ListViewItem(Surname);
            item.SubItems.Add(Name);
            item.SubItems.Add(Patronymic);
            item.SubItems.Add(Department.Name);
            item.SubItems.Add(Position.Name);
            item.SubItems.Add(Cabinet.Number.ToString());
            item.Tag = this;
            return item;
        }

        public Employee Clone() => new Employee(Name, Surname, Patronymic, Department, Position, Cabinet);

    }
}
