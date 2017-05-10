using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ProyectoFinal
{
    interface iMetodos
    {
        void Atacar();
        void TerminarTurno();
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
        public void TerminarTurno()
        {

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

    public class Tablero
    {
        public List<Cartas> TableroJugador1;
        public List<Cartas> TableroJugador2;
        public Jugador Jugador1;
        public Jugador Jugador2;

        public Tablero(List<Cartas> TableroJugador1, List<Cartas> TableroJugador2, Jugador Jugador1, Jugador Jugador2)
        {
            this.TableroJugador1 = TableroJugador1;
            this.TableroJugador2 = TableroJugador2;
            this.Jugador1 = Jugador1;
            this.Jugador2 = Jugador2;
        }

        public static void JugarCartas(Jugador Jugador, List<Cartas> TableroJugador)
        {

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
                    Jugador1.ManaGrowth();
                    bool condicionTurno = true;

                    while (condicionTurno)
                    {
                        Console.WriteLine("Turno de " + Jugador1.nombre);
                        Console.WriteLine("¿Que desea hacer?");
                        Console.WriteLine("(1) Jugar una carta de la mano");
                        Console.WriteLine("(2) Atacar");
                        Console.WriteLine("(3) Usar el poder");
                        Console.WriteLine("(4) Terminar el turno");
                        string decision1 = Console.ReadLine();

                        if (decision1 == "1")
                        {
                            for (int i = 0; i < Mano1.Count; i++)
                            {
                                Console.WriteLine("[" + i + "]" + Mano1[i]);
                            }
                            Console.WriteLine("Elija el numero de carta que desea jugar");
                            string numeroDeCarta = Console.ReadLine();
                            int numeroDeCarta1 = Int32.Parse(numeroDeCarta);
                            Tablero.JugarCartas(Jugador1, TableroJugador1);
                        }
                        else if (decision1 == "2")
                        {
                            for (int i = 0; i < TableroJugador1.Count; i++)
                            {
                                Console.WriteLine("[" + i + "]" + TableroJugador1[i]);
                            }
                            Console.WriteLine("Elija el numero de carta que desee que ataque");
                            string cartaElegida = Console.ReadLine();
                            int cartaElegida1 = Int32.Parse(cartaElegida);
                        }
                        else if (decision1 == "3")
                        {
                            //poder con interface y wea
                        }
                        else if (decision1 == "4")
                        {
                            condicionTurno = false;
                            turno = 1;
                        }
                    }




                }
                else if (turno == 1)
                {
                    Jugador2.ManaGrowth();
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
                            for (int i = 0; i < Mano2.Count; i++)
                            {
                                Console.WriteLine("[" + i + "]" + Mano2[i]);
                            }
                            Console.WriteLine("Elija el numero de carta que desea jugar");
                            string numeroDeCarta = Console.ReadLine();
                            int numeroDeCarta1 = Int32.Parse(numeroDeCarta);
                            Tablero.JugarCartas(Jugador2, TableroJugador2);
                        }
                        else if (decision2 == "2")
                        {
                            for (int i = 0; i < TableroJugador2.Count; i++)
                            {
                                Console.WriteLine("[" + i + "]" + TableroJugador2[i]);
                            }
                            Console.WriteLine("Elija el numero de carta que desee que ataque");
                            string cartaElegida = Console.ReadLine();
                            int cartaElegida1 = Int32.Parse(cartaElegida);
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
