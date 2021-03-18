using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            Console.WriteLine("\n  Kiralık Arabaların Bilgileri: ");
            foreach (Car car in carManager.GetAll())
            {
                Console.WriteLine(" Model Yılı :  " + car.ModelYear + "  Günlük Ücreti : " + car.DailyPrice + "  Açıklaması : " + car.Description   );
            }


            Console.WriteLine("\n Kiralık Arabaların Marka Bilgileri :");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine( "Marka Id : "  +brand.BrandId + "  Araba Markası : " + brand.BrandName );
            }


            Console.WriteLine("\n kiralık Arabaların Renk Bilgileri : ");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("Renk Id :" + color.ColorId +  "  Araba Rengi : " +color.ColorName );
            }


            Console.WriteLine("\n Arabaları Marka ID'sine Göre Getirmek : ");
            foreach (var car1 in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine(" Araba ID: " + car1.CarId +"  Araba Açıklaması: " +  car1.Description + "   Günlük Fiyat: " + car1.DailyPrice );
            }

            Console.WriteLine("\n Arabaları Renk ID'sine Göre Getirmek : ");
            foreach (var car in carManager.GetCarsByColorId(3))
            {
                Console.WriteLine(" araba ID: " +car.CarId + "  Günlük Fiyat: " + car.DailyPrice +"  Araba Açıklaması: " +   car.Description);
            }
        }
    }
}
