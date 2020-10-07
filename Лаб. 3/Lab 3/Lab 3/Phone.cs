using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_3
{
    partial class Phone
    {
        public const int conversationTimeLimit = 360;
        private readonly int id;
        private string surname;
        private string name;
        private string patronym;
        private string address;
        private int creditCardNumber;
        private int debit;
        private int credit;
        private int cityConversationTime;
        private int intercityConversationTime;
        public static int numberOfItems = 0;
        static Phone() // статический конструктор (инкрементирует кол-во объектов)
        {
            numberOfItems++;
        }
        public string Name
        {
            get
            {
                return name;
            }
            set 
            {
                name = value;
            }
        }

        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
            }
        }
        public string Patronym
        {
            get
            {
                return patronym;
            }
            set
            {
                patronym = value;
            }
        }
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
        public int CreditCardNumber
        {
            get
            {
                return creditCardNumber;
            }
            set
            {
                creditCardNumber = value;
            }
        }
        public int Debit
        {
            get
            {
                return debit;
            }
            set
            {
                debit = value;
            }
        }
        public int CityConversationTime
        {
            get
            {
                return cityConversationTime;
            }
            set
            {
                cityConversationTime = value;
            }
        }
        public int Credit
        {
            get
            {
                return credit;
            }
            set
            {
                credit = value;
            }
        }
        public int InterCityConversationTime
        {
            get
            {
                return intercityConversationTime;
            }
            set
            {
                intercityConversationTime = value;
            }
        }
        public int ID
        {
            get
            {
                return id;
            }
        }

        //private Phone() {}
        public Phone() // конструктор по умолчанию
        {
            Random rand = new Random();
            id = rand.Next(1000, 10000);
            surname = "undef";
            name = "undef";
            patronym = "undef";
            address = "undef";
            creditCardNumber = 0;
            debit = 0;
            credit = 0;
            cityConversationTime = 0;
            intercityConversationTime = 0;
        }

        public Phone(int id, string surname, string name, string patronym, string address, int creditCardNumber, int debit,
            int credit, int cityConversationTime, int intercityConversationTime) // конструктор с параметрами
        {
            this.id = numberOfItems * 1000 + 20 * numberOfItems / 5;
            this.surname = surname;
            this.name = name;
            this.patronym = patronym;
            this.address = address;
            this.creditCardNumber = creditCardNumber;
            this.debit = debit;
            this.credit = credit;
            this.cityConversationTime = cityConversationTime;
            this.intercityConversationTime = intercityConversationTime;
        }

        public void Balance()
        {
            Console.WriteLine($"Текущий баланс с учетом дебета({debit}) и кредита({credit}) составляет - {debit - credit}");
        }

    }

    partial class Phone
    {
        public static int GetNumberOfItems() // статический метод (возвращает количество созданных объектов данного класса
        {
            return numberOfItems;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (this.GetType() != obj.GetType()) return false;
            return true;
        }
        public override int GetHashCode()
        {
            int hash = this.id;
            hash = (hash * 47) + this.GetHashCode();
            return hash;
        }
        public override string ToString()
        {
            return "Type " + base.ToString()
            + id + " "
            + surname + " "
            + name + " "
            + patronym + " "
            + address + " "
            + creditCardNumber + " "
            + debit + " "
            + credit + " "
            + cityConversationTime + " "
            + intercityConversationTime;
        }
    }

    
}
