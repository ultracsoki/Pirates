using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pirates
{
    internal class Pirate
    {
        private int intoxication;
        private bool dead;
        static private Random random = new Random();

        public int Intoxication { get => intoxication; set => intoxication = value; }
        public bool Dead { get => dead; set => dead = value; }

        public Pirate()
        {
            this.Intoxication = 0;
            this.Dead = false;
        }

        public void DrinkSomeRum()
        {
            if (this.Dead == true)
            {
                Console.WriteLine(DiePrint());
            }
            else
            {
                Intoxication += 1;
            }
        }
        public string HowsItGoingMate()
        {
            if (this.Dead == true)
            {
                return DiePrint();
            }
            else if (Intoxication < 4)
            {
                return "Pour me anudder!";
            }
            else
            {
                Intoxication = 0;
                return "Arghh, I'ma Pirate. How d'ya d'ink its goin?";
            }
        }

        public void Brawl(Pirate enemyPirate)
        {
            int randomNumber = random.Next(3);
            if (this.Dead == true)
            {
                Console.WriteLine(DiePrint());
            }
            else
            {
                switch (randomNumber)
                {
                    case 0:
                        this.Die();
                        break;
                    case 1:
                        enemyPirate.Die();
                        break;
                    case 2:
                        this.Die();
                        enemyPirate.Die();
                        break;
                }
            }
        }

        public void Die()
        {
            this.Dead = true;
        }

        public string DiePrint()
        {
            return "He's dead.";
        }
    }
}
