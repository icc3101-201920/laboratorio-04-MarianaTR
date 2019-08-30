using Laboratorio_3_OOP_201902.Cards;
using Laboratorio_3_OOP_201902.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Laboratorio_3_OOP_201902
{
    public class Game
    {
        //Atributos
        private Player[] players;
        private Player activePlayer;
        private List<Deck> decks;
        private List<SpecialCard> captainCards;
        private Board boardGame;
        private bool endGame;

        //Constructor
        public Game()
        {
            this.decks = new List<Deck>();
            this.decks.Add(new Deck());
            this.decks.Add(new Deck());
        }

        //Propiedades
        public Player[] Players
        {
            get
            {
                return this.players;
            }
        }
        public Player ActivePlayer
        {
            get
            {
                return this.activePlayer;
            }
            set
            {
                activePlayer = value;
            }
        }
        public List<Deck> Decks
        {
            get
            {
                return this.decks;
            }
        }
        public Board BoardGame
        {
            get
            {
                return this.boardGame;
            }
        }

        
        public bool EndGame
        {
            get
            {
                return this.endGame;
            }
            set
            {
                endGame = value;
            }
        }
        //Nuevo metodo

        public void ReadAddCard()
        {
            //esta es la direccion de donde esta nuestro archivo
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Files\Decks.txt";
            //leer el archivo
            StreamReader reader = new StreamReader("path");
            string line = reader.ReadLine();
            List<Card> mazo = new List<Card>();
            while (true)
            {
                line = reader.ReadLine();
                if (line=="END")
                {
                    break;
                }
                string[] aux = line.Split(",");
                if (aux[0] == "CombatCard") 
                {
                    CombatCard newlist = new CombatCard(aux[1], (EnumType)Enum.Parse(typeof(EnumType), aux[2]), aux[3], int.Parse(aux[4]), bool.Parse(aux[5]));
                    mazo.Add(newlist);
                }
                else
                {
                    SpecialCard newcarta = new SpecialCard(aux[1], (EnumType)Enum.Parse(typeof(EnumType), aux[2]), aux[3]);
                    mazo.Add(newcarta);
                }

            }
            //subir las cartas del jugador 1 al deck
            this.decks[0].Cards = mazo;


            line = "";
            List<Card> mazo2 = new List<Card>();
            line = reader.ReadLine();
            while (true)
            {
                line = reader.ReadLine();
                if (line == "END")
                {
                    break;
                }
                string[] separar = line.Split(",");
                if (separar[0] == "CombatCard") 
                {
                    CombatCard newlist = new CombatCard(separar[1], (EnumType)Enum.Parse(typeof(EnumType), separar[2]), separar[3], int.Parse(separar[4]), bool.Parse(separar[5]));
                    mazo2.Add(newlist);
                }
                else
                {
                    SpecialCard newcarta = new SpecialCard(separar[1], (EnumType)Enum.Parse(typeof(EnumType), separar[2]), separar[3]);
                    mazo2.Add(newcarta);
                }

            }
            //añadir las cartas del juggador 2 al deck
            this.decks[1].Cards = mazo2;

            //cerrar el archivo txt
            reader.Close();
        }
        //Metodos
        public bool CheckIfEndGame()
        {
            if (players[0].LifePoints == 0 || players[1].LifePoints == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int GetWinner()
        {
            if (players[0].LifePoints == 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public void Play()
        {
            throw new NotImplementedException();
        }
    }
}
