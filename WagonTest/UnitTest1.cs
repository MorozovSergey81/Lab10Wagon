using TrainWagons;
using System;

namespace TrainWagonsTests
{
    [TestClass]
    public class WagonTests
    {
        [TestMethod]
        public void ConstructorDefaultInitializesCorrectly()
        {
            Wagon wagon = new Wagon();
            Assert.AreEqual(1, wagon.Number, "Номер вагона по умолчанию должен быть 1");
            Assert.AreEqual(100, wagon.MinSpeed, "Максимальная скорость по умолчанию должна быть 100");
        }

        [TestMethod]
        public void ConstructorWithParametersInitializesCorrectly()
        {
            Wagon wagon = new Wagon(5, 120);
            Assert.AreEqual(5, wagon.Number, "Номер вагона должен быть 5");
            Assert.AreEqual(120, wagon.MinSpeed, "Максимальная скорость должна быть 120");
        }

        [TestMethod]
        public void ConstructorCopyInitializesCorrectly()
        {
            Wagon original = new Wagon(3, 150);
            Wagon copied = new Wagon(original);
            Assert.AreEqual(original.Number, copied.Number, "Номера вагонов должны совпадать");
            Assert.AreEqual(original.MinSpeed, copied.MinSpeed, "Максимальные скорости должны совпадать");
            Assert.AreNotSame(original, copied, "Копия должна быть новым объектом");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NumberSetNegativeThrowsArgumentException()
        {
            Wagon wagon = new Wagon();
            wagon.Number = -1; 
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MaxSpeedSetNonPositiveThrowsArgumentException()
        {
            Wagon wagon = new Wagon();
            wagon.MinSpeed = 0; 
        }

        [TestMethod]
        public void EqualsSameValuesReturnsTrue()
        {
            Wagon wagon1 = new Wagon(2, 110);
            Wagon wagon2 = new Wagon(2, 110);
            Assert.IsTrue(wagon1.Equals(wagon2), "Объекты с одинаковыми значениями должны быть равны");
        }

        [TestMethod]
        public void EqualsDifferentValuesReturnsFalse()
        {
            Wagon wagon1 = new Wagon(2, 110);
            Wagon wagon2 = new Wagon(3, 120);
            Assert.IsFalse(wagon1.Equals(wagon2), "Объекты с разными значениями не должны быть равны");
        }

        [TestMethod]
        public void EqualsNullOrDifferentTypeReturnsFalse()
        {
            Wagon wagon = new Wagon(2, 110);
            Assert.IsFalse(wagon.Equals(null), "Сравнение с null должно вернуть false");
            Assert.IsFalse(wagon.Equals(new object()), "Сравнение с объектом другого типа должно вернуть false");
        }

        [TestMethod]
        public void ToStringReturnsCorrectFormat()
        {
            Wagon wagon = new Wagon(4, 130);
            string result = wagon.ToString();
            Assert.AreEqual("Вагон #4, Макс. скорость: 130 км/ч", result, "ToString должен возвращать правильный формат строки");
        }

        [TestMethod]
        public void CompareToSameNumberReturnsZero()
        {
            Wagon wagon1 = new Wagon(5, 100);
            Wagon wagon2 = new Wagon(5, 120);
            Assert.AreEqual(0, wagon1.CompareTo(wagon2), "Объекты с одинаковым номером должны быть равны (вернуть 0)");
        }

        [TestMethod]
        public void CompareToLowerNumberReturnsNegative()
        {
            Wagon wagon1 = new Wagon(3, 100);
            Wagon wagon2 = new Wagon(5, 120);
            Assert.IsTrue(wagon1.CompareTo(wagon2) < 0, "Объект с меньшим номером должен возвращать отрицательное число");
        }

        [TestMethod]
        public void CompareToHigherNumberReturnsPositive()
        {
            Wagon wagon1 = new Wagon(7, 100);
            Wagon wagon2 = new Wagon(5, 120);
            Assert.IsTrue(wagon1.CompareTo(wagon2) > 0, "Объект с большим номером должен возвращать положительное число");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToNonWagonThrowsArgumentException()
        {
            Wagon wagon = new Wagon(1, 100);
            wagon.CompareTo(new object());
        }
    }
}