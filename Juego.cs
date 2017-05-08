﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoFinal
{
    interface iMetodos
    {
        void Atacar();
        void TerminarTurno();
        void Draw();
    }
    public class Jugador
    {
        public int vida;
        public int mana;
        public List<Cartas> mano;
        public List<Cartas> mazo;
        public string nombre;
        public string heroe;
        public Jugador(int vida, int mana, List<Cartas> mano, List<Cartas> mazo, string nombre, string heroe)
        {
            this.vida = vida;
            this.mana = mana;
            this.mano = mano;
            this.mazo = mazo;
            this.nombre = nombre;
            this.heroe = heroe;
        }
        public void ManaGrowth()
        {

        }



    }


    public class Cartas : iMetodos
    {
        int costo;
        int ataque;
        int vida;
        string nombre;
        Cartas carta;
        public Cartas(int costo, int ataque, int vida, string nombre)
        {
            this.costo = costo;
            this.ataque = ataque;
            this.vida = vida;
            this.nombre = nombre;
            new wisp() = Cartas(0, 1, 1, wisp);
            new murlocRider() = Cartas(1, 1, 2, murlocRider);
            new bloodfenRaptor() = Cartas(2, 3, 2, bloodfenRaptor);
            new riverCrocolisk() = Cartas(2, 2, 3, riverCrocolisk);
            new magmaRager() = Cartas(3, 5, 1, magmaRager);
            new chillwindYeti() = Cartas(4, 4, 5, chillwindYeti);
            new oasisSnapjaw() = Cartas(4, 2, 7, oasisSnapjaw);
            new boulderfistOgre() = Cartas(6, 6, 7, boulderfistOgre);
            new warGolem() = Cartas(7, 7, 7, warGolem);
            new coreHound() = Cartas(7, 9, 5, coreHound);
        }

        public void Atacar ()
        {
            // primero vemos a quien se ataca, si se ataca a carta o heroe
            // si se ataca a carta hacerlo directamente
            // si se ataca a heroe hacerlo a traves de la interfaz
        }
        public void TerminarTurno ()
        {

        }
        public void Draw ()
        {
            // sacar una carta al azar del mazo y ponerla en la mano al principio de cada turno.
        }
    }

    public class Tablero
    {
        public List<Cartas> TableroJugador1;
        public List<Cartas> TableroJugador2;
        public Jugador Jugador1;
        public Jugador Jugador2;
        
        public Tablero (List <Cartas> TableroJugador1, List <Cartas> TableroJugador2, Jugador Jugador1, Jugador Jugador2)
        {
            this.TableroJugador1 = TableroJugador1;
            this.TableroJugador2 = TableroJugador2;
            this.Jugador1 = Jugador1;
            this.Jugador2 = Jugador2;
        }

        public void JugarCartas (Jugador Jugador, List <Cartas> TableroJugador)
        {

        }



    }
    


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido a HearthStone, ingresen sus nombres: ");
            Console.ReadLine("");
        }
    }
}
