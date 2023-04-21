using System;

namespace ClothesCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = new ClothesRepository();

            repository.Insert(new Clothes { Brand = "Dior", Style = "Casual", Price = 50.99m });
            repository.Insert(new Clothes { Brand = "Channel", Style = "Formal", Price = 35.50m });
            repository.Insert(new Clothes { Brand = "Gucci", Style = "Luxury", Price = 500.00m });

            var allClothes = repository.GetAll();
            Console.WriteLine("All clothes:");

            foreach (var clothes in allClothes)
            {
                Console.WriteLine($"Id: {clothes.Id}, Brand: {clothes.Brand}, Style: {clothes.Style}, Price: {clothes.Price}");
            }

            var clothesById = repository.GetById(2);
            Console.WriteLine("\nClothes by id:");
            Console.WriteLine($"Id: {clothesById.Id}, Brand: {clothesById.Brand}, Style: {clothesById.Style}, Price: {clothesById.Price}");

            var expensiveClothes = repository.Find(c => c.Price > 100);
            Console.WriteLine("\nExpensive clothes:");
            foreach (var clothes in expensiveClothes)
            {
                Console.WriteLine($"Id: {clothes.Id}, Brand: {clothes.Brand}, Style: {clothes.Style}, Price: {clothes.Price}");
            }

            repository.Update(new Clothes { Id = 1, Brand = "Mango", Style = "Casual", Price = 45.00m });
            var updatedClothes = repository.GetById(1);
            Console.WriteLine("\nUpdated clothes:");
            Console.WriteLine($"Id: {updatedClothes.Id}, Brand: {updatedClothes.Brand}, Style: {updatedClothes.Style}, Price: {updatedClothes.Price}");

            repository.Delete(3);
            var deletedClothes = repository.GetById(3);
            Console.WriteLine("\nDeleted clothes:");
            Console.WriteLine(deletedClothes == null ? "Not found" : $"Id: {deletedClothes.Id}, Brand: {deletedClothes.Brand}, Style: {deletedClothes.Style}, Price: {deletedClothes.Price}");
        }
    }
}