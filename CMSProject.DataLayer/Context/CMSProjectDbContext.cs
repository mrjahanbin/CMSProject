using CMSProject.DomainClass.Page;
using CMSProject.DomainClass.PageGroup;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMSProject.DataLayer.Context
{
   public class CMSProjectDbContext:DbContext
    {

        public CMSProjectDbContext(DbContextOptions<CMSProjectDbContext> options):base(options)
        {

        }

        public DbSet<PageGroup> PageGroups { get; set; }
        public DbSet<Page> Pages { get; set; }
    }
}
