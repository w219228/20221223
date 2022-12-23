using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebApplication1.Models.EFModels
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("name=AppConnStr")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);
        }

		public System.Data.Entity.DbSet<WebApplication1.Models.VM.ProductIndexVm> ProductIndexVms { get; set; }

		public System.Data.Entity.DbSet<WebApplication1.Models.VM.CategoryIndexVm> CategoryIndexVms { get; set; }
	}
}
