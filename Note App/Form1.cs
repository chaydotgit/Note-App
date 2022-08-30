using System.Data;

namespace Note_App
{
    public partial class Form1 : Form
    {
        DataTable table;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            table = new DataTable();
            table.Columns.Add("Title", typeof(String));
            table.Columns.Add("Notes", typeof(String));

            dataGridView1.DataSource = table;

            dataGridView1.Columns["Notes"].Visible = false;
            dataGridView1.Columns["Title"].Width = 170;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btNew_Click(object sender, EventArgs e)
        {
            txtTitle.Clear();
            txtNote.Clear();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            table.Rows.Add(txtTitle.Text, txtNote.Text);

            txtTitle.Clear();
            txtNote.Clear();
        }

        private void btRead_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;

            if (index > -1)
            {
                txtTitle.Text = table.Rows[index].ItemArray[0].ToString();
                txtNote.Text = table.Rows[index].ItemArray[1].ToString();
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;

            table.Rows[index].Delete();
            txtTitle.Clear();
            txtNote.Clear();
        }
    }
}