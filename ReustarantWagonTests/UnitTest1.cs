using TrainWagons;
using System;
namespace TrainWagonsTests
{
    [TestClass]
    public class RestaurantWagonTests
    {
        [TestMethod]
        public void ConstructorDefaultInitializesCorrectly()
        {
            RestaurantWagon wagon = new RestaurantWagon();
            Assert.AreEqual(1, wagon.Number, "Номер вагона по умолчанию должен быть 1");
            Assert.AreEqual(100, wagon.MinSpeed, "Максимальная скорость по умолчанию должна быть 100");
            Assert.AreEqual("08:00-22:00", wagon.OperatingHours, "Режим работы по умолчанию должен быть '08:00-22:00'");
        }

        [TestMethod]
        public void ConstructorWithParametersInitializesCorrectly()
        {
            RestaurantWagon wagon = new RestaurantWagon(5, 120, "09:00-23:00");
            Assert.AreEqual(5, wagon.Number, "Номер вагона должен быть 5");
            Assert.AreEqual(120, wagon.MinSpeed, "Максимальная скорость должна быть 120");
            Assert.AreEqual("09:00-23:00", wagon.OperatingHours, "Режим работы должен быть '09:00-23:00'");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void OperatingHoursSetEmptyThrowsArgumentException()
        {
            RestaurantWagon wagon = new RestaurantWagon();
            wagon.OperatingHours = ""; 
        }

        [TestMethod]
        public void EqualsSameValuesReturnsTrue()
        {
            RestaurantWagon wagon1 = new RestaurantWagon(2, 110, "08:00-22:00");
            RestaurantWagon wagon2 = new RestaurantWagon(2, 110, "08:00-22:00");
            Assert.IsTrue(wagon1.Equals(wagon2), "Объекты с одинаковыми значениями должны быть равны");
        }

        [TestMethod]
        public void EqualsDifferentValuesReturnsFalse()
        {
            RestaurantWagon wagon1 = new RestaurantWagon(2, 110, "08:00-22:00");
            RestaurantWagon wagon2 = new RestaurantWagon(2, 110, "09:00-23:00");
            Assert.IsFalse(wagon1.Equals(wagon2), "Объекты с разными значениями не должны быть равны");
        }

        [TestMethod]
        public void EqualsNullOrDifferentTypeReturnsFalse()
        {
            RestaurantWagon wagon = new RestaurantWagon(2, 110, "08:00-22:00");
            Assert.IsFalse(wagon.Equals(null), "Сравнение с null должно вернуть false");
            Assert.IsFalse(wagon.Equals(new Wagon(2, 110)), "Сравнение с объектом другого типа должно вернуть false");
        }

        [TestMethod]
        public void ToStringReturnsCorrectFormat()
        {
            RestaurantWagon wagon = new RestaurantWagon(4, 130, "10:00-20:00");
            string result = wagon.ToString();
            Assert.AreEqual("Вагон-ресторан #4, Макс. скорость: 130 км/ч, Режим работы: 10:00-20:00", result, "ToString должен возвращать правильный формат строки");
        }

        [TestMethod]
        public void CompareToInheritsFromWagonCorrectly()
        {
            RestaurantWagon wagon1 = new RestaurantWagon(3, 100, "08:00-22:00");
            RestaurantWagon wagon2 = new RestaurantWagon(5, 120, "09:00-23:00");
            Assert.IsTrue(wagon1.CompareTo(wagon2) < 0, "Объект с меньшим номером должен возвращать отрицательное число");
            Assert.IsTrue(wagon2.CompareTo(wagon1) > 0, "Объект с большим номером должен возвращать положительное число");
            Assert.AreEqual(0, wagon1.CompareTo(wagon1), "Сравнение объекта с самим собой должно вернуть 0");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToNonWagonThrowsArgumentException()
        {
            RestaurantWagon wagon = new RestaurantWagon(1, 100, "08:00-22:00");
            wagon.CompareTo(new object());
        }
    }
}