using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Text;
using Newtonsoft.Json;

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
            foreach (var el in pgList)
            {
                Console.WriteLine(el.ToString());
                Console.WriteLine("|");
            }
        }
    }

    static class ProgramGuideControler
    {
        public static void FindSameYear(ProgramGuide pgObj, int year)
        {
            Console.WriteLine($"\nФильмы вышедшие в веденном году ({year})");
            for (int i = 0; i < pgObj.GetListLength(); i++)
            {
                if (pgObj[i] is FeatureFilm)
                {
                    if (((FeatureFilm)pgObj[i]).relDate.year == year)
                        Console.WriteLine(((FeatureFilm)pgObj[i]).ToString());
                    continue;
                }
                if (pgObj[i] is Cartoon)
                {
                    if (((Cartoon)pgObj[i]).relDate.year == year)
                        Console.WriteLine(((Cartoon)pgObj[i]).ToString());
                    continue;

                }
            }
        }

        public static void ProgramGuideDuration(ProgramGuide pgObj)
        {
            int finalDuration = 0;
            for (int i = 0; i < pgObj.GetListLength(); i++)
            {
                finalDuration += pgObj[i].Duration;
            }
            Console.WriteLine($"Продолжительность программы передач: {finalDuration}");

        }

        public static void ProgramGuideAdAmount(ProgramGuide pgObj)
        {
            int adAmount = 0;
            for (int i = 0; i < pgObj.GetListLength(); i++)
            {
                adAmount += pgObj[i].GetAdAmount();
            }
            Console.WriteLine($"Количество показанной рекламы: {adAmount}");

        }

        public static List<FeatureFilm> ReadFile(string path)
        {
            List<FeatureFilm> newCollection = new List<FeatureFilm>();
            try
            {

                using (StreamReader strRead = new StreamReader(path))
                {
                    while (!strRead.EndOfStream)
                    {
                        string[] newObjElements = strRead.ReadLine().Split("|");
                        FeatureFilm newObj = new FeatureFilm(newObjElements[0], Convert.ToInt32(newObjElements[1]), newObjElements[2], Convert.ToInt32(newObjElements[3]), newObjElements[4], newObjElements[5]);
                        newCollection.Add(newObj);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return newCollection;
        }
        public static List<FeatureFilm> ReadJson(string path)
        {
            List<FeatureFilm> newCollection = new List<FeatureFilm>();
            try
            {
                using (StreamReader strRead = new StreamReader(path))
                {
                    var reader = new JsonTextReader(new StreamReader(path));
                    JsonSerializer serializer = new JsonSerializer {CheckAdditionalContent = true };
                    while (!strRead.EndOfStream)
                    {
                        newCollection.Add((FeatureFilm)serializer.Deserialize(reader, typeof(FeatureFilm)));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return newCollection;
        }
    }
}

