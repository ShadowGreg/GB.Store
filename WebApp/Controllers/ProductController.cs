using Core.Models;
using DataBase.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController: ControllerBase {
    [HttpGet("Get products")]
    public IActionResult GetProducts() {
        try {
            using (var context = new DataContext()) {
                var products = context.Products.Select(x => new Product() {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                }).ToList();
                return Ok(products);
            }
        }
        catch (Exception e) {
            Console.WriteLine(e);
            return StatusCode(500);
        }
    }
}