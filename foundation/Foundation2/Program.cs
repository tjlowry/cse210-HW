using System;

class Program
{
    static void Main()
    {
        Address address1 = new Address("123 Elm St", "San Antonio", "TX", "USA");
        Address address2 = new Address("456 Pine St", "San Antonio", "TX", "USA");

        Customer customer1 = new Customer("Alex Johnson", address1);
        Customer customer2 = new Customer("Emily Davis", address2);

        Product product1 = new Product("Notebook", "N001", 2.99f, 5);
        Product product2 = new Product("Pencil", "P002", 0.99f, 10);
        Product product3 = new Product("Backpack", "B003", 24.99f, 1);

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product2);
        order2.AddProduct(product3);

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost():0.00}\n");

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost():0.00}");
    }
}