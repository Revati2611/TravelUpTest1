using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelUpTask1.Models;

namespace TravelUpTask1.Controllers
{
    public class ItemController : Controller
    {
        private static List<ItemModel> items = new List<ItemModel>();
        private static int currentId = 1;
        // GET: Item
        public ActionResult Index()
        {
            return View(items);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ItemModel item)
        {
            if (ModelState.IsValid)
            {
                item.Id = currentId++;
                items.Add(item);
                return RedirectToAction("Index");
            }
            return View(item);
        }

        public ActionResult Edit(int id)
        {
            var item = items.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(ItemModel item)
        {
            if (ModelState.IsValid)
            {
                var existingItem = items.FirstOrDefault(i => i.Id == item.Id);
                if (existingItem != null)
                {
                    existingItem.Name = item.Name;
                    existingItem.Description = item.Description;
                    return RedirectToAction("Index");
                }
            }
            return View(item);
        }

        public ActionResult Delete(int id)
        {
            var item = items.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var item = items.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                items.Remove(item);
            }
            return RedirectToAction("Index");
        }
    }
}