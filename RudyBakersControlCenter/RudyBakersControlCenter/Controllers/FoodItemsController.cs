using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RudyBakers.Data.DAL;
using RudyBakers.Data.Model;
using RudyBakersControlCenter.ViewModels;
using WebGrease.Css.Extensions;

namespace RudyBakersControlCenter.Controllers
{
    public class FoodItemsController : Controller
    {
        private RudyBakerContext db = new RudyBakerContext();

        // GET: FoodItems
        public ActionResult Index()
        {
            return View(db.FoodItems.ToList());
        }

        // GET: FoodItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodItem foodItem = db.FoodItems.Find(id);
            if (foodItem == null)
            {
                return HttpNotFound();
            }
			var fivm = GetFoodItemVM(foodItem);
			return View(fivm);
        }

        // GET: FoodItems/Create
        public ActionResult Create()
        {
	        ViewBag.HealthInfoList = HttpContext.Application["HealthInfos"] as ICollection<HealthInfo>;
            return View();
        }

        // POST: FoodItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,ShortDescription,LongDescription")] FoodItem foodItem)
        {
            if (ModelState.IsValid)
            {
                db.FoodItems.Add(foodItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(foodItem);
        }

        // GET: FoodItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodItem foodItem = db.FoodItems.Find(id);
            if (foodItem == null)
            {
                return HttpNotFound();
            }
			var fivm = GetFoodItemVM(foodItem);
			return View(fivm);
        }

        // POST: FoodItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FoodItemViewModel fivm)
        {
            if (ModelState.IsValid)
            {
				db.Entry(fivm.FoodItem).State = EntityState.Modified;
	            db.Entry(fivm.FoodItem).Collection(fi => fi.HealthInfos).Load();
	            fivm.PostedHealthInfoIds.ForEach(i =>
	            {
		            if (fivm.FoodItem.HealthInfos.All(h => h.ID != i))
		            {
			            var newHi = new HealthInfo {ID = i};
						db.HealthInfos.Attach(newHi);
						fivm.FoodItem.HealthInfos.Add(newHi);//db.HealthInfos.Find(i));
			            
		            }
	            });

				fivm.FoodItem.Prices = fivm.FoodItem.Prices.Where(p => p.Amount != decimal.Zero).ToList();

				var newPrice = fivm.FoodItem.Prices.Where(p => p.ID == 0);
	            newPrice.ForEach(np => db.Prices.Add(np));

				//db.FoodItems.Attach(fivm.FoodItem);

				db.SaveChanges();
                return RedirectToAction("Index");
            }
	        
            return View(fivm);
        }

        // GET: FoodItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodItem foodItem = db.FoodItems.Find(id);
            if (foodItem == null)
            {
                return HttpNotFound();
            }
            return View(foodItem);
        }

        // POST: FoodItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FoodItem foodItem = db.FoodItems.Find(id);
            db.FoodItems.Remove(foodItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

		public ActionResult DeletePrice(int id)
		{
			db.Prices.Remove(db.Prices.Find(id));
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult AddPrice(int foodItemId)
		{
			var price = new Price();
			var fivm = GetFoodItemVM(db.FoodItems.Find(foodItemId));
			db.Prices.Add(price);
			fivm.FoodItem.Prices.Add(price);
			
			//db.SaveChanges();
			return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
		}
		protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

	    private FoodItemViewModel GetFoodItemVM(FoodItem foodItemModel)
	    {
		    var fivm = new FoodItemViewModel();
		    fivm.FoodItem = foodItemModel;
		    fivm.AllHealthInfos = db.HealthInfos.ToList(); //CacheManager.GetHealthInfos();
			fivm.FoodItem.Prices.Add(new Price());
		    fivm.PriceDisplay = fivm.FoodItem.Prices.Select(p =>
		    {
			    switch (p.Unit)
			    {
				    case UnitEnum.Dozen:
					    return $"{p.Amount:C} per dozen";
				    case UnitEnum.Each:
					    return $"{p.Amount:C} each";
				    case UnitEnum.Pound:
					    return $"{p.Amount:C} per pound";
				    default:
					    return $"{p.Amount:C}";
			    }
		    });
		    return fivm;
	    }
    }
}
