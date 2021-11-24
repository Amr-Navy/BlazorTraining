using GenericDataManager.Models;
using GenericDataManager.Repositories;
using System;
using System.Linq;

namespace GenericDataManager
{
    class Program
    {
        static void Main(string[] args)
        {
            //var CustomerManager = new DataManager<Customer, CustomersDataContext>(new CustomersDataContext());
            var CustomerManager = new MemoryDataManager<Customer>();

            string name = "My Customer";
            
            // Create (C)
            var MyCustomer = CustomerManager.Insert(new Customer() { Name = name }).Result;

            if (MyCustomer != null)
			{
                Console.WriteLine($"Customer {MyCustomer.Name} was created successfully");
			}

            MyCustomer = null;

            // Retrieve (R)
            MyCustomer = CustomerManager.Get(x => x.Name == name).Result.FirstOrDefault();

            if (MyCustomer != null)
            {
                Console.WriteLine($"Customer {MyCustomer.Name} was retrieved successfully");

                // Update (U)
                MyCustomer.Name = "Name Changed";
                MyCustomer = CustomerManager.Update(MyCustomer).Result;

                if (MyCustomer.Name != name)
                {
                    Console.WriteLine($"Customer {MyCustomer.Name} was updated successfully");
                }

                // Delete (D)
                var deleted = CustomerManager.Delete(MyCustomer).Result;
                if (deleted)
                {
                    Console.WriteLine($"Customer {MyCustomer.Name} was deleted successfully");
                }

            }


            Console.ReadLine();
        }
    }

    
}
