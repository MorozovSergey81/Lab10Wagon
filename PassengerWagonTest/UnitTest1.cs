using TrainWagons;
using System;

namespace TrainWagonsTests
{
    [TestClass]
    public class PassengerWagonTests
    {
        [TestMethod]
        public void ConstructorDefaultInitializesCorrectly()
        {
            PassengerWagon wagon = new PassengerWagon();
            Assert.AreEqual(1, wagon.Number, "Номер вагона по умолчанию должен быть 1");
            Assert.AreEqual(100, wagon.MinSpeed, "Максимальная скорость по умолчанию должна быть 100");
            Assert.AreEqual(20, wagon.SleepingPlaces, "Количество спальных мест по умолчанию должно быть 20");
            Assert.AreEqual(30, wagon.Seats, "Количество сидячих мест по умолчанию должно быть 30");
        }

        [TestMethod]
        public void ConstructorWithParametersInitializesCorrectly()
        {
            PassengerWagon wagon = new PassengerWagon(5, 120, 25, 40);
            Assert.AreEqual(5, wagon.Number, "Номер вагона должен быть 5");
            Assert.AreEqual(120, wagon.MinSpeed, "Максимальная скорость должна быть 120");
            Assert.AreEqual(25, wagon.SleepingPlaces, "Количество спальных мест должно быть 25");
            Assert.AreEqual(40, wagon.Seats, "Количество сидячих мест должно быть 40");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SleepingPlacesSetNegativeThrowsArgumentException()
        {
            PassengerWagon wagon = new PassengerWagon();
            wagon.SleepingPlaces = -1; 
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SeatsSetNegativeThrowsArgumentException()
        {
            PassengerWagon wagon = new PassengerWagon();
            wagon.Seats = -1; 
        }

        [TestMethod]
        public void EqualsSameValuesReturnsTrue()
        {
            PassengerWagon wagon1 = new PassengerWagon(2, 110, 20, 30);
            PassengerWagon wagon2 = new PassengerWagon(2, 110, 20, 30);
            Assert.IsTrue(wagon1.Equals(wagon2), "Объекты с одинаковыми значениями должны быть равны");
        }

        [TestMethod]
        public void EqualsDifferentValuesReturnsFalse()
        {
            PassengerWagon wagon1 = new PassengerWagon(2, 110, 20, 30);
            PassengerWagon wagon2 = new PassengerWagon(2, 110, 25, 35);
            Assert.IsFalse(wagon1.Equals(wagon2), "Объекты с разными значениями не должны быть равны");
        }

        [TestMethod]
        public void EqualsNullOrDifferentTypeReturnsFalse()
        {
            PassengerWagon wagon = new PassengerWagon(2, 110, 20, 30);
            Assert.IsFalse(wagon.Equals(null), "Сравнение с null должно вернуть false");
            Assert.IsFalse(wagon.Equals(new Wagon(2, 110)), "Сравнение с объектом другого типа должно вернуть false");
        }

        [TestMethod]
        public void ToStringReturnsCorrectFormat()
        {
            PassengerWagon wagon = new PassengerWagon(4, 130, 25, 40);
            string result = wagon.ToString();
            Assert.AreEqual("Пассажирский вагон #4, Макс. скорость: 130 км/ч, Спальных мест: 25, Сидячих мест: 40", result, "ToString должен возвращать правильный формат строки");
        }

        [TestMethod]
        public void CompareToInheritsFromWagonCorrectly()
        {
            PassengerWagon wagon1 = new PassengerWagon(3, 100, 20, 30);
            PassengerWagon wagon2 = new PassengerWagon(5, 120, 25, 35);
            Assert.IsTrue(wagon1.CompareTo(wagon2) < 0, "Объект с меньшим номером должен возвращать отрицательное число");
            Assert.IsTrue(wagon2.CompareTo(wagon1) > 0, "Объект с большим номером должен возвращать положительное число");
            Assert.AreEqual(0, wagon1.CompareTo(wagon1), "Сравнение объекта с самим собой должно вернуть 0");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToNonWagonThrowsArgumentException()
        {
            PassengerWagon wagon = new PassengerWagon(1, 100, 20, 30);
            wagon.CompareTo(new object());
        }
    }
}