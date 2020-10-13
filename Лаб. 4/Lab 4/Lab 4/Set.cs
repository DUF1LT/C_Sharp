using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_4
{
    class Set
    {
        internal int[] elements;
        public Owner SetOwner;
        public Date SetDate;
        public Set()
        {
            elements = new int[] { 1, 2, 3, 4, 5 };
            SetOwner = new Owner();
            SetDate = new Date();
        }
        public Set(int[] array)
        {
            elements = new int[array.Length];
            array.CopyTo(elements, 0);
            SelfCheck();
            SetOwner = new Owner();
            SetDate = new Date();
        }

        public int this[int i]
        {
            get
            {
                if (i >= 0 && i < elements.Length) return elements[i];
                else return 0;
            }
        }
        public void SelfCheck()
        {
            bool isChanged = false;
            for (int i = 0; i < elements.Length; i++)
            {
                for (int j = i + 1; j < elements.Length; j++)
                {
                    if (elements[i] == elements[j])
                    {
                        int addVar = elements[^1]; // ^ = 'elements.Length -'
                        elements[^1] = elements[j];
                        elements[j] = addVar;
                        Array.Resize<int>(ref elements, elements.Length - 1);

                        isChanged = true;
                    }
                }
            }
            Array.Sort(elements);
            if (isChanged)
            {
                Console.WriteLine($"~Обнаружены повторяющиеся элементы в множестве\n!!Множество изменено!!");
                ShowSet();
            }
        }

        public void ShowSet()
        {
            for (int i = 0; i < elements.Length; i++)
            {
                Console.Write(this.elements[i] + " ");
            }
            Console.WriteLine();
        }

        public static bool operator >(int[] numbers, Set obj)
        {
            int amountIsInSet = 0;
            foreach (int number in numbers)
            {
                bool isInSet = false;
                foreach (int el in obj.elements)
                {
                    if (number == el)
                    {
                        Console.WriteLine($"Элемент {number} принадлежит данному множеству");
                        isInSet = true;
                        amountIsInSet++;
                        break;
                    }
                }
                if (!isInSet) Console.WriteLine($"Элемент {number} не принадлежит данному множеству");
            }
            if (amountIsInSet == numbers.Length) return true;
            else return false;
        }
        public static bool operator <(int[] subset, Set obj)
        {
            int matches = 0;
            foreach (int elInSubset in subset)
            {
                foreach (int elInObj in obj.elements)
                {
                    if (elInSubset == elInObj)
                    {
                        matches++;
                        break;
                    }
                }
            }
            if (matches == subset.Length) return true;
            else return false;
        }
        public static Set operator *(Set obj1, Set obj2)
        {
            int crossedLenght;
            int crossedPos = 0;
            if (obj1.elements.Length >= obj2.elements.Length)
                crossedLenght = obj1.elements.Length;
            else
                crossedLenght = obj2.elements.Length;
            int[] crossedElements = new int[crossedLenght];

            foreach (int obj1el in obj1.elements)
            {
                foreach (int obj2el in obj2.elements)
                {
                    if (obj1el == obj2el)
                    {
                        crossedElements[crossedPos++] = obj1el;
                        break;
                    }
                }
            }

            Array.Resize<int>(ref crossedElements, crossedPos);
            Set crossedSet = new Set(crossedElements);
            return crossedSet;
        }

       
        internal class Owner
        {

            private string Id { get; }
            private string Name {get; }
            private string Organisation { get; }


            public Owner()
            {
                Console.WriteLine("Введите ID создателя объекта: ");
                Id = Console.ReadLine();
                Console.WriteLine("Введите имя создателя объекта: ");
                Name = Console.ReadLine();
                Console.WriteLine("Введите название организации создателя объекта: ");
                Organisation = Console.ReadLine();
            }

            public override string ToString()
            {
                return $"ID владельца - {Id},\nИмя владельца - {Name},\nОрганизация - {Organisation} ";
            }

        }
        public class Date
        {
            private int Day { get; }
            private int Month { get; }
            private int Year { get; }

            public Date()
            {
                DateTime date = DateTime.Now;
                Day = date.Day;
                Month = date.Month;
                Year = date.Year;
            }

            public override string ToString()
            {
                return $"Дата создания объекта\n{Day}.{Month}.{Year} ";
            }

            public static explicit operator Date(Set obj)
            {
                return obj.SetDate;
            }
        }


    }


    static class StaticOperation
    {
        public static int FirstNum(this String str)
        {
            string[] elements = str.Split(' ');
            for (int i = 0; i < elements.Length; i++)
            {
                if (Int32.TryParse(elements[i], out _)) return Convert.ToInt32(elements[i]);
                else continue;
            }
            return 0;
        }

        public static bool DeletePositive(this Set set)
        {
            int addVar;
            bool deletedOnce = false;
            for(int i = 0; i < set.elements.Length; i++)
            {
                if(set.elements[i] >= 0)
                {
                    deletedOnce = true;
                    addVar = set.elements[i];
                    set.elements[i] = set.elements[set.elements.Length - 1];
                    set.elements[set.elements.Length - 1] = addVar;
                    Array.Resize<int>(ref set.elements, set.elements.Length - 1);
                }
            }
            return deletedOnce;
        }

        public static int Summ(Set set)
        {
            int summ = 0;
            foreach (int el in set.elements)
            {
                summ += el;
            }
            return summ;
        }

        public static int MaxMinDiff(Set set)
        {
            int max = 0;
            int min = set.elements[0];
            foreach (int el in set.elements)
            {
                if (el > max) max = el;
                if (el < min) min = el;
            }

            return (max - min);
        }

        public static int ElementsAmount(Set set)
        {
            int amount = 0;
            foreach (int el in set.elements)
            {
                amount++;
            }
            return amount;
        }


    }
}
