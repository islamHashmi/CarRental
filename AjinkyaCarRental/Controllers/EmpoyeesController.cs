using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AjinkyaCarRental.Context;
using AjinkyaCarRental.Helpers;

namespace AjinkyaCarRental.Controllers
{
    public class EmpoyeesController : Controller
    {
        private AjinkyaTravelsCarRentalEntities db = new AjinkyaTravelsCarRentalEntities();

        // GET: Empoyees
        public async Task<ActionResult> Index()
        {
            var employees = db.Employees.Include(e => e.CompanyBranch);

            return View(await employees.ToListAsync());
        }

        // GET: Empoyees/Details/5
        public async Task<ActionResult> Details(string pId)
        {
            if (pId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Employee employee = await db.Employees.FindAsync(pId);

            if (employee == null)
            {
                return HttpNotFound();
            }

            return View(employee);
        }

        [HttpGet]
        public async Task<ActionResult> CreateUpdate(string pId)
        {
            var employee = new Employee();

            try
            {
                if (!string.IsNullOrEmpty(pId))
                {
                    string _key = HelperClass.Decrypt(pId);

                    int.TryParse(_key, out int _Id);

                    employee = await db.Employees.FindAsync(_Id);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                employee.branchList = new SelectList(db.CompanyBranches, "branchId", "branchName");
            }

            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateUpdate(Employee party)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (party.employeeId == 0)
                    {
                        party.active = true;
                        party.entryBy = 1;
                        party.entryDate = DateTime.Now;
                        db.Parties.Add(party);
                    }
                    else
                    {
                        party.updatedBy = 2;
                        party.updatedDate = DateTime.Now;
                        db.Entry(party).State = EntityState.Modified;
                    }

                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                party.companyList = new SelectList(db.Companies, "companyId", "companyName");
                party.branchList = new SelectList(db.CompanyBranches, "branchId", "branchName");
                party.statusList = new SelectList(db.PartyStatus, "statusCode", "statusDescription");
            }

            return View(party);
        }

        // GET: Empoyees/Create
        public ActionResult Create()
        {
            ViewBag.branchId = new SelectList(db.CompanyBranches, "branchId", "branchName");

            return View();
        }

        // POST: Empoyees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.branchId = new SelectList(db.CompanyBranches, "branchId", "branchName", employee.branchId);

            return View(employee);
        }

        // GET: Empoyees/Edit/5
        public async Task<ActionResult> Edit(string pId)
        {
            if (pId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Employee employee = await db.Employees.FindAsync(pId);

            if (employee == null)
            {
                return HttpNotFound();
            }

            ViewBag.branchId = new SelectList(db.CompanyBranches, "branchId", "branchName", employee.branchId);

            return View(employee);
        }

        // POST: Empoyees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.branchId = new SelectList(db.CompanyBranches, "branchId", "branchName", employee.branchId);

            return View(employee);
        }

        // GET: Empoyees/Delete/5
        public async Task<ActionResult> Delete(string pId)
        {
            if (pId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Employee employee = await db.Employees.FindAsync(pId);

            if (employee == null)
            {
                return HttpNotFound();
            }

            return View(employee);
        }

        // POST: Empoyees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int pId)
        {
            Employee employee = await db.Employees.FindAsync(pId);
            db.Employees.Remove(employee);
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
