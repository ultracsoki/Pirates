using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pirates
{
    internal class BattleApp
    {
        static void Main(string[] args)
        {
            Ship ship1 = new Ship();
            ship1.FillShip();
            Ship ship2 = new Ship();
            ship2.FillShip();
            ship1.Captain.DrinkSomeRum();
            ship1.Captain.DrinkSomeRum();
            ship1.Captain.DrinkSomeRum();
            ship2.Captain.DrinkSomeRum();
            Console.WriteLine(ship1.ShipPrint());
            Console.WriteLine(ship2.ShipPrint());
            ship1.Battle(ship2);
            Console.WriteLine(ship1.ShipPrint());
            Console.WriteLine(ship2.ShipPrint());

            Console.ReadKey();
        }
    }
}
