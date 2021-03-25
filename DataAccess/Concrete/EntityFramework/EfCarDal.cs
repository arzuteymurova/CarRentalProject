using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from car in context.Cars
                    join color in context.Colors on car.ColorId equals color.Id
                    join b in context.Brands on car.BrandId equals b.Id
                    select new CarDetailsDto
                    {
                        CarName = car.CarName,
                        BrandName = b.Name,
                        ColorName = color.Name,
                        DailyPrice = car.DailyPrice
                    };
                return result.ToList();
            }
        }
    }
}
