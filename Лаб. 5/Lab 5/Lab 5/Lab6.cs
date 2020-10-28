using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_5
{
    class ProgramGuide
    {
        private List<Film> pgList = new List<Film>();

        public Film this[int i]
        {
            get
            {
                return pgList[i];
            }
            set
            {
                pgList[i] = value;
            }
        }

        public int GetListLength()
        {
            return pgList.Count;
        }
        public void AddProgram(Film newObj)
        {
            pgList.Add(newObj);
        }
        public void RemoveProgram(Film newObj)
        {
            pgList.Remove(newObj);
        }

        public void ShowProgramGuide()
        {
            foreach(var el in pgList)
            {
                Console.WriteLine(el.ToString());
                Console.WriteLine("|");
            }
        }
    }

    static class Controler
    {
        public static void FindSameYear(ProgramGuide pgObj, int year)
        {
            Console.WriteLine($"Фильмы вышедшие в веденном году ({year})");
            for(int i = 0; i < pgObj.GetListLength(); i++ )
            {
                if (pgObj[i] is FeatureFilm)
                {
                    if(((FeatureFilm)pgObj[i]).relDate.year == year)
                        Console.WriteLine(((FeatureFilm)pgObj[i]).ToString());
                }
                if (pgObj[i] is Cartoon)
                {
                    if (((Cartoon)pgObj[i]).relDate.year == year)
                        Console.WriteLine(((Cartoon)pgObj[i]).ToString());
                }
            }
        }
    }
}
