using AutoMapper;
using ClosedXML.Excel;
using ClosedXML.Extensions;
using e_Estoque.App.ViewModels.Category;
using e_Estoque.CrossCutting.Notifications;
using e_Estoque.Domain.Entities;
using e_Estoque.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Data;

namespace e_Estoque.App.Controllers
{
    [Authorize]
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(
            INotifier notifier,
            IMapper mapper,
            ICategoryService categoryService) : base(notifier, mapper)
        {
            _categoryService = categoryService;
        }

        // GET: CategoryController
        public async Task<IActionResult> Index()
        {
            var list = await _categoryService.GetAll();
            return View(_mapper.Map<IEnumerable<CategoryViewModel>>(list));
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreatedViewModel viewModel)
        {
            try
            {
                var entity = _mapper.Map<Category>(viewModel);
                await _categoryService.Create(entity);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);

                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var entity = await _categoryService.GetById(id);
            return View(_mapper.Map<CategoryViewModel>(entity));
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, CategoryViewModel viewModel)
        {
            try
            {
                var entity = _mapper.Map<Category>(viewModel);
                await _categoryService.Update(id, entity);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);

                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var entity = await _categoryService.GetById(id);
            return View(_mapper.Map<CategoryViewModel>(entity));
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, CategoryViewModel viewModel)
        {
            try
            {
                var entity = _mapper.Map<Category>(viewModel);
                await _categoryService.Remove(id, entity);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);

                return View();
            }
        }

        public async Task<IActionResult> Download()
        {
            var list = await _categoryService.GetAll();

            var wb = new XLWorkbook();
            wb.Worksheets.Add(GetDataTable(list.ToList()));

            return wb.Deliver("categories.xlsx");
        }

        public DataTable GetDataTable(List<Category> categories)
        {
            DataTable dataTable = new DataTable("Categories");
            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Description");
            dataTable.Columns.Add("ShortDescription");
            dataTable.Columns.Add("CreatedAt");
            dataTable.Columns.Add("UpdatedAt");
            dataTable.Columns.Add("DeletedAt");

            foreach (var category in categories)
            {
                var row = dataTable.NewRow();
                row["Id"] = category.Id;
                row["Name"] = category.Id;
                row["Description"] = category.Description;
                row["ShortDescription"] = category.ShortDescription;
                row["CreatedAt"] = category.CreatedAt;
                row["UpdatedAt"] = category.UpdatedAt;
                row["DeletedAt"] = category.DeletedAt;

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }
}
