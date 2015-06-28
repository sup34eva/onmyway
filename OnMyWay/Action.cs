using System;
using OnMyWay.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMyWay
{
    class Action
    {
        //Dishes
        public OnMyWayDB db = new OnMyWayDB();
        public void AddDish(string name, int price)
        {
            Dish d = new Dish(name, price);

            db.Dish.Add(d);
            db.SaveChanges();
        }
        public void RemoveDish(int id)
        {
            db.Dish.Remove(db.Dish.First(di => di.id == id));
            db.SaveChanges();
        }
        public void UpdateDish(int id, string name, int price)
        {
            Dish d = db.Dish.First(di => di.id == id);
            d.name = name;
            d.price = price;
            db.SaveChanges();
        }
        //Waiters
        public void AddWaiter(string firstName, string lastName, bool occupied)
        {
            Waiter w = new Waiter(firstName, lastName, occupied);

            db.Dish.Add(w);
            db.SaveChanges();
        }
        public void RemoveWaiter(int id)
        {
            db.Waiter.Remove(db.Waiter.First(wa => wa.id == id));
            db.SaveChanges();
        }
        public void UpdateWaiter(int id, string firstName, string lastName, bool occupied)
        {
            Waiter w = db.Waiter.First(wa => wa.id == id);
            w.firstName = firstName;
            w.lastName = lastName;
            w.occupied = occupied;
            db.SaveChanges();
        }
        //Tables
        public void AddTable(int places, int posX, int posY)
        {
            Table t = new Table(places, posX, posY);

            db.Table.Add(t);
            db.SaveChanges();
        }
        public void RemoveTable(int id)
        {
            db.Table.Remove(db.Table.First(ta => ta.id == id));
            db.SaveChanges();
        }
        public void UpdateTable(int id, int places, int posX, int posY)
        {
            Table t = db.Table.First(ta => ta.id == id);
            t.places = places;
            t.posX = posX;
            t.posY = posY;
            db.SaveChanges();
        }
    }
}
