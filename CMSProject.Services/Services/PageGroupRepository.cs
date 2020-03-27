using CMSProject.DataLayer.Context;
using CMSProject.DomainClass.PageGroup;
using CMSProject.Services.Repositores;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMSProject.Services.Services
{
    public class PageGroupRepository : IPageGroupRepository
    {


        CMSProjectDbContext _db;

        public PageGroupRepository(CMSProjectDbContext db)
        {
            _db = db;
        }

        public void DeletePageGroup(int GroupID)
        {
            var group = GetPageGroupById(GroupID);
            DeletePageGroup(group);
        }

        public void DeletePageGroup(PageGroup pageGroup)
        {
            _db.Entry(pageGroup).State = EntityState.Deleted;
        }

        public List<PageGroup> GetAllPageGroup()
        {
            return _db.PageGroups.ToList();
        }

        public PageGroup GetPageGroupById(int GroupID)
        {
            //NoOOOO Check Null or Empty Here
            return _db.PageGroups.Find(GroupID);
        }

        public void InsertPageGroup(PageGroup pageGroup)
        {
            _db.PageGroups.Add(pageGroup);
        }

        public bool PageGroupExists(int GroupID)
        {
            return _db.PageGroups.Any(p => p.GroupID == GroupID);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void UpdatePageGroup(PageGroup pageGroup)
        {
            _db.Entry(pageGroup).State = EntityState.Modified;
        }
    }
}
