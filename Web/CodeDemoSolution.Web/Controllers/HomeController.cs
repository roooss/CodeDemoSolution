using CodeDemoSolution.BusinessLogic.Services;
using CodeDemoSolution.DataAccess.Interfaces.UnitOfWork;
using CodeDemoSolution.Model;
using CodeDemoSolution.Model.Enums;
using System.Web.Mvc;

namespace CodeDemoSolution.Web.Controllers
{
    public class HomeController : Controller
    {
        private ITodoUnitOfWork UnitOfWork { get; set; }

        public HomeController(ITodoUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        // GET: Home
        public ActionResult Index()
        {
            TodoList list = new TodoList();

            list.Title = "Test Two";
            list.Description = "Test Two Desc.";

            TodoListService service = new TodoListService(this.UnitOfWork);

            var result = service.CreateNewTodoList(list);

            string resultString = "Failed";

            switch(result)
            {
                case TodoListSaveResult.MissingDescription:
                    resultString = "Missing Description";
                    break;
                case TodoListSaveResult.MissingTitle:
                    resultString = "Missing Title";
                    break;
                case TodoListSaveResult.NoRecordToSave:
                    resultString = "No Record to save";
                    break;
                case TodoListSaveResult.OtherError:
                    resultString = "Other Error";
                    break;
                case TodoListSaveResult.Saved:
                    resultString = "Saved " + list.Id;
                    break;
            }

            ViewBag.ResultString = resultString;
            return View();
        }
    }
}