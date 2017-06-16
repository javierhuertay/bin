using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
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
        public string heroe;
        public Jugador(int armadura, int vida, int mana, List<Cartas> mano, List<Cartas> mazo, string nombre, List<Cartas> tablero, string heroe, int damage)
        {
            this.damage = damage;
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
        public void UsarPoder(Jugador JugadorPoder, Jugador JugadorOponente, Cartas carta)
        {
            if (JugadorPoder.heroe == "Warrior" || JugadorPoder.heroe == "warrior")
            {
                JugadorPoder.armadura += 2;
            }
            else if (JugadorPoder.heroe == "Hunter" || JugadorPoder.heroe == "hunter")
            {
                JugadorOponente.vida -= 2;
            }
            else if (JugadorPoder.heroe == "Druid" || JugadorPoder.heroe == "druid")
            {
                JugadorPoder.damage += 1;
                JugadorPoder.armadura += 1;
            }
 
            else if (JugadorPoder.heroe == "Mage" || JugadorPoder.heroe == "mage")
            { 
                JugadorOponente.vida -= 1;
            }
            else if (JugadorPoder.heroe == "Paladin" || JugadorPoder.heroe == "paladin")
            {
                JugadorPoder.tablero.Add(carta);
            }
            else if (JugadorPoder.heroe == "Priest" || JugadorPoder.heroe == "priest")
            {
                JugadorPoder.vida += 2;
            }
            else if (JugadorPoder.heroe == "Rogue" || JugadorPoder.heroe == "rogue")
            {
                JugadorPoder.damage += 1;
            }
            else if (JugadorPoder.heroe == "Shaman" || JugadorPoder.heroe == "shaman")
            {
            }
            else if (JugadorPoder.heroe == "Warlock" || JugadorPoder.heroe == "warlock")
            {
                JugadorPoder.vida -= 2;
            }
        }
    }
}
