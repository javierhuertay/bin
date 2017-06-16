using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Entrega3
{
    /// <summary>
    /// Lógica de interacción para Tablero.xaml
    /// </summary>
    public partial class Tablero : Window
    {
        public Jugador Jugador1
        {
            get
            {
                return this.Jugador1;
            }

            set
            {
                this.Jugador1 = value;
            }
        }

        public Tablero(Jugador Jugador1)
        {
            this.Jugador1 = Jugador1;
            InitializeComponent();
        }

        

        public void TableroJugador1 (Jugador Jugador1)
        {
            NombreJugadorShow.Content = Jugador1.nombre;
            VidaJugador.Content = Jugador1.vida;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TableroJugador1(Jugador1);
        }
    }
}
