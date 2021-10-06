using System;


namespace UserInterface
{
    class Program
    {
        static void Main(string[] args)
        {
           bool repeat = true;
            while (repeat)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Lopez shopping center");
                string userChoice;
                Console.WriteLine("option 1: Do you want to enter the store");
                Console.WriteLine("option 2: Do you want to leave the store");
                userChoice=Console.ReadLine();
                switch(userChoice)
                {
                    case "1":
                    {
                        Console.WriteLine("Welcome we will begin shortly Please answer the following: Are you a New User or a Guest");
                        string accountconfirmation;
                        Console.WriteLine("press enter to continue");
                        accountconfirmation=Console.ReadLine();
                        
                        break;
                   
                   
                    }
                    case "2":
                    {
                        repeat=false;
                        Console.WriteLine("test 2");
                        Console.WriteLine("press enter to continue");
                        userChoice=Console.ReadLine();
                        break;
                    }

                    default:
                    {
                       Console.WriteLine("you have chose incorrectly, try again");
                        Console.WriteLine("press enter to continue");
                        userChoice=Console.ReadLine();
                        break; 
                    }
                    
                }
                Console.WriteLine("You Have Left the store");
        }
    }
}
}
