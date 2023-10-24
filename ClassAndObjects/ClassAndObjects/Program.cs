


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassAndObjects;

namespace Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  Avto car1 = new Avto();
            //   Avto car2 = new Avto();
            Avto[] cars = new Avto[2];

            int count = 0;
            string otvet1;
            int otvet = 1;
            int otvetMenu;
            for (int i = 0; i < cars.Length; i++)
            {
                cars[i] = new Avto();
            }

            Console.WriteLine(" Введите номер машины (1 или 2), в меню которой хотите перейти ");
            otvet = Convert.ToInt32(Console.ReadLine());

            while (otvet == 1 || otvet == 2)
            {

                otvet1 = "да";
                while (otvet1 == "да")
                {
                    Console.WriteLine("Меню \n нажмите:  \n 1 - чтобы ввести информацию о машине №" + otvet + "\n 2 - чтобы начать движение \n 3 - чтобы разогнаться \n 4- чтобы притормозить " +
                        "\n 5 - чтобы вывести информацию о машине \n 6 - чтобы вывести координаты");
                    otvetMenu = Convert.ToInt32(Console.ReadLine());
                    if (otvetMenu == 2)
                    {
                        count += 1;
                    }
                    cars[otvet - 1].choose(otvetMenu);
                    Console.WriteLine("Хотите вернуться в меню машины №" + otvet + " ? да/нет");
                    otvet1 = Console.ReadLine();
                    // if (otvet1 == "нет")
                    // {
                    //     break;

                    //  }

                }


                Console.WriteLine(" Введите номер машины (1 или 2), в меню которой хотите перейти или введите 0, если не хотите ничего менять ");
                otvet = Convert.ToInt32(Console.ReadLine());

                if (otvet == 0)
                {
                    break;

                }

            }

          //  if (count >= 2)
          //  {
                Console.WriteLine("Хотите проверить случилась ли авария? да/нет");
                otvet1 = Console.ReadLine();

                cars[0].choose(otvet1, cars[1]);
                //  cars[0].crash(cars[1]);



           // }

            Console.ReadLine();
        }

    }
}








