namespace Module5_practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var user = EnterUser();
            WriteUser(user);
            Console.ReadLine();

        }

        static (string Name, string LastName, byte Age, string[] petNames, string[] favcolors) EnterUser()
        {
            (string Name, string LastName, byte Age, string[] petNames, string[] favcolors) User = ("","", 0, null, null);
            Console.WriteLine("Введите имя: ");
            User.Name = Console.ReadLine();
            Console.WriteLine("Введите фамилию: ");
            User.LastName = Console.ReadLine();
            Console.WriteLine("Введите возраст (до 102 лет)");
            User.Age = Verify(102);
            Console.WriteLine("У вас есть питомец/питомцы? (Написать 'Да' если есть)");
            var HasPet = Console.ReadLine();
            if (HasPet == "Да")
            {
                Console.WriteLine("Введите количество ваших питомцев(до 10 штук), после чего через Enter вводите их имена:");
                User.petNames = InputArray();
            }
            Console.WriteLine("Введите количество ваших любимых цветов(до 10 штук), после чего через Enter вводите их названия:");
            User.favcolors = InputArray();
            

            return User;
        }

        ///в условии сказано что количество животных, любимых цветов и вохзраст должны быть int-полями, но это странно, во всех вариантах вряд ли будет больше 100. Поэтому я тут свое накрутил:
        static byte Verify(byte maxNumber)
        {
            byte returnNumber = 0;
            do
            {
                var enterString = Console.ReadLine();
                if(byte.TryParse(enterString, out returnNumber))
                {
                    if(returnNumber>maxNumber)
                    {
                        Console.WriteLine("Похоже, что с введеными данными ошибка. Повторите ввод:");
                    }
                }
                else
                {
                    Console.WriteLine("Похоже вы ввели не число. Повторите ввод: ");
                }
                
            } while (returnNumber > maxNumber || returnNumber == 0);
            return returnNumber;
        }

        //так же можно добавать различные вариации, напрмиер для цветов максимум 5, а для животных 15, и просто передавать это доп.значение в метод как аргумент
        static string[] InputArray()
        {
            byte Count = Verify(10);
            string[] input = new string[Count];
            for(int i=0; i<input.Length; i++)
            {
                input[i] = Console.ReadLine();
            }
            return input;
        }

        static void WriteUser((string Name, string LastName, byte Age, string[] petNames, string[] favcolors)User)
        {
            Console.WriteLine("------------Ваша анкета-----------");
            Console.WriteLine("Имя: " + User.Name + "\nФамилия: " + User.LastName + "\nВозраст: " + User.Age);
            if(User.petNames!=null)
            {
                Console.WriteLine("Имена ваших питомцев:");
                foreach(string petName in User.petNames)
                {
                    Console.WriteLine(petName);
                }
            }
            else
            {
                Console.WriteLine("У вас нет питомцев.");
            }
            Console.WriteLine("Ваши любимые цвета:");
            foreach(string color in User.favcolors)
            {
                Console.WriteLine(color);
            }
        }

        
    }
}