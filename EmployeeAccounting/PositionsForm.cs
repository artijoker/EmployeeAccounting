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
    public partial class PositionsForm : EditorForm {
        public DataBase DataBase { get; set; }

        public PositionsForm(XElement element) {
            InitializeComponent();

            DataBase = new DataBase(element);
            AddColumnsInListView();
            FillListView();

            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            SubscribeToEventsButtonClick();
        }

        private void SaveButton_Click(object sender, EventArgs e) => DialogResult = DialogResult.OK;


        private void DeleteButton_Click(object sender, EventArgs e) {
            foreach (ListViewItem item in listView.SelectedItems) {
                Position position = (Position)item.Tag;
                if (IsNoEmployeesInThisPosition(position)) {
                    DataBase.Positions.Remove(position);
                    listView.Items.Remove(item);
                }
                else
                    MessageBox.Show(
                        $"Должность {position} нельзя удалить пока её занимает хотя бы один сотрудник. " +
                        $"Сначала измените должность сотрудников на другие должности"
                        );
            }
        }

        private void EditButton_Click(object sender, EventArgs e) {
            if (listView.SelectedItems.Count > 1 || listView.SelectedItems.Count == 0) {
                MessageBox.Show("Для редактирования нужно выбрать одну должность");
                return;
            }
            Position position = (Position)listView.SelectedItems[0].Tag;
            AddEditPositionForm dialog = new AddEditPositionForm(position) { Text = "Редактировать должность" };

            if (dialog.ShowDialog() == DialogResult.OK) {
                DataBase.Positions[listView.SelectedIndices[0]] = dialog.Position;
                listView.Items[listView.SelectedIndices[0]] = dialog.Position.ToListViewItem();

                listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

                for (int index = 0; index < DataBase.Employees.Count; index++)
                    if (DataBase.Employees[index].Position.Name == position.Name)
                        DataBase.Employees[index].Position = dialog.Position;
                    
                
            }
        }

        private void AddButton_Click(object sender, EventArgs e) {
            AddEditPositionForm dialog = new AddEditPositionForm() { Text = "Добавить должность" };

            if (dialog.ShowDialog() == DialogResult.OK) {
                DataBase.Positions.Add(dialog.Position);
                listView.Items.Add(dialog.Position.ToListViewItem());

                listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
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
                new ColumnHeader(){ Text = "Должность"},
                new ColumnHeader(){ Text = "Зарплата"}
            });
        

        private void FillListView() =>
            DataBase.Positions.ToList()
                .ForEach(position => listView.Items.Add(position.ToListViewItem()));
        

        private bool IsNoEmployeesInThisPosition(Position position) =>
            DataBase.Employees.All(employee => employee.Position.Name != position.Name);
        
    }
}
