using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programm.Model
{
    public static class AppData
    {
        public static samoylenkoBDEntities db = new samoylenkoBDEntities();
        public static User currentUser;
    }
}
