using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
namespace VentasOficial
{
    public partial class PSucursal : Form
    {
        public PSucursal()
        {
            InitializeComponent();
        } 
        private void button1_Click(object sender, EventArgs e)
        {
            NSucursal.InsertarSucursal(this.textBox1.Text.Trim(), this.textBox2.Text.Trim(), Convert.ToInt32(textBox3.Text),Convert.ToBoolean(checkBox1.Checked));
            MessageBox.Show("Guardado Correctamente");
        }

        private void PSucursal_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'ventasDataSet2.sp_listarsucursal' Puede moverla o quitarla según sea necesario.
            this.sp_listarsucursalTableAdapter.Fill(this.ventasDataSet2.sp_listarsucursal);
        }
        private int id;
        private DataTable tabla;
         private void Mostrar()
         {
            tabla = NSucursal.Mostrar();
            this.dataGridView1.DataSource = tabla;
            //this.OcultarColumnas();
            //lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
         }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                MessageBox.Show("Emboque mejor el mouse en la fila");
                return;
            }
            else
            {
                id = tabla.Rows[e.RowIndex].Field<int>(0);
                textBox1.Text = tabla.Rows[e.RowIndex].Field<string>(1);
                textBox2.Text = tabla.Rows[e.RowIndex].Field<string>(2);
                textBox3.Text = tabla.Rows[e.RowIndex].Field<int>(3).ToString();
                if (checkBox1.Checked == true)
                {
                    checkBox1.Checked = tabla.Rows[e.RowIndex].Field<bool>(4);
                }
                else
                {
                    checkBox1.Checked = tabla.Rows[e.RowIndex].Field<bool>(4);
                }
                Mostrar();
            }
        }
    }
}
