using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CapstProj.Data;
using CapstProj.Models;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;

namespace CapstProj.Controllers
{[Authorize]
    public class ConfirmController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConfirmController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Confirm
        public async Task<IActionResult> Index()
        {
           
            return View(await _context.ConfirmModel.ToListAsync());
        }

      

       

        // POST: Confirm/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
       // [ValidateAntiForgeryToken]
      public async Task<IActionResult> Create()
        {
            List < ConfirmModel > data= new List<ConfirmModel>();
            string connectionString = ";Database=;User ID=;Password=;Trusted_Connection=False;Encrypt=True;MultipleActiveResultSets=True;";
    //server id and password have been removed for git repo (security concerns)
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("select * from [CartModel]", con);
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ConfirmModel user = new ConfirmModel();
                  //  user.I = rdr["Name"].ToString();
                    user.UID = rdr["UID"].ToString();
                    user.Cost = Convert.ToInt32(rdr["Cost"]);
                    user.qty = Convert.ToInt32(rdr["qty"]);
                    user.P_Name = rdr["P_Name"].ToString();
                    user.ProductImagePath= rdr["ProductImagePath"].ToString();
                    _context.Add(user);
                    await _context.SaveChangesAsync();
                    
                  
                }
 
                con.Close();
            }
           
            var name = User.Identity.Name;
            var results = from row in _context.CartModel.AsEnumerable()
                          where row.UID == name
                          select row;
            foreach (var row in results.ToList())
            {
                _context.CartModel.Remove(row);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");

        }



        // POST: Confirm/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 

        // GET: Confirm/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var confirmModel = await _context.ConfirmModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (confirmModel == null)
            {
                return NotFound();
            }

            return View(confirmModel);
        }
        [Authorize(Roles = "Admin")]
        // POST: Confirm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var confirmModel = await _context.ConfirmModel.FindAsync(id);
            _context.ConfirmModel.Remove(confirmModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConfirmModelExists(string id)
        {
            return _context.ConfirmModel.Any(e => e.ID == id);
        }
    }
}
