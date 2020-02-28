using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Helper;
using WebApplication1.Models;

namespace WebApplication1.Controllers.Pages
{
    public class UserController : Controller
    {

        private string _conString;
        IUserRepository _userRepository;
        public UserController()
        {
            _userRepository = new UserRepository(ConfigurationHelper.getConnectionString());
        }

        // GET: User
        public ActionResult Index()
        {

            var users = _userRepository.GetUsers();
            var usersList = users.Select(s => new UserViewModel
            {
                Id = s.Id,
                UserName = s.UserName,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Password = s.Password,
                IsActive = s.IsActive
            });
            return View(usersList);
        }
        
        public ActionResult Create()
        {
            
                return View(new UserViewModel());
           
        }
        

        [HttpPost]
        public ActionResult Create(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                _userRepository.SaveUser(new Entities.User { UserName = model.UserName, Password = model.Password, FirstName = model.FirstName, LastName = model.LastName, IsActive = model.IsActive });
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Create");
            }
        }


        public ActionResult Edit(int id)
        {
            var users = _userRepository.GetUser(id);
            return View(new UserViewModel
            {
                Id = users.Id,
                UserName = users.UserName,
                FirstName = users.FirstName,
                LastName = users.LastName,
                Password = users.Password,
                IsActive = users.IsActive
            });
        }

        
        [HttpPost]
        public ActionResult Edit(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                _userRepository.SaveUser(new Entities.User { Id = model.Id, UserName = model.UserName, Password = model.Password, FirstName = model.FirstName, LastName = model.LastName, IsActive = model.IsActive });
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Edit");
            }
        }
        
    }
}