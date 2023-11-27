
using System;
using System.IO;

Console.WriteLine("Hello, World!");


//Directory.CreateDirectory(@"C:\Register");
Console.WriteLine("A Directory Created Succesfully....");

var path = @"C:\Register\reg.txt";

//using (File.Create(path))

{
    Console.WriteLine("File Added Successfully....");
}


Console.WriteLine("Enter your username");
string userName = Console.ReadLine();

Console.WriteLine("Enter your Password");
string password = Console.ReadLine();


File.AppendAllText(path, userName);
File.AppendAllText(path, " ");
File.AppendAllText(path, password + Environment.NewLine);


Console.WriteLine("User Registered successfully..");

var details = File.ReadAllText(path);

Console.WriteLine("User details");

Console.WriteLine(details);


Directory.CreateDirectory(@"C:\Login");
Console.WriteLine("A Directory Created Succesfully....");

var path2 = @"C:\Login\log.txt";

using (File.Create(path2))

{
    Console.WriteLine("File Added Successfully....");
}


Console.WriteLine("enter your username");
string userName2 = Console.ReadLine();

Console.WriteLine("Enter your Password");
string password2 = Console.ReadLine();



File.AppendAllText(path2, userName2);
File.AppendAllText(path2, " ");
File.AppendAllText(path2, password2 + Environment.NewLine);


var details2lines = File.ReadAllLines(path2);

Console.WriteLine("User details two");


foreach (var line in details2lines)
{
    var line_split = line.Split(" ");
    if (line_split[0] == userName2 && line_split[1] == password2)
    {
        Console.WriteLine($"Welcome {userName2}");
        break;
    }
    else { Console.WriteLine("incorrect"); }


}



//register register = new register();
//register.reg();









