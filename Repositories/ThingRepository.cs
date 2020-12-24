using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheWayShop.DB;
using TheWayShop.Interfaces;
using TheWayShop_2._0.Models;

namespace TheWayShop_2._0.Repositories
{
    public class ThingRepository : IAllThings<Thing>
    {
        private readonly AppDbContext context;
        private readonly DbSet<Thing> things;

        public ThingRepository(AppDbContext context,DbSet<Thing> things)
        {
            this.context = context;
            this.things = this.context.Thing;
        }

        public IEnumerable<Thing> Things => throw new NotImplementedException();

        public void Create(Thing entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Thing entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Thing getObjectThing(int thingId)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Thing entity)
        {
            throw new NotImplementedException();
        }
    }
}
