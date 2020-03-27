using CMSProject.DataLayer.Context;
using CMSProject.DomainClass.Page;
using CMSProject.Services.Repositores;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMSProject.Services.Services
{
    public class PageRepository : IPageRepository
    {

        CMSProjectDbContext _db;

        public PageRepository(CMSProjectDbContext db)
        {
            _db = db;
        }

        public void DeletePage(Page page)
        {
            _db.Entry(page).State = EntityState.Deleted;
        }

        public void DeletePage(int pageId)
        {
            var page = GetPageById(pageId);
            DeletePage(page);
        }

        public IEnumerable<Page> GetAllPage()
        {
            return _db.Pages.ToList();
        }

        public Page GetPageById(int pageId)
        {
            return _db.Pages.Find(pageId);
        }

        public void InsertPage(Page page)
        {
            _db.Pages.Add(page);
        }

        public bool PageExists(int pageId)
        {
            return _db.Pages.Any(p => p.PageID == pageId);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void UpdatePage(Page page)
        {
            _db.Entry(page).State = EntityState.Modified;
        }
    }
}
