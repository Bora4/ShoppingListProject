using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingListAPI.Models;
using ShoppingListAPI.Models.ViewModels;

namespace ShoppingListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListsController : ControllerBase
    {
        private readonly ShoppingDBContext _context;

        public ShoppingListsController(ShoppingDBContext context)
        {
            _context = context;
        }

        // GET: api/ShoppingLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.ShoppingList>>> GetShoppingLists()
        {
            return await _context.ShoppingLists.ToListAsync();
        }

        // GET: api/ShoppingLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.ShoppingList>> GetShoppingList(int id)
        {

            var shoppingList = await _context.ShoppingLists.FindAsync(id);

            if (shoppingList == null)
            {
                return NotFound();
            }

            await _context.Entry(shoppingList).Collection(a => a.ShoppingListDetails).LoadAsync();

            ShoppingListDetailsController _controller = new(_context);

            ShoppingListDTO shoppingListDTO = new()
            {
                Id = shoppingList.Id,
                Name = shoppingList.Name,
                UserId = shoppingList.UserId

            };


            return Ok(shoppingListDTO);
        }

        [HttpGet]
        [Route("Names/{name}")]
        public async Task<ActionResult<Models.ShoppingList>> GetShoppingList(string name)
        {
            var shoppinglist = await _context.ShoppingLists.Where(s => s.Name == name).FirstOrDefaultAsync();

            if (shoppinglist == null)
            {
                return NotFound();
            }
            return shoppinglist;
        }




        // PUT: api/ShoppingLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShoppingList(int id, Models.ShoppingList shoppingList)
        {
            if (id != shoppingList.Id)
            {
                return BadRequest();
            }

            _context.Entry(shoppingList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoppingListExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ShoppingLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Models.ShoppingList>> PostShoppingList(Models.ShoppingList shoppingList)
        {
            _context.ShoppingLists.Add(shoppingList);
            await _context.SaveChangesAsync();

            await _context.Entry(shoppingList).Reference(a => a.User).LoadAsync();

            ShoppingListDTO shoppingListData = new()
            {
                Id = shoppingList.Id,
                Name = shoppingList.Name,
                UserId = shoppingList.UserId            
                };

            return CreatedAtAction("GetShoppingList", new { id = shoppingList.Id }, shoppingListData);
        }

        // DELETE: api/ShoppingLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShoppingList(int id)
        {
            var shoppingList = await _context.ShoppingLists.FindAsync(id);
            if (shoppingList == null)
            {
                return NotFound();
            }

            ShoppingListDetailsController _controller = new(_context);
            await _controller.DeleteShoppingListDetail(id);

            _context.ShoppingLists.Remove(shoppingList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShoppingListExists(int id)
        {
            return _context.ShoppingLists.Any(e => e.Id == id);
        }
    }
}
