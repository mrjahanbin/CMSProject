﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMSProject.DomainClass.PageGroup
{
    public class PageGroup
    {

        public PageGroup()
        {

        }


        [Key]
        public int GroupID { get; set; }
        [Display(Name = "عنوان گروه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200)]
        public string GroupTitle { get; set; }



        public List<Page.Page> Pages { get; set; }
    }
}
