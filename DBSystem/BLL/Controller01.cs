using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using DBSystem.DAL;
using DBSystem.ENTITIES;

namespace DBSystem.BLL
{
    public class Controller01 //Category
    {
        public List<Entity01> List()
        {
            using (var context = new Context())
            {
                return context.Entity01s.ToList();
            }
        }
        //public List<Entity01> TeamGet(int id)
        //{
        //    using (var context = new Context())
        //    {
        //        IEnumerable<Entity01> results =
        //            context.Database.SqlQuery<Entity01>("Team_Get @ID"
        //                , new SqlParameter("ID", id));
        //        return results.ToList();
        //    }
        //}
        public Entity01 TeamGet(int teamid)
        {
            using (var context = new Context())
            {
                return context.Entity01s.Find(teamid);
            }
        }
    }
}
