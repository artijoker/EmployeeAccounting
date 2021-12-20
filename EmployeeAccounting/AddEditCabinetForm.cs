using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeAccounting {
    public partial class AddEditCabinetForm : SaveCancelForm {

        private static Regex pattern = new Regex(@"^[1-9]{1}[0-9]+$");

        private DataBase DataBase { get; }

        public Cabinet Cabinet { get; set; }
        
        public AddEditCabinetForm(DataBase dataBase) {
            InitializeComponent();

            DataBase = dataBase;

            departmentsComboBox.Items.AddRange(DataBase.Departments.ToArray());
            SubscribeToEventsButtonClick();
        }

        public AddEditCabinetForm(Cabinet cabinet, DataBase dataBase) {
            InitializeComponent();

            Cabinet = cabinet.Clone();
            DataBase = dataBase;
            
            numberTextBox.Text = Cabinet.Number.ToString();
            departmentsComboBox.Items.AddRange(DataBase.Departments.ToArray());
            departmentsComboBox.Text = Cabinet.Department.ToString();

            SubscribeToEventsButtonClick();
        }

        private void SubscribeToEventsButtonClick() {
            cancelButton.Click += CancelButton_Click;
            saveButton.Click += SaveButton_Click;  
        }

        private void SaveButton_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(numberTextBox.Text)) {
                numberTextBox.Focus();
                return;
            }
            
            if (departmentsComboBox.SelectedItem is null) {
                departmentsComboBox.Focus();
                return;
            }

            if(Cabinet != null && ((Department)departmentsComboBox.SelectedItem).Name != Cabinet.Department.Name && !IsNoEmployeesInCabinet(Cabinet)) {
                departmentsComboBox.Focus();
                MessageBox.Show(
                    $"Кабинет №{Cabinet.Number} нельзя закрепить за другим отделом пока к нему прикреплен хотя бы один сотрудник. " +
                    $"Сначала переместите сотрудников в другие кабинеты"
                    );
                return;
            }

            Cabinet = new Cabinet(int.Parse(numberTextBox.Text), (Department)departmentsComboBox.SelectedItem);
            DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e) {
            AutoValidate = AutoValidate.Disable;
            DialogResult = DialogResult.Cancel;
        }

        private void numberTextBox_Validating(object sender, CancelEventArgs e) {
            if (string.IsNullOrEmpty(numberTextBox.Text) || !pattern.IsMatch(numberTextBox.Text)) {
                errorProvider.SetError(numberTextBox, "Данные не указанны или указанны неверно. Номер должен быть положительным числом");
                numberTextBox.BackColor = Color.Pink;
                e.Cancel = true;
            }
            else {
                errorProvider.SetError(numberTextBox, null);
                numberTextBox.BackColor = Color.White;
            }
        }

        private void departmentsComboBox_Validating(object sender, CancelEventArgs e) {
            if (departmentsComboBox.SelectedItem is null) {
                errorProvider.SetError(departmentsComboBox, "Данные не выбраны");
                e.Cancel = true;
            }
            else
                errorProvider.SetError(departmentsComboBox, null);
        }

        private bool IsNoEmployeesInCabinet(Cabinet cabinet) =>
           DataBase.Employees.All(employee => employee.Cabinet.Number != cabinet.Number);
    }
}
