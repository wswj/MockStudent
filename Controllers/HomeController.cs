using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MockStudentManager.Models;
using MockStudentManager.ViewModels;

namespace MockStudentManager.Controllers
{
    
    public class HomeController : Controller
    {
        /// <summary>
        /// viewbag
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            ViewBag.PageTitle = "测试标题";

            return View();
        }
        /// <summary>
        /// 测试viewdata
        /// </summary>
        /// <returns></returns>
        public IActionResult TestViewData() {
            var model = new Student {Name="wswj",Major=Models.EnumTypes.MajorEnum.ComputerScience,Email="1360378350@qq.com" };
            ViewData["PageTitle"] = "测试ViewData";
            ViewData["student"] = model;
            return View();
        }
        /// <summary>
        /// 测试viewdata传递list
        /// </summary>
        /// <returns></returns>
        public IActionResult TestViewDataList() {
            var model1= new Student { Name = "wswj", Major = Models.EnumTypes.MajorEnum.ComputerScience, Email = "1360378350@qq.com" };
            var model2 = new Student { Name = "wswj1", Major = Models.EnumTypes.MajorEnum.ElectronicCommerce, Email = "13083275770@qq.com" };
            IEnumerable<Student> students = new List<Student> { model1,model2 };
            ViewData["students"] = students;
            return View();
        }
        /// <summary>
        /// 测试强类型页面
        /// </summary>
        /// <returns></returns>
        public IActionResult TestStrongModel() {
            var student = new Student {Name="wswj",Email="13603378350@qq.com",Major=Models.EnumTypes.MajorEnum.ElectronicCommerce };
            var model = new HomeDetailsViewModel {PageTitle="测试强类型页面",StudentInfo=student };
            return View(model);
        }

    }
}
