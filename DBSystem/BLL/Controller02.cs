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
    public class Controller02 // Players
    {
        public Entity02 FindByPKID(int id)
        {
            using (var context = new Context())
            {
                return context.Entity02s.Find(id);
            }
        }
        public List<Entity02> List()
        {
            using (var context = new Context())
            {
                return context.Entity02s.ToList();
            }
        }
        public List<Entity02> FindByID(int id)
        {
            using (var context = new Context())
            {
                IEnumerable<Entity02> results =
                    context.Database.SqlQuery<Entity02>("Player_GetByTeam @ID"
                        , new SqlParameter("ID", id));
                return results.ToList();
            }
        }
        //public List<Entity02> FindByPartialName(string partialname)
        //{
        //    using (var context = new Context())
        //    {
        //        IEnumerable<Entity02> results =
        //            context.Database.SqlQuery<Entity02>("Products_GetByPartialProductName @PartialName",
        //                 new SqlParameter("PartialName", partialname));
        //        return results.ToList();
        //    }
        //}
        public int Add(Entity02 item)
        {
            using (var context = new Context())
            {
                context.Entity02s.Add(item);
                context.SaveChanges();
                return item.PlayerID;
            }
        }
        public int Update(Entity02 item)
        {
            using (var context = new Context())
            {
                context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                return context.SaveChanges();
            }
        }
        //public int Discontinue(int productid)
        //{
        //    using (var context = new Context())
        //    {
        //        var existing = context.Entity02s.Find(productid);
        //        existing.Discontinued = true;
        //        context.Entry(existing).State = System.Data.Entity.EntityState.Modified;
        //        return context.SaveChanges();
        //    }
        //}
        public int Delete(int productid)
        {
            using (var context = new Context())
            {
                var existing = context.Entity02s.Find(productid);
                if (existing == null)
                {
                    throw new Exception("Record has been remove from database");
                }
                context.Entity02s.Remove(existing);
                return context.SaveChanges();
            }
        }
    }
}
