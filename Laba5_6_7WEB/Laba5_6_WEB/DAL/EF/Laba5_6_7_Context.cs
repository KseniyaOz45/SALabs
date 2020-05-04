namespace DAL.EF
{
    using DAL.Entities;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Laba5_6_7_Context : DbContext
    {
        // Контекст настроен для использования строки подключения "Laba5_6_7_Context" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "DAL.EF.Laba5_6_7_Context" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "Laba5_6_7_Context" 
        // в файле конфигурации приложения.
        //public Laba5_6_7_Context()
        //    : base("name=Laba5_6_7_Context")
        //{
        //    Database.SetInitializer<Laba5_6_7_Context>(new DBInitializer());
        //}

        public Laba5_6_7_Context(string connectionString)
            : base(connectionString)
        {
        }

        static Laba5_6_7_Context()
        {
            Database.SetInitializer<Laba5_6_7_Context>(new DBInitializer());
        }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Atraction> Atractions { get; set; }
        public DbSet<Hero> Heroes { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}