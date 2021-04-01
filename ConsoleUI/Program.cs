using System;
using Business.Concrete;
using Core.Entities.Concrete;
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
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            UserManager userManager = new UserManager(new EfUserDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());


            bool cikis = true;

            while (cikis)
            {
                Console.WriteLine(
                    "_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-Araba Kiralama Sistemi Ana Menü-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-" +
                    "\n\n1.Araba Ekleme\n" +
                    "2.Araba Silme\n" +
                    "3.Araba Güncelleme\n" +
                    "4.Arabaların Listelenmesi\n" +
                    "5.Arabaların detaylı bir şekilde Listelenmesi\n" +
                    "6.Arabaların Marka Id'sine göre Listelenmesi\n" +
                    "7.Arabaların Renk Id'sine göre Listelenmesi\n" +
                    "8.Renk Ekleme\n" +
                    "9.Renk Listeleme\n" +
                    "10.Marka Ekleme\n" +
                    "11.Marka Listeleme \n" +
                    "12.Müşteri Ekleme\n" +
                    "13.Müşterilerin Listelenmesi\n" +
                    "14.Kullanıcı Ekleme\n" +
                    "15.Kullanıcıların Listelenmesi\n" +
                    "16.Araba Kiralama\n" +
                    "17.Araba Teslim Etme\n" +
                    "18.Araba Kiralama Listesi\n" +
                    "19.Çıkış\n" +
                    "Hangi işlemi gerçekleştirmek istersiniz ?"
                    );

                int number = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-\n");
                switch (number)
                {
                    case 1:
                        CarAdd(carManager, brandManager, colorManager);
                        break;
                    case 2:
                        GetCarDetails(carManager);
                        CarDelete(carManager);
                        break;
                    case 3:
                        GetCarDetails(carManager);
                        CarUpdate(carManager);
                        break;
                    case 4:
                        GetAllCar(carManager);
                        break;
                    case 5:
                        GetCarDetails(carManager);
                        break;
                    case 6:
                        GetAllBrand(brandManager);
                        CarListByBrand(carManager);
                        break;
                    case 7:
                        GetAllColor(colorManager);
                        CarListByColor(carManager);
                        break;
                    case 8:
                        GetAllColor(colorManager);
                        AddColor(colorManager);
                        break;
                    case 9:
                        GetAllColor(colorManager);
                        Console.ReadLine();

                        break;
                    case 10:
                        GetAllBrand(brandManager);
                        AddBrand(brandManager);
                        Console.ReadLine();
                        break;
                    case 11:
                        GetAllBrand(brandManager);
                        Console.ReadLine();
                        break;
                    case 12:
                        GetAllUser(userManager);
                        CustomerAdd(customerManager);
                        break;
                    case 13:
                        GetAllCustomer(customerManager);
                        break;
                    case 14:
                        UserAdd(userManager);
                        break;
                    case 15:
                        GetAllUser(userManager);
                        break;
                    case 16:
                        GetCarDetails(carManager);
                        GetAllCustomer(customerManager);
                        RentalAdd(rentalManager);
                        break;
                    case 17:
                        ReturnRental(rentalManager);
                        break;
                    case 18:
                        GetAllRentalDetail(rentalManager);
                        break;
                    case 19:
                        cikis = false;

                        Console.WriteLine("Çıkış işlemi gerçekleşti.");
                        break;
                }
            }
        }

        private static void GetAllRentalDetail(RentalManager rentalManager)
        {
            Console.WriteLine("Kiralanan Arabalar Listesi: \nId\tMüşteri Adı\tMüşteri Id\tKiralama Tarihi\tTeslim Tarihi");
            foreach (var rental in rentalManager.GetRentalDetails().Data)
            {
                Console.WriteLine($"{rental.RentalId}\t{rental.CarName}\t{rental.CustomerFirstName}\t{rental.RentDate}\t{rental.ReturnDate}");
            }
        }

        private static void ReturnRental(RentalManager rentalManager)
        {
            Console.WriteLine("Kiraladığınız Arabanın Car Id Değerini Giriniz:");
            int carId = Convert.ToInt32(Console.ReadLine());
            var returnedRental = rentalManager.GetRentalDetails(I => I.CarId == carId);
            foreach (var rental in returnedRental.Data)
            {
                rental.ReturnDate = DateTime.Now;
                Console.WriteLine(returnedRental.Message);
            }
        }

        private static void RentalAdd(RentalManager rentalManager)
        {

            Console.Write("Kiralamayı yapacak 'Müşteri ID' : ");
            string _tempCustomer = Console.ReadLine();
            if (_tempCustomer != null)
            {
                Console.Write("Kiralanacak Araç ID DEğerini Giriniz: ");
                int _carId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Kiralama Tarihi[aa/gg/yyyy] : ");
                DateTime _rentDate = Convert.ToDateTime(Console.ReadLine());
                DateTime? _returnDate = null;
                int _customerId = Convert.ToInt32(_tempCustomer);

                Rental rental = new Rental
                {
                    CarId = _carId,
                    CustomerId = _customerId,
                    RentDate = _rentDate,
                    ReturnDate = _returnDate
                };

                var result = rentalManager.Add(rental);
                Console.WriteLine(result.Message);
            }



        }

        private static void UserAdd(UserManager userManager)
        {
            Console.WriteLine("Kullanıcı Adı: ");
            string userNameForAdd = Console.ReadLine();
            Console.WriteLine("Kullanıcı Soyadı: ");
            string userSurnameForAdd = Console.ReadLine();
            Console.WriteLine("Email : ");
            string userEmailForAdd = Console.ReadLine();
            Console.WriteLine("Kullanıcı Şifre: ");
            string userPasswordForAdd = Console.ReadLine();


            User userForAdd = new User
            {
                FirstName = userNameForAdd,
                LastName = userSurnameForAdd,
                Email = userEmailForAdd,
                
            };
            var result =userManager.Add(userForAdd);
            Console.WriteLine(result.Message);
        }
    

        private static void GetAllCustomer(CustomerManager customerManager)
        {
            Console.WriteLine("Müşterilerin Listesi: \nId\tKullanıcı Id\tŞirket Adı");
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine($"{customer.Id}\t{customer.UserId}\t{customer.CompanyName}");
            }
        }

        private static void GetAllUser(UserManager userManager)
        {
            Console.WriteLine("Kullanıcı Listesi: \nId\tAdı\tSoyadı\tEmail\tŞİfre");
            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine($"{user.Id}\t{user.FirstName}\t{user.LastName}");
            }
        }

        private static void CustomerAdd(CustomerManager customerManager)
        {

            Console.Write("Kullanıcı ID : ");
            string _nullUserId = Console.ReadLine();

            if (_nullUserId == null)
            {
                Console.WriteLine("Lütfen Kullanıcı ID DEğeri Giriniz!");

            }
            else
            {
                int _userIdForAdd = Convert.ToInt32(_nullUserId);
                Console.Write("Şirket Adı : ");
                string _companyNameForAdd = Console.ReadLine();

                Customer customer = new Customer
                {
                    UserId = _userIdForAdd,
                    CompanyName = _companyNameForAdd
                };
                var result = customerManager.Add(customer);
                Console.WriteLine(result.Message);
            }
        }

        private static void AddBrand(BrandManager brandManager)
        {

            Console.Write("\nEklemek istediğiniz yeni Marka Adı : ");
            string _brandName;
            _brandName = Console.ReadLine();

            Brand brand = new Brand
            {
                BrandName = _brandName
            };

            var result =brandManager.Add(brand);
            Console.WriteLine(result.Message);
        }

        private static void AddColor(ColorManager colorManager)
        {

            Console.Write("\nEklemek istediğiniz yeni Renk Adı : ");
            string _colorName;
            _colorName = Console.ReadLine();

            Color color = new Color
            {
                ColorName = _colorName
            };

            var result = colorManager.Add(color);
            Console.WriteLine(result.Message);

        }



        private static void CarListByColor(CarManager carManager)
        {
            Console.WriteLine("Görmek İstediğiniz Araba Renge Ait ID Değerini Giriniz:");
            int colorIdForCarList = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"\n\nColor Id'si {colorIdForCarList} olan arabalar: \nId\tRenk Id\tMarka Adı\tModel Yılı\tGünlük Fiyat\tAçıklama");
            foreach (var car in carManager.GetCarsByColorId(colorIdForCarList).Data)
            {
                Console.WriteLine($"{car.Id}\t{car.ColorId}\t\t{car.BrandId}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
            }
        }


        private static void GetAllColor(ColorManager colorManager)
        {
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine($"{color.Id}\t{color.ColorName}");
            }
        }


        private static void CarListByBrand(CarManager carManager)
        {
            Console.WriteLine("Görmek İstediğiniz Araba Markasına Ait ID Değerini Giriniz: ");
            int brandIdForCarList = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"\n\nBrand Id'si {brandIdForCarList} olan arabalar: \nMarka Id\tRenk Id\tSeri Adı\tModel Yılı\tGünlük Fiyat\tAçıklama");
            foreach (var car in carManager.GetCarsByColorId(brandIdForCarList).Data)
            {
                Console.WriteLine($"{car.ColorId}\t\t{car.BrandId}\t\t{car.CarName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
            }
        }

        private static void GetAllBrand(BrandManager brandManager)
        {
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine($"{brand.Id}\t{brand.BrandName}");
            }
        }

        private static void GetAllCar(CarManager carManager)
        {
            Console.WriteLine("Arabaların Listesi:  \nId\tRenk\tMarka\tSeri Adı\tModel Yılı\tGünlük Fiyatı\tAçıklama");
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine($"{car.Id}\t{car.ColorId}\t\t{car.BrandId}\t\t{car.CarName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
            }
        }

        private static void CarUpdate(CarManager carManager)
        {
            Console.WriteLine("Güncellemek İstediğiniz Araba Id Değeri: ");
            int carIdForUpdate = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Marka Id: ");
            int brandIdForUpdate = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Renk Id: ");
            int colorIdForUpdate = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Günlük Fiyat: ");
            decimal dailyPriceForUpdate = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Açıklama : ");
            string descriptionForUpdate = Console.ReadLine();

            Console.WriteLine("Model Yılı: ");
            int modelYearForUpdate = Convert.ToInt32(Console.ReadLine());

            Car carForUpdate = new Car
            {
                Id = carIdForUpdate,
                BrandId = brandIdForUpdate,
                ColorId = colorIdForUpdate,
                DailyPrice = dailyPriceForUpdate,
                Description = descriptionForUpdate,
                ModelYear = modelYearForUpdate
            };
            carManager.Update(carForUpdate);
            Console.WriteLine("\n Listenin Son Hali :");
            GetAllCar(carManager);
        }

        private static void GetCarDetails(CarManager carManager)
        {
            Console.WriteLine("Araba Detay Listesi:  \nRenk Adı\tMarka Adı\tModel Yılı\tGünlük Fiyat\tAçıklama");
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine($"{car.ColorName}\t\t{car.BrandName}\t\t{car.CarName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
            }
        }

        private static void CarDelete(CarManager carManager)
        {

            Console.Write("Silmek istediğiniz Kayıt ID Değerini Giriniz: ");
            int _deleteId = Convert.ToInt32(Console.ReadLine());

            Car deleteCar = new Car { Id = _deleteId };

            carManager.Delete(deleteCar);
            Console.WriteLine();

            Console.WriteLine("Listenin Son Hali :");
            GetAllCar(carManager);
        }

        private static void CarAdd(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
        {
            Console.WriteLine("Araba Renkleri:");
            GetAllColor(colorManager);

            Console.WriteLine("Araba Markaları:");
            GetAllBrand(brandManager);

            Console.WriteLine("\nMarka Id: ");
            int brandIdForAdd = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Renk Id: ");
            int colorIdForAdd = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Günlük Fiyat: ");
            decimal dailyPriceForAdd = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Araba Açıklama : ");
            string descriptionForAdd = Console.ReadLine();

            Console.WriteLine("Model Yılı: ");
            int modelYearForAdd = Convert.ToInt32(Console.ReadLine());

            Car carForAdd = new Car { BrandId = brandIdForAdd, ColorId = colorIdForAdd, DailyPrice = dailyPriceForAdd, Description = descriptionForAdd, ModelYear = modelYearForAdd };
            
            var result = carManager.Add(carForAdd);
            Console.WriteLine(result.Message);
            
        }
    }
    
}
