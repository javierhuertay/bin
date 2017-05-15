using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ProyectoFinal
{
    interface IHeroe
    {
        void UsarPoder();
    }
    public class Jugador
    {

        public int vida;
        public int mana;
        public List<Cartas> mano;
        public List<Cartas> mazo;
        public string nombre;
        public List<Cartas> tablero;
        public Jugador(int vida, int mana, List<Cartas> mano, List<Cartas> mazo, string nombre, List<Cartas> tablero)
        {
            this.vida = vida;
            this.mana = mana;
            this.mano = mano;
            this.mazo = mazo;
            this.nombre = nombre;
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
        public void JugarCartas(List<Cartas> mano, List<Cartas> tablero, int cartaAJugar, int mana)
        {
            if (mana >= tablero[cartaAJugar].costo)
            {
                mana -= tablero[cartaAJugar].costo;
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
    }
    class Hunter : Jugador, IHeroe
    {
        int costo;
        int damage;
        public Hunter(int costo, int damage) : base(vida, mana, mano, mazo, nombre, tablero)
        {
            this.costo = 2;
            this.damage = 2;
        }
        public void UsarPoder() 
        {
            JugadorPoder.mana -= 2;
            JugadorOponente.vida -= JugadorPoder.damage;
        }
    }
    class Warrior : Jugador, IHeroe
    {
        int costo;
        int armadura;
        public Warrior(int costo, int armadura) : base(vida, mana, mano, mazo, nombre, tablero)
        {
            this.costo = 2;
            this.armadura = 0;
        }
        public void UsarPoder()
        {
            JugadorPoder.mana -= 2;
            JugadorPoder.armadura = 2;
        }
    }
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
        public void Draw(List<Cartas> Mano, List<Cartas> Mazo, List<Cartas> Monton)
        {
            int r = rnd.Next(Monton.Count);
            if (Mano.Count < 10)
            {
                Mano.Add(Monton[r]);
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
        public void crearMano(List<Cartas> Mano, List<Cartas> Mazo)
        {
            while (Mano.Count <= 3)
            {
                int r = rnd.Next(Mazo.Count);
                Mano.Add(Mazo[r]);
                Mazo.Remove(Mazo[r]);
            }
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            bool ResumenCartas = true;
            List<Cartas> listaCartas = new List<Cartas>();
            if (ResumenCartas)
            {
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

            Console.WriteLine("Bienvenido a HearthStone, ingresen sus nombres: ");
            Console.WriteLine("Jugador 1:");
            string name1 = Console.ReadLine();

            Console.WriteLine("Jugador 2:");
            string name2 = Console.ReadLine();

            Console.WriteLine(name1 + ", ¿Seras Hunter o Warrior?");
            string heroe1 = Console.ReadLine();
            Console.WriteLine(name2 + ", ¿Seras Hunter o Warrior?");
            string heroe2 = Console.ReadLine();

            List<Cartas> Mazo1 = listaCartas;
            List<Cartas> Mazo2 = listaCartas;

            List<Cartas> Mano1 = new List<Cartas>();
            List<Cartas> Mano2 = new List<Cartas>();

            List<Cartas> TableroJugador1 = new List<Cartas>();
            List<Cartas> TableroJugador2 = new List<Cartas>();

            if (heroe1 == "Hunter")
            {
                Hunter Jugador1 = new Hunter(30, 0, Mano1, Mazo1, name1, TableroJugador1);
            }
            else if (heroe1 == "hunter")
            {
                Hunter Jugador1 = new Hunter(30, 0, Mano1, Mazo1, name1, TableroJugador1);
            }
            else if (heroe1 == "Warrior")
            {
                Warrior Jugador1 = new Warrior(30, 0, Mano1, Mazo1, name1, TableroJugador1);
            }
            else if (heroe1 == "warrior")
            {
                Warrior Jugador1 = new Warrior(30, 0, Mano1, Mazo1, name1, TableroJugador1);
            }
            else if (heroe2 == "Hunter")
            {
                Hunter Jugador2 = new Hunter(30, 0, Mano2, Mazo2, name2, TableroJugador2);
            }
            else if (heroe2 == "hunter")
            {
                Hunter Jugador2 = new Hunter(30, 0, Mano2, Mazo2, name2, TableroJugador2);
            }
            else if (heroe2 == "Warrior")
            {
                Warrior Jugador2 = new Warrior(30, 0, Mano2, Mazo2, name2, TableroJugador2);

            }
            else if (heroe2 == "Warrior")
            {
                Warrior Jugador2 = new Warrior(30, 0, Mano2, Mazo2, name2, TableroJugador2);
            }
            else if (heroe2 == "warrior")
            {
                Warrior Jugador2 = new Warrior(30, 0, Mano2, Mazo2, name2, TableroJugador2);

            }
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
                    List<Cartas> posiblesAtacantes1 = Jugador1.mano; //Asi la misma carta no puede atacar dos veces.
                    int manaTurno = Jugador1.mana; //Mana a la que se le puede restar, si no partiria de 0 practicamente todas las rondas.
                    Console.WriteLine("Turno de " + Jugador1.nombre);
                    while (condicionTurno)
                    {
                        Console.WriteLine(Jugador1.nombre + " tienes " + Jugador1.mana + " puntos de mana.");
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
                            string numeroDeCartaString1 = Console.ReadLine();//Numero de carta que quiere jugar, parte desde el 0
                            int numeroDeCartaInt1 = Int32.Parse(numeroDeCartaString1);//Numero a int
                            Jugador1.JugarCartas(Jugador1.mano, Jugador1.tablero, numeroDeCartaInt1, Jugador1.tablero[numeroDeCartaInt1].costo);//Se juega la carta, se agrega al tablero y se borra de la mano
                        }
                        else if (decision1 == "2") //Atacar con una creatura
                        {
                            for (int i = 0; i < posiblesAtacantes1.Count; i++)
                            {
                                Console.WriteLine("[" + i + "]" + posiblesAtacantes1[i]);
                            }
                            Console.WriteLine("Elija el numero de carta que desee que ataque");
                            string cartaElegidaString1 = Console.ReadLine();
                            int cartaElegidaInt1 = Int32.Parse(cartaElegidaString1); // Hasta aca se tiene la carta que va a atacar, falta decidir a quien se va a atacar

                            Console.WriteLine("A quien desea a atacar"); // primero vemos a quien se ataca, si se ataca a carta o a Jugador
                            Console.WriteLine("(1) Jugador oponente");
                            Console.WriteLine("(2) Alguna carta del oponente");
                            string target1 = Console.ReadLine();
                            int target = Int32.Parse(target1);

                            if (target == 1)
                            {
                                Jugador1.AtacarJugador(posiblesAtacantes1, cartaElegidaInt1, Jugador2);
                            }
                            else if (target == 2)
                            {
                                Console.WriteLine("indique a cual carta del oponente desea atacar");
                                for (int i = 0; i < Jugador1.tablero.Count; i++)
                                {
                                    Console.WriteLine("[" + i + "]" + Jugador1.tablero[i]);
                                }
                                string numeroDeTarget1 = Console.ReadLine();
                                int numeroDeTargetInt1 = Int32.Parse(numeroDeTarget1);
                                Jugador1.AtacarCarta(posiblesAtacantes1, cartaElegidaInt1, Jugador2.tablero, numeroDeTargetInt1);
                            }
                        }
                        else if (decision1 == "3") //Poder del guerrero.
                        {
                            Jugador1.UsarPoder(Jugador1, Jugador2);
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
                    Jugador2.ManaGrowth(); //Jugador gana 1 de mana al comienzo del turno.
                    bool condicionTurno = true; //Para mantenerse en el menu.
                    List<Cartas> posiblesAtacantes2 = Jugador2.mano; //Asi la misma carta no puede atacar dos veces.
                    int manaTurno = Jugador2.mana; //Mana a la que se le puede restar, si no partiria de 0 practicamente todas las rondas.
                    Console.WriteLine("Turno de " + Jugador2.nombre);
                    while (condicionTurno)
                    {
                        Console.WriteLine(Jugador2.nombre + " tienes " + Jugador2.mana + " puntos de mana.");
                        Console.WriteLine("¿Que desea hacer?");
                        Console.WriteLine("(1) Jugar una carta de la mano");
                        Console.WriteLine("(2) Atacar");
                        Console.WriteLine("(3) Usar el poder");
                        Console.WriteLine("(4) Terminar el turno");
                        string decision2 = Console.ReadLine(); //Que es lo que hara el jugador.

                        if (decision2 == "1") //Jugar una carta
                        {
                            for (int i = 0; i < Jugador2.mano.Count; i++)
                            {
                                Console.WriteLine("[" + i + "]" + Jugador2.mano[i]); //Mostramos lo que tenemos en la mano
                            }
                            Console.WriteLine("Elija el numero de carta que desea jugar");
                            string numeroDeCartaString2 = Console.ReadLine();//Numero de carta que quiere jugar, parte desde el 0
                            int numeroDeCartaInt2 = Int32.Parse(numeroDeCartaString2);//Numero a int
                            Jugador2.JugarCartas(Jugador2.mano, Jugador2.tablero, numeroDeCartaInt2, Jugador2.tablero[numeroDeCartaInt2].costo);//Se juega la carta, se agrega al tablero y se borra de la mano
                        }
                        else if (decision2 == "2") //Atacar con una creatura
                        {
                            for (int i = 0; i < posiblesAtacantes2.Count; i++)
                            {
                                Console.WriteLine("[" + i + "]" + posiblesAtacantes2[i]);
                            }
                            Console.WriteLine("Elija el numero de carta que desee que ataque");
                            string cartaElegidaString2 = Console.ReadLine();
                            int cartaElegidaInt2 = Int32.Parse(cartaElegidaString2); // Hasta aca se tiene la carta que va a atacar, falta decidir a quien se va a atacar

                            Console.WriteLine("A quien desea a atacar"); // primero vemos a quien se ataca, si se ataca a carta o a Jugador
                            Console.WriteLine("(1) Jugador oponente");
                            Console.WriteLine("(2) Alguna carta del oponente");
                            string target2 = Console.ReadLine();
                            int target = Int32.Parse(target2);

                            if (target == 1)
                            {
                                Jugador1.AtacarJugador(posiblesAtacantes2, cartaElegidaInt2, Jugador1);
                            }
                            else if (target == 2)
                            {
                                Console.WriteLine("indique a cual carta del oponente desea atacar");
                                for (int i = 0; i < Jugador1.tablero.Count; i++)
                                {
                                    Console.WriteLine("[" + i + "]" + Jugador1.tablero[i]);
                                }
                                string numeroDeTarget2 = Console.ReadLine();
                                int numeroDeTargetInt2 = Int32.Parse(numeroDeTarget2);
                                Jugador1.AtacarCarta(posiblesAtacantes2, cartaElegidaInt2, Jugador1.tablero, numeroDeTargetInt2);

                            }
                        }
                        else if (decision2 == "3") //Poder del guerrero.
                        {
                            Jugador2.UsarPoder(Jugador2, Jugador1);
                        }
                        else if (decision2 == "4")//Terminar Turno
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
