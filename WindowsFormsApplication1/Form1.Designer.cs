using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.appIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.appNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.devUrlDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prodUrlDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.queryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fieldTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kPINameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastDateTestedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.queryResultDevDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.queryResultProdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastTestPassedDevDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastTestPassedProdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateLastPassedDevDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateLastPassedProdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.testIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.appTestTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dWControlDataSet = new WindowsFormsApplication1.DWControlDataSet();
            this.appTestTableTableAdapter = new WindowsFormsApplication1.DWControlDataSetTableAdapters.AppTestTableTableAdapter();
            this.tableAdapterManager = new WindowsFormsApplication1.DWControlDataSetTableAdapters.TableAdapterManager();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appTestTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dWControlDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.appIDDataGridViewTextBoxColumn,
            this.appNameDataGridViewTextBoxColumn,
            this.devUrlDataGridViewTextBoxColumn,
            this.prodUrlDataGridViewTextBoxColumn,
            this.queryDataGridViewTextBoxColumn,
            this.fieldTypeDataGridViewTextBoxColumn,
            this.kPINameDataGridViewTextBoxColumn,
            this.lastDateTestedDataGridViewTextBoxColumn,
            this.queryResultDevDataGridViewTextBoxColumn,
            this.queryResultProdDataGridViewTextBoxColumn,
            this.lastTestPassedDevDataGridViewTextBoxColumn,
            this.lastTestPassedProdDataGridViewTextBoxColumn,
            this.dateLastPassedDevDataGridViewTextBoxColumn,
            this.dateLastPassedProdDataGridViewTextBoxColumn,
            this.testIDDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.appTestTableBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(36, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(442, 325);
            this.dataGridView1.TabIndex = 0;
            // 
            // appIDDataGridViewTextBoxColumn
            // 
            this.appIDDataGridViewTextBoxColumn.DataPropertyName = "AppID";
            this.appIDDataGridViewTextBoxColumn.HeaderText = "AppID";
            this.appIDDataGridViewTextBoxColumn.Name = "appIDDataGridViewTextBoxColumn";
            // 
            // appNameDataGridViewTextBoxColumn
            // 
            this.appNameDataGridViewTextBoxColumn.DataPropertyName = "AppName";
            this.appNameDataGridViewTextBoxColumn.HeaderText = "AppName";
            this.appNameDataGridViewTextBoxColumn.Name = "appNameDataGridViewTextBoxColumn";
            // 
            // devUrlDataGridViewTextBoxColumn
            // 
            this.devUrlDataGridViewTextBoxColumn.DataPropertyName = "DevUrl";
            this.devUrlDataGridViewTextBoxColumn.HeaderText = "DevUrl";
            this.devUrlDataGridViewTextBoxColumn.Name = "devUrlDataGridViewTextBoxColumn";
            // 
            // prodUrlDataGridViewTextBoxColumn
            // 
            this.prodUrlDataGridViewTextBoxColumn.DataPropertyName = "ProdUrl";
            this.prodUrlDataGridViewTextBoxColumn.HeaderText = "ProdUrl";
            this.prodUrlDataGridViewTextBoxColumn.Name = "prodUrlDataGridViewTextBoxColumn";
            // 
            // queryDataGridViewTextBoxColumn
            // 
            this.queryDataGridViewTextBoxColumn.DataPropertyName = "Query";
            this.queryDataGridViewTextBoxColumn.HeaderText = "Query";
            this.queryDataGridViewTextBoxColumn.Name = "queryDataGridViewTextBoxColumn";
            // 
            // fieldTypeDataGridViewTextBoxColumn
            // 
            this.fieldTypeDataGridViewTextBoxColumn.DataPropertyName = "FieldType";
            this.fieldTypeDataGridViewTextBoxColumn.HeaderText = "FieldType";
            this.fieldTypeDataGridViewTextBoxColumn.Name = "fieldTypeDataGridViewTextBoxColumn";
            // 
            // kPINameDataGridViewTextBoxColumn
            // 
            this.kPINameDataGridViewTextBoxColumn.DataPropertyName = "KPI Name";
            this.kPINameDataGridViewTextBoxColumn.HeaderText = "KPI Name";
            this.kPINameDataGridViewTextBoxColumn.Name = "kPINameDataGridViewTextBoxColumn";
            // 
            // lastDateTestedDataGridViewTextBoxColumn
            // 
            this.lastDateTestedDataGridViewTextBoxColumn.DataPropertyName = "Last Date Tested";
            this.lastDateTestedDataGridViewTextBoxColumn.HeaderText = "Last Date Tested";
            this.lastDateTestedDataGridViewTextBoxColumn.Name = "lastDateTestedDataGridViewTextBoxColumn";
            // 
            // queryResultDevDataGridViewTextBoxColumn
            // 
            this.queryResultDevDataGridViewTextBoxColumn.DataPropertyName = "Query Result Dev";
            this.queryResultDevDataGridViewTextBoxColumn.HeaderText = "Query Result Dev";
            this.queryResultDevDataGridViewTextBoxColumn.Name = "queryResultDevDataGridViewTextBoxColumn";
            // 
            // queryResultProdDataGridViewTextBoxColumn
            // 
            this.queryResultProdDataGridViewTextBoxColumn.DataPropertyName = "Query Result Prod";
            this.queryResultProdDataGridViewTextBoxColumn.HeaderText = "Query Result Prod";
            this.queryResultProdDataGridViewTextBoxColumn.Name = "queryResultProdDataGridViewTextBoxColumn";
            // 
            // lastTestPassedDevDataGridViewTextBoxColumn
            // 
            this.lastTestPassedDevDataGridViewTextBoxColumn.DataPropertyName = "Last Test Passed Dev";
            this.lastTestPassedDevDataGridViewTextBoxColumn.HeaderText = "Last Test Passed Dev";
            this.lastTestPassedDevDataGridViewTextBoxColumn.Name = "lastTestPassedDevDataGridViewTextBoxColumn";
            // 
            // lastTestPassedProdDataGridViewTextBoxColumn
            // 
            this.lastTestPassedProdDataGridViewTextBoxColumn.DataPropertyName = "Last Test Passed Prod";
            this.lastTestPassedProdDataGridViewTextBoxColumn.HeaderText = "Last Test Passed Prod";
            this.lastTestPassedProdDataGridViewTextBoxColumn.Name = "lastTestPassedProdDataGridViewTextBoxColumn";
            // 
            // dateLastPassedDevDataGridViewTextBoxColumn
            // 
            this.dateLastPassedDevDataGridViewTextBoxColumn.DataPropertyName = "Date Last Passed Dev";
            this.dateLastPassedDevDataGridViewTextBoxColumn.HeaderText = "Date Last Passed Dev";
            this.dateLastPassedDevDataGridViewTextBoxColumn.Name = "dateLastPassedDevDataGridViewTextBoxColumn";
            // 
            // dateLastPassedProdDataGridViewTextBoxColumn
            // 
            this.dateLastPassedProdDataGridViewTextBoxColumn.DataPropertyName = "Date Last Passed Prod";
            this.dateLastPassedProdDataGridViewTextBoxColumn.HeaderText = "Date Last Passed Prod";
            this.dateLastPassedProdDataGridViewTextBoxColumn.Name = "dateLastPassedProdDataGridViewTextBoxColumn";
            // 
            // testIDDataGridViewTextBoxColumn
            // 
            this.testIDDataGridViewTextBoxColumn.DataPropertyName = "TestID";
            this.testIDDataGridViewTextBoxColumn.HeaderText = "TestID";
            this.testIDDataGridViewTextBoxColumn.Name = "testIDDataGridViewTextBoxColumn";
            // 
            // appTestTableBindingSource
            // 
            this.appTestTableBindingSource.DataMember = "AppTestTable";
            this.appTestTableBindingSource.DataSource = this.dWControlDataSet;
            // 
            // dWControlDataSet
            // 
            this.dWControlDataSet.DataSetName = "DWControlDataSet";
            this.dWControlDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // appTestTableTableAdapter
            // 
            this.appTestTableTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.AppTestTableTableAdapter = this.appTestTableTableAdapter;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.UpdateOrder = WindowsFormsApplication1.DWControlDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.Location = new System.Drawing.Point(12, 539);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1343, 574);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appTestTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dWControlDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView1;
        private DWControlDataSet dWControlDataSet;
        private System.Windows.Forms.BindingSource appTestTableBindingSource;
        private DWControlDataSetTableAdapters.AppTestTableTableAdapter appTestTableTableAdapter;
        private DWControlDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewTextBoxColumn appIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn appNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn devUrlDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodUrlDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn queryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fieldTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kPINameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastDateTestedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn queryResultDevDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn queryResultProdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastTestPassedDevDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastTestPassedProdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateLastPassedDevDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateLastPassedProdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn testIDDataGridViewTextBoxColumn;
        private Button button1;
    }
}


