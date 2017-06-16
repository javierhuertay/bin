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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Entrega3
{

    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Cartas> listaCartas = new List<Cartas>();
        Cartas wisp = new Cartas(0, 1, 1, "wisp");
        Cartas murlocRaider = new Cartas(1, 1, 2, "Murloc Raider");
        Cartas bloodfenRaptor = new Cartas(2, 3, 2, "Bloodfen Raptor");
        Cartas riverCrocolisk = new Cartas(2, 2, 3, "River CrocoLisk");
        Cartas magmaRager = new Cartas(3, 5, 1, "Magma Rager");
        Cartas chillwindYeti = new Cartas(4, 4, 5, "Chill Wind Yeti");
        Cartas oasisSnapjaw = new Cartas(4, 2, 7, "Oasis Snap Jaw");
        Cartas boulderfistOgre = new Cartas(6, 6, 7, "Boulder Fist Ogre");
        Cartas warGolem = new Cartas(7, 7, 7, "War Golem");
        Cartas coreHound = new Cartas(7, 9, 5, "Core Hound");
        Cartas theCoin = new Cartas(0, 0, 0, "the coin");
        public MainWindow()
        {
            InitializeComponent();
        }

        private void comenzar (string NombreJugador1, string NombreJugador2, string HeroeJugador1, string HeroeJugador2)
        {
            listaCartas.Add(wisp);
            listaCartas.Add(wisp);
            listaCartas.Add(wisp);
            listaCartas.Add(murlocRaider);
            listaCartas.Add(murlocRaider);
            listaCartas.Add(murlocRaider);
            listaCartas.Add(bloodfenRaptor);
            listaCartas.Add(bloodfenRaptor);
            listaCartas.Add(bloodfenRaptor);
            listaCartas.Add(riverCrocolisk);
            listaCartas.Add(riverCrocolisk);
            listaCartas.Add(riverCrocolisk);
            listaCartas.Add(magmaRager);
            listaCartas.Add(magmaRager);
            listaCartas.Add(magmaRager);
            listaCartas.Add(chillwindYeti);
            listaCartas.Add(chillwindYeti);
            listaCartas.Add(chillwindYeti);
            listaCartas.Add(oasisSnapjaw);
            listaCartas.Add(oasisSnapjaw);
            listaCartas.Add(oasisSnapjaw);
            listaCartas.Add(boulderfistOgre);
            listaCartas.Add(boulderfistOgre);
            listaCartas.Add(boulderfistOgre);
            listaCartas.Add(warGolem);
            listaCartas.Add(warGolem);
            listaCartas.Add(warGolem);
            listaCartas.Add(coreHound);
            listaCartas.Add(coreHound);
            listaCartas.Add(coreHound);

            List<Cartas> Mazo1 = listaCartas;
            List<Cartas> Mazo2 = listaCartas;
            List<Cartas> Mano1 = new List<Cartas>();
            List<Cartas> Mano2 = new List<Cartas>();
            List<Cartas> TableroJugador1 = new List<Cartas>();
            List<Cartas> TableroJugador2 = new List<Cartas>();
            Jugador Jugador1 = new Jugador(0, 30, 0, Mano1, Mazo1, NombreJugador1, TableroJugador1, HeroeJugador1);
            Jugador Jugador2 = new Jugador(0, 30, 0, Mano2, Mazo2, NombreJugador2, TableroJugador2, HeroeJugador2);
        }

        private void Boton1_Click(object sender, RoutedEventArgs e)
        {
            if ((TextBoxHeroe1.Text != "Druid") && (TextBoxHeroe1.Text != "Hunter") && (TextBoxHeroe1.Text != "Mage") && (TextBoxHeroe1.Text != "Paladin") && (TextBoxHeroe1.Text != "Priest") && (TextBoxHeroe1.Text != "Rogue") && (TextBoxHeroe1.Text != "Shaman") && (TextBoxHeroe1.Text != "Warlock") && (TextBoxHeroe1.Text != "Warrior") && (TextBoxHeroe1.Text != "druid") && (TextBoxHeroe1.Text != "hunter") && (TextBoxHeroe1.Text != "mage") && (TextBoxHeroe1.Text != "paladin") && (TextBoxHeroe1.Text != "priest") && (TextBoxHeroe1.Text != "rogue") && (TextBoxHeroe1.Text != "shaman") && (TextBoxHeroe1.Text != "warlock") && (TextBoxHeroe1.Text != "warrior"))
            {
                if ((TextBoxHeroe2.Text != "Druid") && (TextBoxHeroe2.Text != "Hunter") && (TextBoxHeroe2.Text != "Mage") && (TextBoxHeroe2.Text != "Paladin") && (TextBoxHeroe2.Text != "Priest") && (TextBoxHeroe2.Text != "Rogue") && (TextBoxHeroe2.Text != "Shaman") && (TextBoxHeroe2.Text != "Warlock") && (TextBoxHeroe2.Text != "Warrior") && (TextBoxHeroe2.Text != "druid") && (TextBoxHeroe2.Text != "hunter") && (TextBoxHeroe2.Text != "mage") && (TextBoxHeroe2.Text != "paladin") && (TextBoxHeroe2.Text != "priest") && (TextBoxHeroe2.Text != "rogue") && (TextBoxHeroe2.Text != "shaman") && (TextBoxHeroe2.Text != "warlock") && (TextBoxHeroe2.Text != "warrior"))
                {
                    Advertencia1.Visibility = System.Windows.Visibility.Visible;
                    Advertencia2.Visibility = System.Windows.Visibility.Visible;
                }

                else
                {
                    Advertencia1.Visibility = System.Windows.Visibility.Visible;
                }
            }

            else if ((TextBoxHeroe2.Text != "Druid") && (TextBoxHeroe2.Text != "Hunter") && (TextBoxHeroe2.Text != "Mage") && (TextBoxHeroe2.Text != "Paladin") && (TextBoxHeroe2.Text != "Priest") && (TextBoxHeroe2.Text != "Rogue") && (TextBoxHeroe2.Text != "Shaman") && (TextBoxHeroe2.Text != "Warlock") && (TextBoxHeroe2.Text != "Warrior") && (TextBoxHeroe2.Text != "druid") && (TextBoxHeroe2.Text != "hunter") && (TextBoxHeroe2.Text != "mage") && (TextBoxHeroe2.Text != "paladin") && (TextBoxHeroe2.Text != "priest") && (TextBoxHeroe2.Text != "rogue") && (TextBoxHeroe2.Text != "shaman") && (TextBoxHeroe2.Text != "warlock") && (TextBoxHeroe2.Text != "warrior"))
            {
                if ((TextBoxHeroe1.Text != "Druid") && (TextBoxHeroe1.Text != "Hunter") && (TextBoxHeroe1.Text != "Mage") && (TextBoxHeroe1.Text != "Paladin") && (TextBoxHeroe1.Text != "Priest") && (TextBoxHeroe1.Text != "Rogue") && (TextBoxHeroe1.Text != "Shaman") && (TextBoxHeroe1.Text != "Warlock") && (TextBoxHeroe1.Text != "Warrior") && (TextBoxHeroe1.Text != "druid") && (TextBoxHeroe1.Text != "hunter") && (TextBoxHeroe1.Text != "mage") && (TextBoxHeroe1.Text != "paladin") && (TextBoxHeroe1.Text != "priest") && (TextBoxHeroe1.Text != "rogue") && (TextBoxHeroe1.Text != "shaman") && (TextBoxHeroe1.Text != "warlock") && (TextBoxHeroe1.Text != "warrior"))
                {
                    Advertencia1.Visibility = System.Windows.Visibility.Visible;
                    Advertencia2.Visibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    Advertencia2.Visibility = System.Windows.Visibility.Visible;
                }
            }
            else
            {
                comenzar(TextBoxJugador1.Text, TextBoxJugador2.Text, TextBoxHeroe1.Text, TextBoxHeroe2.Text);
                Tablero tablero = new Tablero();
                tablero.Show();
                this.Close();
            }
        }

        private void TextBoxHeroe2_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
