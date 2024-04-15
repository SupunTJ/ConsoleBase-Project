using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBaseProject
{
    public class AsciText
    {
        public void DisplayTitle()
        {
            Console.ForegroundColor= ConsoleColor.DarkGreen;
            string title = @"
 
                    
                         ____      ____ ________ _____      ______   ___  ____    ____ ________  
                        |_  _|    |_  _|_   __  |_   _|   .' ___  |.'   `|_   \  /   _|_   __  | 
                          \ \  /\  / /   | |_ \_| | |    / .'   \_/  .-.  \|   \/   |   | |_ \_| 
                           \ \/  \/ /    |  _| _  | |   _| |      | |   | || |\  /| |   |  _| _  
                            \  /\  /    _| |__/ |_| |__/ \ `.___.'\  `-'  _| |_\/_| |_ _| |__/ | 
                             \/  \/    |________|________|`.____ .'`.___.|_____||_____|________| 
                                                                         

             
               __ ___     _   _     ___                        __  _       _     ___    __     __ ___ _        
              (_   | | | | \ |_ |\ | |    |\/|  /\  |\ |  /\  /__ |_ |\/| |_ |\ | |    (_ \_/ (_   | |_ |\/|   
              __)  | |_| |_/ |_ | \| |    |  | /--\ | \| /--\ \_| |_ |  | |_ | \| |    __) |  __)  | |_ |  |   
            ==================================================================================================                                                                                      

                                    +-+-+-+-+-+-+-+ +-+-+ +-+-+-+-+-+-+-+-+-+-+-+
                                    |F|A|C|U|L|T|Y| |O|F| |E|N|G|I|N|E|E|R|I|N|G|
                                    +-+-+-+-+-+-+-+ +-+-+ +-+-+-+-+-+-+-+-+-+-+-+
                                                                                      
";
            Console.WriteLine(title);
            Console.WriteLine("Press any Key to Continue");
            Console.ReadKey();
        }
    }
}
