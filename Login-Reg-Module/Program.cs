
using System;
using System.IO;
using System.Security.Claims;

//Console.Clear();
Console.WriteLine("Choose an option:");
Console.WriteLine("1) Register");
Console.WriteLine("2) Login");
Console.WriteLine("3) Admin Login");
Console.Write("\r\nSelect an option: ");

switch (Console.ReadLine())
{
    case "1":
        Console.WriteLine("Hello, World!");

        //Directory.CreateDirectory(@"C:\Register");
        Console.WriteLine("A Directory Created Succesfully....");
        var path = @"C:\Register\reg.txt";
        //using (File.Create(path))

        Console.WriteLine("File Added Successfully....");

        Console.WriteLine("Enter your username");
        string userName = Console.ReadLine();

        Console.WriteLine("Enter your Password");
        string password = Console.ReadLine();

        string[] lines = File.ReadAllLines(path);

        // Geting the number of lines
        int numberOfLines = lines.Length;
        var Id = numberOfLines;
        var inID = ++Id;
        var strID = inID.ToString();

        File.AppendAllText(path, strID);
        File.AppendAllText(path, " ");
        File.AppendAllText(path, userName);
        File.AppendAllText(path, " ");
        File.AppendAllText(path, password + Environment.NewLine);


        Console.WriteLine("User Registered successfully..");

        var details = File.ReadAllText(path);

        Console.WriteLine("User details");

        Console.WriteLine(details);

        return 0;


    case "2":
        var regPath = @"C:\Register\reg.txt";
        var logPath = @"C:\Register\log.txt";

        Console.WriteLine("User Login");

        Console.WriteLine("Enter your username");
        string userName2 = Console.ReadLine();

        Console.WriteLine("Enter your Password");
        string password2 = Console.ReadLine();

        bool loginSuccessful = false;

        // Check if the file exists
        if (File.Exists(regPath))
        {
            // Read all lines from the registration file
            string[] regDetails = File.ReadAllLines(regPath);

            // Iterate through each line and check if the credentials match
            foreach (var line in regDetails)
            {
                // Split the line into ID, NAME, and PASSWORD
                string[] parts = line.Split(' ');

                // Check if the parts match the search criteria
                if (parts.Length >= 3 && parts[1] == userName2 && parts[2] == password2)
                {
                    loginSuccessful = true;
                    break; // Credentials found, exit the loop
                }
            }
        }
       

        if (loginSuccessful)
        {
            // Append the login details to the log file
            File.AppendAllText(logPath, $"{userName2} {password2}{Environment.NewLine}");
            Console.WriteLine("User details found and logged in successfully.");

            var books = File.ReadAllText(@"C:\Register\book.txt");

            Console.WriteLine("books Available");

            Console.WriteLine(books);
        }
        else
        {
            Console.WriteLine("User details not found. Login failed.");
        }



        return 0;

    case "3":
        var path3 = @"C:\Register\admin.txt";
        var path4 = @"C:\Register\adminlogin.txt";

        using (File.Create(path4))

        Console.WriteLine("File Added Successfully....");

        Console.WriteLine("Enter your username");
        string userName3 = Console.ReadLine();

        Console.WriteLine("Enter your Password");
        string password3 = Console.ReadLine();


        File.AppendAllText(path4, " ");
        File.AppendAllText(path4, userName3);
        File.AppendAllText(path4, " ");
        File.AppendAllText(path4, password3 + Environment.NewLine);


        Console.WriteLine("Admin Registered successfully..");

        var details3 = File.ReadAllText(path3);
        var details4 = File.ReadAllText(path4);     
        

        Console.WriteLine("User details");

        Console.WriteLine(details3);
        Console.WriteLine(details4);

        if (details3 == details4)
        {
            Console.WriteLine("Admin logged in");
            //Directory.CreateDirectory(@"C:\Register");
            Console.WriteLine("A Directory Created Succesfully....");
            var path5 = @"C:\Register\book.txt";
            //using (File.Create(path5))

            Console.WriteLine("File Added Successfully....");

            Console.WriteLine("Enter Book Name");
            string bookName = Console.ReadLine();

            Console.WriteLine("Enter Book Description");
            string bookDesc = Console.ReadLine();

            string[] lines1 = File.ReadAllLines(path5);

            // Geting the number of lines
            int numberOfLines1 = lines1.Length;
            var bookID = numberOfLines1;
            var BInID = ++bookID;
            var strBID = BInID.ToString();

            File.AppendAllText(path5, strBID);
            File.AppendAllText(path5, " ");
            File.AppendAllText(path5, bookName);
            File.AppendAllText(path5, " - ");
            File.AppendAllText(path5, bookDesc + Environment.NewLine);


            Console.WriteLine("Book Added Successfully");

            var books = File.ReadAllText(path5);

            Console.WriteLine("books details");

            Console.WriteLine(books);

        }
        else
        {
            Console.WriteLine("incorrect details");
        }


        return 0;
    default:
        return 0;
}





//register register = new register();
//register.reg();









