using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;



namespace ConsoleBaseProject
{
    public class myMenu
    {
        public int collumPosition { get; set; }
        public int rowPosition { get; set; }
        public int itemSelect { get; set; }
        public int userCounter { get; set; }

        public List<menuItems> MenuItems { get; set; }
        public List<User> Users { get; set; }


        public myMenu()
        {

            collumPosition = 50;
            rowPosition = 10;
            itemSelect = 0;
            userCounter = 3998;

            MenuItems = new List<menuItems> {

                new menuItems("    Add User",true),
                new menuItems("  Select  User", false),
                new menuItems("  Delete  User", false),
                new menuItems("Display All Users", false),
                new menuItems("      Quit", false)
            };

            Users = new List<User>();
        }



        public void displayMenu()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.CursorVisible = false; //visibility of cursor
            bool running = true;

            while (running)
            {
                

                Console.SetCursorPosition(collumPosition, rowPosition);

                for (int i = 0; i < MenuItems.Count; i++)
                {
                    Console.SetCursorPosition(collumPosition, rowPosition + i);
                    
                    if (MenuItems[i].IsSelected)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        
                        Console.Write(MenuItems[i].Title);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(MenuItems[i].Title);

                    }
                }

                var key = Console.ReadKey();

                    if (key.Key == ConsoleKey.DownArrow)
                    {
                        MenuItems[itemSelect].IsSelected = false;
                        itemSelect = (itemSelect + 1) % MenuItems.Count;
                        MenuItems[itemSelect].IsSelected = true;

                    }
                    if (key.Key == ConsoleKey.UpArrow)
                    {
                        MenuItems[itemSelect].IsSelected = false;
                        itemSelect = (itemSelect - 1);
                        if (itemSelect < 0)
                        {
                            itemSelect = MenuItems.Count - 1;
                        }
                        MenuItems[itemSelect].IsSelected = true;
                    }

                    if (key.Key == ConsoleKey.Enter)
                    {


                        if (MenuItems[itemSelect].Title == "    Add User")
                        {
                        try
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            int userID = userCounter++;
                            Console.WriteLine("\n\t\tYour User ID : EG/2020/" + userID);

                            Console.WriteLine("\n\nEnter the First Name: ");
                            string firstName = Console.ReadLine();

                            Console.WriteLine("Enter the Last Name: ");
                            string lastName = Console.ReadLine();

                            Console.WriteLine("Enter the Date of Birth: ");
                            string dateOfBirth = Console.ReadLine();

                            Console.WriteLine("Enter the Address: ");
                            string address = Console.ReadLine();

                            User newuser = new User(firstName, lastName, dateOfBirth, address, userID);
                            Users.Add(newuser);

                            Console.Clear();
                        }
                        catch
                        {
                            Console.WriteLine("Invalid Input");
                        }

                        }
                        if (MenuItems[itemSelect].Title == "  Select  User")
                        {
                        try
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Enter User ID (Last 4 Digits) : ");
                            int userID = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine($"You Selected User with ID : {userID}");
                            bool found = false;

                            if (Users.Count == null)
                            {
                                Console.Clear();
                                Console.WriteLine("User list is empty");
                                Console.ReadLine();
                                break;
                            }
                            else
                            {
                                foreach (User user in Users)
                                {
                                    if (user.UserID == userID)
                                    {
                                        Console.WriteLine("IS THIS THE USER : (y/n)");
                                        found = true;
                                        char c = Convert.ToChar(Console.ReadLine());
                                        if (c == 'y')
                                        {
                                            SubMenu submenu = new SubMenu();
                                            submenu.displaySubMenu(user, Users);
                                        }
                                        else
                                        {
                                            Console.WriteLine("User not selected");
                                            Console.ReadLine();
                                            Console.Clear();
                                            break;
                                        }
                                        break;
                                    }

                                }
                                if (found == false)
                                {

                                    Console.WriteLine("user not valid or user deleted");
                                    Console.ReadLine();
                                    Console.Clear();
                                }
                       
                            }
                        }
                        catch
                        {
                            
                            Console.WriteLine("Invalid input format. ");

                            Console.ReadLine();
                            Console.Clear();
                        }
                    }
                        if (MenuItems[itemSelect].Title == "  Delete  User")
                        {
                            try {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Enter the last 4 digits of your User ID the user you want to delete: ");
                                int useriD = Convert.ToInt32(Console.ReadLine());
                                User userToDelete = Users.FirstOrDefault(user => user.UserID == useriD);
                                if (userToDelete != null)
                                {
                                    Users.Remove(userToDelete);
                                    Console.Clear();
                                    Console.WriteLine(" User has been successfully deleted. ");
                                    Console.WriteLine("\n\n Press any key to return to main menu");
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("No user found with the given ID.");
                                }
                                Console.WriteLine("\nPress any key to return to the main menu");
                                Console.ReadLine();
                                Console.Clear();
                            }
                            catch
                            {
                                Console.WriteLine("Invalid Input\n");
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }

                        if (MenuItems[itemSelect].Title == "Display All Users")
                        {
                            try
                            {   
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("\t\t\t\t" + "ID".PadRight(10) + "First Name".PadRight(15) + "Last Name".PadRight(15) + "Date of Birth".PadRight(20) + "GPA".PadRight(10));
                                Console.WriteLine(" \t\t\t\t" + "----------------------------------------------------------------");
                                foreach (var user in Users)
                                {
                                    Console.WriteLine(" \t\t\t\t" + user.UserID.ToString().PadRight(10) + user.FirstName.PadRight(15) + user.LastName.PadRight(15) + user.DateOfBirth.PadRight(20) + user.GpaCalculation().ToString().PadRight(10));
                                }
                                Console.WriteLine("\nPress any key to return to the main menu");
                                Console.ReadLine();

                                Console.Clear();
                            }
                            catch
                            {
                                Console.WriteLine("Invalid Input");

                            }
                        }

                        if (MenuItems[itemSelect].Title == "      Quit")
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Clear();
                            running = false;
                        }
                    }
            }
        }
    }
}

