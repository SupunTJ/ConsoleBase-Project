using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBaseProject
{
    public class SubMenu
    {
        public int collumPosition { get; set; }
        public int rowPosition { get; set; }
        public int itemSelect { get; set; }
        public int userCounter { get; set; }

        public List<SubMenuItems> subMenuItems { get; set; }
        public List<Module> Modules { get; set; }


        public SubMenu()
        {

            collumPosition = 50;
            rowPosition = 10;
            itemSelect = 0;
            

            subMenuItems = new List<SubMenuItems> {

                new SubMenuItems(" Modify User",true),
                new SubMenuItems(" Add  Modules", false),
                new SubMenuItems("Display Modules", false),
                new SubMenuItems("Remove Modules", false),
                new SubMenuItems(" Delete User", false),
                new SubMenuItems("    Back", false)
            };
            Modules = new List<Module>();
        }


        
        public void displaySubMenu(User user,List<User> Users)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.CursorVisible = false; 
            bool running = true;

            while (running)
            {
                Console.SetCursorPosition(collumPosition, rowPosition);

                for (int i = 0; i < subMenuItems.Count; i++)
                {
                    Console.SetCursorPosition(collumPosition, rowPosition + i);
                    
                    if (subMenuItems[i].subIsSelected)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        
                        Console.Write(subMenuItems[i].subTitle);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(subMenuItems[i].subTitle);

                    }
                }
                
                var key = Console.ReadKey(); 

                if (key.Key == ConsoleKey.DownArrow)
                {
                    subMenuItems[itemSelect].subIsSelected = false;
                    itemSelect = (itemSelect + 1) % subMenuItems.Count;
                    subMenuItems[itemSelect].subIsSelected = true;
                    
                }
                if (key.Key == ConsoleKey.UpArrow)
                {
                    subMenuItems[itemSelect].subIsSelected = false;
                    itemSelect = (itemSelect - 1);
                    if (itemSelect < 0)
                    {
                        itemSelect = subMenuItems.Count - 1;
                    }
                    subMenuItems[itemSelect].subIsSelected = true;
                }

                if(key.Key == ConsoleKey.Enter)
                {
                    if (subMenuItems[itemSelect].subTitle == " Modify User")
                    {
                        try
                        {
                            Console.Clear();
                            Console.WriteLine("For the cofirmation");
                            Console.WriteLine("Enter the User ID Again : ");
                            int userid = Convert.ToInt32(Console.ReadLine());

                            User selectedUser = Users.Find(u => u.UserID == userid);

                            if (selectedUser != null)
                            {
                                Console.WriteLine("Enter the new First Name: ");
                                selectedUser.FirstName = Console.ReadLine();
                                Console.WriteLine("Enter the new Last Name: ");
                                selectedUser.LastName = Console.ReadLine();
                                Console.WriteLine("Enter the new Date of Birth: ");
                                selectedUser.DateOfBirth = Console.ReadLine();
                                Console.WriteLine("Enter the new Address: ");
                                selectedUser.Address = Console.ReadLine();
                                Console.WriteLine("User has been modified successfully!");
                            }
                            else
                            {
                                Console.WriteLine("User not found.");

                            }
                            Console.WriteLine("\nPress any key to return to the main menu");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        catch(Exception ex)
                        {
                            
                            Console.WriteLine("Invalid input format. ");

                            Console.ReadLine();
                            Console.Clear();

                        }
                    }
                    if (subMenuItems[itemSelect].subTitle == " Add  Modules")
                    {
                        
                        Console.Clear();
                        Console.WriteLine();

                        Console.WriteLine("\tEE3301 Analog Electronics\n\tEE3305 Signals And Systems\n\tEE3302 Data Structures\n\tEE3250 GUI Programming\n\tEE3203 Measurement\n\tEE3251 Programing Project");

                        Console.WriteLine();

                        Console.WriteLine("Enter the Module Name: ");
                        string moduleName = Console.ReadLine();

                        Console.WriteLine("Enter the Module ID (EEXXXX): ");
                        string moduleID = Console.ReadLine();
                        string grade;
                        try
                        {
                            Console.WriteLine("Enter the Grade(A / B / C / E): ");
                            grade = Console.ReadLine();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Input (A / B / C / E) ");
                            continue;
                        }
                        int creditvalue;
                        try
                        {
                            Console.WriteLine("Enter the Credit Value: ");
                            creditvalue = Convert.ToInt32(Console.ReadLine());
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine("Input an integer");
                            Console.Clear();
                            continue;
                        }

                        Console.WriteLine("Module Added");

                        double gradePoint = 0;
                        if (grade == "A")
                        {
                            gradePoint = 4;
                        }
                        else if (grade == "B")
                        {
                            gradePoint = 3;
                        }
                        else if (grade == "C")
                        {
                            gradePoint = 2;
                        }
                        else if (grade == "E")
                        {
                            gradePoint = 0;
                        }


                        Module newmodule = new Module(moduleID, moduleName, grade, creditvalue, gradePoint);
                        user.Modules.Add(newmodule);
                        Console.Clear();
                        
                                            
                    }

                    if (subMenuItems[itemSelect].subTitle == "Display Modules")
                    {
                        try
                        {
                            Console.Clear();
                            Console.WriteLine("Module ID".PadRight(15) + "Module Name".PadRight(25) + "Grade".PadRight(15) + "Credit Value".PadRight(10));
                            Console.WriteLine("---------------------------------------------------------------------------------------");
                            foreach (Module module in user.Modules)
                            {
                                Console.WriteLine(module.ModuleID.ToString().PadRight(15) + module.ModuleName.PadRight(27) + module.Grade.PadRight(18) + module.CreditValue.ToString().PadRight(10));
                            }
                            Console.WriteLine("\nPress any key to return to the main menu");
                            Console.ReadLine();
                            Console.Clear();

                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine("Invalid input format.");
                        }
                    }

                    if (subMenuItems[itemSelect].subTitle == "Remove Modules")
                    {
                        try
                        {
                            Console.Clear();
                            Console.WriteLine("Enter the module code, you want to delete: ");
                            string moduleid = Console.ReadLine();
                            Module modulesToDelete = user.Modules.FirstOrDefault(module => module.ModuleID == moduleid);
                            if (modulesToDelete != null)
                            {
                                user.Modules.Remove(modulesToDelete);
                                Console.Clear();
                                Console.WriteLine(" Module has been successfully Removed. ");
                                Console.WriteLine("\n Press any key to return Back");
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("No module found with the given ID.");

                            }
                            Console.WriteLine("\nPress any key to go back");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine("Invalid input format.");
                        }
                    }
                    
                    if(subMenuItems[itemSelect].subTitle == " Delete User")
                    {
                        try
                        {
                            Console.Clear();
                            Console.WriteLine("Are you sure you want to delete!");
                            Users.Remove(user);
                            Console.WriteLine("\nPress any key to continue");
                            Console.ReadLine();
                            running= false;
                            Console.Clear();
                        }
                        catch
                        {
                            Console.WriteLine("Invalid input format.");
                        }
                    }
                    
                    if(subMenuItems[itemSelect].subTitle == "    Back")
                    {
                        Console.WriteLine("going back");
                        Console.Clear();
                        running = false;
                    }
                }


            }
        }
    }
}
