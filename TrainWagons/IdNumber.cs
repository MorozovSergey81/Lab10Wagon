using System;

namespace TrainWagons
{
    public class IdNumber
    {
        private int number;
        public int Number
        {
            get => number;
            set => number = value >= 0 ? value : throw new ArgumentException("Номер не может быть отрицательным");
        }

        public IdNumber(int number) => Number = number;
        public override string ToString() => $"ID: {Number}";
        public override bool Equals(object obj) => obj is IdNumber id && Number == id.Number;
    }

    public partial class Wagon : IInit, IComparable, ICloneable
    {
        public IdNumber Id { get; set; } = new IdNumber(0);
        public object Clone()
        {
            Wagon clone = (Wagon)MemberwiseClone();
            clone.Id = new IdNumber(Id.Number); 
            return clone;
        }
        public Wagon ShallowCopy() => (Wagon)MemberwiseClone();
    }
}