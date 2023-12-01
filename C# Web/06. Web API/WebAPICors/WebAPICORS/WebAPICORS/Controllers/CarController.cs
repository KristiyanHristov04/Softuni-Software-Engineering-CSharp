using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebAPICORS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly CarDbContext context;
        public CarController(CarDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult GetAllCars()
        {
            List<Car> cars = this.context.Cars.ToList();
            return Ok(cars);
        }

        [HttpPost]
        public IActionResult Add(string brand, string model)
        {
            Car car = new Car();
            car.Brand = brand;
            car.Model = model;

            this.context.Cars.Add(car);
            this.context.SaveChanges();

            return CreatedAtAction("Add", car);
        }
    }
}
