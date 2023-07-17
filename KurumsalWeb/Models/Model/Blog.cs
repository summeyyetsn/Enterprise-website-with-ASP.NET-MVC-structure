using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KurumsalWeb.Models.Model
{
    [Table("Blog")]
    public class Blog
    {
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogText { get; set; }
        public string BlogImageURL { get; set; }
        public int? CategorieId { get; set; }
        public Categorie Categorie { get; set; }
    }
}