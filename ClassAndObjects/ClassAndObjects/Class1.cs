using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassAndObjects
{
    public class Avto
    {

        private string nom;
        private int bak;
        int rasst;
        private float rashod;
        private double probeg;
        private int beginX;
        private int beginY;
        private int endX;
        private int endY;
        private int km;
        private int top;
        private List<string> coordinates = new List<string>();
        private float razgonSpeed;

        private float speed;

        public void choose(int otvet)
        {

            switch (otvet)
            {
                case 1:
                    info(this.nom, this.bak, this.rashod);
                    break;
                case 2:
                    move(this.km);

                    break;

                case 3:
                    razgon();
                    break;
                case 4:
                    tormoz();
                    break;
                case 5:
                    output();
                    break;
                case 6:

                    coord(this.rasst, this.beginX, this.endX);

                    break;



            }

        }
        public void choose(string otvet, Avto car)
        {
            switch (otvet)
            {
                case "да":
                    if (this.coordinates.Count > 0 && car.coordinates.Count > 0)
                    {
                        crash(car);
                    }
                    else
                    {
                        Console.WriteLine("Ошибка, убедитесь, что обе машины совершили поездки");
                    
                    }
                    break;
                default: break;

            }


        }

        private void info(string nom, float bak, float rashod)
        {
            Console.WriteLine("Введите номера машины: ");
            this.nom = Console.ReadLine();
            Console.WriteLine("Введите количество бензина в машине (максимум 55): ");
            this.bak = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите расход топлива машины: ");
            this.rashod = float.Parse(Console.ReadLine());

        }

        private void output()
        {
            Console.WriteLine("Номер машины: " + this.nom);
            Console.WriteLine("Количество бензина в машине: " + this.bak);
            Console.WriteLine("Расход топлива: " + this.rashod);
            Console.WriteLine("Пробег: " + probeg);

        }

        private void zapravka(int top)
        {
            this.bak += top;

        }

        private void move(int km)
        {
            this.rasst = 0;
            int ostatokKm;
            raschetKm();
            if (this.bak - (this.km * this.rashod / 100) >= 0) //  если бензина хватает, чтобы доехать
            {
                this.bak = Convert.ToInt32(this.bak - this.km * this.rashod / 100);
                raschetProbeg(this.km);
                this.rasst += this.km;
                Console.WriteLine("Вы успешно проехали заданное расстояние");

            }
            else //если бензина не хватит
            {
                ostatokKm = (int)(this.bak / (this.rashod / 100));
                Console.WriteLine("Вы проехали " + ostatokKm);
                this.bak = 0;
                this.km -= ostatokKm;
                raschetProbeg(ostatokKm);

                Console.WriteLine("Чтобы проехать полное расстояние требуется заправка. Едем на заправку? да/нет");
                string otvet = Console.ReadLine();

                switch (otvet)
                {
                    case "да":

                        top = 1;
                        while ((this.rashod / 100 * this.km) > this.bak && top != 0)
                        {

                            Console.WriteLine("Сколько бензина залить? Чтобы доехать  требуется " + (this.rashod / 100 * this.km) + " литров. " +
                                "\nЕсли введете 0, движение прекратится." +
                                " \nВведите -1, если хотите узнать информацию о машине");
                            top = Convert.ToInt32(Console.ReadLine());
                            if (top == 0)
                            {

                                return;

                            }
                            else if (top == -1)
                            {
                                this.output();

                            }

                            else if (top > 55 - this.bak)
                            {
                                Console.WriteLine("Могу дозаправить максимум  " + (55 - this.bak) + ". Объем бака 55л"); //бак 55 литров
                                top = 55 - this.bak;
                                zapravka(top);
                            }
                            else
                            {
                                zapravka(top);
                            }

                            if (this.bak >= (this.rashod / 100 * this.km)) //если в баке  хватает топлива, чтобы доехать
                            {
                                ostatokKm = this.km;
                                this.rasst += ostatokKm;
                                raschetProbeg(ostatokKm);

                                this.bak = Convert.ToInt32(Math.Ceiling(this.bak - (this.rashod / 100 * this.km)));
                                this.km = 0;

                            }
                            else //если еще не хватает, чтобы доехать
                            {
                                ostatokKm = (int)(this.bak / (this.rashod / 100));
                                this.km = this.km - ostatokKm;
                                this.bak = 0;
                                this.rasst += ostatokKm; //считает расстояние за эту поездку
                                raschetProbeg(ostatokKm);

                            }


                        }
                        break;

                    case "нет": //если на заправку ехать отказались
                        this.km = (int)(this.bak / (this.rashod / 100));
                        this.rasst += this.km;
                        raschetProbeg(this.km);
                        break;

                }


            }



        }

        private void tormoz()
        {
            Console.WriteLine("Введите текущую скорость: ");
            this.speed = float.Parse(Console.ReadLine());
            Console.WriteLine("На сколько км/ч сбросить скорость? ");
            float sbros = float.Parse(Console.ReadLine());
            this.speed -= sbros;
            Console.WriteLine("измененная скорость: " + this.speed);

        }

        private void razgon()
        {
            Console.WriteLine("Введите текущую скорость: ");
            this.speed = float.Parse(Console.ReadLine());
            Console.WriteLine("На сколько км/ч увеличить скорость? ");
            this.razgonSpeed = float.Parse(Console.ReadLine());
            this.speed += razgonSpeed;
            Console.WriteLine("измененная скорость: " + this.speed);

        }

        private void raschetKm()
        {
            Console.WriteLine("Начальная координата X: ");
            this.beginX = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Начальная координата Y: ");
            this.beginY = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Конечная координата X: ");
            this.endX = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Конечная координата Y: ");
            this.endY = Convert.ToInt32(Console.ReadLine());
            /*      int tempX = this.beginX;
                  int tempY = ((tempX - this.beginX) * (this.endY - this.beginY) / (this.endX - this.beginX)) + this.beginY;

                  for (int i = 0; tempX <= this.endX; i++)
                  {
                    //  this.coordinates.Add("" + tempX + " " + tempY);

                      if (this.endX > this.beginX)
                      {
                          tempX += 1;


                      }
                      else
                      {
                          tempX -= 1;

                      }
                      tempY = ((tempX - this.beginX) * (this.endY - this.beginY) / (this.endX - this.beginX)) + this.beginY;

                  }
      */
            this.km = Convert.ToInt32(Math.Abs(Math.Sqrt(Math.Pow(this.beginX - this.endX, 2) + Math.Pow(this.beginY - this.endY, 2))));
            Console.WriteLine("Рассточние между начальной и конечной координатой " + this.km);
        }

        private void raschetProbeg(double km)
        {
            this.probeg += km;

        }

        private void crash(Avto car2)
        {
            bool crashCheck = false;
            string crashCoor = null;

            for (int k = 0; k < this.coordinates.Count; k++) //первые координаты не учитываю, потому что могут вводиться 0,0 в оба листа
            {
                for (int l = 0; l < car2.coordinates.Count; l++)
                {
                    if (this.coordinates[k] == car2.coordinates[l])
                    {
                        crashCheck = true;
                        crashCoor = this.coordinates[k];

                        break;

                    }


                }

                if (crashCheck == true)

                {

                    break;

                }
            }


            switch (crashCheck)
            {

                case true:
                    Console.WriteLine("Авария!");
                    Console.WriteLine("На координатах " + crashCoor);
                    break;
                case false:
                    Console.WriteLine("Аварии не случилось! :)");
                    break;

            }
          /*  if (crashCheck == false)
            {
                

            }

            else
            {
                

            }

            Console.ReadLine();
*/
        }
        private void coord(int rasst, int beginX, int endX)
        {

            int tempX = this.beginX;

            int count = 0;


            while (count <= this.rasst)
            {

                this.coordinates.Add("" + tempX);
                Console.WriteLine(tempX);

                if (this.endX > this.beginX)
                {
                    tempX += 1;

                }
                else
                {
                    tempX -= 1;

                }
                count += 1;
                //    tempY = ((tempX - this.beginX) * (this.endY - this.beginY) / (this.endX - this.beginX)) + this.beginY;



            }





            //   }


        }

    }
}





