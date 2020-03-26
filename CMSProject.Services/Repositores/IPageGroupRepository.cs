using CMSProject.DomainClass.PageGroup;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMSProject.Services.Repositores
{
    public interface IPageGroupRepository
    {
        List<PageGroup> GellAppPageGroup();
        PageGroup GetPageGroupById(int groupId);
        void InsertPageGroup(PageGroup pageGroup);
        void UpdatePageGroup(PageGroup pageGroup);
        void DeletePageGroup(int GroupId);
        void DeletePageGroup(PageGroup pageGroup);
        void Save();
    }
}
