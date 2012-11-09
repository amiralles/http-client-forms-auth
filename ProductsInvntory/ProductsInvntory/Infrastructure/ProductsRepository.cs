namespace ProductsInvntory.Infrastructure {
    using System.Collections.Generic;
    using Controllers;
    using Models;

    public class ProductsRepository {
        private readonly List<Product> _products;
        public ProductsRepository() {
            _products = new List<Product>(new[] {
                new Product{Id=1, UnitsInStock=14, Name="Foo"},
                new Product{Id=2, UnitsInStock=05, Name="Bar"},
                new Product{Id=3, UnitsInStock=20, Name="Baz"},
                new Product{Id=4, UnitsInStock=12, Name="Bazinga"}
            });
        }

        public List<Product> All() {
            return _products;
        }

        public void AddOrUpdate(Product productStock) {
            if (_products.Contains(productStock))
                _products.Remove(productStock);
            _products.Add(productStock);
        }
    }
}