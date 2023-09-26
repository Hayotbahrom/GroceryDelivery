using GroceryDelivery.Domain.Entities;
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
            Console.WriteLine(@"
    1-customer
    2-driver
    3-admin
");
            Console.Write("enter you wanted position:");
            string position = Console.ReadLine();

            switch (position)
            {
                case "1":
                    {
                        CustomerService customerService = new CustomerService();
                        Console.WriteLine("sign in --> 1 || sign up --> 2");
                        string user1= Console.ReadLine();
                        switch(user1)
                        {
                            case "1":
                                {
                                    Console.Write("email: ");
                                    string email= Console.ReadLine();
                                    Console.Write("password: ");
                                    string password = Console.ReadLine();
                                    var res = await customerService.SignInAsync(email, password);
                                    if (res is not null)
                                    {
                                        Console.WriteLine(@"
        1-update
        2-delete
        3-get By Id
        4-get all");
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
                                                }break;
                                            case "3":
                                                {

                                                    Console.WriteLine("GetBY ID");
                                                    Console.Write("id: ");
                                                    long id = long.Parse(Console.ReadLine());
                                                    var result = await customerService.DeleteByIdAsync(id);
                                                    Console.WriteLine("successfully deleted ....");
                                                }
                                                break;
                                            case "4":
                                                {
                                                    var results = await customerService.GetAllAsync();
                                                    foreach ( var result in results)
                                                    {
                                                        Console.WriteLine(@$"--------------------------------------------------------------------------------------       
        {result.Id}
        {result.FirstName}
        {result.Lastname}
        {result.Email}
        {result.Password}
        {result.Address}
---------------------------------------------------------------------------------------------------");
                                                    }
                                                }break;
                                            default: Console.WriteLine("            not found command");
                                                break;
                                                    
                                        }

                                    }

                                }break;
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
                                Console.WriteLine("not found command ");break;

                        }
                    }
                    break;
                case "2":
                    {

                    }break;
                case "3":
                    {

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
