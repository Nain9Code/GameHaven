using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameHaven.Models;

namespace GameHaven.Session
{
    public static class UserSession
    {
        public static Users CurrentUser { get; set; }
    }
}
