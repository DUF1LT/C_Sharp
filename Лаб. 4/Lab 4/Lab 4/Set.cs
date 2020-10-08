using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_4
{
    class Set
    {
        private int[] elements;

        public Set() 
        {
            elements = new int[] { 1, 2, 3, 4, 5 };
        }
        public Set(int[] array)
        {
            elements = array;
            SelfCheck();
        }

        public void SelfCheck()
        {
            bool isChanged = false;
            for(int i = 0; i < elements.Length; i++)
            {
                for(int j = i + 1; j < elements.Length; j++)
                {
                    if(elements[i] == elements[j])
                    {
                        int addVar = elements[elements.Length - 1];
                        elements[elements.Length - 1] = elements[j];
                        elements[j] = elements[elements.Length - 1];
                        Array.Resize<int>(ref elements, elements.Length - 1);
                        isChanged = true;
                    }
                }
            }
            if (isChanged) Console.WriteLine($"Обнаружены повторяющиеся элементы в множестве.\n Множество изменено");
            else Console.WriteLine("Множество корректно");
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
            foreach(int elInSubset in subset)
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
            if (matches == obj.elements.Length) return true;
            else return false;
        }
        public static int[] operator *(Set obj1, Set obj2)
        {
            int crossedLenght;
            int crossedPos = 0;
            if (obj1.elements.Length >= obj2.elements.Length)
                crossedLenght = obj1.elements.Length;
            else
                crossedLenght = obj2.elements.Length;

            int[] crossedElements = new int[crossedLenght];

            foreach(int obj1el in obj1.elements)
            {
                foreach (int obj2el in obj2.elements)
                {
                    if(obj1el == obj2el)
                    {
                        crossedElements[crossedPos++] = obj1el;
                        break;
                    }
                }
            }
            Array.Resize<int>(ref crossedElements, crossedPos + 1);
            return crossedElements;
        }
    }
}
