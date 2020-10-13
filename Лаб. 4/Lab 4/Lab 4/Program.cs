using System;

namespace Lab_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите элементы первого множества(через пробел): ");
            string enteredArray = Console.ReadLine();
            string[] elements = enteredArray.Split(' ');
            int[] enteredElements = new int[elements.Length];
            for (int i = 0; i < elements.Length; i++)
            {
                enteredElements[i] = Convert.ToInt32(elements[i]);
            }
            Set firstSet = new Set(enteredElements);

            Console.WriteLine();
            Console.WriteLine("Введите элементы второго множества(через пробел): ");
            enteredArray = Console.ReadLine();
            elements = enteredArray.Split(' ');
            enteredElements = new int[elements.Length];
            for (int i = 0; i < elements.Length; i++)
            {
                enteredElements[i] = Convert.ToInt32(elements[i]);
            }
            Set secondSet = new Set(enteredElements);

            Console.WriteLine();
            bool exit = false;
            do
            {
                Console.Write($"Выберите множество, в котором хотите проверить элементы на принадлежность(-1 для продолжение): ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case -1:
                        {
                            exit = true;
                            break;
                        }
                    case 1:
                        {
                            Console.WriteLine($"Первое множество: ");
                            firstSet.ShowSet();
                            Console.WriteLine($"Проверка на принадлежность введенных элементов в первом множестве \n(введите элементы через пробел, которые хотите проверить на принадлежность): ");
                            enteredArray = Console.ReadLine();
                            elements = enteredArray.Split(' ');
                            enteredElements = new int[elements.Length];
                            for (int i = 0; i < elements.Length; i++)
                            {
                                enteredElements[i] = Convert.ToInt32(elements[i]);
                            }
                            Console.WriteLine();
                            if (enteredElements > firstSet) Console.WriteLine($"Все введенные элементы принадлежат множеству\n");
                            else Console.WriteLine($"Не все введенные элементы принадлежат множеству\n");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine($"Второе множество: ");
                            secondSet.ShowSet();
                            Console.WriteLine($"Проверка на принадлежность введенных элементов во втором множестве \n(введите элементы через пробел, которые хотите проверить на принадлежность): ");
                            enteredArray = Console.ReadLine();
                            elements = enteredArray.Split(' ');
                            enteredElements = new int[elements.Length];
                            for (int i = 0; i < elements.Length; i++)
                            {
                                enteredElements[i] = Convert.ToInt32(elements[i]);
                            }
                            Console.WriteLine();
                            if (enteredElements > secondSet) Console.WriteLine($"Все введенные элементы принадлежат множеству\n");
                            else Console.WriteLine($"Не все введенные элементы принадлежат множеству\n");
                            break;
                        }
                }
            } while (!exit);

            Console.WriteLine();
            exit = false;
            do
            {
                Console.Write($"Выберите множество, в котором хотите проверить введенное множество на подмножество(-1 для продолжение): ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case -1:
                        {
                            exit = true;
                            break;
                        }
                    case 1:
                        {
                            Console.WriteLine($"Первое множество: ");
                            firstSet.ShowSet();
                            Console.WriteLine($"Проверка на подмножество введенного множества в первом множестве \n(введите множество через пробел): ");
                            enteredArray = Console.ReadLine();
                            elements = enteredArray.Split(' ');
                            enteredElements = new int[elements.Length];
                            for (int i = 0; i < elements.Length; i++)
                            {
                                enteredElements[i] = Convert.ToInt32(elements[i]);
                            }
                            Console.WriteLine();
                            if (enteredElements < firstSet) Console.WriteLine($"Введенное множество является подмножеством данного множества\n");
                            else Console.WriteLine($"Введенное множество не является подмножеством данного множества\n");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine($"Второе множество: ");
                            secondSet.ShowSet();
                            Console.WriteLine($"Проверка на подмножество введенного множества во втором множестве \n(введите множество через пробел): ");
                            enteredArray = Console.ReadLine();
                            elements = enteredArray.Split(' ');
                            enteredElements = new int[elements.Length];
                            for (int i = 0; i < elements.Length; i++)
                            {
                                enteredElements[i] = Convert.ToInt32(elements[i]);
                            }
                            Console.WriteLine();
                            if (enteredElements < secondSet) Console.WriteLine($"Введенное множество является подмножеством данного множества\n");
                            else Console.WriteLine($"Введенное множество не является подмножеством данного множества\n");
                            break;
                        }
                }
            } while (!exit);

            Console.WriteLine("\nПересечение двух введенных множеств: ");
            Set crossedSet = firstSet * secondSet;
            crossedSet.ShowSet();

            firstSet.SetOwner.ToString();
            firstSet.SetDate.ToString();

            



        }
    }
}
