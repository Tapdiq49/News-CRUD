using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp2.Data;
using WebApp2.Data.Entities;
using WebApp2.Models.News;

namespace WebApp2.Controllers
{
    public class NewsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public NewsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<News> news = _context.news.ToList();

            return View(news);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([FromForm] CreateNewsViewModel model)
        {
            if (ModelState.IsValid)
            {
                News news = new News
                {
                    Title = model.Title,
                    Body = model.Body,
                    datetime = model.dateTime
                };
                _context.news.Add(news);
                _context.SaveChanges();

                return RedirectToAction("index");
            }


            return View(model);
        }
        public IActionResult Delete([FromRoute] int id)
        {
            News news = _context.news.FirstOrDefault(s => s.Id == id);

            if (news == null) return NotFound();

            _context.news.Remove(news);

            _context.SaveChanges();

            return RedirectToAction("index");
        }
        public IActionResult Edit([FromRoute] int id)
        {
            News news = _context.news.FirstOrDefault(s => s.Id == id);
            if (news == null) return NotFound();

            CreateNewsViewModel model = new CreateNewsViewModel
            {
                Title = news.Title,
                Body = news.Body,
                dateTime = news.datetime
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int id, [FromForm] CreateNewsViewModel model)
        {
            News news = _context.news.FirstOrDefault(s => s.Id == id);
            if (news == null) return NotFound();
            news.Title = model.Title;
            news.Body = model.Body;
            news.datetime = model.dateTime;
            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}
