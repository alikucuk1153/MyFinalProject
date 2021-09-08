using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products; // veri tabanı
        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                // Oracle, Sql, Postgres, MongoDb, Excel ....gibi veri kaynaklarından geliyor gibi simüle edildi
                new Product{ProductId=1, CategoryId=1, ProductName="Bardak", UnitPrice=15, UnitsInStock=15},
                new Product{ProductId=1, CategoryId=2, ProductName="Kamera", UnitPrice=500, UnitsInStock=3},
                new Product{ProductId=1, CategoryId=3, ProductName="Telefon", UnitPrice=1500, UnitsInStock=2},
                new Product{ProductId=1, CategoryId=4, ProductName="Klavye", UnitPrice=150, UnitsInStock=65},
                new Product{ProductId=1, CategoryId=5, ProductName="Fare", UnitPrice=85, UnitsInStock=1},
            };
        }
        public void Add(Product product)
        {
            _products.Add(product); //veri tabanı list e eklemek
        }

        public void Delete(Product product)
        {
            // LINQ - Language Integrated Query - Dile Gömülü Sorgulama - Liste bazlı yapıları aynı Sql gibi filtrelemeye yarar.
          
            // ürünleri tek tek dolaşmaya yarar ve yeni ürün ıd ile ürünün ıd eşit ise
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            _products.Remove(productToDelete);
        }
            
        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            // where kosuluna uyan ürünleri yeni bir liste haline getirir ve onu döndürür.
           return _products.Where(p => p.CategoryId == categoryId).ToList(); 
        }

        public void Update(Product product)  // ekrandan gelen ürün
        {
            // gönderilen ürün ıd sine sahip listedeki ürünü bul
            // ekrandan gelen ürünleri data daki ürünlerle güncelleme işlemi
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
