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
    public class ShoppingListDetailsController : ControllerBase
    {
        private readonly ShoppingDBContext _context;

        public ShoppingListDetailsController(ShoppingDBContext context)
        {
            _context = context;
        }

        // GET: api/ShoppingListDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShoppingListDetail>>> GetShoppingListDetails()
        {
            return await _context.ShoppingListDetails.ToListAsync();
        }

        // GET: api/ShoppingListDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingListDetail>> GetShoppingListDetail(int id)
        {
            var shoppingListDetails = await _context.ShoppingListDetails.Where(s => s.ShoppingListId == id).ToListAsync();

            if (shoppingListDetails == null)
            {
                return NotFound();
            }

            List<ShoppingListDetailDTO> shoppingListDetailDTOs = new();

            foreach (ShoppingListDetail item in shoppingListDetails)
            {
                await _context.Entry(item).Reference(a => a.Item).LoadAsync();
                ShoppingListDetailDTO shoppingListDetailDTO = new()
                {
                    Item = new ItemDTO()
                    {
                        Id = item.ItemId,
                        Name = item.Item.Name
                    },
                    ItemId = item.ItemId,
                    Quantity = item.Quantity,
                    ShoppingListId = item.ShoppingListId

                };
                shoppingListDetailDTOs.Add(shoppingListDetailDTO);
            }

            

            

            return Ok(shoppingListDetailDTOs);
        }

        // PUT: api/ShoppingListDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShoppingListDetail(int id, ShoppingListDetail shoppingListDetail)
        {
            if (id != shoppingListDetail.ShoppingListId)
            {
                return BadRequest();
            }

            _context.Entry(shoppingListDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoppingListDetailExists(id))
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

        // POST: api/ShoppingListDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ShoppingListDetail>> PostShoppingListDetail(ShoppingListDetail shoppingListDetail)
        {
            _context.ShoppingListDetails.Add(shoppingListDetail);
            try
            {
                await _context.SaveChangesAsync();
                
            }
            catch (DbUpdateException)
            {
                if (ShoppingListDetailExists(shoppingListDetail.ShoppingListId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            await _context.Entry(shoppingListDetail).Reference(a => a.ShoppingList).LoadAsync();
            await _context.Entry(shoppingListDetail).Reference(b => b.Item).LoadAsync();
            ShoppingListDetailDTO shoppingListDetailData = new()
            {
                ShoppingListId = shoppingListDetail.ShoppingListId,
                ItemId = shoppingListDetail.ItemId,
                Quantity = shoppingListDetail.Quantity,
                Item = new ItemDTO { Id = shoppingListDetail.ItemId, Name=shoppingListDetail.Item.Name },

            };

            ShoppingListsController _controller = new(_context);

            return CreatedAtAction("GetShoppingListDetail", new { id = shoppingListDetail.ShoppingListId }, shoppingListDetailData);
        }

        // DELETE: api/ShoppingListDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShoppingListDetail(int id)
        {

            List<ShoppingListDetail> result = (from a in _context.ShoppingListDetails where a.ShoppingListId == id select a).ToList();

            if (result == null)
            {
                return NotFound();
            }

            foreach (ShoppingListDetail item in result)
            {
                _context.ShoppingListDetails.Remove(item);
                await _context.SaveChangesAsync();
            }

            
            

            return NoContent();
        }

        [HttpDelete]
        [Route("{listid}/{itemid}")]
        public async Task<IActionResult> DeleteItemFromList(int listid, int itemid )
        {
            var result = await _context.ShoppingListDetails.Where(s => s.ShoppingListId == listid && s.ItemId == itemid).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }

            _context.ShoppingListDetails.Remove(result);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShoppingListDetailExists(int id)
        {
            return _context.ShoppingListDetails.Any(e => e.ShoppingListId == id);
        }
    }
}
