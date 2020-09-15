using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace LAB_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //value type 
            bool boolType = false; // true of false flag
            byte byteType = 255; // 0 to 255 - usigned byte
            sbyte sbyteType = -128; //-128 to 127 - signed byte
            char charType = 'T'; // Any single symbol ('')
            decimal decType = 2.4325224412412124121m; // 28-29 digits
            double doubType = 2.42132131212; // ~15-17 digits
            float fType = 2.32324f; //~6-9 digits
            int intType = 23441412; // signed 32-bit 
            uint uintType = 343243342; // unsigned 32-bit
            long longType = 24241241124124; // signed 64-bit
            ulong ulongType = 1242345893458234254; //unsigned 64-bit
            short shortType = 32767; // signed 16-bit
            ushort ushortType = 64342; //unsigned 16-bit

            //implicit conversion (неявное приведение)
            int implicitConvInt = 2454354;
            long implicitConvLong = implicitConvInt;

            short implicitConvShort = 2324;
            implicitConvInt = implicitConvShort;

            uint implicitConvUint = 421312321;
            implicitConvLong = implicitConvUint;

            byte implicitConvByte = 120;
            implicitConvShort = implicitConvByte;

            ushort implicitConvUshort = 23424;
            implicitConvInt = implicitConvUshort;

            //Explicit conversion (явное приведение)
            double explicitConvDouble = 23345.3;
            int explicitConvInt = (int)explicitConvDouble;

            sbyte explicitConvSbyte = 120;
            byte explicitConvByte = (byte)explicitConvSbyte;

            float explicitConvFloat = 23.42342f;
            explicitConvDouble = explicitConvFloat;

            decimal explicitConvDec = (decimal)explicitConvDouble;

            explicitConvByte = (byte)explicitConvFloat;

            //Convert

            bool convertBool = Convert.ToBoolean(intType);

            //boxing and unboxing (упаковка и распаковка)

            int boxingInt = 123;
            object intBox = boxingInt;
            int unboxingInt = (int)boxingInt;

            // неявная типизация 
            var Variable = 5;
            Console.WriteLine("Тип неявно типизированной переменной -  " + Variable.GetType());

            //Nullable 
            int? nullInt = null; // неопределенное значение типа int
            Console.WriteLine("Переменная nullInt хранит значение - " + nullInt.HasValue);

            var Var = 5;
            //Var = "Hello"; - Error



            //STRING 

            Console.WriteLine();

            string str1 = "Hello";
            string str2 = " World";
            Console.WriteLine("Строка 1: " + str1);
            Console.WriteLine("Строка 2: " + str2);


            Console.WriteLine(String.Compare(str1, str2) == 0 ? "Строки одинаковы" : "Строки не одинаковы");

            string str3 = String.Copy(str1);

            str3 += str2;
            Console.WriteLine("Присоединенная строка - " + str3);

            Console.WriteLine("Подстрока с 3 элемента строки 3 - " + str3.Substring(2));

            string[] strArr;
            strArr = str3.Split(' ');

            int counter = 1;
            foreach (string word in strArr)
            {
                Console.WriteLine("Слово: " + counter + " " + word);
                counter++;
            }


            string str4 = str3.Insert(str3.Length / 2, "!");
            Console.WriteLine("Строка 4 с добавлением символа в середину: " + str4);

            str4 = str4.Remove(0, 7);

            Console.WriteLine("Строка 4 с удаленной подстрокой: " + str4);

            //string interpolation

            Console.WriteLine();
            Console.WriteLine($"Это строка 1: \"{str1}\", это строка 2:  \"{str2}\", это строка 3: \"{str3}\", а это строка 4 \"{str4}\" ");

            string emptyStr = "";
            string nullStr = null;
            Console.WriteLine($"Строка emptyStr пустая или null-строка  - {String.IsNullOrEmpty(emptyStr)} , строка nullStr пустая или null-строка - {String.IsNullOrEmpty(nullStr)} ");

            Console.WriteLine();
            StringBuilder strBuilderExample = new StringBuilder("Это строка, созданная с помощью StringBuilder", 80);

            Console.WriteLine($"Строка StringBuilder - {strBuilderExample}");

            strBuilderExample.Remove(0, 3);
            Console.WriteLine($"Строка StringBuilder - {strBuilderExample}");

            strBuilderExample.Insert(0, "\"Добавление в начало\"");
            Console.WriteLine($"Строка StringBuilder - {strBuilderExample}");

            strBuilderExample.Append("\"Добавление в конец\"");
            Console.WriteLine($"Строка StringBuilder - {strBuilderExample}");

            //ARRAYS
            Console.WriteLine();

            Console.WriteLine("Двумерный массив: ");
            int[,] matrix = { { 2, 4, 6 }, { 3, 5, 7 } };
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Введите кол-во элементов в массиве строк");
            int sizeOfArr = Convert.ToInt32(Console.ReadLine());
            string[] stringArr = new string[sizeOfArr];
            for (int co = 0; co < sizeOfArr; co++)
            {
                Console.WriteLine("Введите слово №" + (co + 1));
                stringArr[co] = Console.ReadLine();
            }
            Console.WriteLine("Введеные слова: ");
            for (int co = 0; co < sizeOfArr; co++)
            {
                Console.WriteLine(stringArr[co]);
            }
            Console.WriteLine("Укажите позицию слова, которое хотите поменять, и заменяющее слово: ");
            while (true)
            {
                Console.Write("Позиция: "); int pos = Convert.ToInt32(Console.ReadLine());
                if (pos <= sizeOfArr && pos > 0)
                {
                    Console.Write("Заменяющее слово: "); string subsWord = Console.ReadLine();
                    stringArr[pos - 1] = subsWord;
                    Console.WriteLine("Слово изменено!");
                    Console.WriteLine("Итог: ");
                    for (int co = 0; co < sizeOfArr; co++)
                    {
                        Console.WriteLine(stringArr[co]);
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Введена неверная позиция");
                }
            }

            Console.WriteLine();

            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[2];
            jaggedArray[1] = new int[3];
            jaggedArray[2] = new int[4];
            Console.WriteLine("Введите значения ступенчатого массива: ");
            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        {
                            for (int j = 0; j < jaggedArray[0].Length; j++)
                            {
                                jaggedArray[i][j] = Convert.ToInt32(Console.ReadLine());
                            }
                            break;
                        }
                    case 1:
                        {
                            for (int j = 0; j < jaggedArray[1].Length; j++)
                            {
                                jaggedArray[i][j] = Convert.ToInt32(Console.ReadLine());
                            }
                            break;
                        }
                    case 2:
                        {
                            for (int j = 0; j < jaggedArray[2].Length; j++)
                            {
                                jaggedArray[i][j] = Convert.ToInt32(Console.ReadLine());
                            }
                            break;
                        }
                }
            }

            Console.WriteLine("Итоговый массив: ");
            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        {
                            for (int j = 0; j < jaggedArray[0].Length; j++)
                            {
                                Console.Write(jaggedArray[i][j] + " ");
                            }
                            Console.WriteLine();
                            break;
                        }
                    case 1:
                        {
                            for (int j = 0; j < jaggedArray[1].Length; j++)
                            {
                                Console.Write(jaggedArray[i][j] + " ");
                            }
                            Console.WriteLine();
                            break;
                        }
                    case 2:
                        {
                            for (int j = 0; j < jaggedArray[2].Length; j++)
                            {
                                Console.Write(jaggedArray[i][j] + " ");
                            }
                            Console.WriteLine();
                            break;
                        }

                }
            }

            Console.WriteLine();

            var implicitTypedArray = new[] { 2, 3, 4 };
            Console.WriteLine("Неявно типизированный массив:");
            foreach (var el in implicitTypedArray)
            {
                Console.Write(el + " ");
            }
            Console.WriteLine();
            var implTypingString = "Hello Everyone";
            Console.WriteLine("Неявно типизированная строка:");
            Console.WriteLine(implTypingString);

            Console.WriteLine();

            (int, string, char, string, ulong) tuple = (2, "Hello", 'a', "World", 24124124);
            ValueTuple<int, string, char, string, ulong> tupleEx1 = (2, "Hello", 'a', "World", 24124124);
            var tupleEx2 = (2, "Hello", 'a', "World", 24124124);

            Console.WriteLine("Элементы кортежа:");

            Console.WriteLine($"Элемент кортежа 1: {tuple.Item1};\nЭлемент кортежа 2: {tuple.Item2};\nЭлемент кортежа 3: " +
                $"{tuple.Item3};\nЭлемент кортежа 4: {tuple.Item4};\nЭлемент кортежа 5: {tuple.Item5};");

            Console.WriteLine();

            Console.WriteLine($"Элемент кортежа 1: {tuple.Item1};\nЭлемент кортежа 3: " +
                $"{tuple.Item3};\nЭлемент кортежа 4: {tuple.Item4};");


            (int, string, char, string, ulong) tuple2 = (3, "Bye", 'b', "Mom", 2464654);
           

            (int intTup, string strTup, char chTup, string str2Tup, ulong ulTup) = tuple;
            (intTup, _, _, str2Tup, _) = tuple2;


            Console.WriteLine();

            Console.WriteLine($"Кортеж 1 равен кортежу 2 - {tuple.Equals(tuple2)}");

            Console.WriteLine();


            int[] newArr = { 1, 4, 6, 0, -1, 2, 10, -4 };
            string newWord = "Hello World again";
            (int, int, int, char) localFunction(int [] array, string word)
            {
                int max = 0, min = array[0], summ = 0;
                char firstChar;
                for(int i = 0; i < array.Length; i++)
                {
                    if(min < array[i])
                    {
                        min = array[i];
                    }
                    if(max > array[i])
                    {
                        max = array[i];
                    }
                    summ += array[i];
                }
                firstChar = word[0];

                (int, int, int, char) returned = (min, max, summ, firstChar);

                return returned;
            }
            (int, int, int, char) returnedTuples = localFunction(newArr, newWord);

            Console.WriteLine($"Минимальный элемент в массиве - {returnedTuples.Item1}, максимальный элемент в массиве - {returnedTuples.Item2}, " +
                $"сумма элементов в массиве - {returnedTuples.Item3}, первый символ в строке - {returnedTuples.Item4} ");

            Console.WriteLine();
            
            void checkedFunc()
            {
               checked 
                {
                    int maxInt = 2147483647;
                }

            }
            void uncheckedFunc()
            {
                unchecked
                {
                    int maxInt = 2147483647;
                }
            }

            checkedFunc();
            uncheckedFunc();

        }
    }
}
