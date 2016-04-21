using System;
using System.IO;
using SQLite;



namespace DatabaseDemo.ORM
{
    public class DBRepository
    {
        // Código para criar o banco
        public string CreateDB()
        {
            var output = "";
            output += "Creating Database if it doesn't exist...";
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "ormdemo.db3");
            var db = new SQLiteConnection(dbPath);
            output += "Database Created...";

            return output;
        }

        public string CreateTable()
        {
            try
            {
                string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "ormdemo.db3");
                var db = new SQLiteConnection(dbPath);

                db.CreateTable<ToDoTasks>();

                string result = "Table Created Successfully...";
                return result;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }

        }

        public string InsertRecord(string task)
        {
            try
            {
                string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "ormdemo.db3");
                var db = new SQLiteConnection(dbPath);

                ToDoTasks item = new ToDoTasks();
                item.Task = task;
                db.Insert(item);

                return "Record Added...";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        // Code to retrieve all the records...
        public string GetAllRecords()
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "ormdemo.db3");
            var db = new SQLiteConnection(dbPath);

            string output = "";
            output += "Retrieving the data using ORM...";

            var table = db.Table<ToDoTasks>();
            foreach(var item in table)
            {
                output += "\n" + item.Id + "---" + item.Task;
            }

            return output;
        }

        // Code to retrieve specific record using ORM...
        public string GetTaskByID(int id)
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "ormdemo.db3");
            var db = new SQLiteConnection(dbPath);

            var item = db.Get<ToDoTasks>(id);

            return item.Task;

        }

        // Code to update the record using ORM...
        public string UpdateRecord(int id, string task)
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "ormdemo.db3");
            var db = new SQLiteConnection(dbPath);

            var item = db.Get<ToDoTasks>(id);
            item.Task = task;
            db.Update(item);

            return "Record Updated...";
        }

        // Code to delete the record using ORM...
        public string RemoveTask(int id)
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "ormdemo.db3");
            var db = new SQLiteConnection(dbPath);

            //var item = db.Delete<ToDoTasks>(id);
            var item = db.Get<ToDoTasks>(id);
            db.Delete(item);
            return "Record Deleted...";
        }
    }
}