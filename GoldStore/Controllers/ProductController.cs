using GoldStore.Extensions;
using GoldStore.Models;
using GoldStore.Services.Store;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace GoldStore.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
         
        // GET: Products
        public ActionResult Index()
        {
            var productEntity = _productService.GetAllProducts();

            var products = productEntity.Select(x => x.ToModel());

            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = _productService.GetProductById(id);
            ProductModel productModel = product.ToModel();


            if (productModel == null)
            {
                return HttpNotFound();
            }
            return View(productModel);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Price,BatchNum,ExpiryDate,Count")] ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                var product = productModel.ToEntity();

                _productService.InsertProduct(product);

                return RedirectToAction("Index");
            }

            return View(productModel);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = _productService.GetProductById(id);
            ProductModel productModel = product.ToModel();

            if (productModel == null)
            {
                return HttpNotFound();
            }
            return View(productModel);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price,BatchNum,ExpiryDate,Count")] ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                var product = _productService.GetProductById(productModel.Id);
                product = productModel.ToEntity(product);
                _productService.UpdateProduct(product);

                return RedirectToAction("Index");
            }
            return View(productModel);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = _productService.GetProductById(id);
            ProductModel productModel = product.ToModel();

            if (product == null)
            {
                return HttpNotFound();
            }
            return View(productModel);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var product = _productService.GetProductById(id);
            _productService.DeleteProduct(product);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {                
            }
            base.Dispose(disposing);
        }
    }
}
