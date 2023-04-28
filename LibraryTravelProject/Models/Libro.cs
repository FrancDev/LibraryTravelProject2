using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryTravelProject.Models
{

	[Table("libros")]
	public class Libro
	{

	[Key]
		public int ISBN { get; set; }

		[DisplayName("Editorial")]
		public int editoriales_id { get; set; }

		[ForeignKey("editoriales_id")]
		public editoriales Editorial { get; set; }
		public string Titulo { get; set; }
		public string Sinopsis { get; set; }

        [DisplayName("No. Paginas")]
        public string n_paginas { get; set; }
		public ICollection<Autor> Autores { get; set; }

	}



	[Table("autores")]
	public class Autor
	{

		[Key]
		public int Id { get; set; }
		public string Nombre { get; set; }
		public string Apellidos { get; set; }
		public ICollection<Libro> Libros { get; set; }
	}



	[Table("editoriales")]
	public class editoriales
	{

		[Key]
		public int id { get; set; }
		public string Nombre { get; set; }
		public string Sede { get; set; }
		public ICollection<Libro> Libros { get; set; }
	}

	[Table("autores_has_libros")]
	public class AutorLibro
	{
		public int AutorId { get; set; }
		public int LibroISBN { get; set; }
		public Autor Autor { get; set; }
		public Libro Libro { get; set; }
	}

}

