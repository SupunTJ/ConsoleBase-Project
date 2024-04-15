using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBaseProject
{
    public class SubMenuItems
    {
        public string subTitle { get; set; }
        public bool subIsSelected { get; set; }


        public SubMenuItems(string subtitle, bool subisSelected)
        {
            subTitle = subtitle;
            subIsSelected = subisSelected;
        }
    }
}
