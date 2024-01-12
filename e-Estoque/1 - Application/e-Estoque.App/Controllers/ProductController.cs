using AutoMapper;
using ClosedXML.Excel;
using ClosedXML.Extensions;
using e_Estoque.App.ViewModels.Category;
using e_Estoque.App.ViewModels.Company;
using e_Estoque.App.ViewModels.Product;
using e_Estoque.CrossCutting.Notifications;
using e_Estoque.Domain.Entities;
using e_Estoque.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Serilog;
using System.Data;

namespace e_Estoque.App.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ICompanyService _companyService;

        public ProductController(
            INotifier notifier,
            IMapper mapper,
            IProductService productService,
            ICategoryService categoryService,
            ICompanyService companyService) : base(notifier, mapper)
        {
            _productService = productService;
            _categoryService = categoryService;
            _companyService = companyService;
        }

        // GET: ProductController
        public async Task<IActionResult> Index()
        {
            var list = await _productService.GetAll();
            return View(_mapper.Map<IEnumerable<ProductViewModel>>(list));
        }

        // GET: ProductController/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = _mapper.Map<IEnumerable<CategoryViewModel>>(await _categoryService.GetAll())
                .Select(c => new SelectListItem()
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                })
                .ToList();

            ViewBag.Companies = _mapper.Map<IEnumerable<CompanyViewModel>>(await _companyService.GetAll())
              .Select(c => new SelectListItem()
              {
                  Text = c.Name,
                  Value = c.Id.ToString()
              })
              .ToList();

            return View(new ProductCreatedViewModel());
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreatedViewModel viewModel)
        {
            try
            {
                var entity = _mapper.Map<Product>(viewModel);
                await _productService.Create(entity);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);

                return View();
            }
        }

        // GET: ProductController/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            ViewBag.Categories = _mapper.Map<IEnumerable<CategoryViewModel>>(await _categoryService.GetAll())
               .Select(c => new SelectListItem()
               {
                   Text = c.Name,
                   Value = c.Id.ToString()
               })
               .ToList();

            ViewBag.Companies = _mapper.Map<IEnumerable<CompanyViewModel>>(await _companyService.GetAll())
              .Select(c => new SelectListItem()
              {
                  Text = c.Name,
                  Value = c.Id.ToString()
              })
              .ToList();

            var entity = await _productService.GetById(id);

            return View(_mapper.Map<ProductViewModel>(entity));
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProductViewModel viewModel)
        {
            try
            {
                var entity = _mapper.Map<Product>(viewModel);
                await _productService.Update(id, entity);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);

                return View();
            }
        }

        // GET: ProductController/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var entity = await _productService.GetById(id);

            return View(_mapper.Map<ProductViewModel>(entity));
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, ProductViewModel viewModel)
        {
            try
            {
                var entity = _mapper.Map<Product>(viewModel);
                await _productService.Remove(id, entity);

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
            var list = await _productService.GetAll();

            var wb = new XLWorkbook();
            wb.Worksheets.Add(GetDataTable(list.ToList()));

            return wb.Deliver($"products-{DateTime.Now.ToString()}.xlsx");
        }

        public DataTable GetDataTable(List<Product> list)
        {
            DataTable dataTable = new DataTable("Products");
            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Description");
            dataTable.Columns.Add("ShortDescription");
            dataTable.Columns.Add("Price");
            dataTable.Columns.Add("Weight");
            dataTable.Columns.Add("Height");
            dataTable.Columns.Add("Length");
            dataTable.Columns.Add("Quantity");
            dataTable.Columns.Add("IdCategory");
            dataTable.Columns.Add("IdCompany");
            dataTable.Columns.Add("CreatedAt");
            dataTable.Columns.Add("UpdatedAt");
            dataTable.Columns.Add("DeletedAt");

            foreach (var entity in list)
            {
                var row = dataTable.NewRow();

                row["Id"] = entity.Id;
                row["Name"] = entity.Name;
                row["Description"] = entity.Description;
                row["ShortDescription"] = entity.ShortDescription;
                row["Price"] = entity.Price;
                row["Weight"] = entity.Weight;
                row["Height"] = entity.Height;
                row["Length"] = entity.Length;
                row["Quantity"] = entity.Quantity;
                row["IdCategory"] = entity.IdCategory;
                row["IdCompany"] = entity.IdCompany;
                row["CreatedAt"] = entity.CreatedAt;
                row["UpdatedAt"] = entity.UpdatedAt;
                row["DeletedAt"] = entity.DeletedAt;

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }
}