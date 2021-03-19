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
            CarTest(carManager);
            //BrandTest(brandManager);
            //ColorTest(colorManager);

            Console.WriteLine("\n Arabaları Marka ID'sine Göre Getirmek : ");
            foreach (var car1 in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine(" Araba ID: " + car1.CarId + "  Araba Açıklaması: " + car1.Description + "   Günlük Fiyat: " + car1.DailyPrice);
            }

            Console.WriteLine("\n Arabaları Renk ID'sine Göre Getirmek : ");
            foreach (var car in carManager.GetCarsByColorId(3))
            {
                Console.WriteLine(" araba ID: " + car.CarId + "  Günlük Fiyat: " + car.DailyPrice + "  Araba Açıklaması: " + car.Description);
            }


            Console.WriteLine("\n Araba Bilgileri Silmek:");
            carManager.Delete(new Car { CarId = 15});
            Console.WriteLine("\n  Silme İşleminden Sonra Araba Bilgileri:");
            foreach (Car car in carManager.GetAll())
            {
                Console.WriteLine("Araba Id:" + car.CarId + "   ,Araba Adı:" + car.CarName + ", Günlük Fiyatı: " + car.DailyPrice + ",   Model Yılı: " + car.ModelYear + ",    Araba Açıklama:" + car.Description);
            }


            Console.WriteLine("\n Araba Bilgileri Eklemek:");
            carManager.Add(new Car { CarId =4, CarName="A3 Serisi" , BrandId=1 , ColorId=2 , DailyPrice=350 , ModelYear=2007,  Description= " Manuel Benzin" });
            carManager.Add(new Car { CarId = 5, CarName = "A3 Serisi", BrandId = 5, ColorId = 1, DailyPrice = 350, ModelYear = 2006, Description = " Manuel Benzin" });
            Console.WriteLine("\n Ekleme İşleminden Sonra Güncel Araba Bilgileri:");
            foreach (Car car in carManager.GetAll())
            {
                Console.WriteLine("Araba Id:" + car.CarId + "   ,Araba Adı:" + car.CarName + ", Günlük Fiyatı: " + car.DailyPrice + ",   Model Yılı: " + car.ModelYear + ",    Araba Açıklama:" + car.Description);
            }

            Console.WriteLine("\n Araba Bilgileri Güncellemek:");
            carManager.Update(new Car { CarId = 14, CarName = "A6 Serisi", BrandId = 4, ColorId = 3, DailyPrice = 450, ModelYear = 2009, Description = " Manuel Benzin" });
            Console.WriteLine("\n  Güncel Araba Bilgileri:");
            foreach (Car car in carManager.GetAll())
            {
                Console.WriteLine("Araba Id:" + car.CarId + "   ,Araba Adı:" + car.CarName + ", Günlük Fiyatı: " + car.DailyPrice + ",   Model Yılı: " + car.ModelYear + ",    Araba Açıklama:" + car.Description);
            }


        }

        private static void ColorTest(ColorManager colorManager)
        {
            Console.WriteLine("\n kiralık Arabaların Renk Bilgileri : ");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("Renk Id :" + color.ColorId + "  Araba Rengi : " + color.ColorName);
            }
        }

        private static void BrandTest(BrandManager brandManager)
        {
            Console.WriteLine("\n Kiralık Arabaların Marka Bilgileri :");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("Marka Id : " + brand.BrandId + "  Araba Markası : " + brand.BrandName);
            }
        }

        private static void CarTest(CarManager carManager)
        {
            Console.WriteLine("\n  Kiralık Arabaların Bilgileri: ");
            foreach (Car car in carManager.GetAll())
            {
                Console.WriteLine(" Araba Adı :" + car.CarName + "Model Yılı :  " + car.ModelYear + "  Günlük Ücreti : " + car.DailyPrice + "  Açıklaması : " + car.Description);
            }
        }
        
    }
}
