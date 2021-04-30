using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Authorization;
using System.Dynamic;
using Microsoft.AspNetCore.Identity;
using Phase4JoePizzaProject;

namespace WebApp.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _securityManager;
        private readonly SignInManager<ApplicationUser> _loginManager;
        public OrderController(AppDbContext context, UserManager<ApplicationUser> _sec, SignInManager<ApplicationUser> _log)
        {
            _context = context;
            _securityManager = _sec;
            _loginManager = _log;
        }

        // GET: Order

        public async Task<IActionResult> Index()
        {
            var user = await this._securityManager.GetUserAsync(User);

            List<OrderDetails> l = new List<OrderDetails>();
            var list = await _context.OrderDetails.ToListAsync();
 
            list = list.Where(ord => ord.Name == user.UserName).ToList();
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

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetails = await _context.OrderDetails
                .FirstOrDefaultAsync(m => m.Oid == id);
            var pid = orderDetails.Pid;
            var laptopModel = await _context.PizzaModel
                .FirstOrDefaultAsync(m => m.ID == pid);
            OrderDetails ord = new OrderDetails();
            ord = orderDetails;
            ord.Pizza = laptopModel;
            if (orderDetails == null)
            {
                return NotFound();
            }

            return View(ord);
        }



        public async Task<IActionResult> CreateAsync(string id)
        {
            ViewBag.Pid = id;
            var laptopModel = await _context.PizzaModel
                .FirstOrDefaultAsync(m => m.ID == id);
           
            var user = await _securityManager.GetUserAsync(User);
            OrderDetails ord = new OrderDetails();
            ord.Name = user.UserName;
            ord.Address = user.Address;
            ord.Phone = user.PhoneNumber;
            ord.Pizza = laptopModel;
            ord.Price = laptopModel.Price;      
            

            return View(ord);
        }

        // POST: Order/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderDetails orderDetails)
        {
            if (ModelState.IsValid)
            {
                //orderDetails.Price = orderDetails.Pizza.Price;
                //orderDetails.Price *= orderDetails.Quantity;

                _context.Add(orderDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orderDetails);
        }


        


        private bool OrderDetailsExists(string id)
        {
            return _context.OrderDetails.Any(e => e.Oid == id);
        }
    }
}