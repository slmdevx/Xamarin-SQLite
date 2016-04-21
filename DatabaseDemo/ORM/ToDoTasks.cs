using SQLite;

namespace DatabaseDemo.ORM
{
    [Table("ToDoTasks")]
    class ToDoTasks
    {
        [PrimaryKey, AutoIncrement, Column("_Id")]
        public int Id { get; set; }

        [MaxLength (50)]
        public string Task { get; set; }
    }
}