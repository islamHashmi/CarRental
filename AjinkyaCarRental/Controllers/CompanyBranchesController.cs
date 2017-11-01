using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using AjinkyaCarRental.Context;

namespace AjinkyaCarRental.Controllers
{
    public class CompanyBranchesController : Controller
    {
        private AjinkyaTravelsCarRentalEntities db = new AjinkyaTravelsCarRentalEntities();

        // GET: CompanyBranches
        public async Task<ActionResult> Index()
        {
            return View(await db.CompanyBranches.Where(m => m.active == true).ToListAsync());
        }

        // GET: CompanyBranches/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CompanyBranch companyBranch = await db.CompanyBranches.FindAsync(id);

            if (companyBranch == null)
            {
                return HttpNotFound();
            }

            return View(companyBranch);
        }

        // GET: CompanyBranches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompanyBranches/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "branchName")] CompanyBranch companyBranch)
        {
            if (ModelState.IsValid)
            {
                companyBranch.entryBy = 1;
                companyBranch.entryDate = DateTime.Now;
                companyBranch.active = true;

                db.CompanyBranches.Add(companyBranch);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(companyBranch);
        }

        // GET: CompanyBranches/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyBranch companyBranch = await db.CompanyBranches.FindAsync(id);
            if (companyBranch == null)
            {
                return HttpNotFound();
            }
            return View(companyBranch);
        }

        // POST: CompanyBranches/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "branchId,branchName,entryBy,entryDate,active")] CompanyBranch companyBranch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyBranch).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(companyBranch);
        }

        // GET: CompanyBranches/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyBranch companyBranch = await db.CompanyBranches.FindAsync(id);
            if (companyBranch == null)
            {
                return HttpNotFound();
            }
            return View(companyBranch);
        }

        // POST: CompanyBranches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CompanyBranch companyBranch = await db.CompanyBranches.FirstOrDefaultAsync(x => x.branchId == id);

            companyBranch.active = false;

            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
