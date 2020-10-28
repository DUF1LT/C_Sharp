using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_5
{

    public enum Month
    {
        January = 1, February, March, April, May, June, July, August, September, October, November, December 
    }

    public struct ReleaseDate
    {
        public int day;
        public int month;
        public int year;
        public string GetDate()
        {
            return day + "." + month + "." + year;
        }
    }
    interface IDirector
    {
        void Direct();
        void Credits();
    }

    
    interface IAdvertisement
    {
        public void ShowAd()
        {
            Console.WriteLine("~~Реклама~~");
        }

        public void GetMoney()
        {
            Console.WriteLine("~~Получены деньги с рекламы~~");
        }
    }


    public abstract class TVProgram : IAdvertisement
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

        public override string ToString()
        {
            return base.ToString() + " " + name + " " + duration + " " + description;
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

    public abstract class Film : TVProgram, IAdvertisement, IDirector
    {
        protected int ageLimit;
        protected int adAmount;

        public void Direct()
        {
            Console.WriteLine("Фильм срежесирован Вадимом");
        }
        
        void IDirector.Credits()
        {
            Console.WriteLine("Directed by someone");
        }

        public override string ToString()
        {
            return base.ToString() + " " + ageLimit + " ";
        }
        public abstract void Credits();
        public void ShowAd()
        {
            adAmount++;
            Console.WriteLine("~~Реклама~~");
        }

        public void GetMoney()
        {
            Console.WriteLine($"~~Получены деньги с показанных {adAmount} реклам(ы)~~");
        }
        public int GetAdAmount()
        {
            return adAmount;
        }
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
            return base.ToString() + " " + Country;
        }
       

    }

    public class FeatureFilm : Film, IDirector
    {
        public string Actor { get; }
        public readonly ReleaseDate relDate;
        
        
        public FeatureFilm(string name, int duration, string description, int ageLimit, string releaseDate, string actor)
        {
            relDate = new ReleaseDate();
            GetDate(out relDate.day, out relDate.month, out relDate.year);
            void GetDate(out int _day, out int _month, out int _year)
            {
                
                string[] date = releaseDate.Split(".");
                _day = Convert.ToInt32(date[0]);
                switch(Convert.ToInt32(date[1]))
                {
                    case 1:
                        {
                            _month = (int)Month.January;
                            break;
                        }
                    case 2:
                        {
                            _month = (int)Month.February;
                            break;
                        }
                    case 3:
                        {
                            _month = (int)Month.March;
                            break;
                        }
                    case 4:
                        {
                            _month = (int)Month.April;
                            break;
                        }
                    case 5:
                        {
                            _month = (int)Month.May;
                            break;
                        }
                    case 6:
                        {
                            _month = (int)Month.June;
                            break;
                        }
                    case 7:
                        {
                            _month = (int)Month.July;
                            break;
                        }
                    case 8:
                        {
                            _month = (int)Month.August;
                            break;
                        }
                    case 9:
                        {
                            _month = (int)Month.September;
                            break;
                        }
                    case 10:
                        {
                            _month = (int)Month.October;
                            break;
                        }
                    case 11:
                        {
                            _month = (int)Month.November;
                            break;
                        }
                    case 12:
                        {
                            _month = (int)Month.December;
                            break;
                        }
                    default:
                        _month = 0;
                        break;
                }
                _year = Convert.ToInt32(date[2]);
            }
            
            this.name = name;
            this.duration = duration;
            this.description = description;
            this.ageLimit = ageLimit;
            adAmount = 0;
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

        public override string ToString()
        {
            return base.ToString() + relDate.GetDate() + " " + Actor;
        }
       
    }

    public class Cartoon : Film, IDirector
    {
        public string MainCharacter { get; }
        public readonly ReleaseDate relDate;

        public Cartoon(string name, int duration, string description, int ageLimit, string releaseDate, string mainCharacter)
        {
            relDate = new ReleaseDate();
            GetDate(out relDate.day, out relDate.month, out relDate.year);
            void GetDate(out int _day, out int _month, out int _year)
            {

                string[] date = releaseDate.Split(".");
                _day = Convert.ToInt32(date[0]);
                switch (Convert.ToInt32(date[1]))
                {
                    case 1:
                        {
                            _month = (int)Month.January;
                            break;
                        }
                    case 2:
                        {
                            _month = (int)Month.February;
                            break;
                        }
                    case 3:
                        {
                            _month = (int)Month.March;
                            break;
                        }
                    case 4:
                        {
                            _month = (int)Month.April;
                            break;
                        }
                    case 5:
                        {
                            _month = (int)Month.May;
                            break;
                        }
                    case 6:
                        {
                            _month = (int)Month.June;
                            break;
                        }
                    case 7:
                        {
                            _month = (int)Month.July;
                            break;
                        }
                    case 8:
                        {
                            _month = (int)Month.August;
                            break;
                        }
                    case 9:
                        {
                            _month = (int)Month.September;
                            break;
                        }
                    case 10:
                        {
                            _month = (int)Month.October;
                            break;
                        }
                    case 11:
                        {
                            _month = (int)Month.November;
                            break;
                        }
                    case 12:
                        {
                            _month = (int)Month.December;
                            break;
                        }
                    default:
                        _month = 0;
                        break;
                }
                _year = Convert.ToInt32(date[2]);
            }
            this.name = name;
            this.duration = duration;
            this.description = description;
            this.ageLimit = ageLimit;
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

        public override string ToString()
        {
            return base.ToString() + relDate.GetDate() + " " + MainCharacter;
        }
        
    }

    class Printer
    {
        public void IAmPrinting(object someObj)
        {
            Console.WriteLine(someObj.ToString());
        }
    }
}
