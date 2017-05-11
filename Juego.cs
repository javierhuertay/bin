using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ProyectoFinal
{
    interface iMetodos
    {
        void Atacar();
        void Draw(List <Cartas> a, List <Cartas> b);
    }

    class Hunter
    {
        int costo;
        string nombre;
        int damage;
        void hunter(int costo, string nombre, int damage)
        {
            this.costo = 2;
            this.nombre = nombre;
            this.damage = 2;
        }
    }
    class Warrior
    {
        int costo;
        string nombre;
        int armadura;
        void warrior(int costo, string nombre, int armadura)
        {
            this.costo = 2;
            this.nombre = nombre;
            armadura += 2;
        }

    }
    public class Jugador
    {

        public int vida;
        public int mana;
        public List<Cartas> mano;
        public List<Cartas> mazo;
        public string nombre;
        public string heroe;
        public List<Cartas> tablero;
        public Jugador(int vida, int mana, List<Cartas> mano, List<Cartas> mazo, string nombre, string heroe, List <Cartas> tablero)
        {
            this.vida = vida;
            this.mana = mana;
            this.mano = mano;
            this.mazo = mazo;
            this.nombre = nombre;
            this.heroe = heroe;
            this.tablero = tablero;
        }
        public void ManaGrowth()
        {
            mana += 1;
            if (mana > 10)
            {
                mana = 10;
            }
        }
        public void JugarCartas (List <Cartas> mano,List <Cartas> tablero, int cartaAJugar)
        {
            tablero.Add(mano[cartaAJugar]);
            mano.Remove(mano[cartaAJugar]);
        }

    }


    public class Cartas : iMetodos
    {
        Random rnd = new Random();
        public List<Cartas> mano;
        public List<Cartas> mazo;
        int costo;
        int ataque;
        int vida;
        string nombre;
        Cartas carta;
        Cartas wisp;
        Cartas murlocRaider;
        Cartas bloodfenRaptor;
        Cartas riverCrocolisk;
        Cartas magmaRager;
        Cartas chillwindYeti;
        Cartas oasisSnapjaw;
        Cartas boulderfistOgre;
        Cartas warGolem;
        Cartas coreHound;
        List<Cartas> listaCartas = new List<Cartas>();

        public Cartas(int costo, int ataque, int vida)
        {
            this.costo = costo;
            this.ataque = ataque;
            this.vida = vida;
            wisp = new Cartas(0, 1, 1);
            murlocRaider = new Cartas(1, 1, 2);
            bloodfenRaptor = new Cartas(2, 3, 2);
            riverCrocolisk = new Cartas(2, 2, 3);
            magmaRager = new Cartas(3, 5, 1);
            chillwindYeti = new Cartas(4, 4, 5);
            oasisSnapjaw = new Cartas(4, 2, 7);
            boulderfistOgre = new Cartas(6, 6, 7);
            warGolem = new Cartas(7, 7, 7);
            coreHound = new Cartas(7, 9, 5);
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
        }

        public void Atacar()
        {
            // primero vemos a quien se ataca, si se ataca a carta o heroe
            // si se ataca a carta hacerlo directamente
            // si se ataca a heroe hacerlo a traves de la interfaz
        }
        
        public void Draw(List <Cartas> Mano, List <Cartas> Mazo)
        {
            int r = rnd.Next(listaCartas.Count);
            if (Mano.Count < 10)
            {
                Mano.Add(listaCartas[r]);
            }
            // sacar una carta al azar del mazo y ponerla en la mano al principio de cada turno.
        }
        public void crearMazo()
        {
            while (mazo.Count <= 30)
            {
                int r = rnd.Next(listaCartas.Count);
                mazo.Add(listaCartas[r]);
            }
        }
        public void crearMano(List <Cartas> Mano, List <Cartas> Mazo)
        {
            if (Mano.Count <= 10)
            {
                int r = rnd.Next(listaCartas.Count);
                Mano.Add(Mazo[r]);
            }

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido a HearthStone, ingresen sus nombres: ");
            Console.WriteLine("Jugador 1:");
            string name1 = Console.ReadLine();

            Console.WriteLine("Jugador 2:");
            string name2 = Console.ReadLine();

            Console.WriteLine(name1 + ", ¿Seras Hunter o Warrior?");
            string heroe1 = Console.ReadLine();

            Console.WriteLine(name2 + ", ¿Seras Hunter o Warrior?");
            string heroe2 = Console.ReadLine();

            List<Cartas> Mazo1 = new List<Cartas>();
            List<Cartas> Mazo2 = new List<Cartas>();

            List<Cartas> Mano1 = new List<Cartas>();
            List<Cartas> Mano2 = new List<Cartas>();

            List<Cartas> TableroJugador1 = new List<Cartas>();
            List<Cartas> TableroJugador2 = new List<Cartas>();

            Jugador Jugador1 = new Jugador(30, 0, Mano1, Mazo1, name1, heroe1, TableroJugador1);
            Jugador Jugador2 = new Jugador(30, 0, Mano2, Mazo2, name2, heroe2, TableroJugador2);

            Console.WriteLine("Comienza el juego");
            bool condicionJuego = true;
            
            Random rmd = new Random();
            int turno = rmd.Next(0, 2);

            while (condicionJuego)
            {
                if (turno == 0)
                {
                    Jugador1.ManaGrowth(); //Jugador gana 1 de mana al comienzo del turno.
                    bool condicionTurno = true; //Para mantenerse en el menu.
                    List<Cartas> posibleAtacantes = Jugador1.mano; //Asi la misma carta no puede atacar dos veces.

                    while (condicionTurno)
                    {
                        Console.WriteLine("Turno de " + Jugador1.nombre);
                        Console.WriteLine("¿Que desea hacer?");
                        Console.WriteLine("(1) Jugar una carta de la mano");
                        Console.WriteLine("(2) Atacar");
                        Console.WriteLine("(3) Usar el poder");
                        Console.WriteLine("(4) Terminar el turno");
                        string decision1 = Console.ReadLine(); //Que es lo que hara el jugador.

                        if (decision1 == "1") //Jugar una carta
                        {
                            for (int i = 0; i < Jugador1.mano.Count; i++)
                            {
                                Console.WriteLine("[" + i + "]" + Jugador1.mano[i]); //Mostramos lo que tenemos en la mano
                            }
                            Console.WriteLine("Elija el numero de carta que desea jugar");
                            string numeroDeCarta = Console.ReadLine();//Numero de carta que quiere jugar, parte desde el 0
                            int numeroDeCarta1 = Int32.Parse(numeroDeCarta);//Numero a int
                            Jugador1.JugarCartas(Jugador1.mano, Jugador1.tablero,numeroDeCarta1);//Se juega la carta, se agrega al tablero y se borra de la mano
                        }
                        else if (decision1 == "2") //Atacar con una creatura
                        {
                            for (int i = 0; i < posibleAtacantes.Count; i++)
                            {
                                Console.WriteLine("[" + i + "]" + posibleAtacantes[i]);
                            }
                            Console.WriteLine("Elija el numero de carta que desee que ataque");
                            string cartaElegida = Console.ReadLine();
                            int cartaElegida1 = Int32.Parse(cartaElegida);
                        }
                        else if (decision1 == "3") //Poder del guerrero.
                        {
                            //poder con interface y wea
                        }
                        else if (decision1 == "4")//Terminar Turno
                        {
                            condicionTurno = false;
                            turno = 1;
                        }
                    }
                }
                else if (turno == 1)
                {
                    Jugador2.ManaGrowth(); //Jugador gana 1 de mana al comienzo del turno
                    bool condicionTurno = true;

                    while (condicionTurno)
                    {
                        Console.WriteLine("Turno de " + Jugador2.nombre);
                        Console.WriteLine("¿Que desea hacer?");
                        Console.WriteLine("(1) Jugar una carta de la mano");
                        Console.WriteLine("(2) Atacar");
                        Console.WriteLine("(3) Usar el poder");
                        Console.WriteLine("(4) Terminar el turno");
                        string decision2 = Console.ReadLine();

                        if (decision2 == "1")
                        {
                            for (int i = 0; i < Jugador2.mano.Count; i++)
                            {
                                Console.WriteLine("[" + i + "]" + Jugador2.mano[i]);
                            }
                            Console.WriteLine("Elija el numero de carta que desea jugar");
                            string numeroDeCarta2 = Console.ReadLine();
                            int numeroDeCartaInt2 = Int32.Parse(numeroDeCarta2);
                            Jugador2.JugarCartas(Jugador2.mano, Jugador2.tablero, numeroDeCartaInt2);
                        }
                        else if (decision2 == "2")
                        {
                            for (int i = 0; i < Jugador2.tablero.Count; i++)
                            {
                                Console.WriteLine("[" + i + "]" + Jugador2.tablero[i]);
                            }
                            Console.WriteLine("Elija el numero de carta que desee que ataque");
                            string cartaElegida = Console.ReadLine();
                            int cartaElegidaInt = Int32.Parse(cartaElegida);
                        }
                        else if (decision2 == "3")
                        {
                            //poder con interface y wea
                        }
                        else if (decision2 == "4")
                        {
                            condicionTurno = false;
                            turno = 0;
                        }
                    }




                }
            }
        }
    }
}