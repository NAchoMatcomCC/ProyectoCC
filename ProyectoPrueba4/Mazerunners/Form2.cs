using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mazerunners
{
    public partial class SeleccionPersonajes : Form
    {
        private int[] personajes_seleccionados = new int[2];
        public SeleccionPersonajes()
        {
            InitializeComponent();
        }

        private void SeleccionPersonajes_Load(object sender, EventArgs e)
        {
            // Crear listas de personajes para cada combobox
            string[] personajes1 = { "Goku", "Freezer", "Vegeta", "Krilin", "Jiren", "Gohan", "Androide 18", "Piccolo", "Trunks", "Cell" };
            string[] personajes2 = { "Goku", "Freezer", "Vegeta", "Krilin", "Jiren", "Gohan", "Androide 18", "Piccolo", "Trunks", "Cell" };

            // Inicializar combobox1 con personajes1
            comboBox1.DataSource = personajes1;

            // Inicializar combobox2 con personajes2
            comboBox2.DataSource = personajes2;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {

            // Aquí irá el código para confirmar la selección de personajes

            string[] personajes = { "Goku", "Freezer", "Vegeta", "Krilin", "Jiren", "Gohan", "Androide 18", "Piccolo", "Trunks", "Cell" };

            personajes_seleccionados[0] = Array.IndexOf(personajes, comboBox1.SelectedItem.ToString()) + 1;
            personajes_seleccionados[1] = Array.IndexOf(personajes, comboBox2.SelectedItem.ToString()) + 1;

            // Aquí puedes agregar el código para cerrar el formulario y regresar al formulario anterior

            Form1 juego=new Form1(personajes_seleccionados);
            this.Visible=false;
            juego.ShowDialog();
            this.Close();

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            // Aquí irá el código para regresar al formulario anterior
            this.Close();
        }
    }
}
