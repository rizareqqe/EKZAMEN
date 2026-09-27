using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1
{
    public static class AppState
    {
        public static WpfApp1.Models.User? CurrentUser { get; set; }
    }
}
