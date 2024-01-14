using AutoMapper;
using ClosedXML.Excel;
using ClosedXML.Extensions;
using e_Estoque.App.ViewModels.Inventory;
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
    public class InventoryController : BaseController
    {
        private readonly IInventoryService _inventoryService;
        private readonly IProductService _productService;

        public InventoryController(
            INotifier notifier,
            IMapper mapper,
            IInventoryService inventoryService,
            IProductService productService) : base(notifier, mapper)
        {
            _inventoryService = inventoryService;
            _productService = productService;
        }

        // GET: InventoryController
        public async Task<IActionResult> Index()
        {
            var list = await _inventoryService.GetAll();
            return View(_mapper.Map<IEnumerable<InventoryViewModel>>(list));
        }

        // GET: InventoryController/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Products = _mapper.Map<IEnumerable<ProductViewModel>>(await _productService.GetAll())
                 .Select(c => new SelectListItem()
                 {
                     Text = c.Name,
                     Value = c.Id.ToString()
                 })
                 .ToList();

            return View(new InventoryCreatedViewModel());
        }

        // POST: InventoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InventoryCreatedViewModel viewModel)
        {
            try
            {
                var entity = _mapper.Map<Inventory>(viewModel);
                await _inventoryService.Create(entity);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);

                return View();
            }
        }

        // GET: InventoryController/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            ViewBag.Products = _mapper.Map<IEnumerable<ProductViewModel>>(await _productService.GetAll())
                 .Select(c => new SelectListItem()
                 {
                     Text = c.Name,
                     Value = c.Id.ToString()
                 })
                 .ToList();

            var entity = await _inventoryService.GetById(id);

            return View(_mapper.Map<InventoryViewModel>(entity));
        }

        // POST: InventoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, InventoryViewModel viewModel)
        {
            try
            {
                var entity = _mapper.Map<Inventory>(viewModel);
                await _inventoryService.Update(id, entity);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);

                return View();
            }
        }

        // GET: InventoryController/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var entity = await _inventoryService.GetById(id);

            return View(_mapper.Map<InventoryViewModel>(entity));
        }

        // POST: InventoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, InventoryViewModel viewModel)
        {
            try
            {
                var entity = _mapper.Map<Inventory>(viewModel);
                await _inventoryService.Remove(id, entity);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);

                return View();
            }
        }

        public async Task<JsonResult> GetInventoryJson()
        {
            var list = await _inventoryService.GetAll();
            var inventoryJsons = list
                .Select(c => new InventoryJson(
                    c.Id,
                    c.Quantity, 
                    c.IdProduct, 
                    c.Product.Name))
                .ToList();

            return Json(inventoryJsons);
        }

        public async Task<IActionResult> Download()
        {
            var list = await _inventoryService.GetAll();

            var wb = new XLWorkbook();
            wb.Worksheets.Add(GetDataTable(list.ToList()));

            return wb.Deliver($"inventory-{DateTime.Now.ToString()}.xlsx");
        }

        public DataTable GetDataTable(List<Inventory> taxs)
        {
            DataTable dataTable = new DataTable("Categories");
            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("Quantity");
            dataTable.Columns.Add("DateOrder");
            dataTable.Columns.Add("IdProduct");
            dataTable.Columns.Add("CreatedAt");
            dataTable.Columns.Add("UpdatedAt");
            dataTable.Columns.Add("DeletedAt");

            foreach (var tax in taxs)
            {
                var row = dataTable.NewRow();
                row["Id"] = tax.Id;
                row["Quantity"] = tax.Quantity;
                row["DateOrder"] = tax.DateOrder;
                row["IdProduct"] = tax.IdProduct;
                row["CreatedAt"] = tax.CreatedAt;
                row["UpdatedAt"] = tax.UpdatedAt;
                row["DeletedAt"] = tax.DeletedAt;

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }
}