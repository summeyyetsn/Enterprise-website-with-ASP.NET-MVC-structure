using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KurumsalWeb.Models.Model
{
    [Table ("SystemIdentity")]
    public class SystemIdentity
    {
        [Key]
        public int IdentityId { get; set; }
        [DisplayName("Website Title")]
        [Required,StringLength(100,ErrorMessage ="Must be at least 100 characters!")]
        public string Title { get; set; }
        [DisplayName("Website Keywords")]
        [Required, StringLength(200, ErrorMessage = "Must be at least 200 characters!")]
        public string Keywords { get; set; }
        [AllowHtml]
        [DisplayName("Website Description")]
        [Required, StringLength(300, ErrorMessage = "Must be at least 300 characters!")]
        public string Description { get; set; }
        [DisplayName("Website LogoURL ")]
        public string LogoURL { get; set; }
        [DisplayName("Website SuperScription")]
        public string SuperScription { get; set; }
    }
}