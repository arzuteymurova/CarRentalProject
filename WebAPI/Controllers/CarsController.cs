using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
         ICarService _carService;

         public CarsController(ICarService carService)
         {
             _carService = carService;
         }

         [HttpPost("add")]
         public IActionResult Add(Car car)
         {
             var result = _carService.Add(car);
             if (result.Success)
             {
                 return Ok(result.Message);
             }

             return BadRequest(result.Message);
         }


         [HttpPost("update")]
         public IActionResult Update(Car car)
         {
             var result = _carService.Update(car);
             if (result.Success)
             {
                 return Ok(result.Message);
             }

             return BadRequest(result.Message);
         }


         [HttpPost("delete")]
         public IActionResult Delete(Car car)
         {
             var result = _carService.Delete(car);
             if (result.Success)
             {
                 return Ok(result.Message);
             }

             return BadRequest(result.Message);
         }

         [HttpGet("getall")]
         public IActionResult GetAll()
         {
             var result = _carService.GetAll();
             if (result.Success)
             {
                 return Ok(result.Data);
             }

             return BadRequest(result.Message);
         }

         [HttpGet("getbyid")]
         public IActionResult Get(int id)
         {
             var result = _carService.GetById(id);
             if (result.Success)
             {
                 return Ok(result.Data);
             }

             return BadRequest(result.Message);
         }

         [HttpGet("getbybrand")]
         public IActionResult GetByBrandId(int brandId)
         {
             var result = _carService.GetCarsBrandId(brandId);
             if (result.Success)
             {
                 return Ok(result.Data);
             }

             return BadRequest(result.Message);
         }

         [HttpGet("getbycolor")]
         public IActionResult GetByColorId(int colorId)
         {
             var result = _carService.GetCarsByColorId(colorId);
             if (result.Success)
             {
                 return Ok(result.Data);
             }

             return BadRequest(result.Message);
         }

         [HttpGet("getcardetails")]
         public IActionResult GetCarDetails()
         {
             var result = _carService.GetCarDetails();
             if (result.Success)
             {
                 return Ok(result.Data);
             }

             return BadRequest(result.Message);
         }

    }
}
