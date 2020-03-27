using CMSProject.DomainClass.Page;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMSProject.Services.Repositores
{
    public interface IPageRepository
    {
        IEnumerable<Page> GetAllPage();

        Page GetPageById(int pageId);

        void InsertPage(Page page);
        void UpdatePage(Page page);
        void DeletePage(Page page);
        void DeletePage(int pageId);
        bool PageExists(int pageId);
        void Save();

    }
}
