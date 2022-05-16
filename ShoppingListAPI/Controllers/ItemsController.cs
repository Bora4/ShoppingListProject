using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingListAPI.Models;
using ShoppingListAPI.Models.ViewModels;

namespace ShoppingList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ShoppingDBContext _context;

        public ItemsController(ShoppingDBContext context)
        {
            _context = context;
        }

        // GET: api/Items
        [HttpGet]
        public List<Item> GetItems()
        {
            List<Item> items = new List<Item>();
            items = (from i in _context.Items select i).ToList();
            return items;
        }

        // GET: api/Items/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(int id)
        {
            var item = await _context.Items.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        //[HttpGet("{name}")]
        [HttpGet]
        [Route("Names/{name}")]
        //[ActionName("ItemNames")]
        public async Task<ActionResult<Item>> GetItemByName(string name) 
        {
            var item = await _context.Items.Where(i => i.Name == name).FirstOrDefaultAsync();

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        // PUT: api/Items/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, Item item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
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

        // POST: api/Items
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            await _context.Entry(item).Reference(a => a.Category).LoadAsync();

            ItemDTO itemData = new ItemDTO()
            {
                Id = item.Id,
                CategoryId = item.CategoryId,
                Name = item.Name,
                Category = new CategoryDTO() { ID = item.Category.Id, Name = item.Category.Name }
            };

            return CreatedAtAction("GetItem", new { id = item.Id }, itemData);

            
        }

        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.Id == id);
        }
    }
}
