using System;
using Microsoft.EntityFrameworkCore;
namespace ListOfActivities.Models
{
	public class ActivitiesContext : DbContext
	{
		public DbSet<Activities> Activities { get; set; } = null!;

		public ActivitiesContext(DbContextOptions options)
			:base(options)
		{
			Database.EnsureCreated();
		}
	}
}

