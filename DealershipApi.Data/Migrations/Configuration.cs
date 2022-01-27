namespace DealershipApi.Data.Migrations
{
    using DealershipApi.Data.DataModels;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DealershipApi.Data.DataModels.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DealershipApi.Data.DataModels.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            var customers = new List<Customer>
            {
                new Customer {FirstName = "John", LastName = "Wick", Address = "12234 Fake Street", Email = "jwick@fakeemail.com"},
                new Customer {FirstName = "Steven", LastName = "Garcia", Address = "1836 High Street", Email = "sgarcia@fakeemail.com"},
                new Customer {FirstName = "Royce", LastName = "Young", Address = "26 Cedar Lane", Email = "royceyoung@fakeemail.com"},
                new Customer {FirstName = "Chuck", LastName = "Norris", Address = "150 Texas Road", Email = "cnorris@fakeemail.com"},
                new Customer {FirstName = "John", LastName = "Lawrence", Address = "2770 Pike Road", Email = "jlawrence@fakeemail.com"},
                new Customer {FirstName = "Robert", LastName = "Plant", Address = "150 Texas Road", Email = "rplant@fakeemail.com"},
                new Customer {FirstName = "Jim", LastName = "Douglas", Address = "1880 Cherry Road", Email = "jdouglas@fakeemail.com"},
                new Customer {FirstName = "Percy", LastName = "de la Cruz", Address = "520 Water Drive", Email = "pdelacruz@fakeemail.com"},
                new Customer {FirstName = "Victoria", LastName = "Gondaker", Address = "1501 Park Place", Email = "vgondaker@fakeemail.com"},
                new Customer {FirstName = "Beatrice", LastName = "Rogers", Address = "280 Emerson Ave", Email = "brogers@fakeemail.com"},
                new Customer {FirstName = "Johah", LastName = "Hill", Address = "21 Jump Street", Email = "jhill@fakeemail.com"},
                new Customer {FirstName = "Andrew", LastName = "Baker", Address = "540 Water Drive", Email = "abaker@fakeemail.com"},
                new Customer {FirstName = "David", LastName = "Green", Address = "8847 Hazel Dell Road", Email = "dgreen@fakeemail.com"},
                new Customer {FirstName = "Jessica", LastName = "Green", Address = "847 Hazel Dell Road", Email = "jgreen@fakeemail.com"}
            };

            
            customers.ForEach(s => context.Customers.AddOrUpdate(p => p.Id, s));
            context.SaveChanges();
            //  customers.ForEach(c => context.Customers.AddOrUpdate())

            var dealerships = new List<Dealership>
            {
                new Dealership { Name = "Shay's Car Emporium Kia Mazda East" , Address = "123 East Street"},
                new Dealership { Name = "Shay's Car Emporium Honda West" , Address = "123 West Street"},
                new Dealership { Name = "Shay's Car Emporium Chevy North" , Address = "123 North Street"},
                new Dealership { Name = "Shay's Car Emporium Crysler Jeep Dodge South" , Address = "123 South Street"},
            };
            dealerships.ForEach(s => context.Dealerships.AddOrUpdate(p => p.Id, s));
            context.SaveChanges();

            var suppliers = new List<Supplier>
            {
                new Supplier { Name ="Kia America", SupplierType= SupplierType.Wholeseller, Email = "Kia@fakeemail.com"},
                new Supplier { Name ="Mazda America", SupplierType= SupplierType.Wholeseller, Email = "Mazda@fakeemail.com"},
                new Supplier { Name ="Honda America", SupplierType= SupplierType.Wholeseller, Email = "Honda@fakeemail.com"},
                new Supplier { Name ="Chevy America", SupplierType= SupplierType.Wholeseller, Email = "Chevy@fakeemail.com"},
                new Supplier { Name ="CJD America", SupplierType= SupplierType.Wholeseller, Email = "CJD@fakeemail.com"},
                new Supplier { Name ="Brittany Spears", SupplierType= SupplierType.Individual, Email = "bspears@fakeemail.com"},
                new Supplier { Name ="Jerry Seinfeld", SupplierType= SupplierType.Individual, Email = "jseinfeld@fakeemail.com"},
                new Supplier { Name ="Bob Sacamano", SupplierType= SupplierType.Individual, Email = "bsacamano@fakeemail.com"},
                new Supplier { Name ="John Snow", SupplierType= SupplierType.Individual, Email = "jsnow@fakeemail.com"},
            };
            suppliers.ForEach(s => context.Suppliers.AddOrUpdate(p => p.Id, s));
            context.SaveChanges();

            var salesPeople = new List<SalesPerson>
            {
                new SalesPerson {FirstName = "Ryan", LastName="Jenkins", Email = "rjenkins@ShaysFakeEmail.com", DealerShipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Kia Mazda East").Id },
                new SalesPerson {FirstName = "Bobby", LastName="Jones", Email = "bjones@ShaysFakeEmail.com", DealerShipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Kia Mazda East").Id },
                new SalesPerson {FirstName = "Anne", LastName="Carter", Email = "acarter@ShaysFakeEmail.com", DealerShipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Honda West").Id },
                new SalesPerson {FirstName = "Trisha", LastName="White", Email = "twhite#ShaysFakeEmail.com", DealerShipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Honda West").Id },
                new SalesPerson {FirstName = "Alex", LastName="Carson", Email = "acarson@ShaysFakeEmail.com", DealerShipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Chevy North").Id },
                new SalesPerson {FirstName = "David", LastName="Thompson", Email = "dthompson@ShaysFakeEmail.com", DealerShipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Chevy North").Id },
                new SalesPerson {FirstName = "Larry", LastName="David", Email = "ldavid@ShaysFakeEmail.com", DealerShipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Crysler Jeep Dodge South").Id },
                new SalesPerson {FirstName = "Reggie", LastName="Miller", Email = "rmiller@ShaysFakeEmail.com", DealerShipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Crysler Jeep Dodge South").Id },
            };

            salesPeople.ForEach(s => context.SalesPeople.AddOrUpdate(p => p.Id, s));
            context.SaveChanges();

            var vehicles = new List<Vehicle>
            {
                new Vehicle { Make ="Chevrolet", Model="Malibu", ModelYear=2005, Color="Black", InvoicePrice=2500, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Kia Mazda East").Id, InStock = true, VehicleCondition=VehicleCondition.Used, Mileage=115000},
                new Vehicle { Make ="Nissan", Model="Altima", ModelYear=2017, Color="Blue", InvoicePrice=6500, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Kia Mazda East").Id, InStock = true, VehicleCondition=VehicleCondition.Used, Mileage=60000},
                new Vehicle { Make ="Honda", Model="Accord", ModelYear=2019, Color="White", InvoicePrice=9800, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Kia Mazda East").Id, InStock = true, VehicleCondition=VehicleCondition.Used, Mileage=14000},
                new Vehicle { Make ="Dodge", Model="Charger", ModelYear=2007, Color="Black", InvoicePrice=5000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Kia Mazda East").Id, InStock = true, VehicleCondition=VehicleCondition.Used, Mileage=95000},
                new Vehicle { Make ="Nissan", Model="Altima", ModelYear=2016, Color="Blue", InvoicePrice=6000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Kia Mazda East").Id, InStock = true, VehicleCondition=VehicleCondition.Used, Mileage=50000},
                new Vehicle { Make ="Chevrolet", Model="Impala", ModelYear=2008, Color="Red", InvoicePrice=6000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Kia Mazda East").Id, InStock = true, VehicleCondition=VehicleCondition.Used, Mileage=90000 },
                new Vehicle { Make ="Ford", Model="Focus", ModelYear=2015, Color="Black", InvoicePrice=7500, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Kia Mazda East").Id, InStock = true, VehicleCondition=VehicleCondition.Used, Mileage=100000},
                new Vehicle { Make ="Honda", Model="Accord", ModelYear=2019, Color="Blue", InvoicePrice=9500, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Kia Mazda East").Id, InStock = true, VehicleCondition=VehicleCondition.Used, Mileage=20000},
                new Vehicle { Make ="Dodge", Model="Charger", ModelYear=2010, Color="Silver", InvoicePrice=7000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Kia Mazda East").Id, InStock = true, VehicleCondition=VehicleCondition.Used, Mileage=120000},
                new Vehicle { Make ="Toyota", Model="Camry", ModelYear=2018, Color="White", InvoicePrice=8000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Kia Mazda East").Id, InStock = true , VehicleCondition=VehicleCondition.Used, Mileage=20000},
                new Vehicle { Make ="Kia", Model="Telluride", ModelYear=2022, Color="White", InvoicePrice=30000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Kia Mazda East").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Kia", Model="Telluride", ModelYear=2022, Color="Red", InvoicePrice=35000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Kia Mazda East").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Kia", Model="Soul", ModelYear=2022, Color="Blue", InvoicePrice=22000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Kia Mazda East").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Kia", Model="Soul", ModelYear=2022, Color="Yellow", InvoicePrice=25000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Kia Mazda East").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Kia", Model="Stinger", ModelYear=2022, Color="Silver", InvoicePrice=30000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Kia Mazda East").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Kia", Model="Stinger", ModelYear=2022, Color="Yellow", InvoicePrice=35000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Kia Mazda East").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Kia", Model="Stinger", ModelYear=2022, Color="Blue", InvoicePrice=40000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Kia Mazda East").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Mazda", Model="CX5", ModelYear=2022, Color="White", InvoicePrice=20000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Kia Mazda East").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Mazda", Model="CX5", ModelYear=2022, Color="Blue", InvoicePrice=22000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Kia Mazda East").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Mazda", Model="CX5", ModelYear=2022, Color="Black", InvoicePrice=28000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Kia Mazda East").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Mazda", Model="Mazda6", ModelYear=2022, Color="Red", InvoicePrice=27000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Kia Mazda East").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Mazda", Model="Mazda6", ModelYear=2022, Color="White", InvoicePrice=30000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Kia Mazda East").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Mazda", Model="CX9", ModelYear=2022, Color="Red", InvoicePrice=35000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Kia Mazda East").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Mazda", Model="CX9", ModelYear=2022, Color="White", InvoicePrice=38000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Kia Mazda East").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Mazda", Model="Miata", ModelYear=2022, Color="Silver", InvoicePrice=22000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Kia Mazda East").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Mazda", Model="Miata", ModelYear=2022, Color="White", InvoicePrice=30000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Kia Mazda East").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},

                new Vehicle { Make ="Chevrolet", Model="Malibu", ModelYear=2008, Color="Black", InvoicePrice=4000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Honda West").Id, InStock = true, VehicleCondition=VehicleCondition.Used, Mileage=90000},
                new Vehicle { Make ="Nissan", Model="Maxima", ModelYear=2019, Color="Black", InvoicePrice=10000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Honda West").Id, InStock = true, VehicleCondition=VehicleCondition.Used, Mileage=10000},
                new Vehicle { Make ="Nissan", Model="Maixma", ModelYear=2019, Color="White", InvoicePrice=9800, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Honda West").Id, InStock = true, VehicleCondition=VehicleCondition.Used, Mileage=15000 },
                new Vehicle { Make ="Toyota", Model="Camry", ModelYear=2012, Color="Red", InvoicePrice=5000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Honda West").Id, InStock = true , VehicleCondition=VehicleCondition.Used, Mileage=80000},
                new Vehicle { Make ="Honda", Model="Civic", ModelYear=2016, Color="Blue", InvoicePrice=6000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Honda West").Id, InStock = true , VehicleCondition=VehicleCondition.Used, Mileage=50000},
                new Vehicle { Make ="Chevrolet", Model="Impala", ModelYear=2016, Color="Red", InvoicePrice=7000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Honda West").Id, InStock = true, VehicleCondition=VehicleCondition.Used, Mileage=40000 },
                new Vehicle { Make ="Ford", Model="Focus", ModelYear=2015, Color="Black", InvoicePrice=7500, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Honda West").Id, InStock = true, VehicleCondition=VehicleCondition.Used, Mileage=30000 },
                new Vehicle { Make ="Honda", Model="Accord", ModelYear=2019, Color="White", InvoicePrice=9500, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Honda West").Id, InStock = true , VehicleCondition=VehicleCondition.Used, Mileage=15000},
                new Vehicle { Make ="Dodge", Model="Charger", ModelYear=2010, Color="Black", InvoicePrice=7000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Honda West").Id, InStock = true, VehicleCondition=VehicleCondition.Used, Mileage=75000 },
                new Vehicle { Make ="Toyota", Model="Camry", ModelYear=2017, Color="White", InvoicePrice=7000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Honda West").Id, InStock = true, VehicleCondition=VehicleCondition.Used, Mileage=25000 },
                new Vehicle { Make ="Honda", Model="CRV", ModelYear=2022, Color="White", InvoicePrice=20000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Honda West").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Honda", Model="CRV", ModelYear=2022, Color="Black", InvoicePrice=27500, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Honda West").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Honda", Model="CRV", ModelYear=2022, Color="Black", InvoicePrice=30000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Honda West").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Honda", Model="CRV", ModelYear=2022, Color="Red", InvoicePrice=32000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Honda West").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Honda", Model="Civic", ModelYear=2022, Color="White", InvoicePrice=20000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Honda West").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Honda", Model="Civic", ModelYear=2022, Color="White", InvoicePrice=21000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Honda West").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Honda", Model="Civic", ModelYear=2022, Color="Red", InvoicePrice=23000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Honda West").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Honda", Model="Civic", ModelYear=2022, Color="Silver", InvoicePrice=30000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Honda West").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Honda", Model="Accord", ModelYear=2022, Color="Grey", InvoicePrice=24000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Honda West").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Honda", Model="Accord", ModelYear=2022, Color="Black", InvoicePrice=26000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Honda West").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Honda", Model="Accord", ModelYear=2022, Color="Blue", InvoicePrice=30000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Honda West").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Honda", Model="Accord", ModelYear=2022, Color="Red", InvoicePrice=32000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Honda West").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Honda", Model="Odyssey", ModelYear=2022, Color="Blue", InvoicePrice=35000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Honda West").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Honda", Model="Ridgeline", ModelYear=2022, Color="White", InvoicePrice=35000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Honda West").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},


                new Vehicle { Make ="Honda", Model="Oddyssey", ModelYear=2016, Color="Red", InvoicePrice=10000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Chevy North").Id, InStock = true, VehicleCondition=VehicleCondition.Used, Mileage=80000 },
                new Vehicle { Make ="Nissan", Model="Maxima", ModelYear=2020, Color="Black", InvoicePrice=11000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Chevy North").Id, InStock = true, VehicleCondition=VehicleCondition.Used, Mileage=5000 },
                new Vehicle { Make ="Nissan", Model="Maixma", ModelYear=2019, Color="White", InvoicePrice=9800, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Chevy orth").Id, InStock = true, VehicleCondition=VehicleCondition.Used, Mileage=15000 },
                new Vehicle { Make ="Dodge", Model="Challenger", ModelYear=2019, Color="Red", InvoicePrice=8000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Chevy North").Id, InStock = true, VehicleCondition=VehicleCondition.Used, Mileage=50000 },
                new Vehicle { Make ="Honda", Model="Accord", ModelYear=2016, Color="Blue", InvoicePrice=7500, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Chevy North").Id, InStock = true, VehicleCondition=VehicleCondition.Used, Mileage=40000 },
                new Vehicle { Make ="Chevrolet", Model="Impala", ModelYear=2016, Color="Silver", InvoicePrice=7000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Chevy North").Id, InStock = true, VehicleCondition=VehicleCondition.Used, Mileage=30000 },
                new Vehicle { Make ="Ford", Model="F-150", ModelYear=2015, Color="Black", InvoicePrice=9000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Chevy North").Id, InStock = true, VehicleCondition=VehicleCondition.Used, Mileage=75000 },
                new Vehicle { Make ="Honda", Model="Accord", ModelYear=2019, Color="White", InvoicePrice=9500, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Chevy North").Id, InStock = true, VehicleCondition=VehicleCondition.Used, Mileage=20000 },
                new Vehicle { Make ="Dodge", Model="Charger", ModelYear=2014, Color="Black", InvoicePrice=7500, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Chevy North").Id, InStock = true, VehicleCondition=VehicleCondition.Used, Mileage=100000 },
                new Vehicle { Make ="Toyota", Model="Camry", ModelYear=2018, Color="White", InvoicePrice=7500, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Chevy North").Id, InStock = true , VehicleCondition=VehicleCondition.Used, Mileage=30000},
                new Vehicle { Make ="Chevrolet", Model="Equinox", ModelYear=2022, Color="White", InvoicePrice=20000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Chevy North").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Chevrolet", Model="Equinox", ModelYear=2022, Color="Red", InvoicePrice=22000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Chevy North").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Chevrolet", Model="Blazer", ModelYear=2022, Color="Red", InvoicePrice=25000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Chevy North").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Chevrolet", Model="Traverse", ModelYear=2022, Color="White", InvoicePrice=27000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Chevy North").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Chevrolet", Model="Traverse", ModelYear=2022, Color="Silver", InvoicePrice=27000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Chevy North").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Chevrolet", Model="Traverse", ModelYear=2022, Color="Black", InvoicePrice=29000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Chevy North").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Chevrolet", Model="Tahoe", ModelYear=2022, Color="White", InvoicePrice=46000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Chevy North").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Chevrolet", Model="Tahoe", ModelYear=2022, Color="Black", InvoicePrice=50000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Chevy North").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Chevrolet", Model="Tahoe", ModelYear=2022, Color="Black", InvoicePrice=65000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Chevy North").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Chevrolet", Model="Tahoe", ModelYear=2022, Color="Silver", InvoicePrice=70000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Chevy North").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Chevrolet", Model="Suburban", ModelYear=2022, Color="Red", InvoicePrice=50000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Chevy North").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Chevrolet", Model="Suburban", ModelYear=2022, Color="Blue", InvoicePrice=80000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Chevy North").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Chevrolet", Model="Silverado 1500", ModelYear=2022, Color="Green", InvoicePrice=35000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Chevy North").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Chevrolet", Model="Silverado 1500", ModelYear=2022, Color="Tan", InvoicePrice=55000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Chevy North").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Chevrolet", Model="Malibu", ModelYear=2022, Color="Red", InvoicePrice=25000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Chevy North").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Chevrolet", Model="Camaro", ModelYear=2022, Color="Red", InvoicePrice=40000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Chevy North").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Chevrolet", Model="Camaro", ModelYear=2022, Color="Yellow", InvoicePrice=45000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Chevy North").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Chevrolet", Model="Corvette", ModelYear=2022, Color="Blue", InvoicePrice=75000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Chevy North").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Chevrolet", Model="Corvette", ModelYear=2022, Color="White", InvoicePrice=80000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Chevy North").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},


                new Vehicle { Make ="Jeep", Model="Wrangler", ModelYear=2019, Color="Red", InvoicePrice=30000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Crysler Jeep Dodge South").Id, InStock = true , VehicleCondition=VehicleCondition.Used, Mileage=20000},
                new Vehicle { Make ="Jeep", Model="Wrangler", ModelYear=2018, Color="Blue", InvoicePrice=27000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Crysler Jeep Dodge South").Id, InStock = true , VehicleCondition=VehicleCondition.Used, Mileage=30000},
                new Vehicle { Make ="Nissan", Model="Maixma", ModelYear=2019, Color="White", InvoicePrice=9500, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Crysler Jeep Dodge South").Id, InStock = true , VehicleCondition=VehicleCondition.Used, Mileage=20000},
                new Vehicle { Make ="Honda", Model="Accord", ModelYear=2019, Color="White", InvoicePrice=11000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Crysler Jeep Dodge South").Id, InStock = true , VehicleCondition=VehicleCondition.Used, Mileage=15000},
                new Vehicle { Make ="Ford", Model="F-150", ModelYear=2018, Color="Blue", InvoicePrice=15000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Crysler Jeep Dodge South").Id, InStock = true , VehicleCondition=VehicleCondition.Used, Mileage=50000},
                new Vehicle { Make ="Honda", Model="Accord", ModelYear=2019, Color="White", InvoicePrice=9500, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Crysler Jeep Dodge South").Id, InStock = true, VehicleCondition=VehicleCondition.Used, Mileage=15000 },
                new Vehicle { Make ="Dodge", Model="Dart", ModelYear=2014, Color="Red", InvoicePrice=7500, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Crysler Jeep Dodge South").Id, InStock = true , VehicleCondition=VehicleCondition.Used, Mileage=10000},
                new Vehicle { Make ="Toyota", Model="Camry", ModelYear=2018, Color="White", InvoicePrice=7500, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Crysler Jeep Dodge South").Id, InStock = true , VehicleCondition=VehicleCondition.Used, Mileage=50000},
                new Vehicle { Make ="Chrysler", Model="300", ModelYear=2022, Color="Black", InvoicePrice=40000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Crysler Jeep Dodge South").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Chrysler", Model="Pacifia", ModelYear=2022, Color="White", InvoicePrice=31000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Crysler Jeep Dodge South").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Chrysler", Model="Pacifia", ModelYear=2022, Color="White", InvoicePrice=37000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Crysler Jeep Dodge South").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Jeep", Model="Wrangler", ModelYear=2022, Color="Red", InvoicePrice=29000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Crysler Jeep Dodge South").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Jeep", Model="Wrangler", ModelYear=2022, Color="Green", InvoicePrice=35000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Crysler Jeep Dodge South").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Jeep", Model="Wrangler", ModelYear=2022, Color="Blue", InvoicePrice=40000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Crysler Jeep Dodge South").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Jeep", Model="Wrangler", ModelYear=2022, Color="Red", InvoicePrice=42000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Crysler Jeep Dodge South").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Jeep", Model="Gladiator", ModelYear=2022, Color="Tan", InvoicePrice=31000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Crysler Jeep Dodge South").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Jeep", Model="Gladiator", ModelYear=2022, Color="Green", InvoicePrice=39000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Crysler Jeep Dodge South").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Jeep", Model="Gladiator", ModelYear=2022, Color="Grey", InvoicePrice=40000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Crysler Jeep Dodge South").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Jeep", Model="Grand Cherokee", ModelYear=2022, Color="Red", InvoicePrice=45000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Crysler Jeep Dodge South").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Jeep", Model="Wagoneer", ModelYear=2022, Color="Black", InvoicePrice=60000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Crysler Jeep Dodge South").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Dodge", Model="Charger", ModelYear=2022, Color="Red", InvoicePrice=30000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Crysler Jeep Dodge South").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Dodge", Model="Charger", ModelYear=2022, Color="White", InvoicePrice=45000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Crysler Jeep Dodge South").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Dodge", Model="Challenger", ModelYear=2022, Color="Black", InvoicePrice=45000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Crysler Jeep Dodge South").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Dodge", Model="Challenger", ModelYear=2022, Color="Green", InvoicePrice=60000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Crysler Jeep Dodge South").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Dodge", Model="Durango", ModelYear=2022, Color="Red", InvoicePrice=30000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Crysler Jeep Dodge South").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Dodge", Model="Durango", ModelYear=2022, Color="White", InvoicePrice=40000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Crysler Jeep Dodge South").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Ram", Model="1500", ModelYear=2022, Color="Black", InvoicePrice=36000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Crysler Jeep Dodge South").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Ram", Model="1500", ModelYear=2022, Color="White", InvoicePrice=37000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Crysler Jeep Dodge South").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
                new Vehicle { Make ="Ram", Model="2500", ModelYear=2022, Color="Black", InvoicePrice=49000, DealershipId = dealerships.Single(d => d.Name == "Shay's Car Emporium Crysler Jeep Dodge South").Id, InStock = true , VehicleCondition=VehicleCondition.New, Mileage=0},
            };
            vehicles.ForEach(s => context.Vehicles.AddOrUpdate(p => p.Id, s));
            vehicles.ForEach(s => context.Vehicles.AddOrUpdate(p => p.VehicleName, s));
            context.SaveChanges();



        }
    }


}

