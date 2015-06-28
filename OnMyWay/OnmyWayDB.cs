﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnMyWay.Data;

namespace OnMyWay
{
    class OnmyWayDB : DbContext
    {
        public DbSet<Dish> Dish { get; set; }
        public DbSet<Table> Table { get; set; }
        public DbSet<Waiter> Waiter { get; set; }
    }
}
