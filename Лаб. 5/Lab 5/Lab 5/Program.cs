using System;

namespace Lab_5
{
    class Program
    {
        static void Main(string[] args)
        {
            News newsObj = new News("Russia Today", 70, "Новости о России сегодня", "Россия");
            FeatureFilm ffObj = new FeatureFilm("Interstellar", 250, "Фильм про космос и черные дыры", 16, "26.10.2014", "Matthew MacConaughey");
            Cartoon cartObj = new Cartoon("The Incredibles", 116, "Фильм про суперсемейку", 5, "5.11.2004", "Mr. Incredible");

            newsObj.TurnOn();
            newsObj.VolumeUp();
            Console.WriteLine(newsObj.ToString());

            TVProgram prog = new Cartoon("Смешарики", 40, "Фильм про существ круглого цвета", 2, "2.12.2012", "Крош И Ёжик");
            Console.WriteLine(prog.ToString());

            Console.WriteLine(prog is TVProgram ? "Объект prog есть класс TVProgram" : "Объект prog не есть класс TVProgram");
            Console.WriteLine(newsObj is Film ? "Объект newsObj есть класс Film" : "Объект newsObj не есть класс Film");

            var cartProg = prog as Cartoon;
            if (cartProg != null)
               Console.WriteLine(cartProg.ToString());

            ffObj.Direct();
            ffObj.ShowAd();
            cartObj.ShowAd();
            Printer prt = new Printer();
            TVProgram[] array = new TVProgram[] {cartObj, newsObj, ffObj};
            foreach(var el in array)
            {
                prt.IAmPrinting(el);
                Console.WriteLine();
            }
        }

    }
}
