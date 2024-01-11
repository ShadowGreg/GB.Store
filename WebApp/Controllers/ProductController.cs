using Core.Models;
using DataBase.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

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

    [HttpPost("Add product to data base")]
    public IActionResult PutProduct(ProductResponse productResponse) {
        try {
            using (var context = new DataContext()) {
                if (!context.Products.Any().Equals(productResponse.Name)) {
                    context.Products.Add(new Product() {
                        Id = productResponse.Id,
                        Name = productResponse.Name,
                        Description = productResponse.Description,
                        Cost = productResponse.Cost,
                        CategoryId = productResponse.CategoryId,
                    });
                    context.SaveChanges();
                    var id = context.Products
                        .First(p => EF.Functions.Like(p.Name, productResponse.Name))
                        .Id;
                    return Ok(id);
                }

                return StatusCode(409);
            }
        }
        catch (Exception e) {
            Console.WriteLine(e);
            return StatusCode(500);
        }
    }
    
    [HttpDelete("Delete product")]
    public async Task<IActionResult> DeleteCategory(ProductResponse productResponse) {
        try {
            using (var context = new DataContext()) {
                var temp = context.Categories.Find(productResponse.Id);
                if (temp != null) {
                    context.Categories.Remove(temp);
                    await context.SaveChangesAsync();
                }
            }
        }
        catch (Exception e) {
            Console.WriteLine(e);
            return StatusCode(500);
        }

        return Ok();
    }
}