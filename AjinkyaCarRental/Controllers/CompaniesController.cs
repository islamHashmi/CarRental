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
    public class CompaniesController : Controller
    {
        private AjinkyaTravelsCarRentalEntities db = new AjinkyaTravelsCarRentalEntities();

        // GET: Companies
        public async Task<ActionResult> Index()
        {
            return View(await db.Companies.Where(m => m.active == true).ToListAsync());
        }

        // GET: Companies/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Company company = await db.Companies.FindAsync(id);

            if (company == null)
            {
                return HttpNotFound();
            }

            return View(company);
        }

        // GET: Companies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Companies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "address,panNumber,telephone1,telephone2,serviceTaxNumber,companyName")] Company company)
        {
            if (ModelState.IsValid)
            {
                company.entryBy = 1;
                company.entryDate = DateTime.Now;
                company.active = true;

                db.Companies.Add(company);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(company);
        }

        // GET: Companies/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Company company = await db.Companies.FindAsync(id);

            if (company == null)
            {
                return HttpNotFound();
            }

            return View(company);
        }

        // POST: Companies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "companyId,address,panNumber,telephone1,telephone2,serviceTaxNumber,companyName,entryBy,entryDate,active")] Company company)
        {
            if (ModelState.IsValid)
            {
                company.updatedBy = 1;
                company.updatedDate = DateTime.Now;
                db.Entry(company).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(company);
        }

        // GET: Companies/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Company company = await db.Companies.FindAsync(id);

            if (company == null)
            {
                return HttpNotFound();
            }

            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var company = await db.Companies.FirstOrDefaultAsync(m => m.companyId == id);

            company.active = false;

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
