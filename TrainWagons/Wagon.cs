using System;

namespace TrainWagons
{
    public partial class Wagon
    {
        private int number;
        private int minSpeed;

        public int Number
        {
            get => number;
            set => number = value >= 0 ? value : throw new ArgumentException("Номер не может быть отрицательным");
        }

        public int MinSpeed
        {
            get => minSpeed;
            set => minSpeed = value > 0 ? value : throw new ArgumentException("Минимальная скорость должна быть положительной");
        }

        public Wagon() { Number = 1; MinSpeed = 100; }
        public Wagon(int number, int minSpeed)
        {
            Number = number;
            MinSpeed = minSpeed;
        }

        public Wagon(Wagon other)
        {
            Number = other.Number;
            MinSpeed = other.MinSpeed;
        }

        public virtual void Show() => Console.WriteLine($"Вагон #{Number}, Минимальная: {MinSpeed} км/ч");
        public virtual void Init()
        {
            Console.Write("Введите номер вагона: ");
            Number = int.Parse(Console.ReadLine());
            Console.Write("Введите максимальную скорость: ");
            MinSpeed = int.Parse(Console.ReadLine());
        }

        public void RandomInit()
        {
            throw new NotImplementedException();
        }

        public virtual void RandomInit(Random rnd)
        {
            Number = rnd.Next(1, 1000);
            MinSpeed = rnd.Next(50, 200);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            Wagon other = (Wagon)obj;
            return Number == other.Number && MinSpeed == other.MinSpeed;
        }

        public override string ToString() => $"Вагон #{Number}, Макс. скорость: {MinSpeed} км/ч";
        public int CompareTo(object? obj)
        {
            if (obj == null) return 1; //если объект пустой считаем текущий объект больше
            if (!(obj is Wagon other)) throw new ArgumentException("Объект не является вагоном"); //проверяем, что объект является вагоном
            return this.Number.CompareTo(other.Number); //cравниваем по номеру вагона
        }
    }
}