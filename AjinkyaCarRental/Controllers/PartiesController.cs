using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using AjinkyaCarRental.Context;
using AjinkyaCarRental.Helpers;

namespace AjinkyaCarRental.Controllers
{
    public class PartiesController : Controller
    {
        private AjinkyaTravelsCarRentalEntities db = new AjinkyaTravelsCarRentalEntities();

        // GET: Parties
        public async Task<ActionResult> Index()
        {
            var parties = db.Parties.Include(p => p.Company).Include(p => p.CompanyBranch).Include(p => p.PartyStatu);

            return View(await parties.Where(m => m.active == true).ToListAsync());
        }

        // GET: Parties/Details/5
        public async Task<ActionResult> Details(string pId)
        {
            if (pId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            string _key = HelperClass.Decrypt(pId);

            int.TryParse(_key, out int _Id);

            Party party = await db.Parties.FindAsync(_Id);

            if (party == null)
            {
                return HttpNotFound();
            }

            return View(party);
        }

        [HttpGet]
        public async Task<ActionResult> CreateUpdate(string pId)
        {
            var party = new Party();

            try
            {
                if (!string.IsNullOrEmpty(pId))
                {
                    string _key = HelperClass.Decrypt(pId);

                    int.TryParse(_key, out int _Id);

                    party = await db.Parties.FindAsync(_Id);

                    var primaryGroup = await db.Parties.FirstOrDefaultAsync(m => m.partyId == party.primaryGroupId);

                    if (primaryGroup != null)
                        party.primaryGroup = primaryGroup.Name;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                party.companyList = new SelectList(db.Companies, "companyId", "companyName");
                party.branchList = new SelectList(db.CompanyBranches, "branchId", "branchName");
                party.statusList = new SelectList(db.PartyStatus, "statusCode", "statusDescription");
            }

            return View(party);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateUpdate(Party party)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (party.partyId == 0)
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

        // GET: Parties/Delete/5
        public async Task<ActionResult> Delete(string pId)
        {
            if (pId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            string _key = HelperClass.Decrypt(pId);

            int.TryParse(_key, out int _Id);

            Party party = await db.Parties.FindAsync(_Id);

            if (party == null)
            {
                return HttpNotFound();
            }

            return View(party);
        }

        // POST: Parties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string pId)
        {
            string _key = HelperClass.Decrypt(pId);

            int.TryParse(_key, out int _Id);

            Party party = await db.Parties.FindAsync(_Id);

            if (party == null)
                return HttpNotFound();

            db.Parties.Remove(party);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<JsonResult> Autocomplete_MainGroup(string prefix)
        {
            var parties = db.Parties.Where(m => m.Name.Contains(prefix))
                .Select(m => new
                {
                    label = m.Name,
                    value = m.partyId
                }).ToListAsync();

            return Json(await parties, JsonRequestBehavior.AllowGet);
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
