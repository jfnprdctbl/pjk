using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Threading.Tasks;
using ProjectKapwa.Models;

namespace ProjectKapwa.Controllers.Forms
{
    public class WorkAcceptanceController : Controller
    {
        [ActionName("Index")]
        public async Task<ActionResult> IndexAsync()
        {
            var items = await RepositoryOperation<WorkAcceptance>.GetItemsAsync();
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
        public async Task<ActionResult> CreateAsync(WorkAcceptance item)
        {
            item.partitionName = "Work Acceptance";
            if (ModelState.IsValid)
            {
                await RepositoryOperation<WorkAcceptance>.CreateItemAsync(item);
                return RedirectToAction("Index");
            }

            return View(item);
        }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(WorkAcceptance item)
        {
            item.Formdata.formName = "Work Acceptance";
            if (ModelState.IsValid)
            {
                await RepositoryOperation<WorkAcceptance>.UpdateItemAsync(item.Id, item);
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

            WorkAcceptance item = await RepositoryOperation<WorkAcceptance>.GetItemAsync(id, partition);
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

            WorkAcceptance item = await RepositoryOperation<WorkAcceptance>.GetItemAsync(id, partition);
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
            await RepositoryOperation<WorkAcceptance>.DeleteItemAsync(id, partition);
            return RedirectToAction("Index");
        }

        [ActionName("Details")]
        public async Task<ActionResult> DetailsAsync(string id, string partition)
        {
            WorkAcceptance item = await RepositoryOperation<WorkAcceptance>.GetItemAsync(id, partition);
            return View(item);
        }
    }
}