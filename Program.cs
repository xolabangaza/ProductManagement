using System;
using System.Collections.Generic;

public class Product
{
    public int ProductID { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        List<Product> products = new List<Product>();
        bool exit = false;

            Console.WriteLine("Welcome , choose form the following menu(1-4): "+"\n"+"\n"+ "1. Add a new product"+ "\n"+ "2. View all products" + "\n"+ "3. Remove a product"+"\n"+ "4. Exit"+"\n");
        while (!exit)
        {
            Console.Write("Select an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    AddProduct(products);
                    break;
                case "2":
                    ViewProducts(products);
                    break;
                case "3":
                    Console.Write("Enter the ProductID to remove: ");
                    if (int.TryParse(Console.ReadLine(), out int productId))
                    {
                        RemoveProduct(products, productId);
                    }
                    else
                    {
                        Console.WriteLine("Invalid ProductID.");
                    }
                    break;
                case "4":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid selection. Please try again.");
                    break;
            }
        }
    }

    static void AddProduct(List<Product> products)
    {
        Product newProduct = new Product();

        int productId; // Declare the variable here
        decimal price; // Declare the variable here

        Console.Write("Enter ProductID: ");
        while (!int.TryParse(Console.ReadLine(), out productId))
        {
            Console.WriteLine("Invalid input. Please enter a numeric ProductID.");
        }
        newProduct.ProductID = productId;

        Console.Write("Enter Name: ");
        newProduct.Name = Console.ReadLine();

        Console.Write("Enter Price: ");
        while (!decimal.TryParse(Console.ReadLine(), out price))
        {
            Console.WriteLine("Invalid input. Please enter a numeric Price.");
        }
        newProduct.Price = price;

        products.Add(newProduct);
        Console.WriteLine("Product added successfully.");
    }

    static void ViewProducts(List<Product> products)
    {
        Console.WriteLine("\nProducts List:");
        for (int i = 0; i < products.Count; i++)
        {
            Console.WriteLine($"{i + 1}. ProductID: {products[i].ProductID}, Name: {products[i].Name}, Price: {products[i].Price:C}");
        }
    }

    static void RemoveProduct(List<Product> products, int productId)
    {
        var productToRemove = products.Find(p => p.ProductID == productId);
        if (productToRemove != null)
        {
            products.Remove(productToRemove);
            Console.WriteLine("Product removed successfully.");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }
}
