using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laba4_Console.BLL;
using System.IO;
using DAL;

namespace Laba4_Console
{
    class Program
    {

        static void Main(string[] args)
        {
            Work_with_atractions work_With_Atractions = new Work_with_atractions();
            Work_with_heroes work_With_Heroes = new Work_with_heroes();
            Work_with_zones work_With_Zones = new Work_with_zones();
            Work_with_orders work_With_Orders = new Work_with_orders();
            Hero hero;
            MyModel db = new MyModel();
            
            int choise=-1;

            do
            {
                string menu_name = "MainMenu.txt";
                string filename = Path.Combine(Environment.CurrentDirectory, menu_name);
                string[] readText = File.ReadAllLines(filename);

                foreach (string s in readText)
                {
                    Console.WriteLine(s);
                }

                choise = int.Parse(Console.ReadLine());

                switch (choise)
                {
                    case 1:
                        menu_name = "OrdersMenu.txt";
                        filename = Path.Combine(Environment.CurrentDirectory, menu_name);
                        readText = File.ReadAllLines(filename);
                        do
                        {
                            foreach (string s in readText)
                            {
                                Console.WriteLine(s);
                            }

                            choise = int.Parse(Console.ReadLine());

                            switch (choise)
                            {
                                case 1:
                                    string Name;
                                    string Type;
                                    int Time;
                                    int Id_hero;
                                    int ID;
                                    int Zone_Count;
                                    Zone[] zones;
                                    int Zone_ID=0;

                                    Console.WriteLine("Создать заказ под ключ? (yes/no)");
                                    string ch = Console.ReadLine();
                                    if (ch == "yes")
                                    {
                                        ID = 0;
                                        Name = "Standart_Order";
                                        Type = "Birthday";
                                        Time = 3;
                                        Id_hero = db.HeroEntities.FirstOrDefault().HeroId;

                                        zones = new Zone[1];
                                        zones[0] = db.ZoneEntities.FirstOrDefault();

                                        work_With_Orders.Add_Order(ID, Name, Type, Time, Id_hero, zones);
                                    }
                                    else
                                    {

                                        Console.WriteLine("Введите ID для добавления заказа: ");
                                        ID = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Введите имя для добавления заказа: ");
                                        Name = Console.ReadLine();
                                        Console.WriteLine("Введите тип для добавления заказа: ");
                                        Type = Console.ReadLine();
                                        Console.WriteLine("Введите время для добавления заказа: ");
                                        Time = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Введите ID героя для добавления заказа: ");
                                        Id_hero = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Введите колличество игровых зон для добавления заказа: ");
                                        Zone_Count = int.Parse(Console.ReadLine());
                                        zones = new Zone[Zone_Count];

                                        for (int i = 0; i < Zone_Count; i++)
                                        {
                                            Console.WriteLine("Введите ID игровой зоны: ");
                                            Zone_ID = int.Parse(Console.ReadLine());

                                            var elem = db.ZoneEntities.Find(Zone_ID);
                                            zones[i] = elem;
                                        }

                                        work_With_Orders.Add_Order(ID, Name, Type, Time, Id_hero, zones);
                                    }
                                    break;
                                case 2:

                                    Console.WriteLine("Введите ID для изменения заказа: ");
                                    ID = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Введите имя для изменения заказа: ");
                                    Name = Console.ReadLine();
                                    Console.WriteLine("Введите тип для изменения заказа: ");
                                    Type = Console.ReadLine();
                                    Console.WriteLine("Введите цену для изменения заказа: ");
                                    Time = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Введите ID героя для изменения заказа: ");
                                    Id_hero = int.Parse(Console.ReadLine());
                                    hero = db.HeroEntities.Find(Id_hero);
                                    Console.WriteLine("Введите колличество игровых зон для изменения заказа: ");
                                    Zone_Count = int.Parse(Console.ReadLine());
                                    zones = new Zone[Zone_Count];
                                    Zone_ID = 0;

                                    for (int i = 0; i < Zone_Count; i++)
                                    {
                                        Console.WriteLine("Введите ID игровой зоны: ");
                                        Zone_ID = int.Parse(Console.ReadLine());

                                        var elem = db.ZoneEntities.Find(Zone_ID);
                                        zones[i] = elem;
                                    }

                                    work_With_Orders.Edit_Order(ID,Name,Type,Time,hero,zones);
                                    break;

                                case 3:
                                    Console.WriteLine("Введите ID для удаления заказа: ");
                                    ID = int.Parse(Console.ReadLine());

                                    work_With_Orders.Del_Order(ID);
                                    break;

                                case 4:
                                    work_With_Orders.Print_all_orders();
                                    break;
                            }


                        } while (choise != 5);
                        break;


                    case 2:
                        menu_name = "ZonesMenu.txt";
                        filename = Path.Combine(Environment.CurrentDirectory, menu_name);
                        readText = File.ReadAllLines(filename);
                        do
                        {
                            foreach (string s in readText)
                            {
                                Console.WriteLine(s);
                            }

                            choise = int.Parse(Console.ReadLine());

                            switch (choise)
                            {
                                case 1:
                                    string Name;
                                    string Type;
                                    int Order_Id;
                                    int Atraction_Count;

                                    Console.WriteLine("Введите имя для добавления игровой зоны: ");
                                    Name = Console.ReadLine();
                                    Console.WriteLine("Введите тип для добавления игровой зоны: ");
                                    Type = Console.ReadLine();
                                    Console.WriteLine("Введите ID заказа для добавления игровой зоны: ");
                                    Order_Id = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Введите колличество аттракционов для добавления заказа: ");
                                    Atraction_Count = int.Parse(Console.ReadLine());
                                    Atraction[] atractions = new Atraction[Atraction_Count];
                                    int Atraction_ID = 0;

                                    for (int i = 0; i < Atraction_Count; i++)
                                    {
                                        Console.WriteLine("Введите ID игровой зоны: ");
                                        Atraction_ID = int.Parse(Console.ReadLine());

                                        var elem = db.AtractionEntities.Find(Atraction_ID);
                                        atractions[i] = elem;
                                    }
                                    work_With_Zones.Add_Zone(Name, Type, Order_Id,atractions);
                                    break;

                                case 2:
                                    int ID;

                                    Console.WriteLine("Введите ID для изменения игровой зоны: ");
                                    ID = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Введите имя для изменения игровой зоны: ");
                                    Name = Console.ReadLine();
                                    Console.WriteLine("Введите тип для изменения игровой зоны: ");
                                    Type = Console.ReadLine();
                                    Console.WriteLine("Введите колличество аттракционов для изменения игровой зоны: ");
                                    Atraction_Count = int.Parse(Console.ReadLine());
                                    atractions = new Atraction[Atraction_Count];
                                    Atraction_ID = 0;

                                    for (int i = 0; i < Atraction_Count; i++)
                                    {
                                        Console.WriteLine("Введите ID игровой зоны: ");
                                        Atraction_ID = int.Parse(Console.ReadLine());

                                        var elem = db.AtractionEntities.Find(Atraction_ID);
                                        atractions[i] = elem;
                                    }

                                    work_With_Zones.Edit_Zone(ID, Name, Type,atractions);
                                    break;

                                case 3:
                                    Console.WriteLine("Введите ID для удаления атрацкиона: ");
                                    ID = int.Parse(Console.ReadLine());

                                    work_With_Zones.Del_Zone(ID);
                                    break;

                                case 4:
                                    work_With_Zones.Print_all_zones();
                                    break;

                            }


                        } while (choise != 5);
                        break;

                    case 3:
                        menu_name = "AtractionMenu.txt";
                        filename = Path.Combine(Environment.CurrentDirectory, menu_name);
                        readText = File.ReadAllLines(filename);
                        do
                        {
                            foreach (string s in readText)
                            {
                                Console.WriteLine(s);
                            }

                            choise = int.Parse(Console.ReadLine());

                            switch (choise)
                            {
                                case 1:
                                    string Name;
                                    string Type;
                                    int Capacity;

                                    Console.WriteLine("Введите имя для добавления атрацкиона: ");
                                    Name = Console.ReadLine();
                                    Console.WriteLine("Введите тип для добавления атрацкиона: ");
                                    Type = Console.ReadLine();
                                    Console.WriteLine("Введите вместимость для добавления атрацкиона: ");
                                    Capacity = int.Parse(Console.ReadLine());

                                    work_With_Atractions.Add_Atraction(Name,Type,Capacity);
                                    break;

                                case 2:
                                    int ID;

                                    Console.WriteLine("Введите ID для изменения атрацкиона: ");
                                    ID = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Введите имя для изменения атрацкиона: ");
                                    Name = Console.ReadLine();
                                    Console.WriteLine("Введите тип для изменения атрацкиона: ");
                                    Type = Console.ReadLine();
                                    Console.WriteLine("Введите вместимость для изменения атрацкиона: ");
                                    Capacity = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Введите колличество игровых зон для изменения аттракциона: ");
                                    int Zone_Count = int.Parse(Console.ReadLine());
                                    Zone[] zones = new Zone[Zone_Count];
                                    int Zone_ID = 0;

                                    for (int i = 0; i < Zone_Count; i++)
                                    {
                                        Console.WriteLine("Введите ID заказа: ");
                                        Zone_ID = int.Parse(Console.ReadLine());

                                        var elem = db.ZoneEntities.Find(Zone_ID);
                                        zones[i] = elem;
                                    }

                                    work_With_Atractions.Edit_Atraction(ID,Name,Type,Capacity,zones);
                                    break;

                                case 3:
                                    Console.WriteLine("Введите ID для удаления атрацкиона: ");
                                    ID = int.Parse(Console.ReadLine());

                                    work_With_Atractions.Del_Atraction(ID);
                                    break;

                                case 4:
                                    work_With_Atractions.Print_all_atractions();
                                    break;

                            }


                        } while (choise != 5);
                        break;

                    case 4:
                        menu_name = "HeroMenu.txt";
                        filename = Path.Combine(Environment.CurrentDirectory, menu_name);
                        readText = File.ReadAllLines(filename);
                        do
                        {
                            foreach (string s in readText)
                            {
                                Console.WriteLine(s);
                            }

                            choise = int.Parse(Console.ReadLine());

                            switch (choise)
                            {

                                case 1:
                                    string Name;
                                    int ID_Order;
                                    int ID;

                                    Console.WriteLine("Введите Id героя: ");
                                    ID = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Введите имя для добавления героя: ");
                                    Name = Console.ReadLine();
                                    //Console.WriteLine("Введите id заказа: ");
                                    //ID_Order= int.Parse(Console.ReadLine());

                                    work_With_Heroes.Add_Hero(ID,Name);
                                    break;

                                case 2:

                                    Console.WriteLine("Введите ID для изменения героя: ");
                                    ID = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Введите имя для изменения героя: ");
                                    Name = Console.ReadLine();
                                    Console.WriteLine("Введите колличество заказов для изменения героя: ");
                                    int Order_Count = int.Parse(Console.ReadLine());
                                    Order[] orders = new Order[Order_Count];
                                    int Order_ID = 0;

                                    for (int i = 0; i < Order_Count; i++)
                                    {
                                        Console.WriteLine("Введите ID заказа: ");
                                        Order_ID = int.Parse(Console.ReadLine());

                                        var elem = db.OrderEntities.Find(Order_ID);
                                        orders[i] = elem;
                                    }
                                    work_With_Heroes.Edit_Hero(ID,Name,orders);
                                    break;

                                case 3:
                                    Console.WriteLine("Введите ID для удаления героя: ");
                                    ID = int.Parse(Console.ReadLine());

                                    work_With_Heroes.Del_Hero(ID);
                                    break;

                                case 4:
                                    work_With_Heroes.Print_all_heroes();
                                    break;
                            }


                        } while (choise != 5);
                        break;

                }

            } while (choise != 0);
            
        }
    }
}
