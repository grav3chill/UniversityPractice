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
        static void Main(string[] args)
        {
            while (true) 
            { 
                var firstList = new List<object>();
                var secondList = new List<object>();
                int listInput = 0;
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
                        Console.Clear();
                        Console.WriteLine("Выбран список 1");
                        Console.WriteLine("Выбери операцию со списом:");
                        Console.WriteLine("1. Добавление элементов в список");
                        Console.WriteLine("2. Удаление эелементов из списка");
                        Console.WriteLine("3. Сортировка списка");
                        Console.WriteLine("4. Вставка элементов в список по индексу");
                        Console.WriteLine("5. Поиск элементов в списке");
                        Console.WriteLine("6. Копирование списка в другой список");
                        Console.WriteLine("7. Вывод элементов списка");
                        
                       
                        
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Выбран список 2");
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
