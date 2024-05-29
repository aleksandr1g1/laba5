using System;

class ProductNotFoundException : Exception
{
    public ProductNotFoundException(string message) : base(message)
    {
    }
}

class Warehouse
{
    public int ProductQuantity { get; private set; }

    public Warehouse(int initialQuantity)
    {
        ProductQuantity = initialQuantity;
    }

    public void DeductProduct(int quantity)
    {
        try
        {
            if (ProductQuantity < quantity)
            {
                throw new ProductNotFoundException("Товар отсутствует на складе");
            }
            else
            {
                ProductQuantity -= quantity;
                Console.WriteLine($"Остаток товара на складе: {ProductQuantity}");
            }
        }
        catch (ProductNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла ошибка: " + ex.Message);
        }
        finally
        {
            Console.WriteLine($"Окончательное количество товара на складе: {ProductQuantity}");
        }
    }
}

class Program
{
    static void Main()
    {
        Warehouse warehouse = new Warehouse(100);

        try
        {
            warehouse.DeductProduct(120);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Исключение перехвачено: " + ex.Message);
        }

        Console.ReadLine();
    }
}