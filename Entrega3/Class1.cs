using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Entrega3
{ 
    public interface INotifyPropertyChanged
    {
        event PropertyChangedEventHandler PropertyChanged;
    }

    public class Jugador: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        public int vida;
        public int mana;
        public List<Cartas> mano;
        public List<Cartas> mazo;
        public string nombre;
        public List<Cartas> tablero;
        internal int damage;
        internal int armadura;
        public string heroe;
        public Jugador(int armadura, int vida, int mana, List<Cartas> mano, List<Cartas> mazo, string nombre, List<Cartas> tablero, string heroe)
        {
            this.vida = vida;
            this.mana = mana;
            this.mano = mano;
            this.mazo = mazo;
            this.nombre = nombre;
            this.tablero = tablero;
            this.heroe = heroe;
            this.armadura = armadura;
        }
        public void ManaGrowth()
        {
            mana += 1;
            if (mana > 10)
            {
                mana = 10;
            }
        }
        public void JugarCartas(List<Cartas> mano, List<Cartas> tablero, int cartaAJugar, int mana)
        {
            if (mana >= mano[cartaAJugar].costo)
            {
                mana -= mano[cartaAJugar].costo;
                tablero.Add(mano[cartaAJugar]);
                mano.Remove(mano[cartaAJugar]);
            }
            else
            {
                Console.WriteLine("No tienes suficiente mana para jugar esta carta");
            }
        }
        public void AtacarCarta(List<Cartas> posiblesAtacantes, int cartaElegida, List<Cartas> tablero, int cartaTarget) // si se ataca a carta hacerlo directamente
        {
            tablero[cartaTarget].vida -= posiblesAtacantes[cartaElegida].ataque;
        }
        public void AtacarJugador(List<Cartas> posiblesAtacantes, int cartaElegida, Jugador jugador)
        {
            jugador.vida -= posiblesAtacantes[cartaElegida].ataque;
        }
        public void UsarPoder(Jugador JugadorPoder, Jugador JugadorOponente)
        {
            if (JugadorPoder.heroe == "Warrior" || JugadorPoder.heroe == "warrior")
            {
                if (JugadorPoder.mana > 2)
                {
                    JugadorPoder.mana -= 2;
                    JugadorPoder.armadura += 2;
                }
                else
                {
                    Console.WriteLine("No tienes suficiente mana para usar el poder");
                }

            }
            else if (JugadorPoder.heroe == "Hunter" || JugadorPoder.heroe == "hunter")
            {
                if (JugadorPoder.mana > 2)
                {
                    JugadorPoder.mana -= 2;
                    JugadorOponente.vida -= 2;
                }
                else
                {
                    Console.WriteLine("No tienes suficiente mana para usar el poder");
                }
            }
        }
    }
    public class Cartas : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        Random rnd = new Random();
        public List<Cartas> mano;
        public List<Cartas> mazo;
        public int costo;
        public int ataque;
        public int vida;
        public string nombre;

        public Cartas(int costo, int ataque, int vida, string nombre)
        {
            this.costo = costo;
            this.ataque = ataque;
            this.vida = vida;
            this.nombre = nombre;
        }
        public static void Draw(List<Cartas> Mano, List<Cartas> Mazo, int rara)
        {
            if (Mano.Count < 10)
            {
                Mano.Add(Mazo[rara]);
                Mazo.Remove(Mazo[rara]);
            }
            // sacar una carta al azar del mazo y ponerla en la mano al principio de cada turno.
        }
        public void crearMazo(List<Cartas> Monton, List<Cartas> Mazo)
        {
            int r = 0;
            while (mazo.Count <= 30)
            {
                r = +1;
                Mazo.Add(Monton[r]);
            }
        }
        public static void crearMano(Jugador Jugador1, Jugador Jugador2, int turno, Cartas theCoin)
        {
            Random rmd = new Random();
            if (turno == 0)
            {
                while (Jugador1.mano.Count < 3)
                {
                    int r = rmd.Next(Jugador1.mazo.Count);
                    Jugador1.mano.Add(Jugador1.mazo[r]);
                    Jugador1.mazo.Remove(Jugador1.mazo[r]);
                }
                while (Jugador2.mano.Count < 4)
                {
                    int r = rmd.Next(Jugador2.mazo.Count);
                    Jugador2.mano.Add(Jugador2.mazo[r]);
                    Jugador2.mazo.Remove(Jugador2.mazo[r]);
                }
                Jugador2.mano.Add(theCoin);
            }
            else if (turno == 1)
            {
                while (Jugador2.mano.Count < 3)
                {
                    int r = rmd.Next(Jugador2.mazo.Count);
                    Jugador2.mano.Add(Jugador2.mazo[r]);
                    Jugador2.mazo.Remove(Jugador2.mazo[r]);
                }
                while (Jugador1.mano.Count < 4)
                {
                    int r = rmd.Next(Jugador1.mazo.Count);
                    Jugador1.mano.Add(Jugador1.mazo[r]);
                    Jugador1.mazo.Remove(Jugador1.mazo[r]);
                }
                Jugador1.mano.Add(theCoin);

            }
        }
    }
}
