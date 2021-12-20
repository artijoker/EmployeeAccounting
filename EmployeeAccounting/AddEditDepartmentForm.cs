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
    public partial class AddEditDepartmentForm : SaveCancelForm {
        public Department Department { get; set; }

        public AddEditDepartmentForm(Department department) {
            InitializeComponent();

            Department = department.Clone();
            nameTextBox.Text = Department.Name;

            SubscribeToEventsButtonClick();
        }

        public AddEditDepartmentForm() {
            InitializeComponent();

            SubscribeToEventsButtonClick();
        }

        private void SaveButton_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(nameTextBox.Text)) {
                nameTextBox.Focus();
                return;
            }
            Department = new Department(nameTextBox.Text);
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

        private void SubscribeToEventsButtonClick() {
            saveButton.Click += SaveButton_Click;
            cancelButton.Click += CancelButton_Click;
        }

    }
}
