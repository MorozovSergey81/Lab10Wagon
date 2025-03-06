using System;
using System.Collections;
using TrainWagons; 

namespace Lab10Wagon
{
    class Program
    {
        static Wagon[] wagons = null;//изначально пуст для дальнейшего заполнения
        static Random rnd = new Random();//инициализация объектов
//менюха
        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Меню управления вагонами ===");
                Console.WriteLine("1. Создать массив вагонов");
                Console.WriteLine("2. Показать массив (невиртуальные методы)");
                Console.WriteLine("3. Показать массив (виртуальные методы)");
                Console.WriteLine("4. Выполнить запросы");
                Console.WriteLine("5. Отсортировать по номеру");
                Console.WriteLine("6. Отсортировать по максимальной скорости");
                Console.WriteLine("7. Клонирование");
                Console.WriteLine("8. Выход");
                Console.Write("Выберите пункт: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        CreateWagonsArray();
                        break;
                    case "2":
                        ShowNonVirtual();
                        break;
                    case "3":
                        ShowVirtual();
                        break;
                    case "4":
                        ExecuteQueries();
                        break;
                    case "5":
                        SortByNumber();
                        break;
                    case "6":
                        SortByMinSpeed();
                        break;
                    case "7":
                        DemonstrateCloning();
                        break;
                    case "8": return;
                    default:
                        Console.WriteLine("Неверный выбор, попробуйте снова.");
                        break;
                }

                Console.WriteLine("\nНажмите Enter для продолжения...");
                Console.ReadLine();
            }
        }
        public class MinSpeedComparer : IComparer//эт реализует интерфейс IComparer
        {
            public int Compare(object x, object y)
            {
                Wagon wx = x as Wagon;//приводим к типу вагону
                Wagon wy = y as Wagon;
                if (wx == null || wy == null) throw new ArgumentException("Объекты должны быть вагонами");//выбрасываем ошибку вдруг чо
                return wx.MinSpeed.CompareTo(wy.MinSpeed);//сравнивает скорость двух вагонов с помощью метода Compare
            }
        }

        static void CreateWagonsArray()//создает массив из 20 вагонов разных типов через рандом
        {
            wagons = new Wagon[20];
            for (int i = 0; i < wagons.Length; i++)
            {
                switch (i % 3)
                {
                    case 0:
                        wagons[i] = new PassengerWagon();
                        break;
                    case 1:
                        wagons[i] = new FreightWagon();
                        break;
                    case 2:
                        wagons[i] = new RestaurantWagon();
                        break;
                }
                wagons[i].RandomInit(rnd);//еще из интерфейса иинит
            }
            Console.WriteLine("Массив из 20 вагонов успешно создан!");
        }

        static void ShowNonVirtual()//выводит массив вагонов через невиртуальные методы
        {
            if (wagons == null)//проверка
            {
                Console.WriteLine("Сначала создайте массив вагонов");
                return;
            }
            Console.WriteLine("Вывод с использованием невиртуальных методов:");
            foreach (var wagon in wagons) wagon.Show();
        }

        static void ShowVirtual()//выводит массив вагонов через виртуальные методы
        {
            if (wagons == null)
            {
                Console.WriteLine("Сначала создайте массив вагонов");
                return;
            }
            Console.WriteLine("Вывод с использованием виртуальных методов:");
            foreach (var wagon in wagons) wagon.Show();
        }

        static void ExecuteQueries()//выполняет запросы к массиву вагонов
        {
            if (wagons == null)//проверка
            {
                Console.WriteLine("Сначала создайте массив вагонов");
                return;
            }
            int totalSleeping = GetTotalSleepingPlaces(wagons);
            int minSpeed = GetMinSpeed(wagons);
            int totalTonnage = GetTotalTonnage(wagons);
            Console.WriteLine($"Общее количество спальных мест: {totalSleeping}");
            Console.WriteLine($"Минимальная скорость: {minSpeed} км/ч");
            Console.WriteLine($"Общий тоннаж грузовых вагонов: {totalTonnage} тонн");
        }

        static int GetTotalSleepingPlaces(Wagon[] wagons)//получает общее количество спальных мест
        {
            int total = 0;
            foreach (var wagon in wagons)
                if (wagon is PassengerWagon pw)
                    total += pw.SleepingPlaces;//получаем количество спальных мест
            return total;
        }

        static int GetMinSpeed(Wagon[] wagons)//получает минимальную скорость через цикл
        {
            int minSpeed = int.MaxValue;
            foreach (var wagon in wagons)
                if (wagon.MinSpeed < minSpeed)//если скорость вагона меньше минимальной
                    minSpeed = wagon.MinSpeed;//то минимальная скорость равна скорости вагона
            return minSpeed;
        }
        

/// <summary>
/// Calculates the total tonnage of all freight wagons in the provided array.
/// </summary>
/// <param name="wagons">An array of Wagon objects which can include different types of wagons.</param>
/// <returns>The total tonnage of all FreightWagon objects in the array.</returns>
        static int GetTotalTonnage(Wagon[] wagons)
        {
            int total = 0;
            foreach (var wagon in wagons)
            {
                var fw = wagon as FreightWagon;
                if (fw != null) total += fw.Tonnage;
            }

            return total;
        }

        static void SortByNumber()
        {
            if (wagons == null)
            {
                Console.WriteLine("Сначала создайте массив вагонов!");
                return;
            }

            Array.Sort(wagons);
            Console.WriteLine("Отсортировано по номеру:");
            foreach (var wagon in wagons) wagon.Show();
        }

        static void SortByMinSpeed()//сортирует вагоны по минимальной скорости через интерфейс компарер и виртуальные методы
        {
            if (wagons == null)
            {
                Console.WriteLine("Сначала создайте массив вагонов!");
                return;
            }

            Array.Sort(wagons, new MinSpeedComparer());//сортирует вагоны по минимальной скорости через интерфейс компарер
            Console.WriteLine("Отсортировано по минимальной скорости:");
            foreach (var wagon in wagons) wagon.Show();
        }

        static void DemonstrateCloning()
        {
            Wagon w1 = new PassengerWagon(1, 100, 20, 30);
            Wagon w2 = (Wagon)w1.Clone();
            Wagon w3 = w1.ShallowCopy();
            Console.WriteLine("Демонстрация клонирования:");
            Console.WriteLine($"Оригинал до изменения: {w1.ToString()}, ID: {w1.Id}");
            Console.WriteLine($"Глубокая копия: {w2.ToString()}, ID: {w2.Id}");
            Console.WriteLine($"Поверхностная копия: {w3.ToString()}, ID: {w3.Id}");
            w1.Id.Number = 999;
            Console.WriteLine("\nПосле изменения ID оригинала:");
            Console.WriteLine($"Оригинал: {w1.ToString()}, ID: {w1.Id}");
            Console.WriteLine($"Глубокая копия: {w2.ToString()}, ID: {w2.Id}");
            Console.WriteLine($"Поверхностная копия: {w3.ToString()}, ID: {w3.Id}");
        }
    }
}