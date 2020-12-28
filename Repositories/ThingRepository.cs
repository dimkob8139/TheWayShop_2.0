using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TheWayShop_2._0.DB;
using TheWayShop_2._0.Interfaces;
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

        public IEnumerable<Thing> Things => context.Thing.Include(c => c.category);

        public void Create(Thing entity)
        {
            context.Thing.Add(entity);
        }

        public void Delete(int id)
        {
            var thing = context.Thing.Find(id);
            Delete(thing);
        }

        public void Delete(Thing entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                context.Thing.Attach(entity);
            }
            context.Entry(entity).State = EntityState.Deleted;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Thing getObjectThing(int thingId)
        {
            return context.Thing.FirstOrDefault(p => p.id == thingId);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Thing entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
