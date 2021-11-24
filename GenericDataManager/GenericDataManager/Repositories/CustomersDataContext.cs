using GenericDataManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericDataManager.Repositories
{
	public class CustomersDataContext : DbContext
	{
		public DbSet<Customer> Customers { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=CustomersDB;Data Source=IZANAGI\SQLEXPRESS");
		}
	}
}
