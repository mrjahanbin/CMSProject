﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMSProject.DomainClass.Page
{
    public class Page
    {
        [Key]
        public int PageID { get; set; }

        [Display(Name = "عنوان صفحه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(400)]
        public string PageTitle { get; set; }

        [Display(Name = "توضیح مختصر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(400)]
        public string ShortDescription { get; set; }

        [Display(Name = "متن کامل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string PageText { get; set; }

        [Display(Name = "بازدید")]
        public int PageVisit { get; set; }

        [Display(Name = "تصویر")]
        public string ImageName { get; set; }

        [Display(Name = "کلمات کلیدی")]
        public string PageTags { get; set; }

        [Display(Name = "نمایش در اسلایدر")]
        public string ShowInSlider { get; set; }
        [Display(Name = "تاریخ")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "گروه خبر")]

        public int GroupId { get; set; }



        public virtual PageGroup.PageGroup PageGroup { get; set; }

        public Page()
        {
        }
    }
}
