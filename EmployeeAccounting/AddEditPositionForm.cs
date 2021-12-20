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
    public partial class AddEditPositionForm : SaveCancelForm {

        private static Regex pattern = new Regex(@"^[1-9]{1}[0-9]*$");

        public Position Position { get; set; }
        
        public AddEditPositionForm() {
            InitializeComponent();

            SubscribeToEventsButtonClick();
        }

        public AddEditPositionForm(Position position) {
            InitializeComponent();

            Position = position.Clone();

            nameTextBox.Text = Position.Name;
            salaryTextBox.Text = Position.Salary.ToString();

            SubscribeToEventsButtonClick();
        }

        private void SubscribeToEventsButtonClick() {
            cancelButton.Click += CancelButton_Click;
            saveButton.Click += SaveButton_Click;
        }

        private void SaveButton_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(nameTextBox.Text)) {
                nameTextBox.Focus();
                return;
            }

            if (string.IsNullOrEmpty(salaryTextBox.Text)) {
                salaryTextBox.Focus();
                return;
            }

            Position = new Position(nameTextBox.Text, int.Parse(salaryTextBox.Text));
            DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e) {
            AutoValidate = AutoValidate.Disable;
            DialogResult = DialogResult.Cancel;
        }


        private void nameTextBox_Validating(object sender, CancelEventArgs e) {
            if (string.IsNullOrEmpty(nameTextBox.Text)) {
                errorProvider.SetError(nameTextBox, "Данные не указанны");
                nameTextBox.BackColor = Color.Pink;
                e.Cancel = true;
            }
            else {
                errorProvider.SetError(nameTextBox, null);
                nameTextBox.BackColor = Color.White;
            }
        }

        private void salaryTextBox_Validating(object sender, CancelEventArgs e) {
            if (string.IsNullOrEmpty(salaryTextBox.Text) || !pattern.IsMatch(salaryTextBox.Text)) {
                errorProvider.SetError(
                    salaryTextBox, "Данные не указанны или указанны неверно. Зарплата должна быть положительным числом"
                    );
                salaryTextBox.BackColor = Color.Pink;
                e.Cancel = true;
            }
            else {
                errorProvider.SetError(salaryTextBox, null);
                salaryTextBox.BackColor = Color.White;
            }
        }
    }
}
