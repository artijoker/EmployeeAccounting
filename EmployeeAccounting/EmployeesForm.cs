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
    public partial class EmployeesForm : EditorForm {

        public DataBase DataBase { get; set; }

        public EmployeesForm(XElement element) {
            InitializeComponent();
            DataBase = new DataBase(element);
            AddColumnsInListView();
            FillListView();

            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            SubscribeToEventsButtonClick();
        }

        private void EditButton_Click(object sender, EventArgs e) {
            if(listView.SelectedItems.Count > 1 || listView.SelectedItems.Count == 0) {
                MessageBox.Show("Для редактирования нужно выбрать одного сотрудника");
                return;
            }
            Employee employee = (Employee)listView.SelectedItems[0].Tag;
            AddEditEmployeeForm dialog = new AddEditEmployeeForm(employee, DataBase) { Text = "Редактировать сотрудника" };

            if (dialog.ShowDialog() == DialogResult.OK) {
                DataBase.Employees[listView.SelectedIndices[0]] = dialog.Employee;
                listView.Items[listView.SelectedIndices[0]] = dialog.Employee.ToListViewItem();
            }
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void AddButton_Click(object sender, EventArgs e) {
            AddEditEmployeeForm dialog = new AddEditEmployeeForm(DataBase) { Text = "Добавить сотрудника" };

            if (dialog.ShowDialog() == DialogResult.OK) {
                DataBase.Employees.Add(dialog.Employee);
                listView.Items.Add(dialog.Employee.ToListViewItem());
            }
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void SaveButton_Click(object sender, EventArgs e) => DialogResult = DialogResult.OK;

        private void DeleteButton_Click(object sender, EventArgs e) {
            foreach (ListViewItem item in listView.SelectedItems) {
                DataBase.Employees.Remove((Employee)item.Tag);
                listView.Items.Remove(item);
            }
        }

        private void SubscribeToEventsButtonClick() {
            deleteButton.Click += DeleteButton_Click;
            saveButton.Click += SaveButton_Click;
            addButton.Click += AddButton_Click;
            editButton.Click += EditButton_Click;
        }

        private void AddColumnsInListView() =>
            listView.Columns.AddRange(new[] {
                new ColumnHeader(){ Text = "Фамилия"},
                new ColumnHeader(){ Text = "Имя"},
                new ColumnHeader(){ Text = "Отчество"},
                new ColumnHeader(){ Text = "Отдел"},
                new ColumnHeader(){ Text = "Должность"},
                new ColumnHeader(){ Text = "Кабинет"}
            });
        

        private void FillListView() =>
            DataBase.Employees.ToList()
                .ForEach(employee => listView.Items.Add(employee.ToListViewItem()));
        

    }
}
