using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Nyhetsapp.Controllers
{
    [Route("news")]
    public class NewsController : Controller
    {
        private INewsRepository _newsRepository;

        public NewsController(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        [HttpPost("add")]
        public IActionResult Add(News news)
        {
            if (news == null)
            {
                return BadRequest("News is null");
            }

            news.CreatedDate = DateTime.Now;
            news.UpdatedDate = DateTime.Now;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _newsRepository.Add(news);

            return Ok(news.Id);
        }

        [HttpGet("count")]
        public IActionResult Count()
        {
            int numberOfNews = _newsRepository.Count();
            return Ok(numberOfNews);
        }


    }
}
