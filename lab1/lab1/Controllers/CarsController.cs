using APIs.Day.One.Models;
using lab1.Filters;
using lab1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace lab1.Controllers
{


    [Route("api/[controller]/[action]")]
    [ApiController]

    public class CarsController : ControllerBase
    {
        #region Static List

        private static List<Car> _cars = new()
            {
               new (1,"car1","Gas",DateTime.Now),
               new (2,"car2","Electric",DateTime.Now),
               new (3,"car3","Gas",DateTime.Now),
               new (4,"car4","Diesel",DateTime.Now),
            };

        #endregion

        #region Get All

        [HttpGet]
        public ActionResult<List<Car>> GetAll()
        {
            return _cars;
        }

        #endregion

        #region Get By ID

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Car> GetById(int id)
        {
            var car = _cars.FirstOrDefault(m => m.Id == id);
            if (car is null)
            {
                return NotFound();
            }

            return car;
        }

        #endregion

        #region Add

        [HttpPost]
        [Route("version1")]
        public ActionResult Add(Car car)
        {
            car.Id = _cars.Count + 1;
            car.Type = "Gas";
            _cars.Add(car);

            return CreatedAtAction(actionName: nameof(GetById),
                routeValues: new { id = car.Id },
                new GeneralResponse { Message = "The entity has been added successfully" });
        }

        [HttpPost]
        [Route("version2")]
        [ValidType]
        public ActionResult Add_V2(Car car)
        {
            car.Id = _cars.Count + 1;
            _cars.Add(car);

            return Ok();
        }

        #endregion

        #region Edit

        [HttpPut]
        [Route("{id}")]
        public ActionResult Edit(Car car, int id)
        {
            if (car.Id != id)
            {
                return BadRequest();
            }

            var mycar = _cars.FirstOrDefault(m => m.Id == id);

            if (mycar is null)
            {
                return NotFound();
            }

            mycar.Name = car.Name;
            mycar.Type = car.Type;
            mycar.ProductDate = car.ProductDate;

            return NoContent();
        }

        #endregion

        #region Delete

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteById(int id)
        {
            var car = _cars.FirstOrDefault(m => m.Id == id);

            if (car is null)
            {
                return NotFound();
            }

            _cars.Remove(car);
            return NoContent();
        }

        #endregion
    }
}
