using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ProjectKapwa.Models
{
    public class Context : DbContext
    {
        public Context() : base("name=Context")
        {
        }

        public DbSet<xforms> xforms { get; set; }
        public DbSet<WorkAcceptance> WorkAcceptance { get; set; }
    }
}