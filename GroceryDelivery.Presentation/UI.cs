using GroceryDelivery.Domain.Entities;
using GroceryDelivery.Domain.Enums;
using GroceryDelivery.Service.DTOs;
using GroceryDelivery.Service.Services;
using System.Globalization;

namespace GroceryDelivery.Presentation;

public class UI
{
    public  async Task StartAsync()
    {
        Console.WriteLine(@"


                    $$\      $$\ $$$$$$$$\ $$\       $$$$$$\   $$$$$$\  $$\      $$\ $$$$$$$$\ 
                    $$ | $\  $$ |$$  _____|$$ |     $$  __$$\ $$  __$$\ $$$\    $$$ |$$  _____|
                    $$ |$$$\ $$ |$$ |      $$ |     $$ /  \__|$$ /  $$ |$$$$\  $$$$ |$$ |      
                    $$ $$ $$\$$ |$$$$$\    $$ |     $$ |      $$ |  $$ |$$\$$\$$ $$ |$$$$$\    
                    $$$$  _$$$$ |$$  __|   $$ |     $$ |      $$ |  $$ |$$ \$$$  $$ |$$  __|   
                    $$$  / \$$$ |$$ |      $$ |     $$ |  $$\ $$ |  $$ |$$ |\$  /$$ |$$ |      
                    $$  /   \$$ |$$$$$$$$\ $$$$$$$$\\$$$$$$  | $$$$$$  |$$ | \_/ $$ |$$$$$$$$\ 
                    \__/     \__|\________|\________|\______/  \______/ \__|     \__|\________|
                                                                           
                                                                                                                                                 
");     bool lamp = true;
        while (lamp)
        {
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("              Welcome to the Role Selection              ");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Please select your role from the following options:");

            Console.WriteLine("1 - Customer");
            Console.WriteLine("2 - Driver");
            Console.WriteLine("3 - Admin");
            Console.WriteLine("4 - The Chef (Cook)");

            Console.WriteLine("--------------------------------------------------------");

            Console.Write("enter you wanted position:");
            string position = Console.ReadLine();

            CustomerService customerService = new CustomerService();
            DriverService driverService = new DriverService();
            switch (position)
            {
                case "1":
                    {
                        bool caseLamp1=true;
                        while(caseLamp1)
                        {

                            Console.WriteLine("sign in --> 1 || sign up --> 2");
                            string user1 = Console.ReadLine();
                            switch (user1)
                            {
                                case "1":
                                    {
                                        Console.Write("email: ");
                                        string email = Console.ReadLine();
                                        Console.Write("password: ");
                                        string password = Console.ReadLine();
                                        var res = await customerService.SignInAsync(email, password);

                                        if (res != 0)
                                        {
                                            bool lampSignIn = true;
                                            while(lampSignIn)
                                            {
                                                Console.WriteLine(@"
        1-update
        2-delete
        3-get By Id
        4-get all
        5-order item");
                                                Console.Write("     enter command: ");
                                                string userCommand = Console.ReadLine();
                                                switch (userCommand)
                                                {
                                                    case "1":
                                                        {
                                                            Console.WriteLine("UPDATE");
                                                            CustomerForUpdateDto customerForCreationDto = new CustomerForUpdateDto();
                                                            Console.Write("id: ");
                                                            customerForCreationDto.Id = long.Parse(Console.ReadLine());
                                                            Console.Write("firstname: ");
                                                            customerForCreationDto.FirtName = Console.ReadLine();
                                                            Console.Write("lastname: ");
                                                            customerForCreationDto.Lastname = Console.ReadLine();
                                                            Console.Write("email: ");
                                                            customerForCreationDto.Email = Console.ReadLine();
                                                            Console.Write("password: ");
                                                            customerForCreationDto.Password = Console.ReadLine();
                                                            Console.Write("address: ");
                                                            customerForCreationDto.Address = Console.ReadLine();
                                                            var result = await customerService.UpdateAsync(customerForCreationDto);
                                                            Console.WriteLine(@$"       
        {result.Id}
        {result.FirstName}
        {result.Lastname}
        {result.Email}
        {result.Password}
        {result.Address}
");
                                                        }
                                                        break;
                                                    case "2":
                                                        {
                                                            Console.WriteLine("DELETE");
                                                            Console.Write("id: ");
                                                            long id = long.Parse(Console.ReadLine());
                                                            var result = await customerService.DeleteByIdAsync(id);
                                                            Console.WriteLine(result);
                                                            Console.WriteLine("successfully deleted ....");
                                                        }
                                                        break;
                                                    case "3":
                                                        {

                                                            Console.WriteLine("GetBY ID");
                                                            Console.Write("id: ");
                                                            long id = long.Parse(Console.ReadLine());
                                                            var result = await customerService.GetByIdAsync(id);
                                                        }
                                                        break;
                                                    case "4":
                                                        {
                                                            Console.WriteLine("GET ALL");
                                                            var results = await customerService.GetAllAsync();
                                                            Console.WriteLine("+-----+------------------+-----------------+-------------------+----------------+-------------------+");
                                                            Console.WriteLine("| ID  | First Name       | Last Name       | Email             | Password       | Address           |");
                                                            Console.WriteLine("+-----+------------------+-----------------+-------------------+----------------+-------------------+");

                                                            foreach (var result in results)
                                                            {
                                                                Console.WriteLine($"| {result.Id,-4} | {result.FirstName,-16} | {result.Lastname,-15} | {result.Email,-17} | {result.Password,-14} | {result.Address,-17} |");
                                                            }

                                                            Console.WriteLine("+-----+------------------+-----------------+-------------------+----------------+-------------------+");

                                                        }
                                                        break;
                                                    case "5":
                                                        {
                                                            Random random = new Random();
                                                            OrderService orderService = new OrderService();
                                                            OrderForCreationDto orderForCreationDto = new OrderForCreationDto();
                                                            ProductService productService = new ProductService();

                                                            var products = await productService.GetAllAsync(); Console.WriteLine("+----+----------------------+-------------+-------+----------+");
                                                            Console.WriteLine("| ID |         Name         |  Category   | Price | Quantity |");
                                                            Console.WriteLine("+----+----------------------+-------------+-------+----------+");

                                                            foreach (var product in products)
                                                            {
                                                                Console.WriteLine($"| {product.Id,2} | {product.Name,-20} | {product.CategoryId,-11} | {product.Price,6} | {product.Quantity,8} |");
                                                            }

                                                            Console.WriteLine("+----+----------------------+-------------+-------+----------+");


                                                            long randomId = await orderService.RandomDriverIdAsync();
                                                            if (randomId != 0)
                                                            {
                                                                try
                                                                {

                                                                    Console.Write("ProductId: ");
                                                                    orderForCreationDto.ProductId = long.Parse(Console.ReadLine());
                                                                    Console.Write("CustomerId: ");
                                                                    orderForCreationDto.CustomerId = long.Parse(Console.ReadLine());
                                                                    orderForCreationDto.DriverId = random.Next(1, (int)randomId);
                                                                    Console.Write("location: ");
                                                                    orderForCreationDto.Location = Console.ReadLine();
                                                                    Console.Write("total amount: ");
                                                                    orderForCreationDto.TotalAmount = decimal.Parse(Console.ReadLine());
                                                                    var result = await orderService.CreateAsync(orderForCreationDto);
                                                                    Console.WriteLine(@$"
    -------------------------------------------------------------------
    Id: {result.Id}
    CustomerId: {result.CustomerId}
    driverId: {result.DriverId}
    productId: {result.ProductId}
    Location: {result.Location}
    total amount: {result.TotalAmount}
    total fee: {result.TotalFee}
    -------------------------------------------------------------------");
                                                                }
                                                                catch (Exception e)
                                                                {
                                                                    Console.WriteLine(e.Message);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Sorry, at the moment we have no free drivers :(");
                                                            }
                                                        }break;
                                                    default:
                                                        Console.WriteLine("            not found command");
                                                        break;
                                                }
                                                Console.WriteLine("back one page yes -->1 // others -->no");
                                                if (Console.ReadLine() != "1")
                                                    lampSignIn = false;
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Customer not found ...(email and password)");
                                        }

                                    }
                                    break;
                                case "2":
                                    {
                                        CustomerForCreationDto customerForCreationDto = new CustomerForCreationDto();
                                        Console.Write("firstname: ");
                                        customerForCreationDto.FirtName = Console.ReadLine();
                                        Console.Write("lastname: ");
                                        customerForCreationDto.Lastname = Console.ReadLine();
                                        Console.Write("email: ");
                                        customerForCreationDto.Email = Console.ReadLine();
                                        Console.Write("password: ");
                                        customerForCreationDto.Password = Console.ReadLine();
                                        Console.Write("address: ");
                                        customerForCreationDto.Address = Console.ReadLine();
                                        var result = await customerService.CreateAsync(customerForCreationDto);
                                        Console.WriteLine(@$"       {result.Id}
        {result.FirstName}
        {result.Lastname}
        {result.Email}
        {result.Password}
        {result.Address}
");
                                    }
                                    break;
                                default:
                                    Console.WriteLine("not found command "); break;
                            }
                            Console.WriteLine("back sign in/up MENU : yes-->1 // others---> no");
                            if (Console.ReadLine() != "1")
                                caseLamp1 = false;
                        }
                    }
                    break;
                case "2":
                    {
                        bool caseLamp2 = true;
                        while (caseLamp2)
                        {
                            Console.WriteLine("sign in -->1 // sign up --- >2 ");
                            string userInput = Console.ReadLine();
                            switch (userInput)
                            {
                                case "1":
                                    {
                                        Console.Write("firstname: ");
                                        string firstname = Console.ReadLine();
                                        Console.Write("lastname: ");
                                        string lastname = Console.ReadLine();
                                        var res = await driverService.SignInCheckAsync(firstname, lastname);

                                        if (res)
                                        {
                                            bool lampSignIn = true;
                                            while (lampSignIn)
                                            {
                                                Console.WriteLine("Successfully enter ...");
                                                Console.WriteLine("1-UPDATE\n2-DELETE\n3-GET ALL\n4-GET BY ID");
                                                string userChoise = Console.ReadLine();
                                                switch (userChoise)
                                                {
                                                    case "1":
                                                        {
                                                            DriverForUpdateDto driverForUpdateDto = new DriverForUpdateDto();
                                                            Console.WriteLine("UPDATE");
                                                            Console.Write("id: ");
                                                            driverForUpdateDto.Id = long.Parse(Console.ReadLine());
                                                            Console.Write("FirstName: ");
                                                            driverForUpdateDto.FirsName = Console.ReadLine();
                                                            Console.WriteLine("Lastname: ");
                                                            driverForUpdateDto.Lastname = Console.ReadLine();
                                                            Console.Write("(track\r\n    bycicle,\r\n    motocycle,\r\n    train, \r\n    airlane): \nVehicle: ");
                                                            driverForUpdateDto.Vehicle = (Vehicle)Enum.Parse(typeof(Vehicle), Console.ReadLine().ToLower());
                                                            var result = await driverService.UpdateAsync(driverForUpdateDto);
                                                            Console.WriteLine(@$"
+-------------------+
| ID:         {result.Id}
| First Name: {result.FirsName}
| Last Name:  {result.Lastname}
| Vehicle:    {result.Vehicle}SS
+-------------------+
Successfully UPDATED!!
");

                                                        }
                                                        break;
                                                    case "2":
                                                        {
                                                            Console.Write("id: ");
                                                            long id = long.Parse(Console.ReadLine());
                                                            var result = await driverService.DeleteByIdAsync(id);
                                                            Console.WriteLine(result+"\nSuccessfully deleted.");
                                                        }break;
                                                    case "3":
                                                        {
                                                            Console.WriteLine("ALL DRIVERS: ");
                                                            var results = await driverService.GetAllAsync();
                                                            Console.WriteLine("+-----+----------------+-------------+-----------+");
                                                            Console.WriteLine("| ID  | First Name     | Last Name  | Vehicle   |");
                                                            Console.WriteLine("+-----+----------------+-------------+-----------+");

                                                            foreach (var result in results)
                                                            {
                                                                Console.WriteLine($"| {result.Id,-4} | {result.FirsName,-14} | {result.Lastname,-11} | {result.Vehicle,-9} |");
                                                            }

                                                            Console.WriteLine("+-----+----------------+-------------+-----------+");

                                                        }
                                                        break;
                                                    case "4":
                                                        {
                                                            Console.Write("id: ");
                                                            long id = long.Parse(Console.ReadLine());
                                                            var result = await driverService.GetByIdAsync(id);
                                                                Console.WriteLine(@$"
+------------------------------------------------------------+
| ID:       {result.Id}
| First Name: {result.FirsName}
| Last Name:  {result.Lastname}
| Vehicle:    {result.Vehicle}
+------------------------------------------------------------+");
                                                            
;
                                                        }
                                                        break;
                                                    default: Console.WriteLine("out of these commands ...:(");break;
                                                }
                                                Console.WriteLine("do you wan to go back? yes --> 1 // others -->no");
                                                if (Console.ReadLine() != "1")
                                                    lampSignIn = false;
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("there is no driver in this full name ...:(\n");
                                        }
                                    }
                                    break;
                                case "2":
                                    {
                                        DriverForCreationDto driverForCreationDto = new DriverForCreationDto();
                                        Console.Write("firstname:");
                                        driverForCreationDto.FirsName = Console.ReadLine();
                                        Console.Write("lastname: ");
                                        driverForCreationDto.Lastname = Console.ReadLine();
                                        Console.Write("(track\r\n    bycicle,\r\n    motocycle,\r\n    train, \r\n    airlane): \nVehicle: ");
                                        bool isTrue = true;
                                        while (isTrue)
                                        {
                                            try
                                            {
                                                driverForCreationDto.Vehicle = (Vehicle)Enum.Parse(typeof(Vehicle), Console.ReadLine());
                                                isTrue = false;
                                            }
                                            catch 
                                            {
                                                Console.WriteLine("wrong input, please try again, and be carefully :)");
                                            }
                                        }

                                        var result = await driverService.CreateAsync(driverForCreationDto);
                                    }
                                    break;
                                default:
                                    Console.WriteLine("this command not found .... ");
                                    break;
                            }
                            Console.WriteLine("back sign in / up MENU : yes -->1 // others --> NO");
                            if (Console.ReadLine() != "1")
                                caseLamp2 = false;
                        }
                    }break;
                case "3":
                    {
                        Console.Write("ADMIN \nenter login: ");
                        if (Console.ReadLine().ToLower() == "admin")
                        {
                            Console.WriteLine("you have entered successfully\n");
                            bool lampAdmin = true;
                            while (lampAdmin)
                            {
                                Console.WriteLine(@"choose command:
1-get all customers info
2-get all Drivers
3-all orders");
                                string adminCommand = Console.ReadLine();
                                switch (adminCommand)
                                {
                                    case "1":
                                        {
                                            var results = await customerService.GetAllAsync();
                                            Console.WriteLine("+-----+----------------+-------------+-------------------+----------------+-------------------+");
                                            Console.WriteLine("| ID  | First Name     | Last Name   | Email             | Password       | Address           |");
                                            Console.WriteLine("+-----+----------------+-------------+-------------------+----------------+-------------------+");

                                            foreach (var result in results)
                                            {
                                                Console.WriteLine($"| {result.Id,-4} | {result.FirstName,-14} | {result.Lastname,-12} | {result.Email,-18} | {result.Password,-14} | {result.Address,-18} |");
                                            }

                                            Console.WriteLine("+-----+----------------+-------------+-------------------+----------------+-------------------+");

                                        }
                                        break;
                                    case "2":
                                        {
                                            var results = await driverService.GetAllAsync(); Console.WriteLine("+------+--------------+-----------+------------------+");
                                            Console.WriteLine("|  ID  |  First Name  |  Lastname |     Vehicle      |");
                                            Console.WriteLine("+------+--------------+-----------+------------------+");

                                            foreach (var result in results)
                                            {
                                                Console.WriteLine($"| {result.Id,4} | {result.FirsName,-12} | {result.Lastname,-9} | {result.Vehicle,-16} |");
                                            }

                                            Console.WriteLine("+------+--------------+-----------+------------------+");

                                        }
                                        break;
                                    case "3":
                                        {
                                            OrderService orderService = new OrderService();
                                            var results = await orderService.GetAllAsync();
                                            Console.WriteLine("+------+-----------+------------+----------------------+--------------------+--------------------+");
                                            Console.WriteLine("|  id  | ProductID | customerID |      DriverID       |      Location      |    Total Amount    |    Total Fee    |");
                                            Console.WriteLine("+------+-----------+------------+----------------------+--------------------+--------------------+");

                                            foreach (var result in results)
                                            {
                                                Console.WriteLine($"| {result.Id,4} | {result.ProductId,-9} | {result.CustomerId,-10} | {result.DriverId,-20} | {result.Location,-18} | {result.TotalAmount,-18} | {result.TotalFee,-15} |");
                                            }

                                            Console.WriteLine("+------+-----------+------------+----------------------+--------------------+--------------------+");

                                        }
                                        break;
                                    default: Console.WriteLine("not found command...");
                                        break;
                                }
                                Console.WriteLine("back one page: yes -->1 // no --> others");
                                if (Console.ReadLine()!="1")
                                    lampAdmin = false;
                            }

                        }
                    }break;
                //the cook
                case "4":
                    {
                        Console.Write("the Cook:\n(cook)enter login:");
                        if (Console.ReadLine().ToLower()=="cook")
                        {
                            bool lampChef = true;
                            while (lampChef)
                            {
                                Console.WriteLine("----------------------------------------------------");
                                Console.WriteLine("           Welcome to the Chef's Console           ");
                                Console.WriteLine("----------------------------------------------------");
                                Console.WriteLine("You have successfully entered the role of a chef!");
                                Console.WriteLine("Please choose an action from the following options:");

                                Console.WriteLine("1 - Create Product");
                                Console.WriteLine("2 - View All Products");
                                Console.WriteLine("3 - Delete Product");
                                Console.WriteLine("4 - Update Product");
                                Console.WriteLine("5 - Get Product by ID");
                                Console.WriteLine();
                                Console.WriteLine("6 - Create Category");
                                Console.WriteLine("7 - View All Categories");
                                Console.WriteLine("8 - Delete Category");
                                Console.WriteLine("9 - Update Category");
                                Console.WriteLine("10 - Get Category by ID");

                                Console.WriteLine("----------------------------------------------------");

                                Console.Write("enter command, Chef: ");
                                string chefCommand = Console.ReadLine();

                                ProductService productService = new ProductService();
                                ProductForUpdateDto productForUpdateDto = new ProductForUpdateDto();
                                ProductForCreationDto productForCreationDto = new ProductForCreationDto();
                                CategoryService categoryService = new CategoryService();
                                CategoryForCreationDto categoryForCreationDto = new CategoryForCreationDto();
                                CategoryForUpdateDto categoryForUpdateDto = new CategoryForUpdateDto();

                                switch (chefCommand)
                                {

                                    //product 1-5
                                    #region case 1-5 
                                    case "1":
                                        {
                                            Console.Write("categoryId: ");
                                            productForCreationDto.CategoryId = long.Parse(Console.ReadLine());
                                            Console.Write("name: ");
                                            productForCreationDto.Name = Console.ReadLine();
                                            Console.Write("price: ");
                                            productForCreationDto.Price = decimal.Parse(Console.ReadLine());
                                            Console.Write("Quantity (as large as possible): ");
                                            productForCreationDto.Quantity = decimal.Parse(Console.ReadLine());
                                            var result = await productService.CreateAsync(productForCreationDto);
                                            Console.Write($"\n{result.Id}=={result.Name}=={result.Price}=={result.CategoryId}=={result.Quantity}\n");
                                        }break;
                                    case "2":
                                        {
                                            var results = await productService.GetAllAsync();
                                            Console.WriteLine("+------+----------------------+-----------+-------------+----------+");
                                            Console.WriteLine("|  ID  |        Name          |   Price   | Category ID | Quantity |");
                                            Console.WriteLine("+------+----------------------+-----------+-------------+----------+");

                                            foreach (var result in results)
                                            {
                                                Console.WriteLine($"| {result.Id,-4} | {result.Name,-20} | {result.Price,-9} | {result.CategoryId,-11} | {result.Quantity,-8} |");
                                            }

                                            Console.WriteLine("+------+----------------------+-----------+-------------+----------+");

                                        }
                                        break;
                                    case "3":
                                        {
                                            Console.Write("id: ");
                                            long id = long.Parse(Console.ReadLine()) ;
                                            var result = await productService.DeleteByIdAsync(id);
                                            Console.WriteLine($"{result} successfully DELETED");
                                        }break;
                                    case "4":
                                        {
                                            Console.Write("id: ");
                                            productForUpdateDto.Id = long.Parse(Console.ReadLine()) ;
                                            Console.Write("categoryId: ");
                                            productForUpdateDto.CategoryId = long.Parse(Console.ReadLine());
                                            Console.Write("name: ");
                                            productForUpdateDto.Name = Console.ReadLine();
                                            Console.Write("price: ");
                                            productForUpdateDto.Price = decimal.Parse(Console.ReadLine());
                                            Console.Write("Quantity (as large as possible): ");
                                            productForUpdateDto.Quantity = decimal.Parse(Console.ReadLine());
                                            var result = await productService.UpdateAsync(productForUpdateDto);
                                            
                                            Console.WriteLine("successfully UPDATED");
                                            Console.WriteLine("+------+----------------------+-----------+-------------+----------+");
                                            Console.WriteLine("|  ID  |        Name          |   Price   | Category ID | Quantity |");
                                            Console.WriteLine("+------+----------------------+-----------+-------------+----------+");

                                            Console.WriteLine($"| {result.Id,-4} | {result.Name,-20} | {result.Price,-9} | {result.CategoryId,-11} | {result.Quantity,-8} |");

                                            Console.WriteLine("+------+----------------------+-----------+-------------+----------+");
                                        }
                                        break;
                                    case "5":
                                        {
                                            Console.Write("id: ");
                                            long id = long.Parse(Console.ReadLine());
                                            var result = await productService.GetByIdAsync(id);
                                            Console.WriteLine("+------+----------------------+-----------+-------------+----------+");
                                            Console.WriteLine("|  ID  |        Name          |   Price   | Category ID | Quantity |");
                                            Console.WriteLine("+------+----------------------+-----------+-------------+----------+");

                                            Console.WriteLine($"| {result.Id,-4} | {result.Name,-20} | {result.Price,-9} | {result.CategoryId,-11} | {result.Quantity,-8} |");

                                            Console.WriteLine("+------+----------------------+-----------+-------------+----------+");

                                        }
                                        break;
                                    #endregion
                                    // category 6-10
                                    case "6":
                                        {
                                            Console.Write("category name: ");
                                            categoryForCreationDto.Name = Console.ReadLine();
                                            var result = await categoryService.CreateAsync(categoryForCreationDto);
                                            Console.WriteLine($"{result.Id}=={result.Name}");
                                        }break;
                                    case "7":
                                        {
                                            var results = await categoryService.GetAllAsync();
                                            Console.WriteLine("+------+----------------------+");
                                            Console.WriteLine("|  ID  |        Name          |");
                                            Console.WriteLine("+------+----------------------+");

                                            foreach (var result in results)
                                            {
                                                Console.WriteLine($"| {result.Id,-4} | {result.Name,-20} |");
                                            }

                                            Console.WriteLine("+------+----------------------+");

                                        }
                                        break;
                                    case "8":
                                        {
                                            Console.Write("id: ");
                                            long id = long.Parse(Console.ReadLine()) ;
                                            var result = await categoryService.DeleteByIdAsync(id);
                                            Console.WriteLine("DELETED..." + result);
                                        }break;
                                    case "9":
                                        {
                                            Console.Write("id: ");
                                            categoryForUpdateDto.Id = long.Parse(Console.ReadLine()) ;
                                            Console.Write("name: ");
                                            categoryForUpdateDto.Name = Console.ReadLine();
                                            var result = await categoryService.UpdateAsync(categoryForUpdateDto);
                                            Console.WriteLine("successfully UPDATED");
                                            Console.WriteLine($"{result.Id, -4} | {result.Name, -20}");
                                        }break;
                                    case "10":
                                        {
                                            Console.Write("id: ");
                                            long id = long.Parse(Console.ReadLine());
                                            var result = await categoryService.GetByIdAsync(id);
                                            Console.WriteLine($" {result.Id,-4} | {result.Name, -20}");
                                        }
                                        break;
                                    default : Console.WriteLine("not found command ,  chef");
                                        break;

                                }
                                Console.Write("back one page: yes --> 1 // no --> others");
                                if (Console.ReadLine() != "1")
                                    lampChef= false;
                            }


                        }
                    }break;
                default:
                    Console.WriteLine("not fount this position");
                    break;
            }
            Console.WriteLine("do you want to go MAIN window? yes/ no and others");
            if (Console.ReadLine() !="yes")
            {
                lamp = false;
            }

        }

        
    }
}
