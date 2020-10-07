using System;

namespace Lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int anountOfItems = Convert.ToInt32(Console.ReadLine());
            Phone[] phoneArray = new Phone[anountOfItems];
            for(int i = 0; i < anountOfItems; i++)
            {
                phoneArray[i] = new Phone();

                Console.WriteLine("Введите имя абонента: ");
                phoneArray[i].Name = Console.ReadLine();
                Console.WriteLine("Введите фамилия абонента: ");
                phoneArray[i].Surname = Console.ReadLine();
                Console.WriteLine("Введите отчество абонента: ");
                phoneArray[i].Patronym = Console.ReadLine();
                Console.WriteLine("Введите адрес абонента: ");
                phoneArray[i].Address = Console.ReadLine();
                Console.WriteLine("Введите номер кредитной карточки абонента: ");
                phoneArray[i].CreditCardNumber = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите дебет абонента: ");
                phoneArray[i].Debit = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите кредит абонента: ");
                phoneArray[i].Credit = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите время городских разговоров абонента: ");
                phoneArray[i].CityConversationTime = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите время междугородних разговоров абонента: ");
                phoneArray[i].InterCityConversationTime = Convert.ToInt32(Console.ReadLine());
            }


            Console.WriteLine("Сведения об абонентах, у которых время внутригородских разговоров превышает заданное");
            foreach(Phone obj in phoneArray)
            {
                if(obj.CityConversationTime > Phone.conversationTimeLimit)
                {
                    Console.WriteLine($"ID абонента: {obj.ID}");
                    Console.WriteLine($"Имя абонента: {obj.Name}");
                    Console.WriteLine($"Фамилия абонента: {obj.Surname} ");
                    Console.WriteLine($"Отчество абонента: {obj.Patronym}");
                    Console.WriteLine($"Адрес абонента: {obj.Address}");
                    Console.WriteLine($"Номер кредитной карточки абонента: {obj.CreditCardNumber}");
                    Console.WriteLine($"Дебет абонента: {obj.Debit}");
                    Console.WriteLine($"Кредит абонента: {obj.Credit}");
                    Console.WriteLine($"Время городских разговоров абонента: {obj.CityConversationTime}");
                    Console.WriteLine($"Время междугородних разговоров абонента: {obj.InterCityConversationTime}");
                    Console.WriteLine();
                }
            }

            Console.WriteLine("Сведения об абонентах, которые пользовались междугородней связью");
            foreach (Phone obj in phoneArray)
            {
                if (obj.InterCityConversationTime < Phone.conversationTimeLimit)
                {
                    Console.WriteLine($"ID абонента: {obj.ID}");
                    Console.WriteLine($"Имя абонента: {obj.Name}");
                    Console.WriteLine($"Фамилия абонента: {obj.Surname} ");
                    Console.WriteLine($"Отчество абонента: {obj.Patronym}");
                    Console.WriteLine($"Адрес абонента: {obj.Address}");
                    Console.WriteLine($"Номер кредитной карточки абонента: {obj.CreditCardNumber}");
                    Console.WriteLine($"Дебет абонента: {obj.Debit}");
                    Console.WriteLine($"Кредит абонента: {obj.Credit}");
                    Console.WriteLine($"Время городских разговоров абонента: {obj.CityConversationTime}");
                    Console.WriteLine($"Время междугородних разговоров абонента: {obj.InterCityConversationTime}");
                    Console.WriteLine();
                }
            }

            if (anountOfItems > 1)
                Console.WriteLine($"Объект 1 класса Phone идентичен объекту 2 класса Phone - {phoneArray[1].Equals(phoneArray[2])}");

            var user = new { Name = "Vadim", Age = "18" };
            Console.WriteLine($"Имя из анонимного типа - {user.Name}, возраст из анонимного типа {user.Age}");
        }
    }
}
