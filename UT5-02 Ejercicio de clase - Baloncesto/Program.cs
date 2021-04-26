using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UT5_02_Ejercicio_de_clase___Baloncesto
{
    class Program
    {
        static void Main(string[] args)
        {
            Jugador lol = new Jugador();

            Console.WriteLine("Vamos a cambiar la altura de {0} a 300", lol.GetNombre());

            try
            {
                lol.SetAltura(300);
            }
            catch (Exception)
            {
                Console.WriteLine("300 es una altura incorrecta, reculemos\n");
                Console.WriteLine("Vamos a cambiar la altura de {0} a 180", lol.GetNombre());
                lol.SetAltura(180);
                
            }



            for (int i = 0; i < 5; i++)
            {
                lol.LanzarCanasta();
            }
            Console.WriteLine();
            lol.GetPuntos();


        }
    }

    class Jugador
    {
        private string nombre;
        private int dorsal, puntos, altura;

        public Jugador()
        {
            Console.WriteLine("DATOS DEL JUGADOR");
            Console.WriteLine("--------------\n");

            do
            {
                Console.Write("Introduzca el nombre: ");
                nombre = Console.ReadLine();

                if (nombre.Length > 20 || nombre == "")
                {
                    Console.WriteLine("Escriba un nombre valido (menos de 20 caracteres o que no este vacio)");
                }

            } while (nombre.Length >20 || nombre == "");

            do
            {
                Console.WriteLine("Escriba el dorsal");
                int.TryParse(Console.ReadLine(), out dorsal);

                if (dorsal < 1 || dorsal > 99)
                {
                    Console.WriteLine("Escribe un dorsal entre el 1 y el 99");
                }

            } while (dorsal<1 || dorsal>99);


            do
            {
                Console.WriteLine("Escribe la altura");
                int.TryParse(Console.ReadLine(), out altura);

                if (altura < 150 || altura > 250)
                {
                    Console.WriteLine("Escribe una altura entre el rango de 150 y 250 cm");
                }

            } while (altura < 150 || altura >250);
        }

        public string MostrarInfo()
        {
            string info = "El jugador se llama " + nombre + " con el dorsal " + dorsal + " y mide " + altura;

            return info;
        } 

        public void LanzarCanasta()
        {
            Console.WriteLine("Pulsa una tecla para lanzar la pelota");
            Console.ReadKey();

            Random r = new Random();
            int rInt = r.Next(0, 100);

            if (rInt <25)
            {
                Console.WriteLine("Has fallado, 0 puntos");
                puntos = puntos + 0;
            }
            else if (rInt >25 &&  rInt < 50)
            {
                Console.WriteLine("Has anotado 1 punto");
                puntos = puntos + 1;
            }
            else if(rInt >50 && rInt < 75)
            {
                Console.WriteLine("Has anotado 2 puntos");
                puntos = puntos + 2;
            }
            else if (rInt > 75 && rInt <=100)
            {
                Console.WriteLine("Has anotado 3 puntos");
                puntos = puntos + 3;
            }
            //Thread.Sleep();
        }

        public void GetPuntos()
        {
            Console.WriteLine("El numero de puntos de "+nombre+" ha sido "+puntos);
        }

        public void SetNombre(string nombre)
        {

            do
            {

                if (nombre.Length > 20 || nombre == "")
                {
                    Console.WriteLine("***ERROR El nombre del jugador debe tener menos de 20 caracteres o no estar vacio)");
                    Console.WriteLine("Vuelva a introducir el nombre");
                    nombre = Console.ReadLine();
                }
            } while (nombre.Length > 20 || nombre == "");

            this.nombre = nombre;
        }

        public void SetAltura(int altura)
        {
            if (altura < 150 || altura > 250)
            {
                throw new Exception("***ERROR La altura del jugador debe estar en el rango 150-250 cm)");
            }

            this.altura = altura;
        }

        public void SetDorsal(int dorsal)
        {
            Console.WriteLine("Escriba el dorsal del jugador");
            int.TryParse(Console.ReadLine(), out dorsal);

            if (dorsal < 1 || dorsal > 99)
            {
                throw new Exception("***ERROR El dorsal del jugador debe estar en el rango 1-99");
            }

            this.dorsal = dorsal;
        }

        public string GetNombre()
        {
            return nombre;
        }

        public int GetAltura(int altura)
        {
            return altura;
        }


    }
}
