﻿using System;
using System.Collections.Generic;

namespace FinalExam.WebApi.Models
{
    public class InvoiceLine
    {
        public int InvoiceLineId { get; set; }
        public int InvoiceId { get; set; }
        public int TrackId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public virtual Invoice Invoice { get; set; }
        public virtual Track Track { get; set; }
    }
}
