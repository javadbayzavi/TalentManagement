using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubAdministration.Models.ViewModels
{
    public class players_invoices
    {
        public player player { get; set; }
        public training_terms training_term { get; set; }

        public double invoice_balance { get; set; }
        public System.Double overallcost { get; set; }

        public int overallpayments { get; set; }
    }
}