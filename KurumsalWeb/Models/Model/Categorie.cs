using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KurumsalWeb.Models.Model
{
    [Table("Categorie")]
    public class Categorie
    {
        [Key]
        public int CategorieId { get; set; }
        [Required,StringLength(50,ErrorMessage ="Must be at least 50 characters!")]
        public string CategorieName { get; set; }
        public string CategorieExplanation { get; set; }
        public ICollection<Blog> Blogs { get; set; }
    }
}