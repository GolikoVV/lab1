using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите максимальный размер стека:");
            int maxSize = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>(maxSize);

            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Добавить элемент в стек");
                Console.WriteLine("2. Извлечь элемент из стека");
                Console.WriteLine("3. Посмотреть верхний элемент стека (Peek)");
                Console.WriteLine("4. Вывести среднее арифметическое");
                Console.WriteLine("5. Создать копию стека");
                Console.WriteLine("6. Печать содержимого стека");
                Console.WriteLine("7. Выйти из программы");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Введите значение для добавления в стек:");
                        int valueToAdd = int.Parse(Console.ReadLine());
                        try
                        {
                            stack.Push(valueToAdd);
                            Console.WriteLine($"Добавлено в стек: {valueToAdd}");
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("Стек переполнен. Невозможно добавить элемент.");
                        }
                        break;

                    case 2:
                        try
                        {
                            int poppedValue = stack.Pop();
                            Console.WriteLine($"Извлечено из стека: {poppedValue}");
                        }
                        catch (InvalidOperationException)
                        {
                            Console.WriteLine("Стек пуст. Невозможно извлечь элемент.");
                        }
                        break;

                    case 3:
                        try
                        {
                            int peekedValue = stack.Peek();
                            Console.WriteLine($"Верхний элемент стека: {peekedValue}");
                        }
                        catch (InvalidOperationException)
                        {
                            Console.WriteLine("Стек пуст. Невозможно просмотреть элемент.");
                        }
                        break;

                    case 4:
                        try
                        {
                            double average = stack.Average();
                            Console.WriteLine($"Среднее арифметическое элементов стека: {average}");
                        }
                        catch (InvalidOperationException)
                        {
                            Console.WriteLine("Стек пуст. Невозможно вычислить среднее.");
                        }
                        break;

                    case 5:
                        Stack<int> copyStack = new Stack<int>(stack);
                        Console.WriteLine("Создана копия стека.");
                        break;

                    case 6:
                        Console.WriteLine("Содержимое стека:");

                        break;

                    case 7:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                        break;
                }
            }
        }
    }
}


