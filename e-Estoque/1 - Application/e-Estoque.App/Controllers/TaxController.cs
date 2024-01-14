using AutoMapper;
using ClosedXML.Excel;
using ClosedXML.Extensions;
using e_Estoque.App.ViewModels.Category;
using e_Estoque.App.ViewModels.Tax;
using e_Estoque.CrossCutting.Notifications;
using e_Estoque.Domain.Entities;
using e_Estoque.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Serilog;
using System.Data;

namespace e_Estoque.App.Controllers
{
    [Authorize]
    public class TaxController : BaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly ITaxService _taxService;

        public TaxController(
            INotifier notifier,
            IMapper mapper,
            ICategoryService categoryService,
            ITaxService taxService) : base(notifier, mapper)
        {
            _categoryService = categoryService;
            _taxService = taxService;
        }

        // GET: TaxController
        public async Task<IActionResult> Index()
        {
            var list = await _taxService.GetAll();
            return View(_mapper.Map<IEnumerable<TaxViewModel>>(list));
        }

        // GET: TaxController/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = _mapper.Map<IEnumerable<CategoryViewModel>>(await _categoryService.GetAll())
                .Select(c => new SelectListItem()
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                })
                .ToList();

            return View(new TaxCreatedViewModel());
        }

        // POST: TaxController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TaxCreatedViewModel viewModel)
        {
            try
            {
                var entity = _mapper.Map<Tax>(viewModel);
                await _taxService.Create(entity);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);

                return View();
            }
        }

        // GET: TaxController/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            ViewBag.Categories = _mapper.Map<IEnumerable<CategoryViewModel>>(await _categoryService.GetAll())
                .Select(c => new SelectListItem()
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                })
                .ToList();

            var entity = await _taxService.GetById(id);

            return View(_mapper.Map<TaxViewModel>(entity));
        }

        // POST: TaxController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, TaxViewModel viewModel)
        {
            try
            {
                var entity = _mapper.Map<Tax>(viewModel);
                await _taxService.Update(id, entity);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);

                return View();
            }
        }

        // GET: TaxController/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var entity = await _taxService.GetById(id);

            return View(_mapper.Map<TaxViewModel>(entity));
        }

        // POST: TaxController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, TaxViewModel viewModel)
        {
            try
            {
                var entity = _mapper.Map<Tax>(viewModel);
                await _taxService.Remove(id, entity);

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
            var list = await _taxService.GetAll();

            var wb = new XLWorkbook();
            wb.Worksheets.Add(GetDataTable(list.ToList()));

            return wb.Deliver($"taxs-{DateTime.Now.ToString()}.xlsx");
        }

        public DataTable GetDataTable(List<Tax> taxs)
        {
            DataTable dataTable = new DataTable("Categories");
            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Description");
            dataTable.Columns.Add("Percentage");
            dataTable.Columns.Add("IdCategory");
            dataTable.Columns.Add("Category Name");
            dataTable.Columns.Add("CreatedAt");
            dataTable.Columns.Add("UpdatedAt");
            dataTable.Columns.Add("DeletedAt");

            foreach (var tax in taxs)
            {
                var row = dataTable.NewRow();
                row["Id"] = tax.Id;
                row["Name"] = tax.Name;
                row["Description"] = tax.Description;
                row["Percentage"] = tax.Percentage;
                row["IdCategory"] = tax.IdCategory;
                row["Category Name"] = tax.Category.Name;
                row["CreatedAt"] = tax.CreatedAt;
                row["UpdatedAt"] = tax.UpdatedAt;
                row["DeletedAt"] = tax.DeletedAt;

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }
}