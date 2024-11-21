using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmpleadosCrud
{
    public partial class FrmEmpleados : Form
    {
        public FrmEmpleados()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Empleado empleado = new Empleado();
            empleado.nombre = txtNombre.Text;
            empleado.edad = Convert.ToInt32 (txtEdad.Text);
            empleado.cargo = txtCargo.Text;

            int result = EmpleadoAG.agregarEmpleado(empleado);
            if (result > 0)
            {
                MessageBox.Show("Empleado cargado existosamente");
            }
            else
            {
                MessageBox.Show("Error al cargar empleado");
            }
            recargarRegistro();
        }

        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            recargarRegistro();
            txtId.Enabled = false; 
        }

        public void recargarRegistro()
        {
            dataGridView1.DataSource = EmpleadoAG.MostrarEmpleados();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            txtId.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["id"].Value);
            txtNombre.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["nombre"].Value);
            txtEdad.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["edad"].Value);
            txtCargo.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["cargo"].Value);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count == 1) { 
            }
            try
            {
                
                int id = int.Parse(txtId.Text); 
                string nombre = txtNombre.Text; 
                int edad = int.Parse(txtEdad.Text); 
                string cargo = txtCargo.Text; 

                Empleado empleado = new Empleado
                {
                    id = id,
                    nombre = nombre,
                    edad = edad,
                    cargo = cargo
                };

                
                int resultado = EmpleadoAG.modificarEmpleado(empleado);

             
                if (resultado > 0)
                {
                    MessageBox.Show("Empleado modificado exitosamente.");
                }
                else
                {
                    MessageBox.Show("No se pudo modificar el empleado. Verifica el ID.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}");
            }
            recargarRegistro();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtId.Clear();
            txtNombre.Clear(); 
            txtCargo.Clear();
            txtEdad.Clear();
            dataGridView1.CurrentCell = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                var currentRow = dataGridView1.CurrentRow;
                if (currentRow != null && currentRow.Cells["id"].Value != null)
                {
                    int id = Convert.ToInt32(currentRow.Cells["id"].Value);
                    int elm = EmpleadoAG.BorrarEmpleado(id);
                    if (elm > 0)
                    {
                        MessageBox.Show("Empleado eliminado correctamente");
                    }
                    else
                    {
                        MessageBox.Show("Error al intentar eliminar");
                    }
                    recargarRegistro(); 
                }
                else
                {
                    MessageBox.Show("No se pudo obtener el ID del empleado.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una fila.");
            }
        }
    }
}
