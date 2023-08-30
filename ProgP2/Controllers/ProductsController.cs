using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using test8.Areas.Identity.Data;
using test8.Models;

namespace test8.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Delete(int id)
        {
            // Retrieve the product from the database based on the ID
            var product = _context.Products.Find(id);

            if (product == null)
            {
                // Product not found, return a not found error or redirect to an error page
                return NotFound();
            }

            // Remove the product from the database
            _context.Products.Remove(product);
            _context.SaveChanges();

            // Redirect to the product list page or perform any other desired action
            return RedirectToAction("Index");
        }


        // GET: Products

        // Rewritten code with comments

        public async Task<IActionResult> Index(string search, string sort, string username, string type, DateTime? startDate, DateTime? endDate)
        {
            // Get the logged in user's ID
            var loggedInUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            // Check if the user is an admin
            bool isAdmin = (User.Identity.Name == "Admin@admin.com");
            ViewBag.admin = isAdmin;

            // Get all products from the database
            IQueryable<Product> query = _context.Products.Include(p => p.User);

            // If the user is not an admin, only show products from the logged in user
            if (!isAdmin)
            {
                query = query.Where(p => p.UserId == loggedInUserId);
            }

            // If a search term is provided, filter the products by name
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.Name.Contains(search));
                ViewBag.CurrentSearch = search;
            }
            else
            {
                ViewBag.CurrentSearch = string.Empty;
            }

            // If a username is provided, filter the products by username
            if (!string.IsNullOrEmpty(username))
            {
                query = query.Where(p => p.User.UserName.Contains(username));
                ViewBag.CurrentUsername = username;
            }
            else
            {
                ViewBag.CurrentUsername = string.Empty;
            }

            // If a username is provided, filter the products by username

            if (!string.IsNullOrEmpty(type))
            {
                query = query.Where(p => p.Type.Contains(type));
                ViewBag.CurrentTypeFilter = type;
            }
            else
            {
                ViewBag.CurrentTypeFilter = string.Empty;
            }

            // If start and end dates are provided, filter the products by date
            if (startDate != null && endDate != null)
            {
                query = query.Where(p => p.DateExpected >= startDate && p.DateExpected <= endDate);
                ViewBag.CurrentStartDate = startDate?.ToString("yyyy-MM-dd");
                ViewBag.CurrentEndDate = endDate?.ToString("yyyy-MM-dd");
            }
            else
            {
                ViewBag.CurrentStartDate = string.Empty;
                ViewBag.CurrentEndDate = string.Empty;
            }

            // Sort the products based on the sort parameter
            switch (sort)
            {
                case "name_asc":
                    query = query.OrderBy(p => p.Name);
                    ViewBag.CurrentSort = "name_asc";
                    break;
                case "name_desc":
                    query = query.OrderByDescending(p => p.Name);
                    ViewBag.CurrentSort = "name_desc";
                    break;
                case "quantity_asc":
                    query = query.OrderBy(p => p.Quantity);
                    ViewBag.CurrentSort = "quantity_asc";
                    break;
                case "quantity_desc":
                    query = query.OrderByDescending(p => p.Quantity);
                    ViewBag.CurrentSort = "quantity_desc";
                    break;
                default:
                    ViewBag.CurrentSort = string.Empty;
                    break;
            }

            // Get the list of products from the database
            var products = await query.ToListAsync();
            ViewBag.Empty = products.Count > 0;

            // Return the view with the list of products

            return View(products);
        }


        public IActionResult Edit(int id)
        {
            // Retrieve the product from the database based on the provided ID
            var product = _context.Products.Find(id);


            if (product == null)
            {
                // Product not found, handle the error scenario
                return NotFound();
            }

            // Pass the product to the view for editing
            ViewBag.UserId = product.UserId;
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product, int userId)
        {
            //This code is used to update an existing product in a database. The first line finds the existing product in the database using the product's Id. The second line finds
            // the user associated with the product using the UserId stored in the product. The third line sets the product's UserId to the existing UserId. The fourth line sets
            // the product's User property to the user found in the second line. The fifth line sets the state of the existing product to detached, which means that the existing
            // product will not be tracked by the context. This allows the updated product to be saved to the database without overwriting the existing product.
            Product temp = _context.Products.Find(product.Id);

            test8User user = await _context.Users.FindAsync(temp.UserId);

            if(product.DateExpected == null)
            {
                product.DateExpected = temp.DateExpected;
            }


            product.UserId = temp.UserId;
            product.User = user;
            _context.Entry(temp).State = EntityState.Detached;

            if (!string.IsNullOrWhiteSpace(product.Name) && !string.IsNullOrWhiteSpace(product.Description) && product.Quantity != 0)
            {

                // Update the product in the database
                _context.Products.Update(product);
                _context.SaveChanges();

                // Redirect to the index page or perform any other desired action
                return RedirectToAction("Index");
            }

            // If the model state is invalid, return the view with validation errors
            return View(product);
        }



        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            // Set the UserId of the product to the currently logged-in user's Id
            product.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            test8User user = await _context.Users.FindAsync(product.UserId);

            product.User = user;

            if (!string.IsNullOrWhiteSpace(product.Name) && !string.IsNullOrWhiteSpace(product.Description) && product.Quantity != 0)
            {
                // Add the product to the database
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Return the invalid model to the view
            return View(product);

        }
    }







}


