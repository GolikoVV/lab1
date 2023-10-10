    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    namespace StackExample
    {
    //  Это класс, представляющий узел стека. Узел содержит данные (Data) и
    //  ссылку на следующий узел (Next).
    //  Этот класс используется для хранения элементов стека.
    class StackNode<T>
        {
            public T Data { get; set; } // Публичное свойство для хранения данных элемента стека
            public StackNode<T> Next { get; set; } // Ссылка на следующий элемент стека

            public StackNode(T data)
            {
                Data = data; // Конструктор для создания нового узла стека с данными
                Next = null; // Изначально нет следующего элемента
            }
        }

        // Класс стека
        class Stack<T>
        {
            private StackNode<T> top; //  ссылка на вершину стека 
        private int capacity; // Максимальная вместимость стека
            private int count; // Текущее количество элементов в стеке
            private double sum; // Сумма элементов для вычисления среднего

            // Конструктор для создания нового (пустого) стека по размеру
            public Stack(int capacity)
            {
                this.capacity = capacity; // Устанавливаем максимальную вместимость
                this.count = 0; // Изначально стек пуст
                this.top = null; // Вершина указывает на null, так как стек пуст
                this.sum = 0; // Изначально сумма равна нулю
            }

            // Конструктор для создания копии другого стека
            public Stack(Stack<T> otherStack)
            {
                this.capacity = otherStack.capacity; // Устанавливаем максимальную вместимость
                this.count = 0; // Изначально стек пуст
                this.top = null; // Вершина указывает на null, так как стек пуст
                this.sum = 0; // Изначально сумма равна нулю

                StackNode<T> current = otherStack.top; // Начинаем с вершины другого стека
                while (current != null)
                {
                    Push(current.Data); // Копируем элементы из другого стека
                    current = current.Next;
                }
            }

            // Метод для добавления нового элемента в стек
            public void Push(T data)
            {
                if (count >= capacity)
                {
                    throw new OverflowException("Стек переполнен.");
                }

                StackNode<T> newNode = new StackNode<T>(data); // Создаем новый узел
                newNode.Next = top; // Устанавливаем новый узел как вершину стека
                top = newNode;

                sum += Convert.ToDouble(data); // Добавляем значение в сумму для вычисления среднего
                count++; // Увеличиваем количество элементов в стеке
            }

            // Метод для извлечения элемента из стека (и удаления его)
            public T Pop()
            {
                if (count <= 0)
                {
                    throw new InvalidOperationException("Стек пуст.");
                }
                StackNode<T> prev = top;
                T data = top.Data; // Получаем данные верхнего элемента
                top = top.Next; // Удаляем верхний элемент из стека
                prev.Next = null;

                sum -= Convert.ToDouble(data); // Вычитаем значение из суммы
                count--; // Уменьшаем количество элементов

                return data; // Возвращаем удаленное значение
            }

            // Метод для возврата элемента без его удаления
            public T Peek()
            {
                if (count <= 0)
                {
                    throw new InvalidOperationException("Стек пуст.");
                }

                return top.Data; // Возвращаем данные верхнего элемента
            }

            // Метод для проверки на переполнение стека
            public bool IsFull()
            {
                return count >= capacity; // Стек полон, если количество элементов достигло максимальной вместимости
            }

            // Метод для печати содержимого стека
            public void Print()
            {
                StackNode<T> current = top; // Начинаем с вершины стека
                while (current != null)
                {
                    Console.Write($"{current.Data} ");
                    current = current.Next;
                }
                Console.WriteLine();
            }

            // Метод для вычисления среднего арифметического элементов стека
            public double GetAverage()
            {
                if (count == 0)
                {
                    return 0; // Если стек пуст, среднее значение равно 0
                }

                return sum / count; // Среднее арифметическое 
            }
        }
    }


