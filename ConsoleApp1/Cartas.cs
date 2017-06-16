using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Cartas
    {
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
        public void TheCoin(Jugador JugadorMoneda, Cartas theCoin)
        {
            if 
        }

    }
}
