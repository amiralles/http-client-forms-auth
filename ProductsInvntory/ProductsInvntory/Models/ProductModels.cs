namespace ProductsInvntory.Models {
    public class ProductStock {
        public virtual int Id { get; set; }
        public virtual int UnitsInStock { get; set; }
    }

    public class Product {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int UnitsInStock { get; set; }
    }
}