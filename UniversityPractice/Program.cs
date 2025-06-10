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
        public static void DisplayAndChooseOptionsForList(int chosenList)
        {
            Console.Clear();
            Console.WriteLine($"Выбран список {chosenList}");
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
            Console.WriteLine("Текущие элементы списка:");
            OutputElementsOfList(list);
            Console.WriteLine("\nДобавляй элементы по одному! :)");
            Console.WriteLine("Чтобы завершить ввод нажми Enter");

            while (true)
            {
                var elementInput = Console.ReadLine();
                if (string.IsNullOrEmpty(elementInput))
                    break;
                list.Add(elementInput);
            }
        }
        public static void RemoveElementsFromList(List<object> list)
        {
            int choice = 0;
            Console.Clear();
            if (list.Count == 0)
            {
                Console.WriteLine("Список пуст");
                return;
            }
            Console.WriteLine($"Элементы списка {list}:");
            OutputElementsOfList(list);
            Console.WriteLine("\nВыберите способ удаления элементов: ");
            Console.WriteLine("1. Удалить элемент в конце списка");
            Console.WriteLine("2. Удалить элемент по индексу");
            Console.WriteLine("3. Удалить все элементы");

            try
            {
                choice = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка ввода");
            }
            switch (choice)
            {
                case 1:
                    try
                    {
                        list.RemoveAt(list.Count - 1);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("Список пуст. Удалять нечего");
                        break;
                    }
                    Console.WriteLine("Элемент удален");
                    break;
                case 2:
                    int index;
                    Console.WriteLine("Выбрано удаление элемента по индексу");
                    Console.WriteLine("Введи индекс удаляемого элемента");
                    try
                    {
                        index = int.Parse(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Ошибка ввода!");
                        break;
                    }

                    try
                    {
                        list.RemoveAt(index);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("Индекс за пределами списка!");
                        break;
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("Неправильный формат индекса! Ожидалось целое число");
                        break;
                    }
                    Console.WriteLine($"Элемент под индексом {index} удален");
                    break;
                case 3:
                    list.Clear();
                    Console.WriteLine("Все элементы списка удалены");
                    break;

                    
                default:
                    Console.Clear();
                    Console.WriteLine("Такой функции нет!");
                    break;
            }
        }
        public static void OutputElementsOfList(List<object> list)
        {
            Console.Clear();
            if (list.Count == 0)
            {
                Console.WriteLine("Список пуст");
            }
            else
            {
                Console.WriteLine("Элементы списка:");
                foreach (var item in list)
                {
                    Console.Write(item + " ");
                }
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
                        DisplayAndChooseOptionsForList(listInput);
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
                                RemoveElementsFromList(firstList);
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
                        DisplayAndChooseOptionsForList(listInput);

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
                                AddElementsToList(secondList);
                                break;
                            case 2:
                                RemoveElementsFromList(secondList);
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
                                OutputElementsOfList(secondList);
                                break;

                            default:
                                Console.Clear();
                                Console.WriteLine("Такой операции нет!");
                                break;
                        }
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
