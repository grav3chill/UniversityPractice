using System;
using System.Runtime.ExceptionServices;
using System.Runtime.Serialization;

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
        public static void InsertElementAtIndex(List<object> list)
        {
            int index;
            object insertedItem = 0;
            Console.Clear();
            Console.WriteLine("Выбрана вставка элемента по индексу");
            Console.WriteLine("Введи индекс");
            try
            {
                index = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка ввода индекса! Ожидалось целое число");
                return;
            }
            if (index < 0 || index >= list.Count)
                throw new ArgumentOutOfRangeException($"Индекс должен быть между 0 и {list.Count}!");
            Console.WriteLine("Введи элемент для вставки");
            try
            {
                insertedItem = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка ввода!");
                return;
            }

            list.Insert(index, insertedItem);
            Console.WriteLine("Вставка прошла успешно!");
            foreach (var x in list)
            {
                Console.Write(x + " ");
            }

        }
        public static List<object> SortList(List<object> list)
        {
            Console.WriteLine("Выбрана сортировка списка");
            Console.WriteLine("Элементы списка:");
            OutputElementsOfList(list);

            Console.WriteLine("\nВыберите тип сортировки:\n1. По возрастанию\n2. По убыванию");

            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 2)
            {
                Console.WriteLine("Ошибка ввода или неверный выбор");
                return list;
            }

            //Разделяем элементы на числа и строки
            var numbers = new List<object>();
            var strings = new List<object>();

            foreach (var item in list)
            {
                if (item is IConvertible convertible)
                {
                    try
                    {
                        Convert.ToDouble(convertible);
                        numbers.Add(item);
                        continue;
                    }
                    catch { }
                }
                strings.Add(item);
            }

            List<object> sorted;
            if (choice == 1)
            {
                sorted = numbers.OrderBy(x => Convert.ToDouble(x))
                               .Concat(strings.OrderBy(x => x.ToString()))
                               .ToList();
            }
            else
            {
                sorted = numbers.OrderByDescending(x => Convert.ToDouble(x))
                               .Concat(strings.OrderByDescending(x => x.ToString()))
                               .ToList();
            }

            Console.WriteLine("Отсортированный список:");
            foreach (var item in sorted)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            return sorted;
        }
        public static void FindElement(List<object> list)
        {
            Console.Clear();
            Console.WriteLine("Выбран поиск элемента в списке");
            Console.WriteLine("Введи элемент для поиска:");

            string targetItem = Console.ReadLine();
            if (string.IsNullOrEmpty(targetItem))
            {
                Console.WriteLine("Вы ничего не ввели!");
                return;
            }

            var indices = new List<int>();
            bool isNumeric = double.TryParse(targetItem, out double numericValue);

            for (int i = 0; i < list.Count; i++)
            {
                if (isNumeric && list[i] is IConvertible convertible)
                {
                    try
                    {
                        double listValue = Convert.ToDouble(convertible);
                        if (Math.Abs(listValue - numericValue) < 0.0001) // учитываем погрешность для double
                        {
                            indices.Add(i);
                        }
                    }
                    catch { }
                }
                else if (targetItem.Equals(list[i]?.ToString(), StringComparison.Ordinal))
                {
                    indices.Add(i);
                }
            }

            if (indices.Count == 0)
            {
                Console.WriteLine($"Элемент '{targetItem}' отсутствует в списке");
            }
            else
            {
                Console.WriteLine($"Элемент '{targetItem}' найден под индексами: {string.Join(", ", indices)}");
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
                                firstList = SortList(firstList);
                                break;
                            case 4:
                                InsertElementAtIndex(firstList);
                                break;
                            case 5:
                                FindElement(firstList);
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
                                secondList = SortList(secondList);
                                break;
                            case 4:
                                InsertElementAtIndex(secondList);
                                break;
                            case 5:
                                FindElement(secondList);
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
