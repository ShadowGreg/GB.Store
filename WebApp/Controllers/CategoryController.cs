using Core.Models;
using DataBase.Repositories;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController: ControllerBase {
    [HttpDelete("Delete category")]
    public async Task<IActionResult> DeleteCategory(CategoryResponse categoryResponse) {
        try {
            using (var context = new DataContext()) {
                var temp = context.Categories.Find(categoryResponse.Id);
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