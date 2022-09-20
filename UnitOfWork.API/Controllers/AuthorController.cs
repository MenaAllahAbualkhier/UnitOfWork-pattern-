using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitOfWork.BL.Interface;
using UnitOfWork.DAL.Entity;

namespace UnitOfWork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public AuthorController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("~/API/AddAuthor")]
        public IActionResult AddAuthor(string name)
        {
            var data = unitOfWork.Author.Add(new Author { Name = name });
            unitOfWork.Complete();
            return Ok(data);
            
        }

        [HttpPost]
        [Route("~/API/AddRanageAuthor")]
        public IActionResult AddAuthor(string[] name)
        {
            var data = new List<Author>();
            foreach (var item in name)
            {
               var x=new Author { Name = item };
                data.Add(x);
            }
            var model = unitOfWork.Author.AddRange(data);
            unitOfWork.Complete();
            return Ok(model);

        }


        [HttpGet]
        [Route("~/API/GetById/Id")]
        public IActionResult GetById(int Id)
        {
            return Ok(unitOfWork.Author.GetById(Id));
        }


        [HttpGet]
        [Route("~/API/GetAll")]
        public IActionResult GetAll()
        {
            return Ok(unitOfWork.Author.GetAll());
        }

        [HttpGet]
        [Route("~/API/Find/id")]
        public IActionResult Find(int id)
        {
            return Ok(unitOfWork.Author.Find(a=>a.Id==id,"Book"));
        }



        [HttpGet]
        [Route("~/API/FindAll")]
        public IActionResult FindAll(string name)
        {
            return Ok(unitOfWork.Author.FindAll(a => a.Name == name, "Book"));
        }


        [HttpPut]
        [Route("~/API/Edit")]
        public IActionResult Edit(int id,string name)
        {
            var update=unitOfWork.Author.Update(new Author {Id=id,Name=name });
            unitOfWork.Complete();
            return Ok(update);
        }


        [HttpDelete]
        [Route("~/API/Delete")]
        public IActionResult Delete(int id, string name)
        {
            unitOfWork.Author.Delete(new Author { Id = id, Name = name });
            unitOfWork.Complete();
            return Ok("Deleted");
        }



        [HttpGet]
        [Route("~/API/Count")]
        public IActionResult cont()
        {
            return Ok(unitOfWork.Author.Count(a=>a.Id>3));
        }



    }
}
