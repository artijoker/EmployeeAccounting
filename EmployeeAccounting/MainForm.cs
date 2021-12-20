using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace EmployeeAccounting {
    public partial class MainForm : Form {
        private XElement Element { get; set; }

        public MainForm() {
            InitializeComponent();

            Element = XElement.Load("Data.xml");
        }

        private void employeesButton_Click(object sender, EventArgs e) {

            EmployeesForm dialog = new EmployeesForm(Element);
            Visible = false;
            dialog.Location = Location;
            dialog.StartPosition = FormStartPosition.Manual;
            if (dialog.ShowDialog() == DialogResult.OK) {
                SaveDataBase(dialog.DataBase);
            }
            Visible = true;
        }

        private void departmentsButton_Click(object sender, EventArgs e) {
            DepartmentsForm dialog = new DepartmentsForm(Element);
            Visible = false;
            dialog.Location = Location;
            dialog.StartPosition = FormStartPosition.Manual;
            if (dialog.ShowDialog() == DialogResult.OK) {
                SaveDataBase(dialog.DataBase);
            }
            Visible = true;
        }

        private void positionsButton_Click(object sender, EventArgs e) {
            PositionsForm dialog = new PositionsForm(Element);
            Visible = false;
            dialog.Location = Location;
            dialog.StartPosition = FormStartPosition.Manual;
            if (dialog.ShowDialog() == DialogResult.OK) {
                SaveDataBase(dialog.DataBase);
            }
            Visible = true;
        }

        private void cabinetsButton_Click(object sender, EventArgs e) {
            CabinetsForm dialog = new CabinetsForm(Element);
            Visible = false;
            dialog.Location = Location;
            dialog.StartPosition = FormStartPosition.Manual;
            if (dialog.ShowDialog() == DialogResult.OK) {
                SaveDataBase(dialog.DataBase);
            }
            Visible = true;
        }

        private void SaveDataBase(DataBase dataBase) {
            XElement xElement = new XElement("Data",
                   new XElement("Departments", dataBase.Departments.Select(data => data.ToXElement())),
                   new XElement("Cabinets", dataBase.Cabinets.Select(data => data.ToXElement())),
                   new XElement("Positions", dataBase.Positions.Select(data => data.ToXElement())),
                   new XElement("Employees", dataBase.Employees.Select(data => data.ToXElement()))
              );
            xElement.Save("Data.xml");
            Element = xElement;
        }

    }
}
