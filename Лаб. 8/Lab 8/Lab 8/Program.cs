using System;
using Lab_5;

namespace Lab_8
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intArray = new int[] { 1, 2, 3, 4, 5 };
            Set<int> intSet = new Set<int>(intArray);
            intSet.LookUp();
            intSet.Delete(2);
            intSet.LookUp();
            intSet.Add(10);
            intSet.Sort();
            intSet.LookUp();
            float[] floatArray = new float[] { 1.2f, 2.4f, 3.6f, 4.2f, 5.56f };
            Set<float> floatSet = new Set<float>(floatArray);
            floatSet.LookUp();
            floatSet.Delete(2);
            floatSet.LookUp();
            floatSet.Add(10);
            floatSet.Sort();
            floatSet.LookUp();
            News newsObj = new News("Russia Today", 70, "Новости о России сегодня", "Россия");
            FeatureFilm ffObj = new FeatureFilm("Interstellar", 250, "Фильм про космос и черные дыры", 16, "26.10.2014", "Matthew MacConaughey");
            Cartoon cartObj = new Cartoon("The Incredibles", 116, "Фильм про суперсемейку", 5, "5.11.2004", "Mr. Incredible");
            Cartoon cartObj2 = new Cartoon("Shrek 2", 105, "Фильм про огра", 5, "19.5.2004", "Shrek");
            TVProgram[] tvArr = new TVProgram[] { newsObj, ffObj, cartObj, cartObj2 };
            Set<TVProgram> tvSet = new Set<TVProgram>(tvArr);
            tvSet.LookUp();
            tvSet.Delete(ffObj);
            tvSet.LookUp();
            tvSet.Add(newsObj);
            tvSet.Sort();
            tvSet.LookUp();
            tvSet.ToFile(@"D:\BSTU stuff\3 семестр 2 курс\ООП\C_Sharp\Лаб. 8\new.txt");
        }
    }
}
