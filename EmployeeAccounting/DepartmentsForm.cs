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
    public partial class DepartmentsForm : EditorForm {
        public DataBase DataBase { get; set; }

        public DepartmentsForm(XElement element) {
            InitializeComponent();

            DataBase = new DataBase(element);

            AddColumnsInListView();
            FillListView();
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            SubscribeToEventsButtonClick();
        }

        private void EditButton_Click(object sender, EventArgs e) {
            if (listView.SelectedItems.Count > 1 || listView.SelectedItems.Count == 0) {
                MessageBox.Show("Для редактирования нужно выбрать один отдел");
                return;
            }

            Department department = (Department)listView.SelectedItems[0].Tag;
            AddEditDepartmentForm dialog = new AddEditDepartmentForm(department) { Text = "Редактировать отдел" };

            if (dialog.ShowDialog() == DialogResult.OK) {
                DataBase.Departments[listView.SelectedIndices[0]] = dialog.Department;
                listView.Items[listView.SelectedIndices[0]] = dialog.Department.ToListViewItem();

                listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

                for (int index = 0; index < DataBase.Cabinets.Count; index++)
                    if (DataBase.Cabinets[index].Department.Name == department.Name)
                        DataBase.Cabinets[index].Department = dialog.Department;

                for (int index = 0; index < DataBase.Employees.Count; index++)
                    if (DataBase.Employees[index].Department.Name == department.Name) {
                        DataBase.Employees[index].Cabinet.Department = dialog.Department;
                        DataBase.Employees[index].Department = dialog.Department;
                    }


                //for (int index = 0; index < DataBase.Cabinets.Count; index++)
                //    if (DataBase.Cabinets[index].Department.Name == department.Name)
                //        DataBase.Cabinets[index] = new Cabinet(DataBase.Cabinets[index].Number, dialog.Department);

                //for (int index = 0; index < DataBase.Employees.Count; index++)
                //    if (DataBase.Employees[index].Department.Name == department.Name) {
                //        DataBase.Employees[index] = new Employee(
                //            DataBase.Employees[index].Name,
                //            DataBase.Employees[index].Surname,
                //            DataBase.Employees[index].Patronymic,
                //            dialog.Department,
                //            DataBase.Employees[index].Position,
                //            new Cabinet(DataBase.Employees[index].Cabinet.Number, dialog.Department)
                //            );
                //    }
            }
        }

        private void AddButton_Click(object sender, EventArgs e) {
            AddEditDepartmentForm dialog = new AddEditDepartmentForm { Text = "Добавить отдел" };

            if (dialog.ShowDialog() == DialogResult.OK) {
                DataBase.Departments.Add(dialog.Department);
                listView.Items.Add(dialog.Department.ToListViewItem());
                listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        private void SaveButton_Click(object sender, EventArgs e) => DialogResult = DialogResult.OK;

        private void DeleteButton_Click(object sender, EventArgs e) {
            foreach (ListViewItem item in listView.SelectedItems) {
                Department department = (Department)item.Tag;

                if (IsNoEmployeesInDepartment(department) && IsNoCabinetsInDepartment(department)) {
                    DataBase.Departments.Remove(department);
                    listView.Items.Remove(item);
                }
                else {
                    MessageBox.Show(
                        $"Отдел {department} нельзя удалить пока к нему прикреплен хотя бы один сотрудник или кабинет. " +
                        $"Сначала переместите всех сотрудников в другие отделы и открепите все кабинеты"
                        );
                }
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
                new ColumnHeader(){ Text = "Отдел"}
            });
        

        private void FillListView() =>
            DataBase.Departments.ToList()
                .ForEach(department => listView.Items.Add(department.ToListViewItem()));
        

        private bool IsNoEmployeesInDepartment(Department department) =>
            DataBase.Employees.All(employee => employee.Department.Name != department.Name);
        

        private bool IsNoCabinetsInDepartment(Department department) =>
            DataBase.Cabinets.All(cabinet => cabinet.Department.Name != department.Name);
        
    }
}
