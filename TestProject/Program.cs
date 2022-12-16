namespace TestProject
{
    /** Первая тестовая задача.
    В классе Array создаётся одномерный массив из 10 элементов, заполненный случайными числами от -10 до 10. Далее он передаётся в класс GenericsMethods<P>.
    В классе GenericsMethods<P> реализуются методы замены значений двух элементов массива, а также поиска максимального и минимального значений массива, 
    его суммы и его сортировки пузырьком.
    В классе Vision находится метод Main, который запускает все методы по порядку.

    class Array
    {
        public void massivegeneration()
        {
            int[] arr = new int[10];
            Random rand = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(-10, 10);
                Console.WriteLine("Элемент " + i + " = " + arr[i]);
            }
            GenericsMethod<int[]>.arr = arr;
        }
    }

    class GenericsMethods<P>
    {
        public static int[]? arr;
        public void Swapgeneration() // Выбор элементов пользователем для замены
        {
            Console.WriteLine("Введите номера элементов, которые хотите переставить");
            string i1, i2;
            i1 = Console.ReadLine();
            i2 = Console.ReadLine();
            Swap<string>(ref i1, ref i2);
        }

        public void Swap<T>(ref string i1, ref string i2) // Замена значений
        {
            int I1 = (int)Convert.ToInt32(i1);
            int I2 = (int)Convert.ToInt32(i2);
            (arr[I2], arr[I1]) = (arr[I1], arr[I2]);
            for (int i = 0; i < arr.Length; i++)
                Console.WriteLine("Элемент " + i + " = " + arr[i]);
        }

        public void MaxValue<T>() // Максимум
        {
            int maxValue = arr.Max();
            Console.WriteLine("\nМаксимальное значение массива = " + maxValue + "\n");
        }

        public void MinValue<T>() //Минимум
        {
            int minValue = arr.Min();
            Console.WriteLine("Максимальное значение массива = " + minValue + "\n");
        }

        public void Summ<T>(ref int summ) // сумма массива
        {
            for (int i = 0; i < arr.Length; i++)
                summ = summ + arr[i];
            Console.WriteLine("Сумма всех элементов массива = " + summ + "\n");
        }

        public void BubbleSort<T>() //Сортировка пузырьком
        {
            int swapper;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        swapper = arr[i];
                        arr[i] = arr[j];
                        arr[j] = swapper;
                    }
                }
            }
            Console.WriteLine("Отсортированный пузырьком массив:");
            for (int i = 0; i < arr.Length; i++)
                Console.WriteLine("Элемент " + i + " = " + arr[i]);
        }
    }

    class Vision
    {
        static void Main()
        {
            Array array = new Array();
            array.massivegeneration();
            GenericsMethod<int[]> generics = new GenericsMethod<int[]>();
            generics.Swapgeneration();
            generics.MaxValue<int>();
            generics.MinValue<int>();
            int summ = 0;
            generics.Summ<int>(ref summ);
            generics.BubbleSort<int[]>();
        }
    }**/

    /** Вторая тестовая задача
 
    class String // класс, где задаётся строка
    {
        public string Word = "Hello";
    }

    class search // класс, где находится метод поиска и вывода
    {
        public void searching(string Word) 
        { 
        for (int i = 1; i<Word.Length; i++)
            {
                if (Word[i] == Word[i - 1]) Console.WriteLine("Повторяющийся символ " + Word[i]);
            }
        }
    }

    class Vision // класс, где происходит взаимодействие строки и метода
    {
        static void Main()
        {
            String String = new String();
            string Word = String.Word;
            search search = new search();
            search.searching(Word);
        }
    } **/

    /** //Третья тестовая задача
    Реализован класс перечислений, где хранятся возможные шкалы измерения температур и переводные коэффиценты.
    Далее реализован класс BaseConverter в котором находится вся логика переводов значений, реализованная в виде 6 отдельных методов,
    что позволяет оптимизировать выполнение программы, не заставляя её выполнять один большой метод. 
    Также вместо названия convert были реализованы другие названия методов перевода для наглядности и самодокументируемости кода.
    И третий класс - это класс взаимодействия с пользователем, в котором реализовано простенькое меню с "защитой от дурака"

    class Enum // класс перечислений шкал и коэффицентов нужных для перевода
    {
        public enum scale { Celsius , Fahrenheit , Kelvin }
        public enum koef{ kelvin = 273 , farenheit1 = 32, farenheit2 = 5, farenheit3 = 9 }
    }

    class BaseConverter // класс перевода значений и вывода их на экран
    {
        Enum Enum = new Enum();
        Type scale = typeof(Enum.scale);
        Type koef = typeof(Enum.koef);

        public void C_to_K(int Temperature)
        {
            int newtemp =  Temperature + (int) Enum.koef.kelvin; 
            Console.WriteLine("Температура после перевода " + newtemp + " +-1 " + Enum.scale.Kelvin);
        }

        public void K_to_C(int Temperature,bool swapper)
        {
            int newtemp = Temperature - (int)Enum.koef.kelvin;
            if (swapper == true)
                C_to_F(newtemp);
            else
                Console.WriteLine("Температура после перевода " + newtemp + " +-1 " + Enum.scale.Celsius);
        }

        public void C_to_F(int Temperature)
        {
            int newtemp = Temperature * (int)Enum.koef.farenheit3 / (int)Enum.koef.farenheit2 + (int)Enum.koef.farenheit1;
            Console.WriteLine("Температура после перевода " + newtemp + " +-1 " + Enum.scale.Fahrenheit);
        }

        public void F_to_C(int Temperature, bool swapper)
        {
            int newtemp = (Temperature - (int)Enum.koef.farenheit1) * (int)Enum.koef.farenheit2 / (int)Enum.koef.farenheit3;
            if (swapper == true)
                C_to_K(newtemp);
            else
                Console.WriteLine("Температура после перевода " + newtemp + " +-1 " + Enum.scale.Celsius);
        }

        public void K_to_F(int Temperature)
        {
            bool swapper = true;
            K_to_C(Temperature,swapper);
        }



        public void F_to_K(int Temperature)
        {
            bool swapper = true;
            F_to_C(Temperature, swapper);
        }
    }

    class Vision // класс UI с самой простой защитой от дурака, которая просто заканчивает программу
    {
        static void Main()
        {
            BaseConverter formulas = new BaseConverter();
            Console.WriteLine("Выберите шкалу\n1.Цельсий\n2.Фаренгейт\n3.Кельвин");
            string readednaumber = Console.ReadLine();
            int convertednumber = Convert.ToInt32(readednaumber);
            bool swapper = false;
            if (convertednumber < 1 || convertednumber > 3) return;
            if (convertednumber == 1)
            {
                Console.WriteLine("В какую шкалу вы хотите перевести?\n1.Фаренгейт\n2.Кельвин");
                readednaumber = Console.ReadLine();
                convertednumber = Convert.ToInt32(readednaumber);
                if (convertednumber < 1 || convertednumber > 2) return;
                Console.WriteLine("Введите температуру:");
                int Temperature = Convert.ToInt32(Console.ReadLine());
                if (convertednumber == 1) 
                formulas.C_to_F(Temperature);
                else
                formulas.C_to_K(Temperature);
            }
            else
                if (convertednumber == 2)
                {
                Console.WriteLine("В какую шкалу вы хотите перевести?\n1.Цельсий\n2.Кельвин");
                readednaumber = Console.ReadLine();
                convertednumber = Convert.ToInt32(readednaumber);
                if (convertednumber < 1 || convertednumber > 2) return;
                Console.WriteLine("Введите температуру:");
                int Temperature = Convert.ToInt32(Console.ReadLine());
                if (convertednumber == 1)
                    formulas.F_to_C(Temperature, swapper);
                else
                    formulas.F_to_K(Temperature);
                }
                else
                {
                Console.WriteLine("В какую шкалу вы хотите перевести?\n1.Цельсий\n2.Фаренгейт");
                readednaumber = Console.ReadLine();
                convertednumber = Convert.ToInt32(readednaumber);
                if (convertednumber < 1 || convertednumber > 2) return;
                Console.WriteLine("Введите температуру:");
                int Temperature = Convert.ToInt32(Console.ReadLine());
                if (convertednumber == 1)
                    formulas.K_to_C(Temperature, swapper);
                else
                    formulas.K_to_F(Temperature);
            }
            return;
        }
    }**/


    // Четвёртая тестовая задача.
    /**
    class Formulas // класс расчётов
    {
        public void AngleCalculate(double Hours, double Minutes)
        {

            double HoursMoveFromMinutes = Hours % 12;
            HoursMoveFromMinutes += Minutes / 60;

            double HoursAngle = (360 / 12) * HoursMoveFromMinutes;
            double MinutesAngle = (360 / 60) * Minutes;

            double result = HoursAngle - MinutesAngle;
            if (result < 0) result *= -1;
            result = result > 180 ? 360 - result : result;
            Console.WriteLine("Угол между стрелками = " + result + "°");
        }

    }

    class Work // класс взаимодействия с пользователем
    {
        static void Main()
        {
            Formulas Math = new();
            Console.WriteLine("Введите часы:");
            double Hours = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите минуты:");
            double Minutes = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Введённое время = {Hours.ToString("00")}:{Minutes.ToString("00")}");// применена интерполяция
            Math.AngleCalculate(Hours, Minutes);
        }
    } **/
}
