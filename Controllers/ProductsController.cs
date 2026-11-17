using Microsoft.AspNetCore.Mvc;

namespace StockFlow.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private static readonly ProductResponse[] Products =
    [
        new(1, "Teclado"),
        new(2, "Mouse")
    ];

        [HttpGet]
        public ActionResult<IEnumerable<ProductResponse>> GetAll()
        {
            return Ok(Products);
        }

        [HttpGet("{id:int}")]
        public ActionResult<ProductResponse> GetById(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);

            if (product is null)
            {
                return NotFound();
            }

            return Ok(product);
        }
    }
}
/// <summary>Datos de un producto devueltos por la API.</summary>
public sealed record ProductResponse(int Id, string Name);