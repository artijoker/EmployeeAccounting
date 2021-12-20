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
    public partial class CabinetsForm : EditorForm {

        public DataBase DataBase { get; set; }

        public CabinetsForm(XElement element) {
            InitializeComponent();

            DataBase = new DataBase(element);

            AddColumnsInListView();
            FillListView();

            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            SubscribeToEventsButtonClick();

        }

        private void EditButton_Click(object sender, EventArgs e) {
            if (listView.SelectedItems.Count > 1 || listView.SelectedItems.Count == 0) {
                MessageBox.Show("Для редактирования нужно выбрать один кабинет");
                return;
            }
            Cabinet cabinet = (Cabinet)listView.SelectedItems[0].Tag;
            AddEditCabinetForm dialog = new AddEditCabinetForm(cabinet, DataBase) { Text = "Редактировать кабинет" };

            if (dialog.ShowDialog() == DialogResult.OK) {
                DataBase.Cabinets[listView.SelectedIndices[0]] = dialog.Cabinet;
                listView.Items[listView.SelectedIndices[0]] = dialog.Cabinet.ToListViewItem();

                listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

                for (int index = 0; index < DataBase.Employees.Count; index++) 
                    if (DataBase.Employees[index].Cabinet.Number == cabinet.Number) 
                        DataBase.Employees[index].Cabinet = dialog.Cabinet;
            }
        }

        private void AddButton_Click(object sender, EventArgs e) {
            AddEditCabinetForm dialog = new AddEditCabinetForm(DataBase) { Text = "Добавить кабинет"};

            if (dialog.ShowDialog() == DialogResult.OK) {
                DataBase.Cabinets.Add(dialog.Cabinet);
                listView.Items.Add(dialog.Cabinet.ToListViewItem());

                listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        private void SaveButton_Click(object sender, EventArgs e) => DialogResult = DialogResult.OK;
        

        private void DeleteButton_Click(object sender, EventArgs e) {
            foreach (ListViewItem item in listView.SelectedItems) {
                Cabinet cabinet = (Cabinet)item.Tag;
                if (IsNoEmployeesInCabinet(cabinet)) {
                    DataBase.Cabinets.Remove((Cabinet)item.Tag);
                    listView.Items.Remove(item);
                }
                else 
                    MessageBox.Show(
                        $"Кабинет № {cabinet} нельзя удалить пока к нему прикреплен хотя бы один сотрудник. " +
                        $"Сначала переместите сотрудников в другие кабинеты"
                        );
                
            }
        }

        private void AddColumnsInListView() =>
            listView.Columns.AddRange(new[] {
                new ColumnHeader(){ Text = "№ кабинета"},
                new ColumnHeader(){ Text = "Отдел"}
            });
        

        private void SubscribeToEventsButtonClick() {
            deleteButton.Click += DeleteButton_Click;
            saveButton.Click += SaveButton_Click;
            addButton.Click += AddButton_Click;
            editButton.Click += EditButton_Click;
        }

        private void FillListView() =>
            DataBase.Cabinets
                .ToList()
                .ForEach(cabinet => listView.Items.Add(cabinet.ToListViewItem()));
        

        private bool IsNoEmployeesInCabinet(Cabinet cabinet) =>
            DataBase.Employees.All(employee => employee.Cabinet.Number != cabinet.Number);
        
    }
}
