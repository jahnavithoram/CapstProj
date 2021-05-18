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
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cart
        public async Task<IActionResult> Index()
        {
            return View(await _context.CartModel.ToListAsync());
        }

        // GET: Cart/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartModel = await _context.CartModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cartModel == null)
            {
                return NotFound();
            }

            return View(cartModel);
        }

       


        // GET: Cart/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartModel = await _context.CartModel.FindAsync(id);
            
            if (cartModel == null)
            {
                //Create();
               return NotFound();
            }
            
            cartModel.qty += 1;
            return await Edit(cartModel); 
        }

        // POST: Cart/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
       public async Task<IActionResult> Edit([Bind("ID,P_Name,Cost,Details,ProductImagePath,CategoryId,qty")] CartModel cartModel)
        {
          

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cartModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartModelExists(cartModel.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
              //  return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index1","Product"); ;
        }
    
        // GET: Cart/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartModel = await _context.CartModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cartModel == null)
            {
                return NotFound();
            }

            return View(cartModel);
        }

        // POST: Cart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var cartModel = await _context.CartModel.FindAsync(id);
            _context.CartModel.Remove(cartModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartModelExists(string id)
        {
            var a = _context.CartModel.Any(e => e.ID == id);
            return a;
        }

        public async Task<IActionResult> AddtoCart([Bind("ID,UID,P_Name,Cost,Details,ProductImagePath,CategoryId,qty")] CartModel cartModel)
        {
            // CartModel tempcartModel = await _context.CartModel.FindAsync(cartModel.ID);
            var tid = cartModel.ID ;
            if (CartModelExists(tid) == true)
            {
                return await Edit(tid); 
            }
            else{
                if (ModelState.IsValid)
                {
                    _context.Add(cartModel);
                    var a = cartModel;
                    await _context.SaveChangesAsync();
                 // return RedirectToAction("Index1", "Product"); ;
                }
             
            }
            return RedirectToAction("Index1", "Product"); ;
        }
    }
}
