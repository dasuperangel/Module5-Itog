using System;

namespace ConsoleApp3
{
    internal class Programm
    {
        public static (string Name, string LastName, int Age, int CountPet, string[] Nickname, int CountBand, string[] favoriteBand) GetInfoUser()
        {
            (string Name, string LastName, int Age, int CountPet, string[] Nickname, int CountBand, string[] favoriteBand) User;

            Console.WriteLine("Введите Ваше имя:");
            User.Name = Console.ReadLine();

            Console.WriteLine("Введите Вашу фамилию:");
            User.LastName = Console.ReadLine();

            string age;
            int intage;
            do
            {
                Console.WriteLine("Введите Ваш возраст:");
                age = Console.ReadLine();

            } while (CheckEnterData(age, out intage));

            User.Age = intage;

            Console.WriteLine("Есть ли у вас питoмец? Напишите да или нет");
            string Pet = (Console.ReadLine());

            if (Pet == "да")
            {
                string numberpet;
                int intnumberpet;
                do
                {
                    Console.WriteLine("Введите количество питомцев");
                    numberpet = Console.ReadLine();

                } while (CheckEnterData(numberpet, out intnumberpet));

                User.CountPet = intnumberpet;

                User.Nickname = GetNickNamePet(User.CountPet);
            }
            else
            {
                User.CountPet = 0;
                User.Nickname = new string[1];
                User.Nickname[0] = "У вас нет ни одного питомца";
            }

            string numberband;
            int intband;

            do
            {
                Console.WriteLine("Введите количество любимых метал банд");
                numberband = Console.ReadLine();

            } while (CheckEnterData(numberband, out intband));

            User.CountBand = intband;

            User.favoriteBand = GetFavoriteBands(User.CountBand);


            return User;
        }

        public static string[] GetNickNamePet(int num)
        {
            string[] NickNamePet = new string[num];
            for (int i = 0; i < NickNamePet.Length; i++)
            {
                Console.WriteLine("Введите кличку животного " + (i + 1));
                NickNamePet[i] = Console.ReadLine();
            }
            return NickNamePet;
        }

        public static string[] GetFavoriteBands(int num)
        {
            string[] Favoritebands = new string[num];
            for (int i = 0; i < Favoritebands.Length; i++)
            {
                Console.WriteLine("Введите название любимой банды " + (i + 1));
                Favoritebands[i] = Console.ReadLine();
            }
            return Favoritebands;
        }

        public static bool CheckEnterData(string checkdata, out int checkintdata)
        {
            if (int.TryParse(checkdata, out int temp))
            {
                if (temp > 0)
                {
                    checkintdata = temp;
                    return false;
                }
            }

            {
                checkintdata = 0;
                return true;
            }
        }

        public static void DisplayDataUser((string Name, string LastName, int Age, int CountPet, string[] Nickname, int CountBand, string[] favoriteBands) User)
        {
            Console.WriteLine("Ваши данные:");

            Console.WriteLine("Ваше имя {0}", User.Name);

            Console.WriteLine("Ваша фаимлия {0}", User.LastName);

            Console.WriteLine("Вам {0} лет", User.Age);

            Console.WriteLine("Вы имеете {0} питомцев", User.CountPet);

            Console.WriteLine("Их зовут:");

            for (int i = 0; i < User.Nickname.Length; i++)
            {
                Console.WriteLine(User.Nickname[i]);
            }
            Console.WriteLine("Количество любимых банд равно {0}", User.CountBand);

            Console.WriteLine("Этими бандами являются:");

            foreach (string item in User.favoriteBands)
            {
                Console.WriteLine(item);
            }
        }


        public static void Main(string[] args)
        {
            var User = GetInfoUser();
            DisplayDataUser(User);
        }
    }
}