using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entity
{
	public partial class EFContext : DbContext
	{ 
		public virtual DbSet<Users> Users { get; set; }
		

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			//if (!optionsBuilder.IsConfigured)
			//{

			//	optionsBuilder.UseSqlServer(@"Server=.;Database=TEST;user id=sa;password=123_*1;MultipleActiveResultSets=True;");
			//}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			
		}
	}
}