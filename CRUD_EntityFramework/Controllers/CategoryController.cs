using CRUD_EntityFramework.DataContext;
using CRUD_EntityFramework.Models;
using CRUD_EntityFramework.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_EntityFramework.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetAllCategory() {

            CategoryInfo model= new CategoryInfo();
           model.CategoryList=_context.categories.ToList();

            return Json(model);
        }

        [HttpPost]
        public IActionResult AddUpdateCategory(Category model)
        {
            CategoryInfo categoryInfo = new CategoryInfo();
            try
            {
                if(model==null)
                {
                    categoryInfo.ErrorMsg = "All Data are required";
                    
                }
                else
                {
                    if(model.Id==0) {
                        _context.Add(model);
                        categoryInfo.TotalRow = _context.SaveChanges();

                        categoryInfo.ErrorMsg = "Category Updated SuccessFully";

                    }
                    else
                    {
                        _context.Update(model);
                        categoryInfo.TotalRow = _context.SaveChanges();

                        categoryInfo.ErrorMsg = "Category Added SuccessFully";
                    }

                    
                    
                }
               
            }
            catch (Exception ex)
            {
                categoryInfo.ErrorMsg = ex.Message;
              
                throw;
            }
            return Json(categoryInfo);






        }

        public IActionResult GetUpdateDeatils(int id)
        {

            Category model = new Category();
            try
            {
              var   categoryData = _context.categories.FirstOrDefault(m => m.Id == id);
                if(categoryData==null)
                {
                    model.Id = 0;
                }
                else
                {
                    model = categoryData;
                }


            }
            catch (Exception)
            {

                throw;
            }
           

            return Json(model);
        }


        public IActionResult DeleteData(Category model)
        {
           

            
            _context.categories.Remove(model);
            _context.SaveChanges();
            
            
            return Json(model);



        }

    }
}
