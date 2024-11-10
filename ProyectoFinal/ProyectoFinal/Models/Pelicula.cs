using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class Pelicula
    {
        [Key]
        public int IdPeliculas { get; set; }
        public string Titulo { get; set; }
        public string Autor {  get; set; }
        public string Sinopsis { get; set; }
        public string Duracion { get; set; }
        public string Clasificacion { get; set;}
        public byte[] Foto { get; set; }
    }
}
