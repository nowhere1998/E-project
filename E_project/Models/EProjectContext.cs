using Microsoft.EntityFrameworkCore;

namespace E_project.Models
{
    public class EProjectContext : DbContext
    {
        public EProjectContext(DbContextOptions<EProjectContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionDetail> TransactionDetails { get; set; }

    }
}
