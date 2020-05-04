namespace Laba4_Console
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using DAL;

    public class MyModel : DbContext
    {
        // Контекст настроен для использования строки подключения "MyModel" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "Laba4_Console.MyModel" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "MyModel" 
        // в файле конфигурации приложения.
        public MyModel()
            : base("name=MyModel")
        {
            Database.SetInitializer(
                new DropCreateDatabaseIfModelChanges<MyModel>());
        }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Order> OrderEntities { get; set; }
        public virtual DbSet<Zone> ZoneEntities { get; set; }
        public virtual DbSet<Atraction> AtractionEntities { get; set; }
        public virtual DbSet<Hero> HeroEntities { get; set; }
        public virtual DbSet<OrderPrice> OrderPrices { get; set; }

        
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}