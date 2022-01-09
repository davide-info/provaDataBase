using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace database
{
    public class Studente
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual  int IdStudente
        { get; set; }

        [Required]

        public virtual string Nome { get; set; }

        public virtual ICollection<Studente> Studenti { get; set; }
    }

    public class Esame
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int IdEsame { get; set; }
        [ForeignKey("studente")]
        public virtual int StudenteForeignKey { get; set; }
        public virtual Studente StudenteKey { get; set; }
        public int VotoEsame { get; set; }
        public DateTime DataEsame { get; set; }
    }


    public class MyContext : DbContext

    {
        private const string ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = master; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public MyContext()
        {

        }
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Studente>().ToTable("Studenti");
            modelBuilder.Entity<Esame>().ToTable("Esami");
            
        }

        public DbSet<Studente> Studenti { get; set; }
        public DbSet<Esame> Esami { get; set; }

        
    }
    }

