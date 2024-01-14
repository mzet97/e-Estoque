using AutoMapper;
using ClosedXML.Excel;
using ClosedXML.Extensions;
using e_Estoque.App.ViewModels.Category;
using e_Estoque.App.ViewModels.Customer;
using e_Estoque.App.ViewModels.Product;
using e_Estoque.App.ViewModels.Sale;
using e_Estoque.App.ViewModels.Tax;
using e_Estoque.CrossCutting.Notifications;
using e_Estoque.Domain.Entities;
using e_Estoque.Domain.Interfaces.Services;
using e_Estoque.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Serilog;
using System.Data;
using System.Linq;
using System.Text;

namespace e_Estoque.App.Controllers
{
    public class SaleController : BaseController
    {
        private readonly ISaleService _saleService;
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;

        public SaleController(
            INotifier notifier,
            IMapper mapper,
            ISaleService saleService,
            ICustomerService customerService,
            IProductService productService) : base(notifier, mapper)
        {
            _saleService = saleService;
            _customerService = customerService;
            _productService = productService;
        }

        // GET: SaleController
        public async Task<IActionResult> Index()
        {
            var list = await _saleService.GetAll();
            var listViewModel = list.Select(x =>
                new SaleViewModel(
                    x.Id,
                    x.Quantity,
                    x.TotalPrice,
                    x.TotalTax,
                    x.SaleType,
                    x.PaymentType,
                    x.DeliveryDate,
                    x.SaleDate,
                    x.PaymentDate,
                    x.IdCustomer,
                    x.CreatedAt,
                    x.UpdatedAt,
                    x.DeletedAt,
                    _mapper.Map<CustomerViewModel>(x.Customer),
                    x.SaleProduct
                    .Select(sp => _mapper.Map<ProductViewModel>(sp.Product) ??
                    new ProductViewModel()).ToList()
                ))
                .ToList();

            return View(listViewModel);
        }

        // GET: SaleController/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Customers = _mapper.Map<IEnumerable<CustomerViewModel>>(await _customerService.GetAll())
                .Select(c => new SelectListItem()
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                })
                .ToList();

            ViewBag.Products = _mapper.Map<IEnumerable<ProductViewModel>>(await _productService.GetAll())
               .Select(c => new SelectListItem()
               {
                   Text = c.Name,
                   Value = c.Id.ToString()
               })
               .ToList();

            return View(new SaleCreatedViewModel());
        }

        // POST: SaleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SaleCreatedViewModel viewModel)
        {
            try
            {
                var entity = new Sale(
                    viewModel.Quantity,
                    0,
                    0,
                    viewModel.SaleType,
                    viewModel.PaymentType,
                    viewModel.DeliveryDate,
                    viewModel.SaleDate,
                    viewModel.PaymentDate,
                    viewModel.IdCustomer,
                    viewModel.Products.Select(x => new SaleProduct(x)).ToList()
                );

                await _saleService.Create(entity);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);

                return View();
            }
        }

        // GET: SaleController/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            ViewBag.Customers = _mapper.Map<IEnumerable<CustomerViewModel>>(await _customerService.GetAll())
               .Select(c => new SelectListItem()
               {
                   Text = c.Name,
                   Value = c.Id.ToString()
               })
               .ToList();

            ViewBag.Products = _mapper.Map<IEnumerable<ProductViewModel>>(await _productService.GetAll())
               .Select(c => new SelectListItem()
               {
                   Text = c.Name,
                   Value = c.Id.ToString()
               })
               .ToList();

            var entity = await _saleService.GetById(id);

            var listViewModel =
                new SaleViewModel(
                    entity.Id,
                    entity.Quantity,
                    entity.TotalPrice,
                    entity.TotalTax,
                    entity.SaleType,
                    entity.PaymentType,
                    entity.DeliveryDate,
                    entity.SaleDate,
                    entity.PaymentDate,
                    entity.IdCustomer,
                    entity.CreatedAt,
                    entity.UpdatedAt,
                    entity.DeletedAt,
                    _mapper.Map<CustomerViewModel>(entity.Customer),
                    entity.SaleProduct
                    .Select(sp => _mapper.Map<ProductViewModel>(sp.Product) ??
                    new ProductViewModel()).ToList()
                );

            return View(listViewModel);
        }

        // POST: SaleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, SaleViewModel viewModel)
        {
            try
            {
                var entity = new Sale(
                   viewModel.Id,
                   viewModel.Quantity,
                   viewModel.TotalPrice,
                   viewModel.TotalTax,
                   viewModel.SaleType,
                   viewModel.PaymentType,
                   viewModel.DeliveryDate,
                   viewModel.SaleDate,
                   viewModel.PaymentDate,
                   viewModel.CreatedAt,
                   viewModel.UpdatedAt,
                   viewModel.DeletedAt,
                   viewModel.IdCustomer,
                   viewModel.Products
                   .Select(x => new SaleProduct(viewModel.Id, x.Id)).ToList()
               );

                await _saleService.Update(id, entity);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);

                return View();
            }
        }

        // GET: SaleController/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var entity = await _saleService.GetById(id);

            var listViewModel =
                new SaleViewModel(
                    entity.Id,
                    entity.Quantity,
                    entity.TotalPrice,
                    entity.TotalTax,
                    entity.SaleType,
                    entity.PaymentType,
                    entity.DeliveryDate,
                    entity.SaleDate,
                    entity.PaymentDate,
                    entity.IdCustomer,
                    entity.CreatedAt,
                    entity.UpdatedAt,
                    entity.DeletedAt,
                    _mapper.Map<CustomerViewModel>(entity.Customer),
                    entity.SaleProduct
                    .Select(sp => _mapper.Map<ProductViewModel>(sp.Product) ??
                    new ProductViewModel()).ToList()
                );

            return View(listViewModel);
        }

        // POST: SaleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, SaleViewModel viewModel)
        {
            try
            {
                var entity = new Sale(
                    viewModel.Id,
                    viewModel.Quantity,
                    viewModel.TotalPrice,
                    viewModel.TotalTax,
                    viewModel.SaleType,
                    viewModel.PaymentType,
                    viewModel.DeliveryDate,
                    viewModel.SaleDate,
                    viewModel.PaymentDate,
                    viewModel.CreatedAt,
                    viewModel.UpdatedAt,
                    viewModel.DeletedAt,
                    viewModel.IdCustomer,
                    viewModel.Products
                    .Select(x => new SaleProduct(viewModel.Id, x.Id)).ToList()
                );

                await _saleService.Remove(id, entity);

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
            var list = await _saleService.GetAll();

            var wb = new XLWorkbook();
            wb.Worksheets.Add(GetDataTable(list.ToList()));

            return wb.Deliver($"sales-{DateTime.Now.ToString()}.xlsx");
        }

        public DataTable GetDataTable(List<Sale> list)
        {
            DataTable dataTable = new DataTable("Sales");
            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("Quantity");
            dataTable.Columns.Add("TotalPrice");
            dataTable.Columns.Add("TotalTax");
            dataTable.Columns.Add("SaleType");
            dataTable.Columns.Add("PaymentType");
            dataTable.Columns.Add("DeliveryDate");
            dataTable.Columns.Add("SaleDate");
            dataTable.Columns.Add("PaymentDate");
            dataTable.Columns.Add("IdCustomer");
            dataTable.Columns.Add("Customer Name");
            dataTable.Columns.Add("IdProducts");
            dataTable.Columns.Add("Prodcuts Names");
            dataTable.Columns.Add("CreatedAt");
            dataTable.Columns.Add("UpdatedAt");
            dataTable.Columns.Add("DeletedAt");

            foreach (var entity in list)
            {
                var row = dataTable.NewRow();

                row["Id"] = entity.Id;
                row["Quantity"] = entity.Quantity;
                row["TotalPrice"] = entity.TotalPrice;
                row["TotalTax"] = entity.TotalTax;
                row["SaleType"] = entity.SaleType;
                row["PaymentType"] = entity.PaymentType;
                row["DeliveryDate"] = entity.DeliveryDate;
                row["SaleDate"] = entity.SaleDate;
                row["PaymentDate"] = entity.PaymentDate;
                row["IdCustomer"] = entity.IdCustomer;
                row["Customer Name"] = entity.Customer.Name;
                
                var listOfProducts = entity.SaleProduct.Select(x => x.Product).ToList();
                var listaNomes = new StringBuilder("");
                var listaId = new StringBuilder("");
                foreach (var item in listOfProducts)
                {
                    listaNomes.AppendLine(item.Name);
                    listaId.AppendLine(item.Id.ToString());
                }
                
                row["IdProducts"] = listaId.ToString();
                row["Prodcuts Names"] = listaNomes.ToString();
                row["CreatedAt"] = entity.CreatedAt;
                row["UpdatedAt"] = entity.UpdatedAt;
                row["DeletedAt"] = entity.DeletedAt;

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }
}