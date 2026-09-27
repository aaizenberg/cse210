// Bonus applies an optional discount and shows the savings and final billed total
class Program
{
    static void DisplayOrder(Order order, decimal discountPercent)
    {
        if (discountPercent < 0m || discountPercent > 1m)
        {
            throw new ArgumentOutOfRangeException(
                nameof(discountPercent),
                "must be between 0 and 1"
            );
        }

        decimal totalCost = order.CalculateTotalCost();
        decimal discountAmount = totalCost * discountPercent;
        decimal finalTotal = totalCost - discountAmount;

        Console.WriteLine("Packing Label ");
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine("Shipping Label ");
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Cost ${totalCost:F2}");

        if (discountAmount > 0m)
        {
            Console.WriteLine($"Discount -${discountAmount:F2}");
        }

        Console.WriteLine($"Final Total ${finalTotal:F2}");
        Console.WriteLine();
    }

    static void Main()
    {
        Address usaAddress = new Address(
            "123 Main Street",
            "Seattle",
            "Washington",
            "USA"
        );
        Customer usaCustomer = new Customer("Alex Johnson", usaAddress);
        Order usaOrder = new Order(usaCustomer);
        usaOrder.AddProduct(new Product("Mouse", "101", 24.99m, 2));
        usaOrder.AddProduct(new Product("Mechanical Keyboard", "205", 89.50m, 1));

        Address internationalAddress = new Address(
            "123 de la calle ejemplo ",
            "Madrid",
            "Madrid",
            "Spain"
        );
        Customer internationalCustomer = new Customer("Sofia Garcia Perez", internationalAddress);
        Order internationalOrder = new Order(internationalCustomer);
        internationalOrder.AddProduct(new Product("USBC Hub", "310", 39.99m, 1));
        internationalOrder.AddProduct(new Product("macbook", "415", 32.75m, 2));

        DisplayOrder(usaOrder, 0.10m);
        DisplayOrder(internationalOrder, 0m);
    }
}
