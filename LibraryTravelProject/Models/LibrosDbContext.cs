using Microsoft.EntityFrameworkCore;
using static LibraryTravelProject.Models.Libro;




namespace LibraryTravelProject.Models
{

	//En esta clase, se definen cuatro propiedades que representan cada una de las tablas del MER:
	public class LibrosDbContext : DbContext
	{
		public DbSet<Autor> Autores { get; set; }
		public DbSet<Libro> Libros { get; set; }
		public DbSet<editoriales> Editoriales { get; set; }
		public DbSet<AutorLibro> AutoresLibros { get; set; }


		//propiedad representa la tabla de relación autores_has_libros

		public LibrosDbContext(DbContextOptions<LibrosDbContext> options) : base(options) { }
		//Además, se define un constructor que recibe una instancia de DbContextOptions<LibrosDbContext> que se utiliza para configurar la conexión a la base de datos.

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<AutorLibro>().HasKey(al => new { al.AutorId, al.LibroISBN });
			modelBuilder.Entity<editoriales>().Property(e => e.id).HasColumnName("id").IsRequired();


		}

	}

}


