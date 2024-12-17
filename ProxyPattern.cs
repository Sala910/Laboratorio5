using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba5
{
    // Интерфейс для работы с базой данных
    public interface IDatabase
    {
        void Query(string sql);
    }

    // Реальный объект
    public class RealDatabase : IDatabase
    {
        public void Query(string sql)
        {
            Console.WriteLine($"Executing query: {sql}");
        }
    }

    // Прокси-объект
    public class DatabaseProxy : IDatabase
    {
        private RealDatabase realDatabase;
        private bool hasAccess;

        public DatabaseProxy(bool access)
        {
            realDatabase = new RealDatabase();
            hasAccess = access;
        }

        public void Query(string sql)
        {
            if (hasAccess)
                realDatabase.Query(sql);
            else
                Console.WriteLine("Access denied.");
        }
    }

}
