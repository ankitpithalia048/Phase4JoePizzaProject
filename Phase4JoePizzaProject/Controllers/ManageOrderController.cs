using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
/*using DataLayer;
using Models;*/
using Microsoft.AspNetCore.Authorization;
using Phase4JoePizzaProject;

namespace Phase3LapotopSellProject.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ManageOrderController : Controller
    {
        private readonly AppDbContext _context;

        public ManageOrderController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ManageOrder
        public async Task<IActionResult> Index()
        {
            List<OrderDetails> l = new List<OrderDetails>();
            var list = await _context.OrderDetails.ToListAsync();
            foreach (var item in list)
            {
                var laptopModel = await _context.PizzaModel
                .FirstOrDefaultAsync(m => m.ID == item.Pid);
                OrderDetails ord = new OrderDetails();
                ord.Pizza = laptopModel;
                ord.Address = item.Address;
                ord.Name = item.Name;
                ord.Oid = item.Oid;
                ord.Phone = item.Phone;
                ord.Pid = item.Pid;
                ord.Quantity = item.Quantity;
                l.Add(ord);
            }

            return View(l);
          
        }

        // GET: ManageOrder/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetails = await _context.OrderDetails
                .FirstOrDefaultAsync(m => m.Oid == id);
            if (orderDetails == null)
            {
                return NotFound();
            }

            return View(orderDetails);
        }

        

        // GET: ManageOrder/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetails = await _context.OrderDetails.FindAsync(id);
            if (orderDetails == null)
            {
                return NotFound();
            }
            return View(orderDetails);
        }

        // POST: ManageOrder/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Oid,Pid,Name,Address,Phone")] OrderDetails orderDetails)
        {
            if (id != orderDetails.Oid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderDetailsExists(orderDetails.Oid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(orderDetails);
        }

        // GET: ManageOrder/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetails = await _context.OrderDetails
                .FirstOrDefaultAsync(m => m.Oid == id);
            if (orderDetails == null)
            {
                return NotFound();
            }

            return View(orderDetails);
        }

        // POST: ManageOrder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var orderDetails = await _context.OrderDetails.FindAsync(id);
            _context.OrderDetails.Remove(orderDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderDetailsExists(string id)
        {
            return _context.OrderDetails.Any(e => e.Oid == id);
        }
    }
}
