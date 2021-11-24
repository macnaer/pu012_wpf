using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEditor.Model;

namespace TextEditor.ViewModel.Services
{
    public class UserDbService
    {
        private const string dbName = "Database.db";
        public static string dbPath = Path.Combine(Environment.CurrentDirectory, dbName);

        public User LoginUser(string login, string passsword)
        {
            using (SQLiteConnection connection = new SQLiteConnection(dbPath))
            {
                connection.CreateTable<User>();
                var user = connection.Table<User>().Where(u => u.Username == login && u.Password == passsword).FirstOrDefault();
                return user;
            }         
        }
    }
}
