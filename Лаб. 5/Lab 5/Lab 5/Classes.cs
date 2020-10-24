using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_5
{
    interface IDirector
    {
        void Direct();
        void Credits();
    }

    interface IAdvertisement
    {
        void ShowAd()
        {
            Console.WriteLine("~~Реклама~~");
        }

        void GetMoney()
        {
            Console.WriteLine("~~Получены деньги с рекламы~~");
        }
    }


    public abstract class TVProgram
    {
        protected string name;
        protected int duration;
        protected string description;
        public string Name
        {
            get
            {
                return name;
            }
        }
        public int Duration
        {
            get
            {
                return duration;
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
        }

        public virtual void VolumeUp() 
        {
            Console.WriteLine("Громкость увеличена");
        }
        public virtual void VolumeDown()
        {
            Console.WriteLine("Громкость уменьшена");
        }

        public abstract void TurnOn();
        public abstract void TurnOff();
       
    }

    public abstract class Film : TVProgram, IAdvertisement
    {
        protected int ageLimit;
        protected string releaseDate;

        public void Direct()
        {
            Console.WriteLine("Фильм срежесирован Вадимом");
        }
 
        public abstract void Credits();
    }

    public sealed class News : TVProgram, IAdvertisement
    {
        public string Country { get; }
        public News(string name, int duration, string description, string country)
        {
            this.name = name;
            this.duration = duration;
            this.description = description;
            Country = country;
        }

        public override void TurnOn()
        {
            Console.WriteLine("Новости включены");
        }

        public override void TurnOff()
        {
            Console.WriteLine("Новости выключены");
        }

        public string GetCountry()
        {
            Console.WriteLine(Country);
            return Country;
        }

        public override string ToString()
        {
            return base.ToString() + name + " " + duration + " " + description + " " + Country + " ";
        }
    }

    public class FeatureFilm : Film, IDirector
    {
        public string Actor { get; }

        public FeatureFilm(string name, int duration, string description, int ageLimit, string releaseDate, string actor)
        {
            this.name = name;
            this.duration = duration;
            this.description = description;
            this.ageLimit = ageLimit;
            this.releaseDate = releaseDate;
            Actor = actor;
        }
        public override void TurnOn()
        {
            Console.WriteLine("Художественный фильм включен");
        }

        public override void TurnOff()
        {
            Console.WriteLine("Художественный фильм выключен");
        }

        void IDirector.Credits()
        {
            Console.WriteLine("directed by robert b weide");
        }
        public override void Credits()
        {
            Console.WriteLine("~~Титры к худ. фильму~~");
        }
    }

    public class Сartoon : Film, IDirector
    {
        public string MainCharacter { get; }

        public Сartoon(string name, int duration, string description, int ageLimit, string releaseDate, string mainCharacter)
        {
            this.name = name;
            this.duration = duration;
            this.description = description;
            this.ageLimit = ageLimit;
            this.releaseDate = releaseDate;
            MainCharacter = mainCharacter;
        }

        public override void TurnOn()
        {
            Console.WriteLine("Мультфильм включен");
        }

        public override void TurnOff()
        {
            Console.WriteLine("Мультфильм выключен");
        }

        void IDirector.Credits()
        {
            Console.WriteLine("directed by robert b weide");
        }
        public override void Credits()
        {
            Console.WriteLine("~~Титры к мультфильму~~");
        }
    }
}
