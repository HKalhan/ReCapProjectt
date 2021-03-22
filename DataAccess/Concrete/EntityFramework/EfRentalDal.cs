using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentalCarDbContext>, IRentalDal
    {
        public List<RentalDetailDto> GetCarDetails(Expression<Func<Rental, bool>> filter=null)
        {
            using (RentalCarDbContext context = new RentalCarDbContext())
            {
                var result = from r in filter == null ? context.Rentals : context.Rentals.Where(filter)
                             join c in context.Cars
                             on r.CarId equals c.Id
                             
                             join cu in context.Customers
                             on r.CustomerId equals cu.Id
                             
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             
                             join u in context.Users
                             on cu.UserId equals u.Id
                             
                             select new RentalDetailDto
                             {
                                 RentalId = r.Id,
                                 CarName = b.BrandName,
                                 CustomerFirstName = u.FirstName + " " + u.LastName,
                                 UserName = u.FirstName + " " + u.LastName,
                                 DailyPrice = c.DailyPrice,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                              
                             };
                return result.ToList();
            }
        }
    }
    
}

