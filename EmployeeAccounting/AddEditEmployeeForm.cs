using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeAccounting {
    public partial class AddEditEmployeeForm : SaveCancelForm {

        private DataBase DataBase { get; }

        public Employee Employee { get; set; }

        public AddEditEmployeeForm(Employee employee, DataBase dataBase) {
            InitializeComponent();

            Employee = employee.Clone();
            DataBase = dataBase;
            
            departmentsComboBox.Items.AddRange(dataBase.Departments.ToArray());
            positionsComboBox.Items.AddRange(dataBase.Positions.ToArray());
            cabinetsComboBox.Items.AddRange(dataBase.Cabinets.Where(cabinet => cabinet.Department.Name == Employee.Department.Name).ToArray());

            InitialValueForEditing();

            SubscribeToEventsButtonClick();
        }

        public AddEditEmployeeForm(DataBase dataBase) {
            InitializeComponent();

            DataBase = dataBase;

            departmentsComboBox.Items.AddRange(dataBase.Departments.ToArray());
            positionsComboBox.Items.AddRange(dataBase.Positions.ToArray());
            cabinetsComboBox.Enabled = false;

            SubscribeToEventsButtonClick();
        }

        private void departmentsComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            cabinetsComboBox.Items.Clear();

            cabinetsComboBox.Items.AddRange(DataBase.Cabinets
                     .Where(cabinet => cabinet.Department.Name == departmentsComboBox.Text)
                     .ToArray());

            cabinetsComboBox.Enabled = true;
        }

        private void SaveButton_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(surnameTextBox.Text)) {
                surnameTextBox.Focus();
                return;
            }
            if (string.IsNullOrEmpty(nameTextBox.Text)) {
                nameTextBox.Focus();
                return;
            }
            if (string.IsNullOrEmpty(patronymicTextBox.Text)) {
                patronymicTextBox.Focus();
                return;
            }
            if (departmentsComboBox.SelectedItem is null) {
                departmentsComboBox.Focus();
                return;
            }
            if (positionsComboBox.SelectedItem is null) {
                positionsComboBox.Focus();
                return;
            }
            if (cabinetsComboBox.SelectedItem is null) {
                cabinetsComboBox.Focus();
                return;
            }

            Employee = new Employee(nameTextBox.Text,
                surnameTextBox.Text,
                patronymicTextBox.Text,
                (Department)departmentsComboBox.SelectedItem,
                (Position)positionsComboBox.SelectedItem,
                (Cabinet)cabinetsComboBox.SelectedItem
                );

            DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e) {
            AutoValidate = AutoValidate.Disable;
            DialogResult = DialogResult.Cancel;
        }

        private void TextBox_Validating(object sender, CancelEventArgs e) {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrEmpty(textBox.Text)) {
                errorProvider.SetError(textBox, "Данные не указанны");
                textBox.BackColor = Color.Pink;
                e.Cancel = true;
            }
            else {
                errorProvider.SetError(textBox, null);
                textBox.BackColor = Color.White;
            }
        }

        private void ComboBox_Validating(object sender, CancelEventArgs e) {
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.SelectedItem is null) {
                errorProvider.SetError(comboBox, "Данные не выбраны");
                e.Cancel = true;
            }
            else
                errorProvider.SetError(comboBox, null);
        }

        private void SubscribeToEventsButtonClick() {
            saveButton.Click += SaveButton_Click;
            cancelButton.Click += CancelButton_Click;
        }

        private void InitialValueForEditing() {
            nameTextBox.Text = Employee.Name;
            surnameTextBox.Text = Employee.Surname;
            patronymicTextBox.Text = Employee.Patronymic;
            departmentsComboBox.Text = Employee.Department.ToString();
            positionsComboBox.Text = Employee.Position.ToString();
            cabinetsComboBox.Text = Employee.Cabinet.ToString();
        }
    }
}
