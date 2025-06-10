using System.Runtime.ExceptionServices;

namespace ListPractice
{
    /// <summary>
    /// Консольное интерактивное приложение, показывающее работу с коллекцией List<>
    /// 
    /// Реализовать:
    /// 1. Добавление элементов в список (один/много)
    /// 2. Удаление эелементов из списка (один/все)
    /// 3. Сортировка списка (по убыванию/возрастанию)
    /// 4. Вставка элементов в список по индексу
    /// 5. Поиск элементов в списке
    /// 6. Копирование списка в другой список
    /// 7. Вывод элементов списка
    /// 
    /// P.S. Элементы могут быть разных типов
    /// </summary>
    internal class Program
    {
        public static void DisplayOptionsForList(int choice)
        {
            Console.Clear();
            Console.WriteLine($"Выбран список {choice}");
            Console.WriteLine("Выбери операцию со списом:");
            Console.WriteLine("1. Добавление элементов в список");
            Console.WriteLine("2. Удаление эелементов из списка");
            Console.WriteLine("3. Сортировка списка");
            Console.WriteLine("4. Вставка элементов в список по индексу");
            Console.WriteLine("5. Поиск элементов в списке");
            Console.WriteLine("6. Копирование списка в другой список");
            Console.WriteLine("7. Вывод элементов списка");
        }

        public static void AddElementsToList(List<object> list)
        {
            Console.Clear();
            Console.WriteLine("Выбрано добавление элементов");
            Console.WriteLine("Добавляй элементы по одному! :)");
            Console.WriteLine("Чтобы завершить ввод нажми Enter");

            while (true)
            {
                var elementInput = Console.ReadLine();
                if (string.IsNullOrEmpty(elementInput))
                    break;
                list.Add(elementInput);
            }
        }
        public static void OutputElementsOfList(List<object> list)
        {
            Console.Clear();
            Console.WriteLine("Элементы списка:");
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
        }
        static void Main(string[] args)
        {
            var firstList = new List<object>();
            var secondList = new List<object>();
            int listInput = 0;
            int optionsInput = 0;

            while (true) 
            { 
                
                try
                {
                    Console.WriteLine("Выбери список \n1. Список 1 \n2. Список 2");
                    listInput = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Ошибка ввода");
                }
                switch (listInput)
                {
                    case 1:
                        Console.WriteLine("Выбран список 1\n");
                        DisplayOptionsForList(listInput);
                        try
                        {
                            optionsInput = int.Parse(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Ошибка ввода!");
                            break;
                        }

                        

                        switch (optionsInput)
                        {
                            case 1:
                                AddElementsToList(firstList);
                                break;
                            case 2:

                                break;
                            case 3:

                                break;
                            case 4:

                                break;
                            case 5:

                                break;
                            case 6:

                                break;
                            case 7:
                                OutputElementsOfList(firstList);
                                break;

                            default:
                                Console.Clear();
                                Console.WriteLine("Такой операции нет!");
                                break;
                        }
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Выбран список 2\n");
                        DisplayOptionsForList(listInput);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Такого списка нет!");
                        break;
                }
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
