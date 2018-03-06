using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Threading.Tasks;



namespace ProjectKapwa.Controllers
{
    using Models;
    public class xformController : Controller
    {
        [ActionName("Index")]
        public async Task<ActionResult> IndexAsync()
        {
            var items = await RepositoryOperation<xforms>.GetItemsAsync();
            var result = items;
            return View(result);
        }

        [ActionName("Create")]
        public async Task<ActionResult> CreateAsync()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(xforms item)
        {
            if (ModelState.IsValid)
            {
                await RepositoryOperation<xforms>.CreateItemAsync(item);
                return RedirectToAction("Index");
            }

            return View(item);
        }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(xforms item)
        {
            if (ModelState.IsValid)
            {
                await RepositoryOperation<xforms>.UpdateItemAsync(item.Id, item);
                return RedirectToAction("Index");
            }

            return View(item);
        }

        [ActionName("Edit")]
        public async Task<ActionResult> EditAsync(string id, string partition)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            xforms item = await RepositoryOperation<xforms>.GetItemAsync(id, partition);
            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        [ActionName("Delete")]
        public async Task<ActionResult> DeleteAsync(string id, string partition)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            xforms item = await RepositoryOperation<xforms>.GetItemAsync(id, partition);
            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmedAsync([Bind(Include = "Id, Category")]string id, string partition)
        {
            await RepositoryOperation<xforms>.DeleteItemAsync(id, partition);
            return RedirectToAction("Index");
        }

        [ActionName("Details")]
        public async Task<ActionResult> DetailsAsync(string id, string partition)
        {
            xforms item = await RepositoryOperation<xforms>.GetItemAsync(id, partition);
            return View(item);
        }
    }
}