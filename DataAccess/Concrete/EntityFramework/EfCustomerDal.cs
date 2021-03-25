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
    public class EfCustomerDal : EfEntityRepositoryBase<Customer,CarRentalContext>, ICustomerDal
    {
        public List<CustomerDetailsDto> GetCustomerDetails()
        {
            using (CarRentalContext context=new CarRentalContext())
            {
                var result = from customer in 
                        context.Customers
                    join u in context.Users on customer.UserId equals u.Id
                    select new CustomerDetailsDto
                    {
                        CustomerId = customer.Id,
                        UserFirstName = u.FirstName,
                        UserLastName = u.LastName,
                        CompanyName = customer.CompanyName,
                        UserId = u.Id
                    };
                return result.ToList();
            }
        }
    }
}
