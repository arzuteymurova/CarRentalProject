using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
    {
        public List<RentalDetailsDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (CarRentalContext context=new CarRentalContext())
            {
                
                var result = from r in context.Rentals
                    join car in context.Cars on r.CarId equals car.Id
                    join customer in context.Customers on r.CustomerId equals customer.Id
                    join b in context.Brands on car.BrandId equals b.Id
                    join color in context.Colors on car.ColorId equals color.Id
                    join u in context.Users on customer.UserId equals u.Id
                    select new RentalDetailsDto
                    {
                        RentalId = r.Id,
                        CarName = car.CarName,
                        CustomerFirstName = u.FirstName,
                        CustomerLastName = u.LastName,
                        CustomerCompanyName = customer.CompanyName,
                        BrandName = b.Name,
                        ColorName = color.Name,
                        RentDate = r.RentDate,
                        ReturnDate = r.ReturnDate

                    };
                return result.ToList();


            }
        }
    }
}

