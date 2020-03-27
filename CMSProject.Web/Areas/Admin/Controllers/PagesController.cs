using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CMSProject.DataLayer.Context;
using CMSProject.DomainClass.Page;
using Microsoft.AspNetCore.Http;
using System.IO;
using CMSProject.Services.Services;
using CMSProject.Services.Repositores;

namespace CMSProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PagesController : Controller
    {
        private IPageRepository _pageRepository;
        IPageGroupRepository _pageGroupRepository;

        public PagesController(IPageRepository pageRepository, IPageGroupRepository pageGroupRepository)
        {
            _pageRepository = pageRepository;
            _pageGroupRepository = pageGroupRepository;
        }






        // GET: Admin/Pages
        public async Task<IActionResult> Index()
        {
            return View(_pageRepository.GetAllPage());
        }

        // GET: Admin/Pages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var page = _pageRepository.GetPageById(id.Value);
            if (page == null)
            {
                return NotFound();
            }

            return View(page);
        }

        // GET: Admin/Pages/Create
        public IActionResult Create()
        {
            ViewData["GroupID"] = new SelectList(_pageGroupRepository.GetAllPageGroup(), "GroupID", "GroupTitle");
            return View();
        }

        // POST: Admin/Pages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PageID,PageTitle,ShortDescription,PageText,PageVisit,ImageName,PageTags,ShowInSlider,CreateDate,GroupID")] Page page, IFormFile imgup)
        {
            if (ModelState.IsValid)
            {

                page.PageVisit = 0;
                page.CreateDate = DateTime.Now;


                if (imgup != null)
                {
                    page.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(imgup.FileName);
                    string savePath = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/pageImages", page.ImageName
                        );

                    using (var stream = new FileStream(savePath, FileMode.Create))
                    {
                        imgup.CopyToAsync(stream);
                    }

                }

                _pageRepository.InsertPage(page);
                _pageRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupID"] = new SelectList(_pageGroupRepository.GetAllPageGroup(), "GroupID", "GroupTitle");
            return View(page);
        }

        // GET: Admin/Pages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var page = _pageRepository.GetPageById(id.Value);
            if (page == null)
            {
                return NotFound();
            }
            ViewData["GroupID"] = new SelectList(_pageGroupRepository.GetAllPageGroup(), "GroupID", "GroupTitle");
            return View(page);
        }

        // POST: Admin/Pages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PageID,PageTitle,ShortDescription,PageText,PageVisit,ImageName,PageTags,ShowInSlider,CreateDate,GroupID")] Page page, IFormFile imgup)
        {
            if (id != page.PageID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {



                    if (imgup != null)
                    {


                        if (page.ImageName == null)
                        {
                            page.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(imgup.FileName);

                        }

                        string savePath = Path.Combine(
                            Directory.GetCurrentDirectory(), "wwwroot/pageImages", page.ImageName
                            );

                        using (var stream = new FileStream(savePath, FileMode.Create))
                        {
                            imgup.CopyToAsync(stream);
                        }

                    }

                    _pageRepository.UpdatePage(page);
                    _pageRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PageExists(page.PageID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupID"] = new SelectList(_pageGroupRepository.GetAllPageGroup(), "GroupID", "GroupTitle");

            return View(page);
        }

        // GET: Admin/Pages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var page = _pageRepository.GetPageById(id.Value);
            if (page == null)
            {
                return NotFound();
            }

            return View(page);
        }

        // POST: Admin/Pages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _pageRepository.DeletePage(id);
            _pageRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool PageExists(int id)
        {
            return _pageRepository.PageExists(id);
        }
    }
}
