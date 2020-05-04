using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Handlers_For_Sorts;
using DAL.Handlers_For_Search;
using DAL.Command_commands;

namespace PL
{
    public class MainMenu
    {
        static void Main(string[] args)
        {

        }
        //Розробити модель вибору способів сортування та пошуку
        //максимального / мінімального значення масиву числових об'єктів
        //Chain of responsibilily, iterator, command
        public static void Menu()
        {
            int choise;
            Objects objects;
            Receiver receiver = new Receiver();

            Handler_For_Sorts h_So1 = new Handler_Bubble();
            Handler_For_Sorts h_So2 = new Handler_Choise();
            Handler_For_Sorts h_So3 = new Handler_Insert();
            Handler_For_Sorts h_So4 = new Handler_Shell();
            Handler_For_Sorts h_So5 = new Handler_Quick();

            Handler_For_Search h_Se1 = new Handler_Lin();
            Handler_For_Search h_Se2 = new Handler_Bin();
            Handler_For_Search h_Se3 = new Handler_Inter();
            
            Console.WriteLine("Создание массива: ");
            Console.WriteLine("Введите размерность массива: ");
            int size = int.Parse(Console.ReadLine());
            objects = new Objects(size);
            Console.WriteLine("Создан пустой массив.");
            do
            {
                Console.WriteLine("1. Заполнить массив");
                Console.WriteLine("2. Очистить массив");
                Console.WriteLine("3. Отсортировать массив");
                Console.WriteLine("4. Найти максимальное/минимальное значение");
                Console.WriteLine("5. Печать массива");
                Console.WriteLine("0. Выйти");

                choise = int.Parse(Console.ReadLine());
                Console.WriteLine("------------------------");
                switch (choise)
                {
                    case 1:
                        Console.WriteLine("Заполнение массива: ");
                        //for (int i = 0; i < size; i++)
                        //{
                        //    Console.WriteLine("Елемент[" + i +"] = ");
                        //    Objects.array[i] = int.Parse(Console.ReadLine());
                        //}
                        receiver.Run_Command_Add();
                        break;
                    case 2:
                        Console.WriteLine("Очистка массива: ");
                        //for (int i=0;i<Objects.array.Length;i++)
                        //{
                        //    Objects.array[i] = 0;
                        //}
                        receiver.Run_Command_Del();
                        break;
                    case 3:
                        
                        h_So1.Successor = h_So2;
                        h_So2.Successor = h_So3;
                        h_So3.Successor = h_So4;
                        h_So4.Successor = h_So5;

                        do
                        {
                            Console.WriteLine("Выберите вид сортировки: ");
                            Console.WriteLine("1. Сортировка пузырьком");
                            Console.WriteLine("2. Сортировка выбором");
                            Console.WriteLine("3. Сортировка вставкой");
                            Console.WriteLine("4. Сортировка Шелла");
                            Console.WriteLine("5. Быстрая сортировка");
                            Console.WriteLine("6. Назад");

                            choise = int.Parse(Console.ReadLine());
                            Console.WriteLine("------------------------");
                            switch (choise)
                            {
                                case 1:
                                    h_So1.HandleRequest(choise);
                                    break;
                                case 2:
                                    h_So1.HandleRequest(choise);
                                    break;
                                case 3:
                                    h_So1.HandleRequest(choise);
                                    break;
                                case 4:
                                    h_So1.HandleRequest(choise);
                                    break;
                                case 5:
                                    h_So1.HandleRequest(choise);
                                    break;
                            }
                        }while (choise!=6);
                        break;
                    case 4:
                        h_Se1.Successor = h_Se2;
                        h_Se2.Successor = h_Se3;

                        do
                        {
                            Console.WriteLine("Виберите вид поиска: ");
                            Console.WriteLine("1. Линейный поиск");
                            Console.WriteLine("2. Простой поиск");
                            Console.WriteLine("3. Встроенный поиск");
                            Console.WriteLine("4. Назад");

                            choise = int.Parse(Console.ReadLine());
                            Console.WriteLine("------------------------");

                            switch (choise)
                            {
                                
                                case 1:
                                    int choise_min_max = 0;
                                    do
                                    {
                                        Console.WriteLine("1. Линейный поиск - мин.");
                                        Console.WriteLine("2. Линейный поиск - макс.");
                                        Console.WriteLine("3. Назад");

                                        choise_min_max = int.Parse(Console.ReadLine());
                                        Console.WriteLine("------------------------");

                                        switch (choise_min_max)
                                        {
                                            case 1:
                                                h_Se1.HandleRequest(choise, choise_min_max);
                                                Console.WriteLine("Минимальный елемент = " + Objects.res_search);
                                                break;
                                            case 2:
                                                h_Se1.HandleRequest(choise, choise_min_max);
                                                Console.WriteLine("Минимальный елемент = " + Objects.res_search);
                                                break;
                                        }
                                    } while (choise_min_max != 3);
                                    break;
                                case 2:
                                    choise_min_max = 0;
                                    do
                                    {
                                        Console.WriteLine("1. Простой поиск - мин.");
                                        Console.WriteLine("2. Простой поиск - макс.");
                                        Console.WriteLine("3. Назад");

                                        choise_min_max = int.Parse(Console.ReadLine());
                                        Console.WriteLine("------------------------");

                                        switch (choise_min_max)
                                        {
                                            case 1:
                                                h_Se1.HandleRequest(choise, choise_min_max);
                                                Console.WriteLine("Минимальный елемент = " + Objects.res_search);
                                                break;
                                            case 2:
                                                h_Se1.HandleRequest(choise, choise_min_max);
                                                Console.WriteLine("Максимальный елемент = " + Objects.res_search);
                                                break;
                                        }
                                    } while (choise_min_max != 3);
                                    break;
                                case 3:
                                    choise_min_max = 0;
                                    do
                                    {
                                        Console.WriteLine("1. Встроенный поиск - мин.");
                                        Console.WriteLine("2. Встроенный поиск - макс.");
                                        Console.WriteLine("3. Назад");

                                        choise_min_max = int.Parse(Console.ReadLine());
                                        Console.WriteLine("------------------------");

                                        switch (choise_min_max)
                                        {
                                            case 1:
                                                h_Se1.HandleRequest(choise, choise_min_max);
                                                Console.WriteLine("Минимальный елемент = "+ Objects.res_search);
                                                break;
                                            case 2:
                                                h_Se1.HandleRequest(choise, choise_min_max);
                                                Console.WriteLine("Минимальный елемент = " + Objects.res_search);
                                                break;
                                        }
                                    } while (choise_min_max != 3);
                                    break;
                            }
                            
                        } while (choise!=4);
                        

                        break;
                    case 5:
                        for (Iterator iterator = objects.getIterator();iterator.hasNext();)
                        {
                            int elem = iterator.next();
                            Console.WriteLine("Елемент: " + elem);
                        }
                        //for (int i=0;i<Objects.array.Length;i++)
                        //{
                        //    Console.WriteLine(Objects.array[i]+"");
                        //}
                        break;
                }

            } while (choise != 0);
        }
    }
}
