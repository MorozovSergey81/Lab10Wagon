using System;
using TrainWagons;

namespace TrainWagonsTests
{
    [TestClass]
    public class FreightWagonTests
    {
        [TestMethod]
        public void ConstructorDefaultInitializesCorrectly()
        {
            FreightWagon wagon = new FreightWagon();
            Assert.AreEqual(1, wagon.Number, "Номер вагона по умолчанию должен быть 1");
            Assert.AreEqual(100, wagon.MinSpeed, "Максимальная скорость по умолчанию должна быть 100");
            Assert.AreEqual("Общее", wagon.Target, "Назначение по умолчанию должно быть 'Общее'");
            Assert.AreEqual(50, wagon.Tonnage, "Тоннаж по умолчанию должен быть 50");
        }

        [TestMethod]
        public void ConstructorWithParametersInitializesCorrectly()
        {
            FreightWagon wagon = new FreightWagon(5, 120, "Уголь", 60);
            Assert.AreEqual(5, wagon.Number, "Номер вагона должен быть 5");
            Assert.AreEqual(120, wagon.MinSpeed, "Максимальная скорость должна быть 120");
            Assert.AreEqual("Уголь", wagon.Target, "Назначение должно быть 'Уголь'");
            Assert.AreEqual(60, wagon.Tonnage, "Тоннаж должен быть 60");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PurposeSetEmptyThrowsArgumentException()
        {
            FreightWagon wagon = new FreightWagon();
            wagon.Target = ""; 
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TonnageSetNonPositiveThrowsArgumentException()
        {
            FreightWagon wagon = new FreightWagon();
            wagon.Tonnage = 0; 
        }

        [TestMethod]
        public void EqualsSameValuesReturnsTrue()
        {
            FreightWagon wagon1 = new FreightWagon(2, 110, "Уголь", 50);
            FreightWagon wagon2 = new FreightWagon(2, 110, "Уголь", 50);
            Assert.IsTrue(wagon1.Equals(wagon2), "Объекты с одинаковыми значениями должны быть равны");
        }

        [TestMethod]
        public void EqualsDifferentValuesReturnsFalse()
        {
            FreightWagon wagon1 = new FreightWagon(2, 110, "Уголь", 50);
            FreightWagon wagon2 = new FreightWagon(2, 110, "Нефть", 60);
            Assert.IsFalse(wagon1.Equals(wagon2), "Объекты с разными значениями не должны быть равны");
        }

        [TestMethod]
        public void EqualsNullOrDifferentTypeReturnsFalse()
        {
            FreightWagon wagon = new FreightWagon(2, 110, "Уголь", 50);
            Assert.IsFalse(wagon.Equals(null), "Сравнение с null должно вернуть false");
            Assert.IsFalse(wagon.Equals(new Wagon(2, 110)), "Сравнение с объектом другого типа должно вернуть false");
        }

        [TestMethod]
        public void ToStringReturnsCorrectFormat()
        {
            FreightWagon wagon = new FreightWagon(4, 130, "Зерно", 70);
            string result = wagon.ToString();
            Assert.AreEqual("Грузовой вагон #4, Макс. скорость: 130 км/ч, Назначение: Зерно, Тоннаж: 70", result, "ToString должен возвращать правильный формат строки");
        }

        [TestMethod]
        public void CompareToInheritsFromWagonCorrectly()
        {
            FreightWagon wagon1 = new FreightWagon(3, 100, "Уголь", 50);
            FreightWagon wagon2 = new FreightWagon(5, 120, "Нефть", 60);
            Assert.IsTrue(wagon1.CompareTo(wagon2) < 0, "Объект с меньшим номером должен возвращать отрицательное число");
            Assert.IsTrue(wagon2.CompareTo(wagon1) > 0, "Объект с большим номером должен возвращать положительное число");
            Assert.AreEqual(0, wagon1.CompareTo(wagon1), "Сравнение объекта с самим собой должно вернуть 0");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToNonWagonThrowsArgumentException()
        {
            FreightWagon wagon = new FreightWagon(1, 100, "Уголь", 50);
            wagon.CompareTo(new object()); 
        }
    }
}