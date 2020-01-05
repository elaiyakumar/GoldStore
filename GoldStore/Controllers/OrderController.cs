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
    
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
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
        public ActionResult Create([Bind(Include = "Id,OrderCode,PoductId,Quantity,Cost,OrderDate")] OrderModel orderModel)
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

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OrderCode,PoductId,Quantity,Cost,OrderDate")] OrderModel orderModel)
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {                
            }
            base.Dispose(disposing);
        }
    }
}
