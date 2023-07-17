using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KurumsalWeb.Models.Model
{
    [Table ("Sevice")]
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }
        [Required,StringLength(150,ErrorMessage ="Must be at least 150 characters!")]
        [DisplayName("Service Title")]
        public string ServiceTitle { get; set; }
        [DisplayName("Service Explanation")]
        public string ServiceExplanation { get; set; }
        [DisplayName("Service Image")]
        public string ImageURL { get; set; }


    }
}