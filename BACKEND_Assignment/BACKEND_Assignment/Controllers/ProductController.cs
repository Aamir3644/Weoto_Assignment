﻿using BACKEND_Assignment.Data;
using BACKEND_Assignment.DTO;
using BACKEND_Assignment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BACKEND_Assignment.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class ProductController :ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Fetching all products
        // Allowed for both - User and Admin
        [HttpGet]
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _context.Product.ToListAsync();
            return Ok(products);
        }

        // Adding Product
        // Only Allowed to Admin
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddProduct([FromBody] ProductDTO productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price
            };

            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            return Created(string.Empty, product);
        }

        // Updating the Product
        // Only Allowed to Admin
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDTO productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = await _context.Product.FindAsync(id);
            if (product == null)
                return NotFound();

            product.Name = productDto.Name;
            product.Price = productDto.Price;

            _context.Product.Update(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Deleting the Product
        // Only Allowed to Admin
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null)
                return NotFound();

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}
