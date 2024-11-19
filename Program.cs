namespace ConsoleApp23
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    // Базовий клас Рослина
    public class Рослина
    {
        private string назва;
        private double висота;

        public Рослина(string назва, double висота)
        {
            this.назва = назва;
            this.висота = висота;
        }

        public string Назва
        {
            get { return назва; }
            set { назва = value; }
        }

        public double Висота
        {
            get { return висота; }
            set { висота = value; }
        }
    }

    // Універсальний клас для роботи зі списком Рослин
    public class GenericList<T> where T : Рослина
    {
        private class Node
        {
            private Node next;
            private T data;

            public Node(T t)
            {
                next = null;
                data = t;
            }

            public Node Next
            {
                get { return next; }
                set { next = value; }
            }

            public T Data
            {
                get { return data; }
                set { data = value; }
            }
        }

        private Node head;

        public GenericList() // Конструктор
        {
            head = null;
        }

        public void AddHead(T t)
        {
            Node n = new Node(t);
            n.Next = head;
            head = n;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        // Метод для знаходження першого елемента за назвою
        public T FindFirstOccurrence(string назва)
        {
            Node current = head;
            T t = null;

            while (current != null)
            {
                if (current.Data.Назва == назва)
                {
                    t = current.Data;
                    break;
                }
                else
                {
                    current = current.Next;
                }
            }
            return t;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Створення списку рослин
            GenericList<Рослина> списокРослин = new GenericList<Рослина>();
            списокРослин.AddHead(new Рослина("Троянда", 1.2));
            списокРослин.AddHead(new Рослина("Соняшник", 1.8));
            списокРослин.AddHead(new Рослина("Клен", 5.0));

            // Виведення всіх рослин у списку
            Console.WriteLine("Список рослин:");
            foreach (var рослина in списокРослин)
            {
                Console.WriteLine($"{рослина.Назва}, висота: {рослина.Висота} м");
            }

            // Пошук рослини за назвою
            var знайденаРослина = списокРослин.FindFirstOccurrence("Соняшник");
            if (знайденаРослина != null)
            {
                Console.WriteLine($"\nЗнайдена рослина: {знайденаРослина.Назва}, висота: {знайденаРослина.Висота} м");
            }
            else
            {
                Console.WriteLine("\nРослину не знайдено.");
            }
        }
    }

}
