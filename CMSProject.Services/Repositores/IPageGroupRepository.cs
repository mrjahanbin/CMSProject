using CMSProject.DomainClass.PageGroup;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMSProject.Services.Repositores
{
    public interface IPageGroupRepository
    {
        List<PageGroup> GetAllPageGroup();
        PageGroup GetPageGroupById(int GroupID);
        void InsertPageGroup(PageGroup pageGroup);
        void UpdatePageGroup(PageGroup pageGroup);
        void DeletePageGroup(int GroupID);
        void DeletePageGroup(PageGroup pageGroup);
        bool PageGroupExists(int GroupID);
        void Save();
    }
}
