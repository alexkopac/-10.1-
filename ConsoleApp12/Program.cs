using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    public class Play
    {
        private string title;
        private string autFullNum;
        private string genre;
        private int relYear;

        
        public string Title
        {
            get { return title; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Назва п'єси не може бути порожньою.");
                }
                title = value;
            }
        }

        // Властивість для ПІБ автора
        public string AutFullNum
        {
            get { return autFullNum; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("ПІБ автора не може бути порожнім.");
                }
                autFullNum = value;
            }
        }

        
        public string Genre
        {
            get { return genre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Жанр не може бути порожнім.");
                }
                genre = value;
            }
        }

        
        public int ReleaseYear
        {
            get { return relYear; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Рік випуску має бути позитивним числом.");
                }
                relYear = value;
            }
        }

       
        public Play(string title, string autFullNum, string genre, int relYear)
        {
            Title = title;
            AutFullNum = autFullNum;
            Genre = genre;
            ReleaseYear = relYear;
        }

        
        public void DisplayPlayInfo()
        {
            Console.WriteLine($"Назва п'єси: {Title}");
            Console.WriteLine($"Автор: {AutFullNum}");
            Console.WriteLine($"Жанр: {Genre}");
            Console.WriteLine($"Рік випуску: {ReleaseYear}");
        }

        
        ~Play()
        {
            Console.WriteLine($"Об'єкт п'єси \"{Title}\" знищено.");
            
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            

            
            Play hamlet = new Play("Гамлет", "Вільям Шекспір", "Трагедія", 1603);
            Console.WriteLine("Інформація про п'єсу:");
            hamlet.DisplayPlayInfo();
            Console.WriteLine();

           
            hamlet.Genre = "Драма";
            hamlet.ReleaseYear = 1609;
            Console.WriteLine("Інформація про п'єсу після змін:");
            hamlet.DisplayPlayInfo();
            Console.WriteLine();

            
            try
            {
                Play emptyTitlePlay = new Play("", "Автор", "Жанр", 2023);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Помилка при створенні п'єси: {ex.Message}");
            }

            Console.WriteLine("\nПеревірка роботи деструктора:");
            CreateAndDestroyPlay("Вишневий сад", "Антон Чехов", "Драма", 1904);
            Console.WriteLine("Закінчення методу Main.");

            
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.WriteLine("Збирач сміття завершив роботу (можливо, деструктор вже спрацював).");
        }

        
        static void CreateAndDestroyPlay(string title, string author, string genre, int year)
        {
            Play playTD = new Play(title, author, genre, year);
            Console.WriteLine($"Створено об'єкт п'єси \"{playTD.Title}\" у методі.");
            
        }
    }
}
