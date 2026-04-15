using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Context;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace FormsApp_CS2_Arbitrage_And_Investment_Tracker.Common
{
    public static class Common
    {
        public static CS2TrackerContext _context;
        static Common()
        {
            var connString = Program.Configuration.GetConnectionString("DefaultConnection");
            _context = new CS2TrackerContext(connString);
        }
    }
}
