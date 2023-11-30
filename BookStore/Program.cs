using BookStore.Controller;



BookController bookController = new BookController();
UserController userController = new UserController();

//await bookController.init();
Console.ForegroundColor = ConsoleColor.Green;
Console.Clear();
Console.WriteLine("***************************************");
Console.WriteLine("********WELCOME TO THE BOOKSTORE*******");
Console.WriteLine("***************************************");
Console.WriteLine("Choose an option:");
Console.WriteLine("1) Admin");
Console.WriteLine("2) User");
Console.WriteLine("3) Admin Login");
Console.Write("\r\nSelect an option: ");

switch (Console.ReadLine())
{
    case "1":
        Console.WriteLine("*****ADMIN LOGIN*****");
       if (Console.ReadLine() == "admin")
        {
            Console.WriteLine("***************************************");
            Console.WriteLine("********WELCOME BACK ADMIN ************");
            Console.WriteLine("***************************************");
            Console.WriteLine("");

            Console.WriteLine("Manage Books");
            await bookController.init();
        }
        else
        {
            Console.WriteLine("wrong details");

        }
        
        break;

    case "2":
        Console.WriteLine("Welcome user");
        await userController.init();

        break;


}