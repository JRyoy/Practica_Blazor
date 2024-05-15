using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blazor.Persistencia
{
    public class AplicacionDbContext : DbContext
    {
        public AplicacionDbContext(DbContextOptions<AplicacionDbContext> opciones)
            : base(opciones)
        {}

        public DbSet<Formulario> Formulario { get; set; }


        internal static void OnModelCreating()
        {
            throw new NotImplementedException();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Formulario>().HasData(
                        new Formulario("Hola", "Messi@Gmail.com"),
                        new Formulario("Holaxd", "Messixd@Gmail.com"),
                        new Formulario("Holaxdxd", "Messi2xdxd@Gmail.com"),
                        new Formulario("Holaxdxdxd", "Messi2xdxdxd@Gmail.com"),
                        new Formulario("Holaxdxdxdxd", "Messi2xdxdxdxd@Gmail.com")
                    );
        }
    }

    [Table("Formulario")]
    public class Formulario
    {
        private static int _contador = 0;
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Password { get; set; }

        public Formulario(string name, string password)
        {
            Id = ++_contador;
            Name = name;
            Password = password;
        }
    }
}