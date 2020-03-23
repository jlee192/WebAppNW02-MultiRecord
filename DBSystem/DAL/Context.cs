using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity; //inheritance of DbContext from EntityFramework
using DBSystem.ENTITIES;

namespace DBSystem.DAL
{
    internal class Context : DbContext
    {
        public Context() : base("FSIS_db")
        {

        }
        public DbSet<Entity01> Entity01s { get; set; }
        public DbSet<Entity02> Entity02s { get; set; }
        public DbSet<Entity03> Entity03s { get; set; }
    }
}
