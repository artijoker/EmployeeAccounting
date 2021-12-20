
namespace EmployeeAccounting {
    partial class MainForm {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent() {
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.departmentsButton = new System.Windows.Forms.Button();
            this.employeesButton = new System.Windows.Forms.Button();
            this.positionsButton = new System.Windows.Forms.Button();
            this.cabinetsButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.departmentsButton, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.employeesButton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.positionsButton, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.cabinetsButton, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(614, 471);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // departmentsButton
            // 
            this.departmentsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.departmentsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.departmentsButton.Image = global::EmployeeAccounting.Resource.icon_departments;
            this.departmentsButton.Location = new System.Drawing.Point(313, 7);
            this.departmentsButton.Margin = new System.Windows.Forms.Padding(5);
            this.departmentsButton.Name = "departmentsButton";
            this.departmentsButton.Size = new System.Drawing.Size(294, 222);
            this.departmentsButton.TabIndex = 1;
            this.departmentsButton.Text = "Отделы";
            this.departmentsButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.departmentsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.departmentsButton.UseVisualStyleBackColor = true;
            this.departmentsButton.Click += new System.EventHandler(this.departmentsButton_Click);
            // 
            // employeesButton
            // 
            this.employeesButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.employeesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.employeesButton.Image = global::EmployeeAccounting.Resource.icon_employee;
            this.employeesButton.Location = new System.Drawing.Point(7, 7);
            this.employeesButton.Margin = new System.Windows.Forms.Padding(5);
            this.employeesButton.Name = "employeesButton";
            this.employeesButton.Size = new System.Drawing.Size(294, 222);
            this.employeesButton.TabIndex = 0;
            this.employeesButton.Text = "Сотрудники";
            this.employeesButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.employeesButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.employeesButton.UseVisualStyleBackColor = true;
            this.employeesButton.Click += new System.EventHandler(this.employeesButton_Click);
            // 
            // positionsButton
            // 
            this.positionsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.positionsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.positionsButton.Image = global::EmployeeAccounting.Resource.icon_position;
            this.positionsButton.Location = new System.Drawing.Point(7, 241);
            this.positionsButton.Margin = new System.Windows.Forms.Padding(5);
            this.positionsButton.Name = "positionsButton";
            this.positionsButton.Size = new System.Drawing.Size(294, 223);
            this.positionsButton.TabIndex = 2;
            this.positionsButton.Text = "Должности";
            this.positionsButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.positionsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.positionsButton.UseVisualStyleBackColor = true;
            this.positionsButton.Click += new System.EventHandler(this.positionsButton_Click);
            // 
            // cabinetsButton
            // 
            this.cabinetsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cabinetsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cabinetsButton.Image = global::EmployeeAccounting.Resource.icon_cabinets;
            this.cabinetsButton.Location = new System.Drawing.Point(313, 241);
            this.cabinetsButton.Margin = new System.Windows.Forms.Padding(5);
            this.cabinetsButton.Name = "cabinetsButton";
            this.cabinetsButton.Size = new System.Drawing.Size(294, 223);
            this.cabinetsButton.TabIndex = 3;
            this.cabinetsButton.Text = "Кабинеты";
            this.cabinetsButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cabinetsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cabinetsButton.UseVisualStyleBackColor = true;
            this.cabinetsButton.Click += new System.EventHandler(this.cabinetsButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 471);
            this.Controls.Add(this.tableLayoutPanel2);
            this.MinimumSize = new System.Drawing.Size(380, 380);
            this.Name = "MainForm";
            this.Text = "Учёт сотрудников";
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button departmentsButton;
        private System.Windows.Forms.Button employeesButton;
        private System.Windows.Forms.Button positionsButton;
        private System.Windows.Forms.Button cabinetsButton;
    }
}

