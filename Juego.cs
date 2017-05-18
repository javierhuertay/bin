using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ProyectoFinal
{
    interface IHeroe
    {
        void UsarPoder(Jugador Jugador1, Jugador Jugador2);
    }
    public class Jugador
    {

        public int vida;
        public int mana;
        public List<Cartas> mano;
        public List<Cartas> mazo;
        public string nombre;
        public List<Cartas> tablero;
        internal int damage;
        internal int armadura;

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
    }
    class Hunter : Jugador, IHeroe
    {
        int costo;
        int damage;

        public Hunter(int costo, int damage, int vida, int mana, List<Cartas> mano, List<Cartas> mazo, string nombre, List<Cartas> tablero)
            : base(vida, mana, mano, mazo, nombre, tablero)
        {
            this.costo = costo;
            this.damage = damage;
        }
        public void UsarPoder(Jugador JugadorPoder, Jugador JugadorOponente)
        {
            JugadorPoder.mana -= 2;
            JugadorOponente.vida -= JugadorPoder.damage;
        }
    }
    class Warrior : Jugador, IHeroe
    {
        int costo;
        int armadura;
        public Warrior(int costo, int armadura, int vida, int mana, List<Cartas> mano, List<Cartas> mazo, string nombre, List<Cartas> tablero)
            : base(vida, mana, mano, mazo, nombre, tablero)
        {
            this.costo = costo;
            this.armadura = armadura;
        }
        public void UsarPoder(Jugador JugadorPoder, Jugador JugadorOponente)
        {
            if (JugadorPoder.mana > 2)
            {
                JugadorPoder.mana -= 2;
                JugadorPoder.armadura += 2;
            }
            else
            {
            }
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
    class Program
    {

        static void Main(string[] args)
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

            //Nombres
            Console.WriteLine("Bienvenido a HearthStone, ingresen sus nombres: ");
            Console.WriteLine("Jugador 1:");
            string name1 = Console.ReadLine();
            Console.WriteLine("Jugador 2:");
            string name2 = Console.ReadLine();

            //Clases
            Console.WriteLine(name1 + ", ¿Seras Hunter o Warrior?");
            string heroe1 = Console.ReadLine();
            Console.WriteLine(name2 + ", ¿Seras Hunter o Warrior?");
            string heroe2 = Console.ReadLine();

            //Mazos
            List<Cartas> Mazo1 = listaCartas;
            List<Cartas> Mazo2 = listaCartas;

            //Manos
            List<Cartas> Mano1 = new List<Cartas>();
            List<Cartas> Mano2 = new List<Cartas>();

            //Tableros
            List<Cartas> TableroJugador1 = new List<Cartas>();
            List<Cartas> TableroJugador2 = new List<Cartas>();

            Console.WriteLine("Comienza el juego");
            bool condicionJuego = true;
            Random rmd = new Random();
            int turno = rmd.Next(0, 2);

            if ((heroe1 == "Hunter" || heroe1 == "hunter") && (heroe2 == "Hunter" || heroe2 == "hunter"))
            {
                Hunter Jugador1 = new Hunter(2, 2, 30, 0, Mano1, Mazo1, name1, TableroJugador1);
                Hunter Jugador2 = new Hunter(2, 2, 30, 0, Mano2, Mazo2, name2, TableroJugador2);
                Cartas.crearMano(Jugador1, Jugador2, turno, theCoin);
                bool cambiarCartas1 = true;
                bool cambiarCartas2 = true;
                while (condicionJuego)
                {
                    if (turno == 0)
                    {
                        while (cambiarCartas1)
                        {
                            for (int i = 0; i < Jugador1.mano.Count; i++)
                            {
                                Console.WriteLine("[" + i + "]" + Jugador1.mano[i].nombre + "|| costo: [" + Jugador1.mano[i].costo + "]"); //Mostramos lo que tenemos en la mano
                            }
                            Console.WriteLine(Jugador1.nombre + ",  ¿Quiere cambiar cartas? (si o no)");
                            string a = Console.ReadLine();

                            while (a == "si" || a == "Si")
                            {
                                for (int i = 0; i < Jugador1.mano.Count; i++)
                                {
                                    Console.WriteLine("[" + i + "]" + Jugador1.mano[i].nombre + "|| costo: [" + Jugador1.mano[i].costo + "]"); //Mostramos lo que tenemos en la mano
                                }
                                Console.WriteLine("Elija la carta que quiere cambiar, 11 si no quiere cambiar");
                                string c = Console.ReadLine();
                                if (c == "11")
                                {
                                    a = "no";
                                    cambiarCartas1 = false;
                                }
                                else
                                {
                                    int c1 = Int32.Parse(c);
                                    Jugador1.mazo.Add(Jugador1.mano[c1]);
                                    Jugador1.mano.Remove(Jugador1.mano[c1]);
                                    int r = rmd.Next(Jugador1.mazo.Count);
                                    Jugador1.mano.Add(Jugador1.mazo[r]);
                                    Mazo1.Remove(Mazo1[r]);
                                }
                            }
                            cambiarCartas1 = false;
                        }
                        int rara1 = rmd.Next(Jugador1.mazo.Count);
                        Cartas.Draw(Jugador1.mano, Jugador1.mazo, rara1);
                        Jugador1.ManaGrowth(); //Jugador gana 1 de mana al comienzo del turno.
                        bool condicionTurno = true; //Para mantenerse en el menu.
                        List<Cartas> posiblesAtacantes1 = new List<Cartas> (Jugador1.tablero); //Asi la misma carta no puede atacar dos veces.
                        int manaTurno = Jugador1.mana; //Mana a la que se le puede restar, si no partiria de 0 practicamente todas las rondas.
                        Console.WriteLine("Turno de " + Jugador1.nombre);
                        bool condicionPoder = true; //Para poder usar solo una vez el poder por turno
                        while (condicionTurno)
                        {
                            Console.WriteLine(Jugador1.nombre + " tienes " + manaTurno + " puntos de mana.");
                            Console.WriteLine("¿Que desea hacer?");
                            Console.WriteLine("(1) Jugar una carta de la mano");
                            if (posiblesAtacantes1.Count >= 1)
                            {
                                Console.WriteLine("(2) Atacar");
                            }
                            if (manaTurno >= 2 && condicionPoder)
                            {
                                Console.WriteLine("(3) Usar el poder");
                            }
                            Console.WriteLine("(4) Terminar el turno");
                            string decision1 = Console.ReadLine(); //Que es lo que hara el jugador.

                            if (decision1 == "1") //Jugar una carta
                            {
                                for (int i = 0; i < Jugador1.mano.Count; i++)
                                {
                                    Console.WriteLine("[" + i + "]" + Jugador1.mano[i].nombre + "||" + " costo " + "[" + Jugador1.mano[i].costo + "]" + " vida " + "[" + Jugador1.mano[i].vida + "]" + "vida" + "[" + Jugador1.mano[i].ataque + "]"); //Mostramos lo que tenemos en la mano
                                }
                                decision1 = "0";
                                while (decision1 == "0")
                                {
                                    Console.WriteLine("Elija el numero de carta que desea jugar, tipe 11 si quiere volver al menú");
                                    string numeroDeCartaString1 = Console.ReadLine();//Numero de carta que quiere jugar, parte desde el 0
                                    int numeroDeCartaInt1 = Int32.Parse(numeroDeCartaString1);//Numero a int
                                    if (numeroDeCartaInt1 == 11)
                                    {
                                        decision1 = "1";
                                    }
                                    else if (Mano1[numeroDeCartaInt1].nombre == "theCoin")
                                    {
                                        manaTurno += 1;
                                        Mano1.Remove(Mano1[numeroDeCartaInt1]);
                                    }
                                    else
                                    {
                                        if (TableroJugador1.Count < 7)
                                        {
                                            if (manaTurno >= Jugador1.mano[numeroDeCartaInt1].costo)
                                            {
                                                manaTurno -= Jugador1.mano[numeroDeCartaInt1].costo;
                                                Jugador1.tablero.Add(Jugador1.mano[numeroDeCartaInt1]);
                                                Jugador1.mano.Remove(Jugador1.mano[numeroDeCartaInt1]);
                                                decision1 = "1";
                                            }
                                            else
                                            {
                                                Console.WriteLine("No hay suficiente mana");
                                                decision1 = "1";
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Ya hay 7 cartas en la mesa");
                                        }
                                    }
                                }
                            }
                            else if (decision1 == "2") //Atacar con una creatura
                            {
                                for (int i = 0; i < posiblesAtacantes1.Count; i++)
                                {
                                    Console.WriteLine("[" + i + "]" + Jugador1.mano[i].nombre + "||" + " vida: " + "[" + Jugador1.mano[i].vida + "]" + " ataque: " + "[" + Jugador1.mano[i].ataque + "]");
                                }
                                decision1 = "0";
                                while (decision1 == "0")
                                {
                                    Console.WriteLine("Elija el numero de carta que desee que ataque, tipe 11 para volver al menú.");
                                    string cartaElegidaString1 = Console.ReadLine();
                                    int cartaElegidaInt1 = Int32.Parse(cartaElegidaString1); // Hasta aca se tiene la carta que va a atacar, falta decidir a quien se va a atacar
                                    if (cartaElegidaInt1 == 11)
                                    {
                                        decision1 = "2";
                                    }
                                    else
                                    {
                                        Console.WriteLine("¿A quien desea a atacar?"); // primero vemos a quien se ataca, si se ataca a carta o a Jugador
                                        Console.WriteLine("(1) Jugador oponente");
                                        Console.WriteLine("(2) Alguna carta del oponente");
                                        string target1 = Console.ReadLine();
                                        int target = Int32.Parse(target1);

                                        if (target == 1)
                                        {
                                            Jugador1.AtacarJugador(posiblesAtacantes1, cartaElegidaInt1, Jugador2);
                                            if (Jugador2.vida <= 0)
                                            {
                                                Console.WriteLine("Juego terminado gano: "+Jugador1.nombre);
                                                condicionJuego = false;
                                            }
                                        }
                                        else if (target == 2)
                                        {
                                            Console.WriteLine("Indique a cual carta del oponente desea atacar");
                                            for (int i = 0; i < Jugador2.tablero.Count; i++)
                                            {
                                                Console.WriteLine("[" + i + "]" + Jugador2.tablero[i].nombre + "|| vida: " + "[" + Jugador2.tablero[i].vida + "]" + " ataque: " + "[" + Jugador2.tablero[i].ataque + "]");
                                            }


                                            string numeroDeTarget1 = Console.ReadLine();
                                            int numeroDeTargetInt1 = Int32.Parse(numeroDeTarget1);
                                            Jugador1.AtacarCarta(posiblesAtacantes1, cartaElegidaInt1, Jugador2.tablero, numeroDeTargetInt1);
                                            if (Jugador2.tablero[numeroDeTargetInt1].vida <= 0)
                                            {
                                                Jugador2.tablero.Remove(Jugador2.tablero[numeroDeTargetInt1]);
                                                Console.WriteLine(Jugador2.tablero[numeroDeTargetInt1].nombre + "ha muerto");
                                            }
                                            if (Jugador1.tablero[cartaElegidaInt1].vida <= 0)
                                            {
                                                Jugador1.tablero.Remove(Jugador1.tablero[cartaElegidaInt1]);
                                                Console.WriteLine(Jugador1.tablero[numeroDeTargetInt1].nombre + "ha muerto");
                                            }
                                        }
                                        decision1 = "2";
                                    }

                                }
                            }
                            else if (decision1 == "3") //Poder del guerrero.
                            {
                                Console.WriteLine("Tipe 11 para ir al menu principal, de lo contrario procedemos a usar el poder");
                                string hola = Console.ReadLine();
                                if (hola == "11")
                                {
                                    decision1 = "0";
                                }
                                else
                                {
                                    Jugador1.UsarPoder(Jugador1, Jugador2);
                                    condicionPoder = false;
                                    if (Jugador2.vida <= 0)
                                    {
                                        Console.WriteLine("Juego terminado gano: " + Jugador1.nombre);
                                        condicionJuego = false;
                                    }
                                }
                            }
                            else if (decision1 == "4")//Terminar Turno
                            {
                                condicionTurno = false;
                                turno = 1;
                                if (Jugador1.mano.Count < 10)
                                {
                                    int r = 0;
                                    Jugador1.mano.Add(Jugador1.mazo[r]);
                                    Jugador1.mazo.Remove(Jugador1.mazo[r]);
                                }
                            }
                        }
                    }

                    else if (turno == 1)
                    {

                        while (cambiarCartas2)
                        {
                            for (int i = 0; i < Jugador2.mano.Count; i++)
                            {
                                Console.WriteLine("[" + i + "]" + Jugador2.mano[i].nombre + "|| costo: [" + Jugador2.mano[i].costo + "]"); //Mostramos lo que tenemos en la mano
                            }
                            Console.WriteLine(Jugador2.nombre + ",  ¿Quiere cambiar cartas? (si o no)");
                            string a = Console.ReadLine();

                            while (a == "si" || a == "Si")
                            {
                                for (int i = 0; i < Jugador2.mano.Count; i++)
                                {
                                    Console.WriteLine("[" + i + "]" + Jugador2.mano[i].nombre + "|| costo: [" + Jugador2.mano[i].costo + "]"); //Mostramos lo que tenemos en la mano
                                }
                                Console.WriteLine("Elija la carta que quiere cambiar, 11 si no quiere cambiar");
                                string c = Console.ReadLine();
                                if (c == "11")
                                {
                                    a = "no";
                                    cambiarCartas2 = false;
                                }
                                else
                                {
                                    int c1 = Int32.Parse(c);
                                    Jugador2.mazo.Add(Jugador2.mano[c1]);
                                    Jugador2.mano.Remove(Jugador2.mano[c1]);
                                    int r = rmd.Next(Jugador2.mazo.Count);
                                    Jugador2.mano.Add(Jugador2.mazo[r]);
                                    Mazo2.Remove(Mazo2[r]);
                                }
                            }
                            cambiarCartas2 = false;
                        }
                        int rara2 = rmd.Next(Jugador2.mazo.Count);
                        Cartas.Draw(Jugador2.mano, Jugador2.mazo, rara2);
                        Jugador2.ManaGrowth(); //Jugador gana 1 de mana al comienzo del turno.
                        bool condicionTurno = true; //Para mantenerse en el menu.
                        List<Cartas> posiblesAtacantes1 = new List<Cartas>(Jugador2.tablero); ; //Asi la misma carta no puede atacar dos veces.
                        int manaTurno = Jugador2.mana; //Mana a la que se le puede restar, si no partiria de 0 practicamente todas las rondas.
                        Console.WriteLine("Turno de " + Jugador2.nombre);
                        bool condicionPoder = true; //Para poder usar solo una vez el poder por turno
                        while (condicionTurno)
                        {
                            Console.WriteLine(Jugador2.nombre + " tienes " + manaTurno + " puntos de mana.");
                            Console.WriteLine("¿Que desea hacer?");
                            Console.WriteLine("(1) Jugar una carta de la mano");

                            if (posiblesAtacantes1.Count >= 1)
                            {
                                Console.WriteLine("(2) Atacar");
                            }
                            if (manaTurno >= 2 && condicionPoder)
                            {
                                Console.WriteLine("(3) Usar el poder");
                            }
                            Console.WriteLine("(4) Terminar el turno");
                            string decision1 = Console.ReadLine(); //Que es lo que hara el jugador.

                            if (decision1 == "1") //Jugar una carta
                            {
                                for (int i = 0; i < Jugador2.mano.Count; i++)
                                {
                                    Console.WriteLine("[" + i + "]" + Jugador2.mano[i].nombre + "||" + " costo " + "[" + Jugador2.mano[i].costo + "]" + " vida " + "[" + Jugador2.mano[i].vida + "]" + "vida" + "[" + Jugador2.mano[i].ataque + "]"); //Mostramos lo que tenemos en la mano
                                }
                                decision1 = "0";
                                while (decision1 == "0")
                                {
                                    Console.WriteLine("Elija el numero de carta que desea jugar, tipe 11 si quiere volver al menú");
                                    string numeroDeCartaString1 = Console.ReadLine();//Numero de carta que quiere jugar, parte desde el 0
                                    int numeroDeCartaInt1 = Int32.Parse(numeroDeCartaString1);//Numero a int
                                    if (numeroDeCartaInt1 == 11)
                                    {
                                        decision1 = "1";
                                    }
                                    else if (Mano2[numeroDeCartaInt1].nombre == "theCoin")
                                    {
                                        manaTurno += 1;
                                        Mano2.Remove(Mano2[numeroDeCartaInt1]);
                                    }
                                    else
                                    {
                                        if (TableroJugador2.Count < 7)
                                        {
                                            if (manaTurno >= Jugador2.mano[numeroDeCartaInt1].costo)
                                            {
                                                manaTurno -= Jugador2.mano[numeroDeCartaInt1].costo;
                                                Jugador2.tablero.Add(Jugador2.mano[numeroDeCartaInt1]);
                                                Jugador2.mano.Remove(Jugador2.mano[numeroDeCartaInt1]);
                                                decision1 = "1";
                                            }
                                            else
                                            {
                                                Console.WriteLine("No hay suficiente mana");
                                                decision1 = "1";
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Ya hay 7 cartas en la mesa");
                                        }
                                    }
                                }
                            }
                            else if (decision1 == "2") //Atacar con una creatura
                            {
                                for (int i = 0; i < posiblesAtacantes1.Count; i++)
                                {
                                    Console.WriteLine("[" + i + "]" + Jugador2.mano[i].nombre + "||" + " vida: " + "[" + Jugador2.mano[i].vida + "]" + " ataque: " + "[" + Jugador2.mano[i].ataque + "]");
                                }
                                decision1 = "0";
                                while (decision1 == "0")
                                {
                                    Console.WriteLine("Elija el numero de carta que desee que ataque, tipe 11 para volver al menú.");
                                    string cartaElegidaString1 = Console.ReadLine();
                                    int cartaElegidaInt1 = Int32.Parse(cartaElegidaString1); // Hasta aca se tiene la carta que va a atacar, falta decidir a quien se va a atacar
                                    if (cartaElegidaInt1 == 11)
                                    {
                                        decision1 = "2";
                                    }
                                    else
                                    {
                                        Console.WriteLine("¿A quien desea a atacar?"); // primero vemos a quien se ataca, si se ataca a carta o a Jugador
                                        Console.WriteLine("(1) Jugador oponente");
                                        Console.WriteLine("(2) Alguna carta del oponente");
                                        string target1 = Console.ReadLine();
                                        int target = Int32.Parse(target1);

                                        if (target == 1)
                                        {
                                            Jugador2.AtacarJugador(posiblesAtacantes1, cartaElegidaInt1, Jugador1);
                                            if (Jugador1.vida <= 0)
                                            {
                                                Console.WriteLine("Juego terminado gano: " + Jugador2.nombre);
                                                condicionJuego = false;
                                            }
                                        }
                                        else if (target == 2)
                                        {
                                            Console.WriteLine("Indique a cual carta del oponente desea atacar");
                                            for (int i = 0; i < Jugador1.tablero.Count; i++)
                                            {
                                                Console.WriteLine("[" + i + "]" + Jugador1.tablero[i].nombre + "|| vida: " + "[" + Jugador1.tablero[i].vida + "]" + " ataque: " + "[" + Jugador1.tablero[i].ataque + "]");
                                            }


                                            string numeroDeTarget1 = Console.ReadLine();
                                            int numeroDeTargetInt1 = Int32.Parse(numeroDeTarget1);
                                            Jugador2.AtacarCarta(posiblesAtacantes1, cartaElegidaInt1, Jugador1.tablero, numeroDeTargetInt1);
                                            if (Jugador1.tablero[numeroDeTargetInt1].vida <= 0)
                                            {
                                                Jugador1.tablero.Remove(Jugador1.tablero[numeroDeTargetInt1]);
                                                Console.WriteLine(Jugador1.tablero[numeroDeTargetInt1].nombre + "ha muerto");
                                            }
                                            if (Jugador2.tablero[cartaElegidaInt1].vida <= 0)
                                            {
                                                Jugador2.tablero.Remove(Jugador2.tablero[cartaElegidaInt1]);
                                                Console.WriteLine(Jugador2.tablero[numeroDeTargetInt1].nombre + "ha muerto");
                                            }
                                        }
                                        decision1 = "2";
                                    }

                                }
                            }
                            else if (decision1 == "3") //Poder del guerrero.
                            {
                                Console.WriteLine("Tipe 11 para ir al menu principal, de lo contrario procedemos a usar el poder");
                                string hola = Console.ReadLine();
                                if (hola == "11")
                                {
                                    decision1 = "0";
                                }
                                else
                                {
                                    Jugador2.UsarPoder(Jugador2, Jugador1);
                                    condicionPoder = false;
                                    if (Jugador1.vida <= 0)
                                    {
                                        Console.WriteLine("Juego terminado gano: " + Jugador2.nombre);
                                        condicionJuego = false;
                                    }
                                }
                            }
                            else if (decision1 == "4")//Terminar Turno
                            {
                                condicionTurno = false;
                                turno = 0;
                                if (Jugador1.mano.Count < 10)
                                {
                                    int r = 0;
                                    Jugador2.mano.Add(Jugador1.mazo[r]);
                                    Jugador2.mazo.Remove(Jugador1.mazo[r]);
                                }
                            }
                        }
                    }
                }

            }
            else if ((heroe1 == "Hunter" || heroe1 == "hunter") && (heroe2 == "Warrior" || heroe2 == "warrior"))
            {
                Hunter Jugador1 = new Hunter(2, 2, 30, 0, Mano1, Mazo1, name1, TableroJugador1);
                Warrior Jugador2 = new Warrior(2, 2, 30, 0, Mano2, Mazo2, name2, TableroJugador2);
                Cartas.crearMano(Jugador1, Jugador2, turno, theCoin);
                bool cambiarCartas1 = true;
                bool cambiarCartas2 = true;
                while (condicionJuego)
                {
                    if (turno == 0)
                    {
                        while (cambiarCartas1)
                        {
                            for (int i = 0; i < Jugador1.mano.Count; i++)
                            {
                                Console.WriteLine("[" + i + "]" + Jugador1.mano[i].nombre + "|| costo: [" + Jugador1.mano[i].costo + "]"); //Mostramos lo que tenemos en la mano
                            }
                            Console.WriteLine(Jugador1.nombre + ",  ¿Quiere cambiar cartas? (si o no)");
                            string a = Console.ReadLine();

                            while (a == "si" || a == "Si")
                            {
                                for (int i = 0; i < Jugador1.mano.Count; i++)
                                {
                                    Console.WriteLine("[" + i + "]" + Jugador1.mano[i].nombre + "|| costo: [" + Jugador1.mano[i].costo + "]"); //Mostramos lo que tenemos en la mano
                                }
                                Console.WriteLine("Elija la carta que quiere cambiar, 11 si no quiere cambiar");
                                string c = Console.ReadLine();
                                if (c == "11")
                                {
                                    a = "no";
                                    cambiarCartas1 = false;
                                }
                                else
                                {
                                    int c1 = Int32.Parse(c);
                                    Jugador1.mazo.Add(Jugador1.mano[c1]);
                                    Jugador1.mano.Remove(Jugador1.mano[c1]);
                                    int r = rmd.Next(Jugador1.mazo.Count);
                                    Jugador1.mano.Add(Jugador1.mazo[r]);
                                    Mazo1.Remove(Mazo1[r]);
                                }
                            }
                            cambiarCartas1 = false;
                        }
                        int rara1 = rmd.Next(Jugador1.mazo.Count);
                        Cartas.Draw(Jugador1.mano, Jugador1.mazo, rara1);
                        Jugador1.ManaGrowth(); //Jugador gana 1 de mana al comienzo del turno.
                        bool condicionTurno = true; //Para mantenerse en el menu.
                        List<Cartas> posiblesAtacantes1 = new List<Cartas>(Jugador1.tablero); //Asi la misma carta no puede atacar dos veces.
                        int manaTurno = Jugador1.mana; //Mana a la que se le puede restar, si no partiria de 0 practicamente todas las rondas.
                        Console.WriteLine("Turno de " + Jugador1.nombre);
                        bool condicionPoder = true; //Para poder usar solo una vez el poder por turno
                        while (condicionTurno)
                        {
                            Console.WriteLine(Jugador1.nombre + " tienes " + manaTurno + " puntos de mana.");
                            Console.WriteLine("¿Que desea hacer?");
                            Console.WriteLine("(1) Jugar una carta de la mano");
                            if (posiblesAtacantes1.Count >= 1)
                            {
                                Console.WriteLine("(2) Atacar");
                            }
                            if (manaTurno >= 2 && condicionPoder)
                            {
                                Console.WriteLine("(3) Usar el poder");
                            }
                            Console.WriteLine("(4) Terminar el turno");
                            string decision1 = Console.ReadLine(); //Que es lo que hara el jugador.

                            if (decision1 == "1") //Jugar una carta
                            {
                                for (int i = 0; i < Jugador1.mano.Count; i++)
                                {
                                    Console.WriteLine("[" + i + "]" + Jugador1.mano[i].nombre + "||" + " costo " + "[" + Jugador1.mano[i].costo + "]" + " vida " + "[" + Jugador1.mano[i].vida + "]" + "vida" + "[" + Jugador1.mano[i].ataque + "]"); //Mostramos lo que tenemos en la mano
                                }
                                decision1 = "0";
                                while (decision1 == "0")
                                {
                                    Console.WriteLine("Elija el numero de carta que desea jugar, tipe 11 si quiere volver al menú");
                                    string numeroDeCartaString1 = Console.ReadLine();//Numero de carta que quiere jugar, parte desde el 0
                                    int numeroDeCartaInt1 = Int32.Parse(numeroDeCartaString1);//Numero a int
                                    if (numeroDeCartaInt1 == 11)
                                    {
                                        decision1 = "1";
                                    }
                                    else if (Mano1[numeroDeCartaInt1].nombre == "theCoin")
                                    {
                                        manaTurno += 1;
                                        Mano1.Remove(Mano1[numeroDeCartaInt1]);
                                    }
                                    else
                                    {
                                        if (TableroJugador1.Count < 7)
                                        {
                                            if (manaTurno >= Jugador1.mano[numeroDeCartaInt1].costo)
                                            {
                                                manaTurno -= Jugador1.mano[numeroDeCartaInt1].costo;
                                                Jugador1.tablero.Add(Jugador1.mano[numeroDeCartaInt1]);
                                                Jugador1.mano.Remove(Jugador1.mano[numeroDeCartaInt1]);
                                                decision1 = "1";
                                            }
                                            else
                                            {
                                                Console.WriteLine("No hay suficiente mana");
                                                decision1 = "1";
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Ya hay 7 cartas en la mesa");
                                        }
                                    }
                                }
                            }
                            else if (decision1 == "2") //Atacar con una creatura
                            {
                                for (int i = 0; i < posiblesAtacantes1.Count; i++)
                                {
                                    Console.WriteLine("[" + i + "]" + Jugador1.mano[i].nombre + "||" + " vida: " + "[" + Jugador1.mano[i].vida + "]" + " ataque: " + "[" + Jugador1.mano[i].ataque + "]");
                                }
                                decision1 = "0";
                                while (decision1 == "0")
                                {
                                    Console.WriteLine("Elija el numero de carta que desee que ataque, tipe 11 para volver al menú.");
                                    string cartaElegidaString1 = Console.ReadLine();
                                    int cartaElegidaInt1 = Int32.Parse(cartaElegidaString1); // Hasta aca se tiene la carta que va a atacar, falta decidir a quien se va a atacar
                                    if (cartaElegidaInt1 == 11)
                                    {
                                        decision1 = "2";
                                    }
                                    else
                                    {
                                        Console.WriteLine("¿A quien desea a atacar?"); // primero vemos a quien se ataca, si se ataca a carta o a Jugador
                                        Console.WriteLine("(1) Jugador oponente");
                                        Console.WriteLine("(2) Alguna carta del oponente");
                                        string target1 = Console.ReadLine();
                                        int target = Int32.Parse(target1);

                                        if (target == 1)
                                        {
                                            Jugador1.AtacarJugador(posiblesAtacantes1, cartaElegidaInt1, Jugador2);
                                            if (Jugador2.vida <= 0)
                                            {
                                                Console.WriteLine("Juego terminado gano: " + Jugador1.nombre);
                                                condicionJuego = false;
                                            }
                                        }
                                        else if (target == 2)
                                        {
                                            Console.WriteLine("Indique a cual carta del oponente desea atacar");
                                            for (int i = 0; i < Jugador2.tablero.Count; i++)
                                            {
                                                Console.WriteLine("[" + i + "]" + Jugador2.tablero[i].nombre + "|| vida: " + "[" + Jugador2.tablero[i].vida + "]" + " ataque: " + "[" + Jugador2.tablero[i].ataque + "]");
                                            }


                                            string numeroDeTarget1 = Console.ReadLine();
                                            int numeroDeTargetInt1 = Int32.Parse(numeroDeTarget1);
                                            Jugador1.AtacarCarta(posiblesAtacantes1, cartaElegidaInt1, Jugador2.tablero, numeroDeTargetInt1);
                                            if (Jugador2.tablero[numeroDeTargetInt1].vida <= 0)
                                            {
                                                Jugador2.tablero.Remove(Jugador2.tablero[numeroDeTargetInt1]);
                                                Console.WriteLine(Jugador2.tablero[numeroDeTargetInt1].nombre + "ha muerto");
                                            }
                                            if (Jugador1.tablero[cartaElegidaInt1].vida <= 0)
                                            {
                                                Jugador1.tablero.Remove(Jugador1.tablero[cartaElegidaInt1]);
                                                Console.WriteLine(Jugador1.tablero[numeroDeTargetInt1].nombre + "ha muerto");
                                            }
                                        }
                                        decision1 = "2";
                                    }

                                }
                            }
                            else if (decision1 == "3") //Poder del guerrero.
                            {
                                Console.WriteLine("Tipe 11 para ir al menu principal, de lo contrario procedemos a usar el poder");
                                string hola = Console.ReadLine();
                                if (hola == "11")
                                {
                                    decision1 = "0";
                                }
                                else
                                {
                                    Jugador1.UsarPoder(Jugador1, Jugador2);
                                    condicionPoder = false;
                                    if (Jugador2.vida <= 0)
                                    {
                                        Console.WriteLine("Juego terminado gano: " + Jugador1.nombre);
                                        condicionJuego = false;
                                    }
                                }
                            }
                            else if (decision1 == "4")//Terminar Turno
                            {
                                condicionTurno = false;
                                turno = 1;
                                if (Jugador1.mano.Count < 10)
                                {
                                    int r = 0;
                                    Jugador1.mano.Add(Jugador1.mazo[r]);
                                    Jugador1.mazo.Remove(Jugador1.mazo[r]);
                                }
                            }
                        }
                    }

                    else if (turno == 1)
                    {

                        while (cambiarCartas2)
                        {
                            for (int i = 0; i < Jugador2.mano.Count; i++)
                            {
                                Console.WriteLine("[" + i + "]" + Jugador2.mano[i].nombre + "|| costo: [" + Jugador2.mano[i].costo + "]"); //Mostramos lo que tenemos en la mano
                            }
                            Console.WriteLine(Jugador2.nombre + ",  ¿Quiere cambiar cartas? (si o no)");
                            string a = Console.ReadLine();

                            while (a == "si" || a == "Si")
                            {
                                for (int i = 0; i < Jugador2.mano.Count; i++)
                                {
                                    Console.WriteLine("[" + i + "]" + Jugador2.mano[i].nombre + "|| costo: [" + Jugador2.mano[i].costo + "]"); //Mostramos lo que tenemos en la mano
                                }
                                Console.WriteLine("Elija la carta que quiere cambiar, 11 si no quiere cambiar");
                                string c = Console.ReadLine();
                                if (c == "11")
                                {
                                    a = "no";
                                    cambiarCartas2 = false;
                                }
                                else
                                {
                                    int c1 = Int32.Parse(c);
                                    Jugador2.mazo.Add(Jugador2.mano[c1]);
                                    Jugador2.mano.Remove(Jugador2.mano[c1]);
                                    int r = rmd.Next(Jugador2.mazo.Count);
                                    Jugador2.mano.Add(Jugador2.mazo[r]);
                                    Mazo2.Remove(Mazo2[r]);
                                }
                            }
                            cambiarCartas2 = false;
                        }
                        int rara2 = rmd.Next(Jugador2.mazo.Count);
                        Cartas.Draw(Jugador2.mano, Jugador2.mazo, rara2);
                        Jugador2.ManaGrowth(); //Jugador gana 1 de mana al comienzo del turno.
                        bool condicionTurno = true; //Para mantenerse en el menu.
                        List<Cartas> posiblesAtacantes1 = new List<Cartas>(Jugador2.tablero); ; //Asi la misma carta no puede atacar dos veces.
                        int manaTurno = Jugador2.mana; //Mana a la que se le puede restar, si no partiria de 0 practicamente todas las rondas.
                        Console.WriteLine("Turno de " + Jugador2.nombre);
                        bool condicionPoder = true; //Para poder usar solo una vez el poder por turno
                        while (condicionTurno)
                        {
                            Console.WriteLine(Jugador2.nombre + " tienes " + manaTurno + " puntos de mana.");
                            Console.WriteLine("¿Que desea hacer?");
                            Console.WriteLine("(1) Jugar una carta de la mano");

                            if (posiblesAtacantes1.Count >= 1)
                            {
                                Console.WriteLine("(2) Atacar");
                            }
                            if (manaTurno >= 2 && condicionPoder)
                            {
                                Console.WriteLine("(3) Usar el poder");
                            }
                            Console.WriteLine("(4) Terminar el turno");
                            string decision1 = Console.ReadLine(); //Que es lo que hara el jugador.

                            if (decision1 == "1") //Jugar una carta
                            {
                                for (int i = 0; i < Jugador2.mano.Count; i++)
                                {
                                    Console.WriteLine("[" + i + "]" + Jugador2.mano[i].nombre + "||" + " costo " + "[" + Jugador2.mano[i].costo + "]" + " vida " + "[" + Jugador2.mano[i].vida + "]" + "vida" + "[" + Jugador2.mano[i].ataque + "]"); //Mostramos lo que tenemos en la mano
                                }
                                decision1 = "0";
                                while (decision1 == "0")
                                {
                                    Console.WriteLine("Elija el numero de carta que desea jugar, tipe 11 si quiere volver al menú");
                                    string numeroDeCartaString1 = Console.ReadLine();//Numero de carta que quiere jugar, parte desde el 0
                                    int numeroDeCartaInt1 = Int32.Parse(numeroDeCartaString1);//Numero a int
                                    if (numeroDeCartaInt1 == 11)
                                    {
                                        decision1 = "1";
                                    }
                                    else if (Mano2[numeroDeCartaInt1].nombre == "theCoin")
                                    {
                                        manaTurno += 1;
                                        Mano2.Remove(Mano2[numeroDeCartaInt1]);
                                    }
                                    else
                                    {
                                        if (TableroJugador2.Count < 7)
                                        {
                                            if (manaTurno >= Jugador2.mano[numeroDeCartaInt1].costo)
                                            {
                                                manaTurno -= Jugador2.mano[numeroDeCartaInt1].costo;
                                                Jugador2.tablero.Add(Jugador2.mano[numeroDeCartaInt1]);
                                                Jugador2.mano.Remove(Jugador2.mano[numeroDeCartaInt1]);
                                                decision1 = "1";
                                            }
                                            else
                                            {
                                                Console.WriteLine("No hay suficiente mana");
                                                decision1 = "1";
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Ya hay 7 cartas en la mesa");
                                        }
                                    }
                                }
                            }
                            else if (decision1 == "2") //Atacar con una creatura
                            {
                                for (int i = 0; i < posiblesAtacantes1.Count; i++)
                                {
                                    Console.WriteLine("[" + i + "]" + Jugador2.mano[i].nombre + "||" + " vida: " + "[" + Jugador2.mano[i].vida + "]" + " ataque: " + "[" + Jugador2.mano[i].ataque + "]");
                                }
                                decision1 = "0";
                                while (decision1 == "0")
                                {
                                    Console.WriteLine("Elija el numero de carta que desee que ataque, tipe 11 para volver al menú.");
                                    string cartaElegidaString1 = Console.ReadLine();
                                    int cartaElegidaInt1 = Int32.Parse(cartaElegidaString1); // Hasta aca se tiene la carta que va a atacar, falta decidir a quien se va a atacar
                                    if (cartaElegidaInt1 == 11)
                                    {
                                        decision1 = "2";
                                    }
                                    else
                                    {
                                        Console.WriteLine("¿A quien desea a atacar?"); // primero vemos a quien se ataca, si se ataca a carta o a Jugador
                                        Console.WriteLine("(1) Jugador oponente");
                                        Console.WriteLine("(2) Alguna carta del oponente");
                                        string target1 = Console.ReadLine();
                                        int target = Int32.Parse(target1);

                                        if (target == 1)
                                        {
                                            Jugador2.AtacarJugador(posiblesAtacantes1, cartaElegidaInt1, Jugador1);
                                            if (Jugador1.vida <= 0)
                                            {
                                                Console.WriteLine("Juego terminado gano: " + Jugador2.nombre);
                                                condicionJuego = false;
                                            }
                                        }
                                        else if (target == 2)
                                        {
                                            Console.WriteLine("Indique a cual carta del oponente desea atacar");
                                            for (int i = 0; i < Jugador1.tablero.Count; i++)
                                            {
                                                Console.WriteLine("[" + i + "]" + Jugador1.tablero[i].nombre + "|| vida: " + "[" + Jugador1.tablero[i].vida + "]" + " ataque: " + "[" + Jugador1.tablero[i].ataque + "]");
                                            }


                                            string numeroDeTarget1 = Console.ReadLine();
                                            int numeroDeTargetInt1 = Int32.Parse(numeroDeTarget1);
                                            Jugador2.AtacarCarta(posiblesAtacantes1, cartaElegidaInt1, Jugador1.tablero, numeroDeTargetInt1);
                                            if (Jugador1.tablero[numeroDeTargetInt1].vida <= 0)
                                            {
                                                Jugador1.tablero.Remove(Jugador1.tablero[numeroDeTargetInt1]);
                                                Console.WriteLine(Jugador1.tablero[numeroDeTargetInt1].nombre + "ha muerto");
                                            }
                                            if (Jugador2.tablero[cartaElegidaInt1].vida <= 0)
                                            {
                                                Jugador2.tablero.Remove(Jugador2.tablero[cartaElegidaInt1]);
                                                Console.WriteLine(Jugador2.tablero[numeroDeTargetInt1].nombre + "ha muerto");
                                            }
                                        }
                                        decision1 = "2";
                                    }

                                }
                            }
                            else if (decision1 == "3") //Poder del guerrero.
                            {
                                Console.WriteLine("Tipe 11 para ir al menu principal, de lo contrario procedemos a usar el poder");
                                string hola = Console.ReadLine();
                                if (hola == "11")
                                {
                                    decision1 = "0";
                                }
                                else
                                {
                                    Jugador2.UsarPoder(Jugador2, Jugador1);
                                    condicionPoder = false;
                                    if (Jugador1.vida <= 0)
                                    {
                                        Console.WriteLine("Juego terminado gano: " + Jugador2.nombre);
                                        condicionJuego = false;
                                    }
                                }
                            }
                            else if (decision1 == "4")//Terminar Turno
                            {
                                condicionTurno = false;
                                turno = 0;
                                if (Jugador1.mano.Count < 10)
                                {
                                    int r = 0;
                                    Jugador2.mano.Add(Jugador1.mazo[r]);
                                    Jugador2.mazo.Remove(Jugador1.mazo[r]);
                                }
                            }
                        }
                    }
                }

            }
            else if ((heroe1 == "Warrior" || heroe1 == "warrior") && (heroe2 == "Hunter" || heroe2 == "hunter"))
            {
                Warrior Jugador1 = new Warrior(2, 2, 30, 0, Mano1, Mazo1, name1, TableroJugador1);
                Hunter Jugador2 = new Hunter(2, 2, 30, 0, Mano2, Mazo2, name2, TableroJugador2);
                Cartas.crearMano(Jugador1, Jugador2, turno, theCoin);
                bool cambiarCartas1 = true;
                bool cambiarCartas2 = true;
                while (condicionJuego)
                {
                    if (turno == 0)
                    {
                        while (cambiarCartas1)
                        {
                            for (int i = 0; i < Jugador1.mano.Count; i++)
                            {
                                Console.WriteLine("[" + i + "]" + Jugador1.mano[i].nombre + "|| costo: [" + Jugador1.mano[i].costo + "]"); //Mostramos lo que tenemos en la mano
                            }
                            Console.WriteLine(Jugador1.nombre + ",  ¿Quiere cambiar cartas? (si o no)");
                            string a = Console.ReadLine();

                            while (a == "si" || a == "Si")
                            {
                                for (int i = 0; i < Jugador1.mano.Count; i++)
                                {
                                    Console.WriteLine("[" + i + "]" + Jugador1.mano[i].nombre + "|| costo: [" + Jugador1.mano[i].costo + "]"); //Mostramos lo que tenemos en la mano
                                }
                                Console.WriteLine("Elija la carta que quiere cambiar, 11 si no quiere cambiar");
                                string c = Console.ReadLine();
                                if (c == "11")
                                {
                                    a = "no";
                                    cambiarCartas1 = false;
                                }
                                else
                                {
                                    int c1 = Int32.Parse(c);
                                    Jugador1.mazo.Add(Jugador1.mano[c1]);
                                    Jugador1.mano.Remove(Jugador1.mano[c1]);
                                    int r = rmd.Next(Jugador1.mazo.Count);
                                    Jugador1.mano.Add(Jugador1.mazo[r]);
                                    Mazo1.Remove(Mazo1[r]);
                                }
                            }
                            cambiarCartas1 = false;
                        }
                        int rara1 = rmd.Next(Jugador1.mazo.Count);
                        Cartas.Draw(Jugador1.mano, Jugador1.mazo, rara1);
                        Jugador1.ManaGrowth(); //Jugador gana 1 de mana al comienzo del turno.
                        bool condicionTurno = true; //Para mantenerse en el menu.
                        List<Cartas> posiblesAtacantes1 = new List<Cartas>(Jugador1.tablero); //Asi la misma carta no puede atacar dos veces.
                        int manaTurno = Jugador1.mana; //Mana a la que se le puede restar, si no partiria de 0 practicamente todas las rondas.
                        Console.WriteLine("Turno de " + Jugador1.nombre);
                        bool condicionPoder = true; //Para poder usar solo una vez el poder por turno
                        while (condicionTurno)
                        {
                            Console.WriteLine(Jugador1.nombre + " tienes " + manaTurno + " puntos de mana.");
                            Console.WriteLine("¿Que desea hacer?");
                            Console.WriteLine("(1) Jugar una carta de la mano");
                            if (posiblesAtacantes1.Count >= 1)
                            {
                                Console.WriteLine("(2) Atacar");
                            }
                            if (manaTurno >= 2 && condicionPoder)
                            {
                                Console.WriteLine("(3) Usar el poder");
                            }
                            Console.WriteLine("(4) Terminar el turno");
                            string decision1 = Console.ReadLine(); //Que es lo que hara el jugador.

                            if (decision1 == "1") //Jugar una carta
                            {
                                for (int i = 0; i < Jugador1.mano.Count; i++)
                                {
                                    Console.WriteLine("[" + i + "]" + Jugador1.mano[i].nombre + "||" + " costo " + "[" + Jugador1.mano[i].costo + "]" + " vida " + "[" + Jugador1.mano[i].vida + "]" + "vida" + "[" + Jugador1.mano[i].ataque + "]"); //Mostramos lo que tenemos en la mano
                                }
                                decision1 = "0";
                                while (decision1 == "0")
                                {
                                    Console.WriteLine("Elija el numero de carta que desea jugar, tipe 11 si quiere volver al menú");
                                    string numeroDeCartaString1 = Console.ReadLine();//Numero de carta que quiere jugar, parte desde el 0
                                    int numeroDeCartaInt1 = Int32.Parse(numeroDeCartaString1);//Numero a int
                                    if (numeroDeCartaInt1 == 11)
                                    {
                                        decision1 = "1";
                                    }
                                    else if (Mano1[numeroDeCartaInt1].nombre == "theCoin")
                                    {
                                        manaTurno += 1;
                                        Mano1.Remove(Mano1[numeroDeCartaInt1]);
                                    }
                                    else
                                    {
                                        if (TableroJugador1.Count < 7)
                                        {
                                            if (manaTurno >= Jugador1.mano[numeroDeCartaInt1].costo)
                                            {
                                                manaTurno -= Jugador1.mano[numeroDeCartaInt1].costo;
                                                Jugador1.tablero.Add(Jugador1.mano[numeroDeCartaInt1]);
                                                Jugador1.mano.Remove(Jugador1.mano[numeroDeCartaInt1]);
                                                decision1 = "1";
                                            }
                                            else
                                            {
                                                Console.WriteLine("No hay suficiente mana");
                                                decision1 = "1";
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Ya hay 7 cartas en la mesa");
                                        }
                                    }
                                }
                            }
                            else if (decision1 == "2") //Atacar con una creatura
                            {
                                for (int i = 0; i < posiblesAtacantes1.Count; i++)
                                {
                                    Console.WriteLine("[" + i + "]" + Jugador1.mano[i].nombre + "||" + " vida: " + "[" + Jugador1.mano[i].vida + "]" + " ataque: " + "[" + Jugador1.mano[i].ataque + "]");
                                }
                                decision1 = "0";
                                while (decision1 == "0")
                                {
                                    Console.WriteLine("Elija el numero de carta que desee que ataque, tipe 11 para volver al menú.");
                                    string cartaElegidaString1 = Console.ReadLine();
                                    int cartaElegidaInt1 = Int32.Parse(cartaElegidaString1); // Hasta aca se tiene la carta que va a atacar, falta decidir a quien se va a atacar
                                    if (cartaElegidaInt1 == 11)
                                    {
                                        decision1 = "2";
                                    }
                                    else
                                    {
                                        Console.WriteLine("¿A quien desea a atacar?"); // primero vemos a quien se ataca, si se ataca a carta o a Jugador
                                        Console.WriteLine("(1) Jugador oponente");
                                        Console.WriteLine("(2) Alguna carta del oponente");
                                        string target1 = Console.ReadLine();
                                        int target = Int32.Parse(target1);

                                        if (target == 1)
                                        {
                                            Jugador1.AtacarJugador(posiblesAtacantes1, cartaElegidaInt1, Jugador2);
                                            if (Jugador2.vida <= 0)
                                            {
                                                Console.WriteLine("Juego terminado gano: " + Jugador1.nombre);
                                                condicionJuego = false;
                                            }
                                        }
                                        else if (target == 2)
                                        {
                                            Console.WriteLine("Indique a cual carta del oponente desea atacar");
                                            for (int i = 0; i < Jugador2.tablero.Count; i++)
                                            {
                                                Console.WriteLine("[" + i + "]" + Jugador2.tablero[i].nombre + "|| vida: " + "[" + Jugador2.tablero[i].vida + "]" + " ataque: " + "[" + Jugador2.tablero[i].ataque + "]");
                                            }


                                            string numeroDeTarget1 = Console.ReadLine();
                                            int numeroDeTargetInt1 = Int32.Parse(numeroDeTarget1);
                                            Jugador1.AtacarCarta(posiblesAtacantes1, cartaElegidaInt1, Jugador2.tablero, numeroDeTargetInt1);
                                            if (Jugador2.tablero[numeroDeTargetInt1].vida <= 0)
                                            {
                                                Jugador2.tablero.Remove(Jugador2.tablero[numeroDeTargetInt1]);
                                                Console.WriteLine(Jugador2.tablero[numeroDeTargetInt1].nombre + "ha muerto");
                                            }
                                            if (Jugador1.tablero[cartaElegidaInt1].vida <= 0)
                                            {
                                                Jugador1.tablero.Remove(Jugador1.tablero[cartaElegidaInt1]);
                                                Console.WriteLine(Jugador1.tablero[numeroDeTargetInt1].nombre + "ha muerto");
                                            }
                                        }
                                        decision1 = "2";
                                    }

                                }
                            }
                            else if (decision1 == "3") //Poder del guerrero.
                            {
                                Console.WriteLine("Tipe 11 para ir al menu principal, de lo contrario procedemos a usar el poder");
                                string hola = Console.ReadLine();
                                if (hola == "11")
                                {
                                    decision1 = "0";
                                }
                                else
                                {
                                    Jugador1.UsarPoder(Jugador1, Jugador2);
                                    condicionPoder = false;
                                    if (Jugador2.vida <= 0)
                                    {
                                        Console.WriteLine("Juego terminado gano: " + Jugador1.nombre);
                                        condicionJuego = false;
                                    }
                                }
                            }
                            else if (decision1 == "4")//Terminar Turno
                            {
                                condicionTurno = false;
                                turno = 1;
                                if (Jugador1.mano.Count < 10)
                                {
                                    int r = 0;
                                    Jugador1.mano.Add(Jugador1.mazo[r]);
                                    Jugador1.mazo.Remove(Jugador1.mazo[r]);
                                }
                            }
                        }
                    }

                    else if (turno == 1)
                    {

                        while (cambiarCartas2)
                        {
                            for (int i = 0; i < Jugador2.mano.Count; i++)
                            {
                                Console.WriteLine("[" + i + "]" + Jugador2.mano[i].nombre + "|| costo: [" + Jugador2.mano[i].costo + "]"); //Mostramos lo que tenemos en la mano
                            }
                            Console.WriteLine(Jugador2.nombre + ",  ¿Quiere cambiar cartas? (si o no)");
                            string a = Console.ReadLine();

                            while (a == "si" || a == "Si")
                            {
                                for (int i = 0; i < Jugador2.mano.Count; i++)
                                {
                                    Console.WriteLine("[" + i + "]" + Jugador2.mano[i].nombre + "|| costo: [" + Jugador2.mano[i].costo + "]"); //Mostramos lo que tenemos en la mano
                                }
                                Console.WriteLine("Elija la carta que quiere cambiar, 11 si no quiere cambiar");
                                string c = Console.ReadLine();
                                if (c == "11")
                                {
                                    a = "no";
                                    cambiarCartas2 = false;
                                }
                                else
                                {
                                    int c1 = Int32.Parse(c);
                                    Jugador2.mazo.Add(Jugador2.mano[c1]);
                                    Jugador2.mano.Remove(Jugador2.mano[c1]);
                                    int r = rmd.Next(Jugador2.mazo.Count);
                                    Jugador2.mano.Add(Jugador2.mazo[r]);
                                    Mazo2.Remove(Mazo2[r]);
                                }
                            }
                            cambiarCartas2 = false;
                        }
                        int rara2 = rmd.Next(Jugador2.mazo.Count);
                        Cartas.Draw(Jugador2.mano, Jugador2.mazo, rara2);
                        Jugador2.ManaGrowth(); //Jugador gana 1 de mana al comienzo del turno.
                        bool condicionTurno = true; //Para mantenerse en el menu.
                        List<Cartas> posiblesAtacantes1 = new List<Cartas>(Jugador2.tablero); ; //Asi la misma carta no puede atacar dos veces.
                        int manaTurno = Jugador2.mana; //Mana a la que se le puede restar, si no partiria de 0 practicamente todas las rondas.
                        Console.WriteLine("Turno de " + Jugador2.nombre);
                        bool condicionPoder = true; //Para poder usar solo una vez el poder por turno
                        while (condicionTurno)
                        {
                            Console.WriteLine(Jugador2.nombre + " tienes " + manaTurno + " puntos de mana.");
                            Console.WriteLine("¿Que desea hacer?");
                            Console.WriteLine("(1) Jugar una carta de la mano");

                            if (posiblesAtacantes1.Count >= 1)
                            {
                                Console.WriteLine("(2) Atacar");
                            }
                            if (manaTurno >= 2 && condicionPoder)
                            {
                                Console.WriteLine("(3) Usar el poder");
                            }
                            Console.WriteLine("(4) Terminar el turno");
                            string decision1 = Console.ReadLine(); //Que es lo que hara el jugador.

                            if (decision1 == "1") //Jugar una carta
                            {
                                for (int i = 0; i < Jugador2.mano.Count; i++)
                                {
                                    Console.WriteLine("[" + i + "]" + Jugador2.mano[i].nombre + "||" + " costo " + "[" + Jugador2.mano[i].costo + "]" + " vida " + "[" + Jugador2.mano[i].vida + "]" + "vida" + "[" + Jugador2.mano[i].ataque + "]"); //Mostramos lo que tenemos en la mano
                                }
                                decision1 = "0";
                                while (decision1 == "0")
                                {
                                    Console.WriteLine("Elija el numero de carta que desea jugar, tipe 11 si quiere volver al menú");
                                    string numeroDeCartaString1 = Console.ReadLine();//Numero de carta que quiere jugar, parte desde el 0
                                    int numeroDeCartaInt1 = Int32.Parse(numeroDeCartaString1);//Numero a int
                                    if (numeroDeCartaInt1 == 11)
                                    {
                                        decision1 = "1";
                                    }
                                    else if (Mano2[numeroDeCartaInt1].nombre == "theCoin")
                                    {
                                        manaTurno += 1;
                                        Mano2.Remove(Mano2[numeroDeCartaInt1]);
                                    }
                                    else
                                    {
                                        if (TableroJugador2.Count < 7)
                                        {
                                            if (manaTurno >= Jugador2.mano[numeroDeCartaInt1].costo)
                                            {
                                                manaTurno -= Jugador2.mano[numeroDeCartaInt1].costo;
                                                Jugador2.tablero.Add(Jugador2.mano[numeroDeCartaInt1]);
                                                Jugador2.mano.Remove(Jugador2.mano[numeroDeCartaInt1]);
                                                decision1 = "1";
                                            }
                                            else
                                            {
                                                Console.WriteLine("No hay suficiente mana");
                                                decision1 = "1";
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Ya hay 7 cartas en la mesa");
                                        }
                                    }
                                }
                            }
                            else if (decision1 == "2") //Atacar con una creatura
                            {
                                for (int i = 0; i < posiblesAtacantes1.Count; i++)
                                {
                                    Console.WriteLine("[" + i + "]" + Jugador2.mano[i].nombre + "||" + " vida: " + "[" + Jugador2.mano[i].vida + "]" + " ataque: " + "[" + Jugador2.mano[i].ataque + "]");
                                }
                                decision1 = "0";
                                while (decision1 == "0")
                                {
                                    Console.WriteLine("Elija el numero de carta que desee que ataque, tipe 11 para volver al menú.");
                                    string cartaElegidaString1 = Console.ReadLine();
                                    int cartaElegidaInt1 = Int32.Parse(cartaElegidaString1); // Hasta aca se tiene la carta que va a atacar, falta decidir a quien se va a atacar
                                    if (cartaElegidaInt1 == 11)
                                    {
                                        decision1 = "2";
                                    }
                                    else
                                    {
                                        Console.WriteLine("¿A quien desea a atacar?"); // primero vemos a quien se ataca, si se ataca a carta o a Jugador
                                        Console.WriteLine("(1) Jugador oponente");
                                        Console.WriteLine("(2) Alguna carta del oponente");
                                        string target1 = Console.ReadLine();
                                        int target = Int32.Parse(target1);

                                        if (target == 1)
                                        {
                                            Jugador2.AtacarJugador(posiblesAtacantes1, cartaElegidaInt1, Jugador1);
                                            if (Jugador1.vida <= 0)
                                            {
                                                Console.WriteLine("Juego terminado gano: " + Jugador2.nombre);
                                                condicionJuego = false;
                                            }
                                        }
                                        else if (target == 2)
                                        {
                                            Console.WriteLine("Indique a cual carta del oponente desea atacar");
                                            for (int i = 0; i < Jugador1.tablero.Count; i++)
                                            {
                                                Console.WriteLine("[" + i + "]" + Jugador1.tablero[i].nombre + "|| vida: " + "[" + Jugador1.tablero[i].vida + "]" + " ataque: " + "[" + Jugador1.tablero[i].ataque + "]");
                                            }


                                            string numeroDeTarget1 = Console.ReadLine();
                                            int numeroDeTargetInt1 = Int32.Parse(numeroDeTarget1);
                                            Jugador2.AtacarCarta(posiblesAtacantes1, cartaElegidaInt1, Jugador1.tablero, numeroDeTargetInt1);
                                            if (Jugador1.tablero[numeroDeTargetInt1].vida <= 0)
                                            {
                                                Jugador1.tablero.Remove(Jugador1.tablero[numeroDeTargetInt1]);
                                                Console.WriteLine(Jugador1.tablero[numeroDeTargetInt1].nombre + "ha muerto");
                                            }
                                            if (Jugador2.tablero[cartaElegidaInt1].vida <= 0)
                                            {
                                                Jugador2.tablero.Remove(Jugador2.tablero[cartaElegidaInt1]);
                                                Console.WriteLine(Jugador2.tablero[numeroDeTargetInt1].nombre + "ha muerto");
                                            }
                                        }
                                        decision1 = "2";
                                    }

                                }
                            }
                            else if (decision1 == "3") //Poder del guerrero.
                            {
                                Console.WriteLine("Tipe 11 para ir al menu principal, de lo contrario procedemos a usar el poder");
                                string hola = Console.ReadLine();
                                if (hola == "11")
                                {
                                    decision1 = "0";
                                }
                                else
                                {
                                    Jugador2.UsarPoder(Jugador2, Jugador1);
                                    condicionPoder = false;
                                    if (Jugador1.vida <= 0)
                                    {
                                        Console.WriteLine("Juego terminado gano: " + Jugador2.nombre);
                                        condicionJuego = false;
                                    }
                                }
                            }
                            else if (decision1 == "4")//Terminar Turno
                            {
                                condicionTurno = false;
                                turno = 0;
                                if (Jugador1.mano.Count < 10)
                                {
                                    int r = 0;
                                    Jugador2.mano.Add(Jugador1.mazo[r]);
                                    Jugador2.mazo.Remove(Jugador1.mazo[r]);
                                }
                            }
                        }
                    }
                }

            }
            else if ((heroe1 == "Warrior" || heroe1 == "warrior") && (heroe2 == "Warrior" || heroe2 == "warrior"))
            {
                Warrior Jugador1 = new Warrior(2, 2, 30, 0, Mano1, Mazo1, name1, TableroJugador1);
                Warrior Jugador2 = new Warrior(2, 2, 30, 0, Mano2, Mazo2, name2, TableroJugador2);
                Cartas.crearMano(Jugador1, Jugador2, turno, theCoin);
                bool cambiarCartas1 = true;
                bool cambiarCartas2 = true;
                while (condicionJuego)
                {
                    if (turno == 0)
                    {
                        while (cambiarCartas1)
                        {
                            for (int i = 0; i < Jugador1.mano.Count; i++)
                            {
                                Console.WriteLine("[" + i + "]" + Jugador1.mano[i].nombre + "|| costo: [" + Jugador1.mano[i].costo + "]"); //Mostramos lo que tenemos en la mano
                            }
                            Console.WriteLine(Jugador1.nombre + ",  ¿Quiere cambiar cartas? (si o no)");
                            string a = Console.ReadLine();

                            while (a == "si" || a == "Si")
                            {
                                for (int i = 0; i < Jugador1.mano.Count; i++)
                                {
                                    Console.WriteLine("[" + i + "]" + Jugador1.mano[i].nombre + "|| costo: [" + Jugador1.mano[i].costo + "]"); //Mostramos lo que tenemos en la mano
                                }
                                Console.WriteLine("Elija la carta que quiere cambiar, 11 si no quiere cambiar");
                                string c = Console.ReadLine();
                                if (c == "11")
                                {
                                    a = "no";
                                    cambiarCartas1 = false;
                                }
                                else
                                {
                                    int c1 = Int32.Parse(c);
                                    Jugador1.mazo.Add(Jugador1.mano[c1]);
                                    Jugador1.mano.Remove(Jugador1.mano[c1]);
                                    int r = rmd.Next(Jugador1.mazo.Count);
                                    Jugador1.mano.Add(Jugador1.mazo[r]);
                                    Mazo1.Remove(Mazo1[r]);
                                }
                            }
                            cambiarCartas1 = false;
                        }
                        int rara1 = rmd.Next(Jugador1.mazo.Count);
                        Cartas.Draw(Jugador1.mano, Jugador1.mazo, rara1);
                        Jugador1.ManaGrowth(); //Jugador gana 1 de mana al comienzo del turno.
                        bool condicionTurno = true; //Para mantenerse en el menu.
                        List<Cartas> posiblesAtacantes1 = new List<Cartas>(Jugador1.tablero); //Asi la misma carta no puede atacar dos veces.
                        int manaTurno = Jugador1.mana; //Mana a la que se le puede restar, si no partiria de 0 practicamente todas las rondas.
                        Console.WriteLine("Turno de " + Jugador1.nombre);
                        bool condicionPoder = true; //Para poder usar solo una vez el poder por turno
                        while (condicionTurno)
                        {
                            Console.WriteLine(Jugador1.nombre + " tienes " + manaTurno + " puntos de mana.");
                            Console.WriteLine("¿Que desea hacer?");
                            Console.WriteLine("(1) Jugar una carta de la mano");
                            if (posiblesAtacantes1.Count >= 1)
                            {
                                Console.WriteLine("(2) Atacar");
                            }
                            if (manaTurno >= 2 && condicionPoder)
                            {
                                Console.WriteLine("(3) Usar el poder");
                            }
                            Console.WriteLine("(4) Terminar el turno");
                            string decision1 = Console.ReadLine(); //Que es lo que hara el jugador.

                            if (decision1 == "1") //Jugar una carta
                            {
                                for (int i = 0; i < Jugador1.mano.Count; i++)
                                {
                                    Console.WriteLine("[" + i + "]" + Jugador1.mano[i].nombre + "||" + " costo " + "[" + Jugador1.mano[i].costo + "]" + " vida " + "[" + Jugador1.mano[i].vida + "]" + "vida" + "[" + Jugador1.mano[i].ataque + "]"); //Mostramos lo que tenemos en la mano
                                }
                                decision1 = "0";
                                while (decision1 == "0")
                                {
                                    Console.WriteLine("Elija el numero de carta que desea jugar, tipe 11 si quiere volver al menú");
                                    string numeroDeCartaString1 = Console.ReadLine();//Numero de carta que quiere jugar, parte desde el 0
                                    int numeroDeCartaInt1 = Int32.Parse(numeroDeCartaString1);//Numero a int
                                    if (numeroDeCartaInt1 == 11)
                                    {
                                        decision1 = "1";
                                    }
                                    else if (Mano1[numeroDeCartaInt1].nombre == "theCoin")
                                    {
                                        manaTurno += 1;
                                        Mano1.Remove(Mano1[numeroDeCartaInt1]);
                                    }
                                    else
                                    {
                                        if (TableroJugador1.Count < 7)
                                        {
                                            if (manaTurno >= Jugador1.mano[numeroDeCartaInt1].costo)
                                            {
                                                manaTurno -= Jugador1.mano[numeroDeCartaInt1].costo;
                                                Jugador1.tablero.Add(Jugador1.mano[numeroDeCartaInt1]);
                                                Jugador1.mano.Remove(Jugador1.mano[numeroDeCartaInt1]);
                                                decision1 = "1";
                                            }
                                            else
                                            {
                                                Console.WriteLine("No hay suficiente mana");
                                                decision1 = "1";
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Ya hay 7 cartas en la mesa");
                                        }
                                    }
                                }
                            }
                            else if (decision1 == "2") //Atacar con una creatura
                            {
                                for (int i = 0; i < posiblesAtacantes1.Count; i++)
                                {
                                    Console.WriteLine("[" + i + "]" + Jugador1.mano[i].nombre + "||" + " vida: " + "[" + Jugador1.mano[i].vida + "]" + " ataque: " + "[" + Jugador1.mano[i].ataque + "]");
                                }
                                decision1 = "0";
                                while (decision1 == "0")
                                {
                                    Console.WriteLine("Elija el numero de carta que desee que ataque, tipe 11 para volver al menú.");
                                    string cartaElegidaString1 = Console.ReadLine();
                                    int cartaElegidaInt1 = Int32.Parse(cartaElegidaString1); // Hasta aca se tiene la carta que va a atacar, falta decidir a quien se va a atacar
                                    if (cartaElegidaInt1 == 11)
                                    {
                                        decision1 = "2";
                                    }
                                    else
                                    {
                                        Console.WriteLine("¿A quien desea a atacar?"); // primero vemos a quien se ataca, si se ataca a carta o a Jugador
                                        Console.WriteLine("(1) Jugador oponente");
                                        Console.WriteLine("(2) Alguna carta del oponente");
                                        string target1 = Console.ReadLine();
                                        int target = Int32.Parse(target1);

                                        if (target == 1)
                                        {
                                            Jugador1.AtacarJugador(posiblesAtacantes1, cartaElegidaInt1, Jugador2);
                                            if (Jugador2.vida <= 0)
                                            {
                                                Console.WriteLine("Juego terminado gano: " + Jugador1.nombre);
                                                condicionJuego = false;
                                            }
                                        }
                                        else if (target == 2)
                                        {
                                            Console.WriteLine("Indique a cual carta del oponente desea atacar");
                                            for (int i = 0; i < Jugador2.tablero.Count; i++)
                                            {
                                                Console.WriteLine("[" + i + "]" + Jugador2.tablero[i].nombre + "|| vida: " + "[" + Jugador2.tablero[i].vida + "]" + " ataque: " + "[" + Jugador2.tablero[i].ataque + "]");
                                            }


                                            string numeroDeTarget1 = Console.ReadLine();
                                            int numeroDeTargetInt1 = Int32.Parse(numeroDeTarget1);
                                            Jugador1.AtacarCarta(posiblesAtacantes1, cartaElegidaInt1, Jugador2.tablero, numeroDeTargetInt1);
                                            if (Jugador2.tablero[numeroDeTargetInt1].vida <= 0)
                                            {
                                                Jugador2.tablero.Remove(Jugador2.tablero[numeroDeTargetInt1]);
                                                Console.WriteLine(Jugador2.tablero[numeroDeTargetInt1].nombre + "ha muerto");
                                            }
                                            if (Jugador1.tablero[cartaElegidaInt1].vida <= 0)
                                            {
                                                Jugador1.tablero.Remove(Jugador1.tablero[cartaElegidaInt1]);
                                                Console.WriteLine(Jugador1.tablero[numeroDeTargetInt1].nombre + "ha muerto");
                                            }
                                        }
                                        decision1 = "2";
                                    }

                                }
                            }
                            else if (decision1 == "3") //Poder del guerrero.
                            {
                                Console.WriteLine("Tipe 11 para ir al menu principal, de lo contrario procedemos a usar el poder");
                                string hola = Console.ReadLine();
                                if (hola == "11")
                                {
                                    decision1 = "0";
                                }
                                else
                                {
                                    Jugador1.UsarPoder(Jugador1, Jugador2);
                                    condicionPoder = false;
                                    if (Jugador2.vida <= 0)
                                    {
                                        Console.WriteLine("Juego terminado gano: " + Jugador1.nombre);
                                        condicionJuego = false;
                                    }
                                }
                            }
                            else if (decision1 == "4")//Terminar Turno
                            {
                                condicionTurno = false;
                                turno = 1;
                                if (Jugador1.mano.Count < 10)
                                {
                                    int r = 0;
                                    Jugador1.mano.Add(Jugador1.mazo[r]);
                                    Jugador1.mazo.Remove(Jugador1.mazo[r]);
                                }
                            }
                        }
                    }

                    else if (turno == 1)
                    {

                        while (cambiarCartas2)
                        {
                            for (int i = 0; i < Jugador2.mano.Count; i++)
                            {
                                Console.WriteLine("[" + i + "]" + Jugador2.mano[i].nombre + "|| costo: [" + Jugador2.mano[i].costo + "]"); //Mostramos lo que tenemos en la mano
                            }
                            Console.WriteLine(Jugador2.nombre + ",  ¿Quiere cambiar cartas? (si o no)");
                            string a = Console.ReadLine();

                            while (a == "si" || a == "Si")
                            {
                                for (int i = 0; i < Jugador2.mano.Count; i++)
                                {
                                    Console.WriteLine("[" + i + "]" + Jugador2.mano[i].nombre + "|| costo: [" + Jugador2.mano[i].costo + "]"); //Mostramos lo que tenemos en la mano
                                }
                                Console.WriteLine("Elija la carta que quiere cambiar, 11 si no quiere cambiar");
                                string c = Console.ReadLine();
                                if (c == "11")
                                {
                                    a = "no";
                                    cambiarCartas2 = false;
                                }
                                else
                                {
                                    int c1 = Int32.Parse(c);
                                    Jugador2.mazo.Add(Jugador2.mano[c1]);
                                    Jugador2.mano.Remove(Jugador2.mano[c1]);
                                    int r = rmd.Next(Jugador2.mazo.Count);
                                    Jugador2.mano.Add(Jugador2.mazo[r]);
                                    Mazo2.Remove(Mazo2[r]);
                                }
                            }
                            cambiarCartas2 = false;
                        }
                        int rara2 = rmd.Next(Jugador2.mazo.Count);
                        Cartas.Draw(Jugador2.mano, Jugador2.mazo, rara2);
                        Jugador2.ManaGrowth(); //Jugador gana 1 de mana al comienzo del turno.
                        bool condicionTurno = true; //Para mantenerse en el menu.
                        List<Cartas> posiblesAtacantes1 = new List<Cartas>(Jugador2.tablero); ; //Asi la misma carta no puede atacar dos veces.
                        int manaTurno = Jugador2.mana; //Mana a la que se le puede restar, si no partiria de 0 practicamente todas las rondas.
                        Console.WriteLine("Turno de " + Jugador2.nombre);
                        bool condicionPoder = true; //Para poder usar solo una vez el poder por turno
                        while (condicionTurno)
                        {
                            Console.WriteLine(Jugador2.nombre + " tienes " + manaTurno + " puntos de mana.");
                            Console.WriteLine("¿Que desea hacer?");
                            Console.WriteLine("(1) Jugar una carta de la mano");

                            if (posiblesAtacantes1.Count >= 1)
                            {
                                Console.WriteLine("(2) Atacar");
                            }
                            if (manaTurno >= 2 && condicionPoder)
                            {
                                Console.WriteLine("(3) Usar el poder");
                            }
                            Console.WriteLine("(4) Terminar el turno");
                            string decision1 = Console.ReadLine(); //Que es lo que hara el jugador.

                            if (decision1 == "1") //Jugar una carta
                            {
                                for (int i = 0; i < Jugador2.mano.Count; i++)
                                {
                                    Console.WriteLine("[" + i + "]" + Jugador2.mano[i].nombre + "||" + " costo " + "[" + Jugador2.mano[i].costo + "]" + " vida " + "[" + Jugador2.mano[i].vida + "]" + "vida" + "[" + Jugador2.mano[i].ataque + "]"); //Mostramos lo que tenemos en la mano
                                }
                                decision1 = "0";
                                while (decision1 == "0")
                                {
                                    Console.WriteLine("Elija el numero de carta que desea jugar, tipe 11 si quiere volver al menú");
                                    string numeroDeCartaString1 = Console.ReadLine();//Numero de carta que quiere jugar, parte desde el 0
                                    int numeroDeCartaInt1 = Int32.Parse(numeroDeCartaString1);//Numero a int
                                    if (numeroDeCartaInt1 == 11)
                                    {
                                        decision1 = "1";
                                    }
                                    else if (Mano2[numeroDeCartaInt1].nombre == "theCoin")
                                    {
                                        manaTurno += 1;
                                        Mano2.Remove(Mano2[numeroDeCartaInt1]);
                                    }
                                    else
                                    {
                                        if (TableroJugador2.Count < 7)
                                        {
                                            if (manaTurno >= Jugador2.mano[numeroDeCartaInt1].costo)
                                            {
                                                manaTurno -= Jugador2.mano[numeroDeCartaInt1].costo;
                                                Jugador2.tablero.Add(Jugador2.mano[numeroDeCartaInt1]);
                                                Jugador2.mano.Remove(Jugador2.mano[numeroDeCartaInt1]);
                                                decision1 = "1";
                                            }
                                            else
                                            {
                                                Console.WriteLine("No hay suficiente mana");
                                                decision1 = "1";
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Ya hay 7 cartas en la mesa");
                                        }
                                    }
                                }
                            }
                            else if (decision1 == "2") //Atacar con una creatura
                            {
                                for (int i = 0; i < posiblesAtacantes1.Count; i++)
                                {
                                    Console.WriteLine("[" + i + "]" + Jugador2.mano[i].nombre + "||" + " vida: " + "[" + Jugador2.mano[i].vida + "]" + " ataque: " + "[" + Jugador2.mano[i].ataque + "]");
                                }
                                decision1 = "0";
                                while (decision1 == "0")
                                {
                                    Console.WriteLine("Elija el numero de carta que desee que ataque, tipe 11 para volver al menú.");
                                    string cartaElegidaString1 = Console.ReadLine();
                                    int cartaElegidaInt1 = Int32.Parse(cartaElegidaString1); // Hasta aca se tiene la carta que va a atacar, falta decidir a quien se va a atacar
                                    if (cartaElegidaInt1 == 11)
                                    {
                                        decision1 = "2";
                                    }
                                    else
                                    {
                                        Console.WriteLine("¿A quien desea a atacar?"); // primero vemos a quien se ataca, si se ataca a carta o a Jugador
                                        Console.WriteLine("(1) Jugador oponente");
                                        Console.WriteLine("(2) Alguna carta del oponente");
                                        string target1 = Console.ReadLine();
                                        int target = Int32.Parse(target1);

                                        if (target == 1)
                                        {
                                            Jugador2.AtacarJugador(posiblesAtacantes1, cartaElegidaInt1, Jugador1);
                                            if (Jugador1.vida <= 0)
                                            {
                                                Console.WriteLine("Juego terminado gano: " + Jugador2.nombre);
                                                condicionJuego = false;
                                            }
                                        }
                                        else if (target == 2)
                                        {
                                            Console.WriteLine("Indique a cual carta del oponente desea atacar");
                                            for (int i = 0; i < Jugador1.tablero.Count; i++)
                                            {
                                                Console.WriteLine("[" + i + "]" + Jugador1.tablero[i].nombre + "|| vida: " + "[" + Jugador1.tablero[i].vida + "]" + " ataque: " + "[" + Jugador1.tablero[i].ataque + "]");
                                            }


                                            string numeroDeTarget1 = Console.ReadLine();
                                            int numeroDeTargetInt1 = Int32.Parse(numeroDeTarget1);
                                            Jugador2.AtacarCarta(posiblesAtacantes1, cartaElegidaInt1, Jugador1.tablero, numeroDeTargetInt1);
                                            if (Jugador1.tablero[numeroDeTargetInt1].vida <= 0)
                                            {
                                                Jugador1.tablero.Remove(Jugador1.tablero[numeroDeTargetInt1]);
                                                Console.WriteLine(Jugador1.tablero[numeroDeTargetInt1].nombre + "ha muerto");
                                            }
                                            if (Jugador2.tablero[cartaElegidaInt1].vida <= 0)
                                            {
                                                Jugador2.tablero.Remove(Jugador2.tablero[cartaElegidaInt1]);
                                                Console.WriteLine(Jugador2.tablero[numeroDeTargetInt1].nombre + "ha muerto");
                                            }
                                        }
                                        decision1 = "2";
                                    }

                                }
                            }
                            else if (decision1 == "3") //Poder del guerrero.
                            {
                                Console.WriteLine("Tipe 11 para ir al menu principal, de lo contrario procedemos a usar el poder");
                                string hola = Console.ReadLine();
                                if (hola == "11")
                                {
                                    decision1 = "0";
                                }
                                else
                                {
                                    Jugador2.UsarPoder(Jugador2, Jugador1);
                                    condicionPoder = false;
                                    if (Jugador1.vida <= 0)
                                    {
                                        Console.WriteLine("Juego terminado gano: " + Jugador2.nombre);
                                        condicionJuego = false;
                                    }
                                }
                            }
                            else if (decision1 == "4")//Terminar Turno
                            {
                                condicionTurno = false;
                                turno = 0;
                                if (Jugador1.mano.Count < 10)
                                {
                                    int r = 0;
                                    Jugador2.mano.Add(Jugador1.mazo[r]);
                                    Jugador2.mazo.Remove(Jugador1.mazo[r]);
                                }
                            }
                        }
                    }
                }

            }
        }
    }
}
