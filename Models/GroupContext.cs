using System;
using Microsoft.EntityFrameworkCore;
using GroupData.Models;

namespace GroupData{

    public class GroupContext:DbContext{

        public GroupContext(DbContextOptions<GroupContext> options): base(options){}

        public DbSet<Product_Group> Product_Group{get;set;}
        public DbSet<Product_Info> Product_Info{get;set;}
    }
}