namespace ProductsInvntory.Controllers {
    using System.Web.Mvc;
    using System.Linq;
    using Infrastructure;
    using Models;

    [Authorize]
    public class ProductController : Controller {
        readonly ProductsRepository _productsRepo;

        public ProductController() {
            _productsRepo = new ProductsRepository();
        }

        [HttpGet]
        public JsonResult All() {
            return Json(_productsRepo.All(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void Update(ProductStock productStock) {
            var dprod = _productsRepo.All().SingleOrDefault(prod => prod.Id == productStock.Id);
            if (dprod != null) {
                dprod.UnitsInStock = productStock.UnitsInStock;
                _productsRepo.AddOrUpdate(dprod);
            }
        }
    }
}