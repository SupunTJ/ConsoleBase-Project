using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBaseProject
{
    public class menuItems
    {
        public string Title { get; set; }
        public bool IsSelected { get; set; }


        public menuItems(string title, bool isSelected)
        {
            Title = title;
            IsSelected = isSelected;
        }
       
    }
}
