using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BLL;

namespace PL
{
    public class Main_Menu
    {
        static void Main(string[] args)
        {
        }
        Game game;
        PC pC;
        Mobile mobile;
        Game_Console console;
        Stock_PC st_PC;
        Stock_Mobile st_Mob;
        Stock_Console st_Cons;
        Watcher_PC watcher_pC;
        Watcher_Mobile watcher_mob;
        Watcher_Console watcher_console;

        Online_Games online = new Online_Games();
        Game_Actions ga = new Game_Actions();
        Console_Actions ca = new Console_Actions();
        List<Game> all_games = new List<Game>();
        List<Game> off_games = new List<Game>();
        int choise = 0;

        public void Menu()
        {
            do
            {
                Console.WriteLine("1. Создать игровую консоль");
                Console.WriteLine("2. Управление интернетом консоли");
                Console.WriteLine("3. Создать игру");
                Console.WriteLine("4. Установить игру");
                Console.WriteLine("5. Запустить игру");
                Console.WriteLine("6. Посмотреть сведения об играх");
                Console.WriteLine("7. Выход");

                choise = int.Parse(Console.ReadLine());

                switch (choise)
                {
                    case 1:
                        Console.WriteLine("1. Создать ПК");
                        Console.WriteLine("2. Создать телефон");
                        Console.WriteLine("3. Создать приставку");

                        choise = int.Parse(Console.ReadLine());

                        switch (choise)
                        {
                            case 1:
                                pC = new PC();
                                
                                Console.WriteLine("Имя ПК = ");
                                pC.Name = Console.ReadLine();
                                Console.WriteLine("Процессор ПК = ");
                                pC.Processor = int.Parse(Console.ReadLine());
                                Console.WriteLine("Объем оперативной памяти ПК = ");
                                pC.Oper_Memory = int.Parse(Console.ReadLine());
                                Console.WriteLine("Видео-карта ПК = ");
                                pC.Video_Card = int.Parse(Console.ReadLine());
                                Console.WriteLine("Размер HDD ПК = ");
                                PC.Size_HDD = int.Parse(Console.ReadLine());

                                st_PC = new Stock_PC(pC);
                                watcher_pC = new Watcher_PC("Watcher - PC", st_PC);
                                
                                break;
                            case 2:
                                mobile = new Mobile();
                                Console.WriteLine("Имя телефона = ");
                                mobile.Name = Console.ReadLine();
                                Console.WriteLine("Процессор телефона = ");
                                mobile.Processor = int.Parse(Console.ReadLine());
                                Console.WriteLine("Объем оперативной памяти телефона = ");
                                mobile.Oper_Memory = int.Parse(Console.ReadLine());
                                Console.WriteLine("Видео-чип телефона = ");
                                mobile.Video_Chip = int.Parse(Console.ReadLine());
                                Console.WriteLine("Объем внутренней памяти ПК = ");
                                Mobile.Internal_Memory = int.Parse(Console.ReadLine());

                                st_Mob = new Stock_Mobile(mobile);
                                watcher_mob = new Watcher_Mobile("Watcher - Mobile", st_Mob);
                                break;
                            case 3:
                                console = new Game_Console();
                                Console.WriteLine("Имя иставки = ");
                                console.Name = Console.ReadLine();
                                Console.WriteLine("Процессор приставки = ");
                                console.Processor = int.Parse(Console.ReadLine());
                                Console.WriteLine("Объем оперативной памяти приставки = ");
                                console.Oper_Memory = int.Parse(Console.ReadLine());
                                Console.WriteLine("Видео-карта приставки = ");
                                console.PZU = int.Parse(Console.ReadLine());
                                Console.WriteLine("Размер HDD приставки = ");
                                Game_Console.Size_HDD = int.Parse(Console.ReadLine());

                                st_Cons = new Stock_Console(console);
                                watcher_console = new Watcher_Console("Watcher - Console", st_Cons);
                                break;
                        }

                        break;
                    case 2:
                        if(pC!= null)
                            Console.WriteLine("Интернет у ПК: " + pC.Internet);
                        if(mobile!=null)
                            Console.WriteLine("Интернет у телефона: " + mobile.Internet);
                        if (console!= null)
                            Console.WriteLine("Интернет у приставки: " + console.Internet);

                        Console.WriteLine("1. ВКЛ/ОТКЛ интернет у ПК");
                        Console.WriteLine("2. ВКЛ/ОТКЛ интернет у телефона");
                        Console.WriteLine("3. ВКЛ/ОТКЛ интернет у приставки");

                        choise = int.Parse(Console.ReadLine());

                        switch (choise)
                        {
                            case 1:
                                if (pC == null)
                                {
                                    Console.WriteLine("Пожалуйста, сначала создайте ПК");
                                }
                                else
                                {
                                    ca.On_Off_Internet_PC(pC);
                                }
                                break;

                            case 2:
                                if (mobile == null)
                                {
                                    Console.WriteLine("Пожалуйста, сначала создайте телефон");
                                }
                                else
                                {
                                    ca.On_Off_Internet_Mobile(mobile);
                                }
                                break;

                            case 3:
                                if (console == null)
                                {
                                    Console.WriteLine("Пожалуйста, сначала создайте консоль");
                                }
                                else
                                {
                                    ca.On_Off_Internet_Console(console);
                                }
                                break;
                        }

                        break;
                    case 3:

                        Console.WriteLine("Имя игры = ");
                        string name = Console.ReadLine();
                        game = new Game(name);
                        Console.WriteLine("Количество жанров игры: ");
                        int count = int.Parse(Console.ReadLine());

                        for (int i = 0; i < count; i++)
                        {
                            Console.WriteLine(i + 1 + " - жанр: ");
                            string g = Console.ReadLine();

                            game.Ganres.Add(g);
                        }

                        Console.WriteLine("Количество платформ игры( максимум 3): ");
                        count = int.Parse(Console.ReadLine());
                        for (int i = 0; i < count; i++)
                        {
                            Console.WriteLine(i + 1 + " - платформа: ");
                            game.Platforms.Add(Console.ReadLine());
                            Console.WriteLine("Минимальные системные требования(Процессор) к " + (i + 1) + " платформе.");
                            game.Processor.Add((int.Parse(Console.ReadLine())));
                            Console.WriteLine("Минимальные системные требования(Оперативная память) к " + (i + 1) + " платформе.");
                            game.Oper_memory.Add(int.Parse(Console.ReadLine()));
                            Console.WriteLine("Минимальные системные требования(Видео-карта/Видео-чип/PZU) к " + (i + 1) + " платформе.");
                            game.Video_cart.Add(int.Parse(Console.ReadLine()));
                            Console.WriteLine("Минимальные системные требования(Объем HDD/Внутренняя память/Объем HDD) к " + (i + 1) + " платформе.");
                            game.Sise_HDD.Add(int.Parse(Console.ReadLine()));
                        }
                        game.Raiting = 3;
                        if (game.Ganres.Contains("Online adventures"))
                        {
                            online.online_games.Add(game);
                        }
                        else
                        {
                            off_games.Add(game);
                        }

                        break;

                    case 4:
                        Console.WriteLine("1. Установить игру на ПК");
                        Console.WriteLine("2. Установить игру на телефон");
                        Console.WriteLine("3. Установить игру на приставку");

                        choise = int.Parse(Console.ReadLine());

                        switch (choise)
                        {
                            case 1:
                                if (game.Name == null)
                                {
                                    Console.WriteLine("Пожалуйста, создайте сначала игру.");
                                }
                                else
                                {
                                    all_games.Clear();
                                    all_games.AddRange(off_games);
                                    all_games.AddRange(online.online_games);

                                    Console.WriteLine("Список игр: ");
                                    for (int i = 0; i < all_games.Count; i++)
                                    {
                                        Console.WriteLine((i + 1) + ". " + all_games[i].Name);
                                    }

                                    Console.WriteLine("Какую игру остановить? ");
                                    choise = int.Parse(Console.ReadLine());


                                    if (pC.Name != null)
                                    {
                                        if (all_games[choise - 1].Ganres.Contains("Online adventures"))
                                        {
                                            Console.WriteLine("Игра не нуждается в установке.");
                                            //game.Installed = true;
                                            //pC.games.Add(game);
                                        }
                                        else
                                        {
                                            if (all_games[choise - 1].Platforms.Contains("PC"))
                                            {
                                                ca.Install_Game_PC(all_games[choise - 1], pC);
                                                Handler handler = new Handler();
                                                watcher_pC.onCount += handler.Message_PC;
                                                st_PC.Start_Notify();
                                                all_games.Clear();
                                                watcher_pC.onCount -= handler.Message_PC;

                                            }
                                            else
                                            {
                                                Console.WriteLine("Невозможно установить игру!");
                                            }


                                        }

                                    }
                                    else if (pC.Name == null)
                                    {
                                        Console.WriteLine("Пожалуйста, создайте сначала компьютер.");
                                    }

                                }
                                break;
                            case 2:
                                if (game.Name == null)
                                {
                                    Console.WriteLine("Пожалуйста, создайте сначала игру.");
                                }
                                else
                                {
                                    all_games.Clear();
                                    all_games.AddRange(off_games);
                                    all_games.AddRange(online.online_games);

                                    Console.WriteLine("Список игр: ");
                                    for (int i = 0; i < all_games.Count; i++)
                                    {
                                        Console.WriteLine((i + 1) + ". " + all_games[i].Name);
                                    }

                                    Console.WriteLine("Какую игру остановить? ");
                                    choise = int.Parse(Console.ReadLine());

                                    if (mobile.Name != null)
                                    {
                                        if (all_games[choise - 1].Ganres.Contains("Online adventures"))
                                        {
                                            Console.WriteLine("Игра не нуждается в установке.");
                                            //game.Installed = true;
                                            //mobile.games.Add(game);
                                        }
                                        else
                                        {
                                            if (all_games[choise - 1].Platforms.Contains("Mobile"))
                                            {
                                                ca.Install_Game_Mobile(all_games[choise - 1], mobile);
                                                Handler handler = new Handler();
                                                watcher_mob.onCount += handler.Message_Mobile;
                                                st_Mob.Start_Notify();
                                                all_games.Clear();
                                                watcher_mob.onCount -= handler.Message_Mobile;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Невозможно установить игру!");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Пожалуйста, создайте сначала телефон.");
                                    }

                                }
                                break;
                            case 3:
                                if (game.Name == null)
                                {
                                    Console.WriteLine("Пожалуйста, создайте сначала игру.");
                                }
                                else
                                {
                                    all_games.Clear();
                                    all_games.AddRange(off_games);
                                    all_games.AddRange(online.online_games);

                                    Console.WriteLine("Список игр: ");
                                    for (int i = 0; i < all_games.Count; i++)
                                    {
                                        Console.WriteLine((i + 1) + ". " + all_games[i].Name);
                                    }

                                    Console.WriteLine("Какую игру остановить? ");
                                    choise = int.Parse(Console.ReadLine());

                                    if (console.Name != null)
                                    {
                                        if (all_games[choise - 1].Ganres.Contains("Online adventures"))
                                        {
                                            Console.WriteLine("Игра не нуждается в установке.");
                                            //game.Installed = true;
                                            //console.games.Add(game);
                                        }
                                        else
                                        {
                                            if (all_games[choise - 1].Platforms.Contains("Console"))
                                            {
                                                ca.Install_Game_Console(all_games[choise - 1], console);
                                                Handler handler = new Handler();
                                                watcher_console.onCount += handler.Message_Console;
                                                st_Cons.Start_Notify();
                                                all_games.Clear();
                                                watcher_console.onCount -= handler.Message_Console;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Невозможно установить игру!");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Пожалуйста, создайте сначала иставку.");
                                    }

                                }
                                break;
                        }

                        break;
                    case 5:
                        Console.WriteLine("1. Запустить игру(ПК)");
                        Console.WriteLine("2. Запустить игру(телефон)");
                        Console.WriteLine("3. Запустить игру(приставка)");

                        choise = int.Parse(Console.ReadLine());

                        switch (choise)
                        {
                            case 1:
                                all_games.Clear();
                                all_games.AddRange(pC.games);
                                all_games.AddRange(online.online_games);
                                Console.WriteLine("Список игр: ");
                                for (int i = 0; i < all_games.Count; i++)
                                {
                                    Console.WriteLine((i + 1) + ". " + all_games[i].Name);
                                }

                                Console.WriteLine("Выберите игру для запуска: ");
                                count = int.Parse(Console.ReadLine());

                                if (all_games[count - 1].Ganres.Contains("Online adventures"))
                                {
                                    if (!all_games[count - 1].Autoriz)
                                    {
                                        Console.WriteLine("Авторизация.");
                                        Console.WriteLine("Пожалуйста, введите Ваш Login: ");
                                        string login = Console.ReadLine();
                                        Console.WriteLine("Пожалуйста, введите Ваш Password: ");
                                        string password = Console.ReadLine();
                                        ga.Obl_Zapis(login, password, all_games[count - 1]);
                                        Console.WriteLine("Запущена онлайн игра.");
                                        ga.Start_Game_PC(all_games, count - 1, pC);

                                    }
                                    else
                                    {
                                        Console.WriteLine("Авторизация.");
                                        Console.WriteLine("Пожалуйста, введите Ваш Login: ");
                                        string login = Console.ReadLine();
                                        Console.WriteLine("Пожалуйста, введите Ваш Password: ");
                                        string password = Console.ReadLine();
                                        ga.Obl_Zapis(login, password, all_games[count - 1]);
                                        if (all_games[count - 1].Autoriz)
                                        {
                                            Console.WriteLine("Запущена онлайн игра.");
                                            ga.Start_Game_PC(all_games, count - 1, pC);
                                        }
                                    }

                                }
                                else
                                {
                                    if (!all_games[count - 1].Autoriz)
                                    {
                                        Console.WriteLine("Авторизация.");
                                        Console.WriteLine("Пожалуйста, введите Ваш Login: ");
                                        string login = Console.ReadLine();
                                        Console.WriteLine("Пожалуйста, введите Ваш Password: ");
                                        string password = Console.ReadLine();
                                        ga.Obl_Zapis(login, password, all_games[count - 1]);
                                        Console.WriteLine("Запущена онлайн игра.");
                                        ga.Start_Game_PC(all_games, count - 1, pC);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Авторизация.");
                                        Console.WriteLine("Пожалуйста, введите Ваш Login: ");
                                        string login = Console.ReadLine();
                                        Console.WriteLine("Пожалуйста, введите Ваш Password: ");
                                        string password = Console.ReadLine();
                                        ga.Obl_Zapis(login, password, all_games[count - 1]);
                                        if (all_games[count - 1].Autoriz)
                                        {
                                            Console.WriteLine("Запущена онлайн игра.");
                                            ga.Start_Game_PC(all_games, count - 1, pC);
                                        }
                                    }

                                }


                                do
                                {
                                    Console.WriteLine("1. Сохранить игру.");
                                    Console.WriteLine("2. Загрузить игру.");
                                    Console.WriteLine("3. Поставить рейтиннг игры.");
                                    Console.WriteLine("4. Exit.");

                                    choise = int.Parse(Console.ReadLine());

                                    switch (choise)
                                    {
                                        case 1:
                                            ga.Save_Game(all_games[count - 1]);
                                            break;
                                        case 2:
                                            bool load = ga.Load_Game(all_games[count - 1]);
                                            if (!load)
                                                Console.WriteLine("Невозможно загрузить игру!");
                                            break;
                                        case 3:
                                            Console.WriteLine("Сейчас рейтинг игры " + all_games[count - 1].Raiting);
                                            Console.WriteLine("Поставить рейтинг игры?");
                                            Console.WriteLine("1. Да");
                                            Console.WriteLine("2. Нет");

                                            choise = int.Parse(Console.ReadLine());

                                            if (choise == 1)
                                            {
                                                float raiting = float.Parse(Console.ReadLine());
                                                ga.Set_Raiting(all_games[count - 1], raiting);
                                                //ga.Exit_Game(all_games[count - 1]);
                                            }
                                            else if (choise == 2)
                                            {
                                                //ga.Exit_Game(all_games[count - 1]);
                                            }

                                            break;

                                    }

                                } while (choise != 4);

                                break;

                            case 2:
                                all_games.Clear();
                                all_games.AddRange(mobile.games);
                                all_games.AddRange(online.online_games);
                                Console.WriteLine("Список игр: ");
                                for (int i = 0; i < all_games.Count; i++)
                                {
                                    Console.WriteLine((i + 1) + ". " + all_games[i].Name);
                                }

                                Console.WriteLine("Выберите игру для запуска: ");
                                count = int.Parse(Console.ReadLine());


                                if (all_games[count - 1].Ganres.Contains("Online adventures"))
                                {
                                    if (!all_games[count - 1].Autoriz)
                                    {
                                        Console.WriteLine("Авторизация.");
                                        Console.WriteLine("Пожалуйста, введите Ваш Login: ");
                                        string login = Console.ReadLine();
                                        Console.WriteLine("Пожалуйста, введите Ваш Password: ");
                                        string password = Console.ReadLine();
                                        ga.Obl_Zapis(login, password, all_games[count - 1]);
                                        Console.WriteLine("Запущена онлайн игра.");
                                        ga.Start_Game_Mobile(all_games, count - 1, mobile);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Авторизация.");
                                        Console.WriteLine("Пожалуйста, введите Ваш Login: ");
                                        string login = Console.ReadLine();
                                        Console.WriteLine("Пожалуйста, введите Ваш Password: ");
                                        string password = Console.ReadLine();
                                        ga.Obl_Zapis(login, password, all_games[count - 1]);
                                        if (all_games[count - 1].Autoriz)
                                        {
                                            Console.WriteLine("Запущена онлайн игра.");
                                            ga.Start_Game_Mobile(all_games, count - 1, mobile);
                                        }
                                    }

                                }
                                else
                                {
                                    if (!all_games[count - 1].Autoriz)
                                    {
                                        Console.WriteLine("Авторизация.");
                                        Console.WriteLine("Пожалуйста, введите Ваш Login: ");
                                        string login = Console.ReadLine();
                                        Console.WriteLine("Пожалуйста, введите Ваш Password: ");
                                        string password = Console.ReadLine();
                                        ga.Obl_Zapis(login, password, all_games[count - 1]);
                                        Console.WriteLine("Запущена онлайн игра.");
                                        ga.Start_Game_Mobile(all_games, count - 1, mobile);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Авторизация.");
                                        Console.WriteLine("Пожалуйста, введите Ваш Login: ");
                                        string login = Console.ReadLine();
                                        Console.WriteLine("Пожалуйста, введите Ваш Password: ");
                                        string password = Console.ReadLine();
                                        ga.Obl_Zapis(login, password, all_games[count - 1]);
                                        if (all_games[count - 1].Autoriz)
                                        {
                                            Console.WriteLine("Запущена онлайн игра.");
                                            ga.Start_Game_Mobile(all_games, count - 1, mobile);
                                        }
                                    }

                                }


                                do
                                {
                                    Console.WriteLine("1. Сохранить игру.");
                                    Console.WriteLine("2. Загрузить игру.");
                                    Console.WriteLine("3. Поставить рейтиннг игры.");
                                    Console.WriteLine("4. Exit.");

                                    choise = int.Parse(Console.ReadLine());

                                    switch (choise)
                                    {
                                        case 1:
                                            ga.Save_Game(all_games[count - 1]);
                                            break;
                                        case 2:
                                            bool load = ga.Load_Game(all_games[count - 1]);
                                            if (!load)
                                                Console.WriteLine("Невозможно загрузить игру!");
                                            break;
                                        case 3:
                                            Console.WriteLine("Сейчас рейтинг игры " + all_games[count - 1].Raiting);
                                            Console.WriteLine("Поставить рейтинг игры?");
                                            Console.WriteLine("1. Да");
                                            Console.WriteLine("2. Нет");

                                            choise = int.Parse(Console.ReadLine());

                                            if (choise == 1)
                                            {
                                                float raiting = float.Parse(Console.ReadLine());
                                                ga.Set_Raiting(all_games[count - 1], raiting);
                                                //ga.Exit_Game(all_games[count - 1]);
                                            }
                                            else if (choise == 2)
                                            {
                                                //ga.Exit_Game(all_games[count - 1]);
                                            }

                                            break;

                                    }
                                } while (choise != 4);
                                break;

                            case 3:
                                all_games.Clear();
                                all_games.AddRange(console.games);
                                all_games.AddRange(online.online_games);

                                Console.WriteLine("Подключить к консоли контроллер?");
                                Console.WriteLine("1. Да");
                                Console.WriteLine("2. Нет");

                                count = int.Parse(Console.ReadLine());

                                if (count==1)
                                {
                                    console.Controller = true;
                                    Console.WriteLine("Контроллеры подключены! ");
                                }
                                else
                                {
                                    console.Controller = false;
                                    Console.WriteLine("Контроллеры отключены! ");
                                }

                                Console.WriteLine("Список игр: ");
                                for (int i = 0; i < all_games.Count; i++)
                                {
                                    Console.WriteLine((i + 1) + ". " + all_games[i].Name);
                                }

                                Console.WriteLine("Выберите игру для запуска: ");
                                count = int.Parse(Console.ReadLine());


                                if (all_games[count - 1].Ganres.Contains("Online adventures"))
                                {
                                    if (console.Controller) {
                                        if (!all_games[count - 1].Autoriz)
                                        {
                                            Console.WriteLine("Авторизация.");
                                            Console.WriteLine("Пожалуйста, введите Ваш Login: ");
                                            string login = Console.ReadLine();
                                            Console.WriteLine("Пожалуйста, введите Ваш Password: ");
                                            string password = Console.ReadLine();
                                            ga.Obl_Zapis(login, password, all_games[count - 1]);
                                            Console.WriteLine("Запущена онлайн игра.");
                                            ga.Start_Game_Console(all_games, count - 1, console);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Авторизация.");
                                            Console.WriteLine("Пожалуйста, введите Ваш Login: ");
                                            string login = Console.ReadLine();
                                            Console.WriteLine("Пожалуйста, введите Ваш Password: ");
                                            string password = Console.ReadLine();
                                            ga.Obl_Zapis(login, password, all_games[count - 1]);
                                            if (all_games[count - 1].Autoriz)
                                            {
                                                Console.WriteLine("Запущена онлайн игра.");
                                                ga.Start_Game_Console(all_games, count - 1, console);
                                            }
                                        }
                                    }

                                }
                                else
                                {
                                    if (console.Controller) {
                                        if (!all_games[count - 1].Autoriz)
                                        {
                                            Console.WriteLine("Авторизация.");
                                            Console.WriteLine("Пожалуйста, введите Ваш Login: ");
                                            string login = Console.ReadLine();
                                            Console.WriteLine("Пожалуйста, введите Ваш Password: ");
                                            string password = Console.ReadLine();
                                            ga.Obl_Zapis(login, password, all_games[count - 1]);
                                            Console.WriteLine("Запущена онлайн игра.");
                                            ga.Start_Game_Console(all_games, count - 1, console);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Авторизация.");
                                            Console.WriteLine("Пожалуйста, введите Ваш Login: ");
                                            string login = Console.ReadLine();
                                            Console.WriteLine("Пожалуйста, введите Ваш Password: ");
                                            string password = Console.ReadLine();
                                            ga.Obl_Zapis(login, password, all_games[count - 1]);
                                            if (all_games[count - 1].Autoriz)
                                            {
                                                Console.WriteLine("Запущена онлайн игра.");
                                                ga.Start_Game_Console(all_games, count - 1, console);
                                            }
                                        }
                                    }

                                }


                                do
                                {
                                    Console.WriteLine("1. Сохранить игру.");
                                    Console.WriteLine("2. Загрузить игру.");
                                    Console.WriteLine("3. Поставить рейтиннг игры.");
                                    Console.WriteLine("4. Exit.");

                                    choise = int.Parse(Console.ReadLine());

                                    switch (choise)
                                    {
                                        case 1:
                                            ga.Save_Game(all_games[count - 1]);
                                            break;
                                        case 2:
                                            bool load = ga.Load_Game(all_games[count - 1]);
                                            if (!load)
                                                Console.WriteLine("Невозможно загрузить игру!");
                                            break;
                                        case 3:
                                            Console.WriteLine("Сейчас рейтинг игры " + all_games[count - 1].Raiting);
                                            Console.WriteLine("Поставить рейтинг игры?");
                                            Console.WriteLine("1. Да");
                                            Console.WriteLine("2. Нет");

                                            choise = int.Parse(Console.ReadLine());

                                            if (choise == 1)
                                            {
                                                float raiting = float.Parse(Console.ReadLine());
                                                ga.Set_Raiting(all_games[count - 1], raiting);
                                                //ga.Exit_Game(all_games[count - 1]);
                                            }
                                            else if (choise == 2)
                                            {
                                                //ga.Exit_Game(all_games[count - 1]);
                                            }

                                            break;

                                    }
                                } while (choise != 4);

                                break;
                            
                        }
                        break;
                    case 6:
                        Console.WriteLine("1. Игры(ПК)");
                        Console.WriteLine("2. Игры(телефон)");
                        Console.WriteLine("3. Игры(приставка)");

                        choise = int.Parse(Console.ReadLine());

                        switch (choise)
                        {
                            case 1:
                                foreach (var game in pC.games)
                                {
                                    Console.WriteLine("Имя: " + game.Name);
                                    Console.WriteLine("Жанр(ы): ");
                                    for (int i = 0; i < game.Ganres.Count; i++)
                                        Console.WriteLine(game.Ganres[i]);
                                    Console.WriteLine("Платформа(ы): ");
                                    for (int i = 0; i < game.Platforms.Count; i++)
                                        Console.WriteLine(game.Platforms[i]);
                                    Console.WriteLine("Минимальные системные требования: ");
                                    for (int i = 0; i < game.Platforms.Count; i++)
                                    {
                                        Console.WriteLine("Процессор для платформы " + (i + 1) + " = " + game.Processor[i]);
                                        Console.WriteLine("Объем оперативной памяти для платформы " + (i + 1) + " = " + game.Oper_memory[i]);
                                        Console.WriteLine("Видеокарта/видеочип/PZU для платформы " + (i + 1) + " = " + game.Video_cart[i]);
                                        Console.WriteLine("Объем HDD/Внутренней памяти/HDD для платформы " + (i + 1) + " = " + game.Sise_HDD[i]);
                                    }
                                    Console.WriteLine("Рейтинг игры: " + game.Raiting);

                                }
                                break;
                            case 2:
                                foreach (var game in mobile.games)
                                {
                                    Console.WriteLine("Имя: " + game.Name);
                                    Console.WriteLine("Жанр(ы): ");
                                    for (int i = 0; i < game.Ganres.Count; i++)
                                        Console.WriteLine(game.Ganres[i]);
                                    Console.WriteLine("Платформа(ы): ");
                                    for (int i = 0; i < game.Platforms.Count; i++)
                                        Console.WriteLine(game.Platforms[i]);
                                    Console.WriteLine("Минимальные системные требования: ");
                                    for (int i = 0; i < game.Platforms.Count; i++)
                                    {
                                        Console.WriteLine("Процессор для платформы " + (i + 1) + " = " + game.Processor[i]);
                                        Console.WriteLine("Объем оперативной памяти для платформы " + (i + 1) + " = " + game.Oper_memory[i]);
                                        Console.WriteLine("Видеокарта/видеочип/PZU для платформы " + (i + 1) + " = " + game.Video_cart[i]);
                                        Console.WriteLine("Объем HDD/Внутренней памяти/HDD для платформы " + (i + 1) + " = " + game.Sise_HDD[i]);
                                    }
                                    Console.WriteLine("Рейтинг игры: " + game.Raiting);

                                }
                                break;
                            case 3:
                                foreach (var game in console.games)
                                {
                                    Console.WriteLine("Имя: " + game.Name);
                                    Console.WriteLine("Жанр(ы): ");
                                    for (int i = 0; i < game.Ganres.Count; i++)
                                        Console.WriteLine(game.Ganres[i]);
                                    Console.WriteLine("Платформа(ы): ");
                                    for (int i = 0; i < game.Platforms.Count; i++)
                                        Console.WriteLine(game.Platforms[i]);
                                    Console.WriteLine("Минимальные системные требования: ");
                                    for (int i = 0; i < game.Platforms.Count; i++)
                                    {
                                        Console.WriteLine("Процессор для платформы " + (i + 1) + " = " + game.Processor[i]);
                                        Console.WriteLine("Объем оперативной памяти для платформы " + (i + 1) + " = " + game.Oper_memory[i]);
                                        Console.WriteLine("Видеокарта/видеочип/PZU для платформы " + (i + 1) + " = " + game.Video_cart[i]);
                                        Console.WriteLine("Объем HDD/Внутренней памяти/HDD для платформы " + (i + 1) + " = " + game.Sise_HDD[i]);
                                    }
                                    Console.WriteLine("Рейтинг игры: " + game.Raiting);

                                }
                                break;
                        }
                        break;
                }
            } while (choise != 7);
            
        }
    }
}
