using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Mazerunners
{
    public partial class FormMenu : Form
    {
        private SoundPlayer sonido;
        public FormMenu()
        {
            InitializeComponent();

            sonido = new SoundPlayer("sonido/itsgoingdownnow.wav");
            sonido.PlayLooping();

        }

        private void btnJugar_Click(object sender, EventArgs e)
        {
            SeleccionPersonajes seleccion=new SeleccionPersonajes();

            this.Visible=false;
            seleccion.ShowDialog();
            this.Visible=true;
        }

        private void btnInstrucciones_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Controles: \n" +
                            "W: Arriba \n" +
                            "A: Izquierda \n" +
                            "S: Abajo \n" +
                            "D: Derecha \n" +
                            "Objetivo: Recoger las esferas del dragón y llegar a la salida.");
        }

        private void btnHabilidades_Click(object sender, EventArgs e)
        {
            // Aquí irá el código para mostrar las habilidades de cada personaje
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        
    }
}
