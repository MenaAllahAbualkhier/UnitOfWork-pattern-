using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitOfWork.BL.Interface;
using UnitOfWork.DAL.Entity;

namespace UnitOfWork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public BookController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("~/API/AddBook")]
        public IActionResult AddBook(string name ,int authorId)
        {
           var data=unitOfWork.Book.Add(new Book { Name = name, AuthorId = authorId });
            unitOfWork.Complete();
            return Ok(data);
        }

        [HttpGet]
        [Route("~/API/test")]
        public IActionResult test()
        {
            return Ok(unitOfWork.Book.test());
        }


    }
}
