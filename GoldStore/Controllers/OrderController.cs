using GoldStore.Extensions;
using GoldStore.Models;
using GoldStore.Services.Store;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace GoldStore.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;

        public OrderController(IOrderService orderService, IProductService productService)
        {
            _orderService = orderService;
            _productService = productService;
        }

        // GET: Orders
        public ActionResult Index()
        {
            var orderEntity = _orderService.GetAllOrders();

            var orders = orderEntity.Select(x => x.ToModel());

            return View(orders.ToList());             
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        { 
            if (id == null)
            {
                return RedirectToAction("Index");
            }        
            var orderEagerLoaded = _orderService.GetOrderByIdEagerLoad(id);

            if (orderEagerLoaded == null)
            {
                return RedirectToAction("Index");
            }

            OrderModel orderModel = orderEagerLoaded.ToModel();

            orderModel.OrderItems = orderEagerLoaded.OrderItems.Select(x => x.ToModel()).ToList();
            
            if (orderModel == null)
            {
                return RedirectToAction("Index");
            }
            return View(orderModel);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OrderCode,OrderStatusId,OrderTotal,OrderDate")] OrderModel orderModel)
        {   
            if (ModelState.IsValid)
            {
                var order = orderModel.ToEntity();

                _orderService.InsertOrder(order);

                return RedirectToAction("Index");
            }

            return View(orderModel);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            var order = _orderService.GetOrderById(id);
            OrderModel orderModel = order.ToModel();

            if (orderModel == null)
            {
                return HttpNotFound();
            }
            return View(orderModel);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OrderCode,OrderStatusId,OrderTotal,OrderDate")] OrderModel orderModel)
        {
            if (ModelState.IsValid)
            {
                var order  = _orderService.GetOrderById(orderModel.Id);
                order = orderModel.ToEntity(order);
                _orderService.UpdateOrder(order);

                return RedirectToAction("Index");
            }
            return View(orderModel);         
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var order = _orderService.GetOrderById(id);
            OrderModel orderModel = order.ToModel();

            if (orderModel == null)
            {
                return HttpNotFound();
            }

            return View(orderModel);         
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var order = _orderService.GetOrderById(id);           
            _orderService.DeleteOrder (order);
            return RedirectToAction("Index");
        } 
        
        // GET: Orders/Create
        public ActionResult CreateOrderItem(int? OrderId, string btnId, string formId)
        {
            var order = _orderService.GetOrderById(OrderId);
            OrderModel orderModel = order.ToModel();

            if (orderModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrderCode = order.OrderCode;
            OrderItemModel orderItemModel = new OrderItemModel();
            orderItemModel.OrderId = OrderId;

            //orderItemModel.AvailableProducts.Add(new SelectListItem { Text = "-Please select a Product-", Value = "0" });
            foreach (var product in _productService.GetAllProducts())
                orderItemModel.AvailableProducts.Add(new SelectListItem { Text = product.Name, Value = product.Id.ToString() });
             
            return View(orderItemModel);
          
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrderItem(string btnId, string formId, [Bind(Include = "Id,OrderId,ProductId,Quantity,Cost")] OrderItemModel orderItemModel)
        { 
            if (ModelState.IsValid)
            {
                var orderItem  = orderItemModel.ToEntity();
                
                _orderService.InsertOrderItem(orderItem);
                
                ViewBag.RefreshPage = true; 
                ViewBag.btnId = btnId;
                ViewBag.formId = formId;
                return View(orderItemModel);
                //return RedirectToAction("Index");
            }
            return View(orderItemModel);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("DeleteOrderItem")]        
        public JsonResult DeleteOrderItemConfirmed(int id)
        {
            var orderItem = _orderService.GetOrderItemById(id);
            //orderItem = orderItem.ToEntity(orderItem);
            _orderService.DeleteOrderItem(orderItem);

            return Json(JsonRequestBehavior.AllowGet);
        }

        private void PopulateDepartmentsDropDownList(object selectedDepartment = null)
        {
             
            var products = _productService.GetAllProducts();

            //ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "Name");
            ViewBag.Department_ID = new SelectList(products, "Id", "Name", selectedDepartment);
            ViewData["ProductSelectList"] = new SelectList(products, "Id", "Name", selectedDepartment);

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
