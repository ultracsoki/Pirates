using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pirates
{
    internal class Ship
    {
        private List<Pirate> crew = new List<Pirate>();
        private Pirate captain;
        static private Random random = new Random();

        internal Pirate Captain { get => captain; set => captain = value; }

        public Ship() 
        {
            this.crew.Clear();
            this.captain = null;
        }

        public void FillShip()
        {
            this.captain = new Pirate();
            int randomNumber = random.Next(113);
            for (int i = 0; i < randomNumber; i++)
            {
                crew.Add(new Pirate());
            }
        }

        public List<Pirate> CrewAlive(Ship ship) 
        {
            List<Pirate> crewAlive = new List<Pirate>();
            for (int i = 0; i < ship.crew.Count; i++)
            {
                if (ship.crew[i].Dead == false)
                {
                    crewAlive.Add(ship.crew[i]);
                }
            }
            return crewAlive;
        }

        public string ShipPrint()
        {
            string printText = "";
            if (this.captain.Dead == true)
            {
                printText += $"A captain consumed {this.captain.Intoxication} rum, and he is dead.";
            }
            else
            {
                printText += $"A captain consumed {this.captain.Intoxication} rum, and he is alive.";
            }
            printText += $"\nNumber of alive pirates in the crew: {CrewAlive(this).Count}";
            return printText;
        }

        public bool Battle(Ship enemyShip)
        {
            int scoreActual = CrewAlive(this).Count - this.captain.Intoxication;
            int scoreEnemy = CrewAlive(enemyShip).Count - enemyShip.captain.Intoxication;

            if (scoreActual > scoreEnemy)
            {
                int randomDeaths = random.Next(enemyShip.crew.Count);
                for (int i = 0; i < randomDeaths; i++)
                {
                    enemyShip.crew[i].Die();
                }
                for (int i = 0; i < CrewAlive(this).Count; i++)
                {
                    int randomRums = random.Next(5);
                    for (int j = 0; j < randomRums; j++)
                    {
                        CrewAlive(this)[i].DrinkSomeRum();
                    }
                }
                Console.WriteLine("Enemy score: " + scoreEnemy);
                Console.WriteLine("Actual score:" + scoreActual);
                return true;
            }
            else if(scoreActual < scoreEnemy)
            {
                int randomDeaths = random.Next(this.crew.Count);
                for (int i = 0; i < randomDeaths; i++)
                {
                    this.crew[i].Die();
                }
                for (int i = 0; i < CrewAlive(enemyShip).Count; i++)
                {
                    int randomRums = random.Next(5);
                    for (int j = 0; j < randomRums; j++)
                    {
                        CrewAlive(enemyShip)[i].DrinkSomeRum();
                    }
                }
                Console.WriteLine("Enemy score: " + scoreEnemy);
                Console.WriteLine("Actual score:" + scoreActual);
                return false;
            }
            else
            {
                throw new Exception("Döntetlen lett.");
            }
        }
    }
}
