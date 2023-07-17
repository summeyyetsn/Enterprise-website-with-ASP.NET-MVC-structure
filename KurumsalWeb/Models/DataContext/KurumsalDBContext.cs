using KurumsalWeb.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KurumsalWeb.Models.DataContext
{
    public class KurumsalDBContext : DbContext
    {
        public KurumsalDBContext():base("KurumsalDB")
        {
            
        }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<Categorie> Categorie { get; set; }
        public DbSet<ContactInformation> ContactInformation { get; set; }

        public DbSet<Service> Service { get; set; }
        public DbSet<SystemIdentity> SystemIdentity { get; set; }
    }
}