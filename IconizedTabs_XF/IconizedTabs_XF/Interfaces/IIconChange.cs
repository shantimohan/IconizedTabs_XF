using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IconizedTabs_XF.Interfaces
{
    public interface IIconChange
    {
        bool IsSelected { get; set; }
        string CurrentIcon { get; }
    }
}
