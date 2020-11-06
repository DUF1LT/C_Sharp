using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Diagnostics;

namespace Lab_5
{
    class Program
    {
        static void Main(string[] args)
        {
            News newsObj = new News("Russia Today", 70, "Новости о России сегодня", "Россия");
            FeatureFilm ffObj = new FeatureFilm("Interstellar", 250, "Фильм про космос и черные дыры", 16, "26.10.2014", "Matthew MacConaughey");
            Cartoon cartObj = new Cartoon("The Incredibles", 116, "Фильм про суперсемейку", 5, "5.11.2004", "Mr. Incredible");
            Cartoon cartObj2 = new Cartoon("Shrek 2", 105, "Фильм про огра", 5, "19.5.2004", "Shrek");

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
            cartObj.ShowAd();

            Printer prt = new Printer();
            TVProgram[] array = new TVProgram[] {cartObj, newsObj, ffObj};
            foreach(var el in array)
            {
                prt.IAmPrinting(el);
                Console.WriteLine();
            }

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~Лабораторная 6~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Logger logger = new Logger();
            Console.WriteLine(cartObj.relDate.GetDate());
            ProgramGuide pg = new ProgramGuide();
            pg.AddProgram(cartObj);
            pg.AddProgram(ffObj);
            pg.AddProgram(cartObj2);
            pg.ShowProgramGuide();
            ProgramGuideControler.FindSameYear(pg, 2004);
            ProgramGuideControler.ProgramGuideDuration(pg);
            ProgramGuideControler.ProgramGuideAdAmount(pg);
            Console.WriteLine();

            //Чтение текстового файла
            string path = @"D:\BSTU stuff\3 семестр 2 курс\ООП\C_Sharp\Лаб. 6\lab6.txt";
            List<FeatureFilm> newCollection = ProgramGuideControler.ReadFile(path);
            foreach (var el in newCollection)
            {
                Console.WriteLine(el.ToString()+ "\n|\nV");
            }
            //Чтение json файла
            
            string path2 = @"D:\BSTU stuff\3 семестр 2 курс\ООП\C_Sharp\Лаб. 6\lab6json.txt";
            try
            {
                newCollection = ProgramGuideControler.ReadJson(path2);
                foreach (var el in newCollection)
                {
                    Console.WriteLine(el.ToString() + "\n|\nV");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                logger.AddLog(e);
            }

            ///////////////////////////////Лаб. 7////////////////////////

            int[] arrayExc = new int[5] { 1, 2, 3, 4, 5 };
            Console.WriteLine("Введите элемент массива, к которому хотите получить доступ");
            int index;
            try
            {
                if (!Int32.TryParse(Console.ReadLine(), out index))
                    throw new WrongInputException("Введен не целое число!");
                try
                {
                    if (index >= arrayExc.Length && index <= 0)
                        throw new IndexOutOfRangeException("Введен неверный индекс!");
                    Console.WriteLine(arrayExc[index]);
                }
                catch(IndexOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    logger.AddLog(ex);

                }
            }
            catch (WrongInputException e)
            {
                Console.WriteLine(e.Message);
                logger.AddLog(e);

            }

            Console.WriteLine("Введите делимое и делитель, чтобы произвести деление");
            int firstInt = Convert.ToInt32(Console.ReadLine());
            int secondInt = Convert.ToInt32(Console.ReadLine());
            try
            {
                if (secondInt == 0)
                    throw new DivideByZeroException("Делитель не должен быть равен 0!");
                Console.WriteLine(firstInt/secondInt);
            }
            catch(DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
                logger.AddLog(ex);

            }
            Console.WriteLine(logger.ToString());
            string path3 = @"D:\BSTU stuff\3 семестр 2 курс\ООП\C_Sharp\Лаб. 6\log.txt";
            logger.ToFile(path3);
            Debug.Assert(false, "Конец программы");
        }

    }
}
