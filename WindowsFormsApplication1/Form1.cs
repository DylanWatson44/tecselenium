using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //sqltest mytest = new sqltest();
            //dataGridView1.AutoGenerateColumns = true;
            //dataGridView1.DataSource = (BindingSource)mytest.getBindingSource();

            //label1.Text = "I got to here";
            this.Size = new Size(1800, 800);
            this.CenterToScreen();
            button1.Anchor = (AnchorStyles.Left | AnchorStyles.Bottom);
            //button1.Click += RefreshGrid(this.button1.Click);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dWControlDataSet.AppTestTable' table. You can move, or remove it, as needed.
            this.appTestTableTableAdapter.Fill(this.dWControlDataSet.AppTestTable);
            
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if(row.Index%2 == 0){
                    for(int j = 0;j< dataGridView1.ColumnCount; j++)
                    {
                        row.Cells[j].Style.BackColor = Color.GhostWhite;
                    }
                    
                }
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                   
                    if (row.Cells[i].Value is string) { 
                    if ((string)row.Cells[i].Value == "False")
                    {
                        row.Cells[i].Style.BackColor = Color.Red;
                    }
                }

            }
        }
            dataGridView1.Size = new Size(this.Width * 9 / 10, this.Height * 5 / 10);
            dataGridView1.SetBounds(this.Width / 40, this.Height / 20, dataGridView1.Width, dataGridView1.Height);
            dataGridView1.Refresh();
            
        }
        
}
}
