using System.Collections;

namespace CollectionCreateProject
{
    class WeekEnumerator : IEnumerator
    {
        string[] days;
        int position;

        public WeekEnumerator(string[] days)
        {
            this.days = days;
            this.position = -1;
        }

        public object Current
        {
            get 
            {
                if (position == -1 || position >= days.Length)
                    throw new ArgumentOutOfRangeException();
                return days[position];
            }
        }

        public bool MoveNext()
        {
            if (position < days.Length - 1)
            {
                position++;
                return true;
            }
            else
                return false;
        }

        public void Reset()
        {
            position = -1;
        }
    }
    class Week : IEnumerable
    {
        string[] days = { "Monday", "Tuesday", "Wensday", "Thursday", "Friday", "Saturday", "Sunday" };
        public IEnumerator GetEnumerator()
        {
            return new WeekEnumerator(days);
        }

    }

    class Counter
    {
        public IEnumerator<int> GetEnumerator()
        {
            for(int i = 0; i < 10; i++)
            {
                yield return i + 1;
            }
        }
    }

    class Fibonachi
    {
        public int Count { set; get; }
        public Fibonachi(int count = 1)
        {
            Count = count;
        }
        public IEnumerator<int> GetEnumerator()
        {
            int f1 = 0;
            int f2 = 1;
            for(int i = 0; i < Count; i++)
            {
                yield return f2;
                int f3 = f1 + f2;
                f1 = f2;
                f2 = f3;
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Week week = new();

            foreach (var day in week)
                Console.Write($"{day} ");
            Console.WriteLine();


            Counter counter = new();

            foreach(var count in counter)
                Console.Write($"{count} ");
            Console.WriteLine();

            Fibonachi fib = new(10);
            foreach (var f in fib)
                Console.Write($"{f} ");
            Console.WriteLine();

            fib.Count = 20;
            foreach (var f in fib)
                Console.Write($"{f} ");
            Console.WriteLine();
        }
    }
}