namespace Homework8_4._8
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.txt_que = new System.Windows.Forms.TextBox();
            this.btn_que = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_del = new System.Windows.Forms.Button();
            this.btn_upd = new System.Windows.Forms.Button();
            this.btn_imp = new System.Windows.Forms.Button();
            this.btn_exp = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bindingSource_order = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderCargoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource_details = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderCustomerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalCostDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_order)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_details)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.comboBox1);
            this.flowLayoutPanel1.Controls.Add(this.txt_que);
            this.flowLayoutPanel1.Controls.Add(this.btn_que);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(15);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1001, 76);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Total",
            "ID",
            "Cost",
            "Name",
            "Goods-Name"});
            this.comboBox1.Location = new System.Drawing.Point(25, 25);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(10);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(127, 26);
            this.comboBox1.TabIndex = 0;
            // 
            // txt_que
            // 
            this.txt_que.Location = new System.Drawing.Point(172, 25);
            this.txt_que.Margin = new System.Windows.Forms.Padding(10);
            this.txt_que.Name = "txt_que";
            this.txt_que.Size = new System.Drawing.Size(286, 28);
            this.txt_que.TabIndex = 1;
            // 
            // btn_que
            // 
            this.btn_que.Location = new System.Drawing.Point(478, 25);
            this.btn_que.Margin = new System.Windows.Forms.Padding(10);
            this.btn_que.Name = "btn_que";
            this.btn_que.Size = new System.Drawing.Size(115, 38);
            this.btn_que.TabIndex = 2;
            this.btn_que.Text = "查询";
            this.btn_que.UseVisualStyleBackColor = true;
            this.btn_que.Click += new System.EventHandler(this.btn_que_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel2.Controls.Add(this.btn_add);
            this.flowLayoutPanel2.Controls.Add(this.btn_del);
            this.flowLayoutPanel2.Controls.Add(this.btn_upd);
            this.flowLayoutPanel2.Controls.Add(this.btn_imp);
            this.flowLayoutPanel2.Controls.Add(this.btn_exp);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 76);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(15);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1001, 91);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(25, 25);
            this.btn_add.Margin = new System.Windows.Forms.Padding(10);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(170, 37);
            this.btn_add.TabIndex = 0;
            this.btn_add.Text = "增加订单";
            this.btn_add.UseVisualStyleBackColor = true;
            // 
            // btn_del
            // 
            this.btn_del.Location = new System.Drawing.Point(215, 25);
            this.btn_del.Margin = new System.Windows.Forms.Padding(10);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(170, 37);
            this.btn_del.TabIndex = 1;
            this.btn_del.Text = "删除订单";
            this.btn_del.UseVisualStyleBackColor = true;
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // btn_upd
            // 
            this.btn_upd.Location = new System.Drawing.Point(405, 25);
            this.btn_upd.Margin = new System.Windows.Forms.Padding(10);
            this.btn_upd.Name = "btn_upd";
            this.btn_upd.Size = new System.Drawing.Size(170, 37);
            this.btn_upd.TabIndex = 2;
            this.btn_upd.Text = "修改订单";
            this.btn_upd.UseVisualStyleBackColor = true;
            // 
            // btn_imp
            // 
            this.btn_imp.Location = new System.Drawing.Point(595, 25);
            this.btn_imp.Margin = new System.Windows.Forms.Padding(10);
            this.btn_imp.Name = "btn_imp";
            this.btn_imp.Size = new System.Drawing.Size(170, 37);
            this.btn_imp.TabIndex = 3;
            this.btn_imp.Text = "导入订单";
            this.btn_imp.UseVisualStyleBackColor = true;
            // 
            // btn_exp
            // 
            this.btn_exp.Location = new System.Drawing.Point(785, 25);
            this.btn_exp.Margin = new System.Windows.Forms.Padding(10);
            this.btn_exp.Name = "btn_exp";
            this.btn_exp.Size = new System.Drawing.Size(170, 37);
            this.btn_exp.TabIndex = 4;
            this.btn_exp.Text = "导出订单";
            this.btn_exp.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 167);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 497F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1001, 497);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.orderCustomerDataGridViewTextBoxColumn,
            this.timeDataGridViewTextBoxColumn,
            this.totalCostDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bindingSource_order;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(494, 491);
            this.dataGridView1.TabIndex = 0;
            // 
            // bindingSource_order
            // 
            this.bindingSource_order.DataMember = "DisplayOrders";
            this.bindingSource_order.DataSource = typeof(Homework8_4._8.Form1);
            this.bindingSource_order.CurrentChanged += new System.EventHandler(this.bindingSource_order_CurrentChanged);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn1,
            this.orderCargoDataGridViewTextBoxColumn,
            this.numDataGridViewTextBoxColumn,
            this.totalPriceDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.bindingSource_details;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(503, 3);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 62;
            this.dataGridView2.RowTemplate.Height = 30;
            this.dataGridView2.Size = new System.Drawing.Size(495, 491);
            this.dataGridView2.TabIndex = 1;
            // 
            // idDataGridViewTextBoxColumn1
            // 
            this.idDataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn1.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn1.MinimumWidth = 8;
            this.idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            this.idDataGridViewTextBoxColumn1.Width = 150;
            // 
            // orderCargoDataGridViewTextBoxColumn
            // 
            this.orderCargoDataGridViewTextBoxColumn.DataPropertyName = "OrderCargo";
            this.orderCargoDataGridViewTextBoxColumn.HeaderText = "OrderCargo";
            this.orderCargoDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.orderCargoDataGridViewTextBoxColumn.Name = "orderCargoDataGridViewTextBoxColumn";
            this.orderCargoDataGridViewTextBoxColumn.Width = 150;
            // 
            // numDataGridViewTextBoxColumn
            // 
            this.numDataGridViewTextBoxColumn.DataPropertyName = "Num";
            this.numDataGridViewTextBoxColumn.HeaderText = "Num";
            this.numDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.numDataGridViewTextBoxColumn.Name = "numDataGridViewTextBoxColumn";
            this.numDataGridViewTextBoxColumn.Width = 150;
            // 
            // totalPriceDataGridViewTextBoxColumn
            // 
            this.totalPriceDataGridViewTextBoxColumn.DataPropertyName = "TotalPrice";
            this.totalPriceDataGridViewTextBoxColumn.HeaderText = "TotalPrice";
            this.totalPriceDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.totalPriceDataGridViewTextBoxColumn.Name = "totalPriceDataGridViewTextBoxColumn";
            this.totalPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalPriceDataGridViewTextBoxColumn.Width = 150;
            // 
            // bindingSource_details
            // 
            this.bindingSource_details.DataMember = "Details";
            this.bindingSource_details.DataSource = typeof(Task1.Order);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Width = 150;
            // 
            // orderCustomerDataGridViewTextBoxColumn
            // 
            this.orderCustomerDataGridViewTextBoxColumn.DataPropertyName = "OrderCustomer";
            this.orderCustomerDataGridViewTextBoxColumn.HeaderText = "OrderCustomer";
            this.orderCustomerDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.orderCustomerDataGridViewTextBoxColumn.Name = "orderCustomerDataGridViewTextBoxColumn";
            this.orderCustomerDataGridViewTextBoxColumn.Width = 150;
            // 
            // timeDataGridViewTextBoxColumn
            // 
            this.timeDataGridViewTextBoxColumn.DataPropertyName = "Time";
            this.timeDataGridViewTextBoxColumn.HeaderText = "Time";
            this.timeDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.timeDataGridViewTextBoxColumn.Name = "timeDataGridViewTextBoxColumn";
            this.timeDataGridViewTextBoxColumn.Width = 150;
            // 
            // totalCostDataGridViewTextBoxColumn
            // 
            this.totalCostDataGridViewTextBoxColumn.DataPropertyName = "TotalCost";
            this.totalCostDataGridViewTextBoxColumn.HeaderText = "TotalCost";
            this.totalCostDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.totalCostDataGridViewTextBoxColumn.Name = "totalCostDataGridViewTextBoxColumn";
            this.totalCostDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalCostDataGridViewTextBoxColumn.Width = 150;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 664);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_order)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_details)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox txt_que;
        private System.Windows.Forms.Button btn_que;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_del;
        private System.Windows.Forms.Button btn_upd;
        private System.Windows.Forms.Button btn_imp;
        private System.Windows.Forms.Button btn_exp;
        private System.Windows.Forms.BindingSource bindingSource_order;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSource_details;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderCargoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn acceptButtonDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn autoScrollDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn autoSizeDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn autoSizeModeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn autoValidateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn backColorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn formBorderStyleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cancelButtonDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn controlBoxDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn helpButtonDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn iconDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isMdiContainerDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn keyPreviewDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maximumSizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mainMenuStripDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn minimumSizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn maximizeBoxDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn minimizeBoxDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn opacityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn rightToLeftLayoutDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn showInTaskbarDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn showIconDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sizeGripStyleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startPositionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn textDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn topMostDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn transparencyKeyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn windowStateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn autoScrollMarginDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn autoScrollMinSizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn accessibleDescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn accessibleNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn accessibleRoleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn allowDropDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn anchorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn backgroundImageDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn backgroundImageLayoutDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn causesValidationDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contextMenuStripDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cursorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataBindingsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dockDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn enabledDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fontDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn foreColorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rightToLeftDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tagDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn useWaitCursorDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn visibleDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paddingDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn imeModeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderCustomerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalCostDataGridViewTextBoxColumn;
    }
}

