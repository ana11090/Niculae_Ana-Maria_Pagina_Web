using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Niculae_Ana_Maria_Pagina_Web.Data;
using Niculae_Ana_Maria_Pagina_Web.Models;

namespace Niculae_Ana_Maria_Pagina_Web.Controllers
{
    public class ShopsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShopsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        // GET: Shops
        public async Task<IActionResult> Index()
        {
            return View(await _context.Shop.ToListAsync());
        }

        [Authorize]
        // GET: Search //ShowSearchForm
        public async Task<IActionResult> ShowSearchForm()
        {
            return View("ShowSearchForm");
        }

        //ShowSearchResults
        public async Task<IActionResult> ShowSearchResults(String SearchName)
        {
            return View("Index", await _context.Shop.Where(j=>j.name.Contains(SearchName)).ToListAsync());
        }

        // GET: Shops/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Shop shop = await _context.Shop
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shop == null)
            {
                return NotFound();
            }


            ShopDetailsViewModel viewModel = await GetShopDetailsViewModelFromShop(shop);

            return View(viewModel);
        }

       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(int id, [Bind("GroupId,FirstName,LastName,WorkTime")] ShopDetailsViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Angajat angajat = new Angajat();
                angajat.FirstName = viewModel.FirstName;
                angajat.LastName = viewModel.LastName;
                angajat.WorkTime = viewModel.WorkTime;


                Shop shop = await _context.Shop
               .FirstOrDefaultAsync(m => m.Id == viewModel.GroupId);
                if (shop == null)
                {
                    return NotFound();
                }

                angajat.MyShop = shop;
                _context.Angajat.Add(angajat);
                await _context.SaveChangesAsync();

                viewModel = await GetShopDetailsViewModelFromShop(shop);

            }
            return View(viewModel);

    }
        private async Task<ShopDetailsViewModel> GetShopDetailsViewModelFromShop(Shop shop)
        {

            ShopDetailsViewModel viewModel = new ShopDetailsViewModel();

            viewModel.Shop = shop;

            List<Angajat> angajats = await _context.Angajat.Where(m => m.MyShop == shop).ToListAsync();
            viewModel.Angajats = angajats;
            return viewModel;

        }
        // GET: Shops/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,name")] Shop shop)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shop);
        }

        // GET: Shops/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shop = await _context.Shop.FindAsync(id);
            if (shop == null)
            {
                return NotFound();
            }
            return View(shop);
        }

        // POST: Shops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,name")] Shop shop)
        {
            if (id != shop.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShopExists(shop.Id))
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
            return View(shop);
        }

        // GET: Shops/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shop = await _context.Shop
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shop == null)
            {
                return NotFound();
            }

            return View(shop);
        }

        // POST: Shops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shop = await _context.Shop.FindAsync(id);
            _context.Shop.Remove(shop);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShopExists(int id)
        {
            return _context.Shop.Any(e => e.Id == id);
        }
    }
}
