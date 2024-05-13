using Microsoft.EntityFrameworkCore;

namespace MentoringApp
{
    public class TaskToDoDB : DbContext
    {
        public DbSet<TaskToDoModel> TaskToDo { get; set; }

        public TaskToDoDB(DbContextOptions<TaskToDoDB> options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "ToDosDb");
        }
    }
}
