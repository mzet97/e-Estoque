using AutoMapper;
using ClosedXML.Excel;
using ClosedXML.Extensions;
using e_Estoque.App.ViewModels.Customer;
using e_Estoque.CrossCutting.Notifications;
using e_Estoque.Domain.Entities;
using e_Estoque.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Data;

namespace e_Estoque.App.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(
            INotifier notifier, 
            IMapper mapper, 
            ICustomerService customerService) : base(notifier, mapper)
        {
            _customerService = customerService;
        }

        // GET: CustomerController
        public async Task<IActionResult> Index()
        {
            var list = await _customerService.GetAll();
            return View(_mapper.Map<IEnumerable<CustomerViewModel>>(list));
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View(new CustomerCreatedViewModel());
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerCreatedViewModel viewModel)
        {
            try
            {
                var entity = _mapper.Map<Customer>(viewModel);
                await _customerService.Create(entity);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);

                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var entity = await _customerService.GetById(id);

            return View(_mapper.Map<CustomerViewModel>(entity));
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, CustomerViewModel viewModel)
        {
            try
            {
                var entity = _mapper.Map<Customer>(viewModel);
                await _customerService.Update(id, entity);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);

                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var entity = await _customerService.GetById(id);

            return View(_mapper.Map<CustomerViewModel>(entity));
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, CustomerViewModel viewModel)
        {
            try
            {
                var entity = _mapper.Map<Customer>(viewModel);
                await _customerService.Remove(id, entity);

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
            var list = await _customerService.GetAll();

            var wb = new XLWorkbook();
            wb.Worksheets.Add(GetDataTable(list.ToList()));

            return wb.Deliver($"customers-{DateTime.Now.ToString()}.xlsx");
        }

        public DataTable GetDataTable(List<Customer> customers)
        {
            DataTable dataTable = new DataTable("Customers");
            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("DocId");
            dataTable.Columns.Add("Email");
            dataTable.Columns.Add("Description");
            dataTable.Columns.Add("PhoneNumber");

            dataTable.Columns.Add("Street");
            dataTable.Columns.Add("Number");
            dataTable.Columns.Add("Complement");
            dataTable.Columns.Add("Neighborhood");
            dataTable.Columns.Add("District");
            dataTable.Columns.Add("City");
            dataTable.Columns.Add("County");
            dataTable.Columns.Add("ZipCode");
            dataTable.Columns.Add("Latitude");
            dataTable.Columns.Add("Longitude");

            dataTable.Columns.Add("CreatedAt");
            dataTable.Columns.Add("UpdatedAt");
            dataTable.Columns.Add("DeletedAt");

            foreach (var customer in customers)
            {
                var row = dataTable.NewRow();
                row["Id"] = customer.Id;
                row["Name"] = customer.Id;
                row["DocId"] = customer.DocId;
                row["Email"] = customer.Email;
                row["Description"] = customer.Description;
                row["PhoneNumber"] = customer.PhoneNumber;

                row["Street"] = customer.CustomerAdress.Street;
                row["Number"] = customer.CustomerAdress.Number;
                row["Complement"] = customer.CustomerAdress.Complement;
                row["Neighborhood"] = customer.CustomerAdress.Neighborhood;
                row["District"] = customer.CustomerAdress.District;
                row["City"] = customer.CustomerAdress.City;
                row["County"] = customer.CustomerAdress.County;
                row["ZipCode"] = customer.CustomerAdress.ZipCode;
                row["Latitude"] = customer.CustomerAdress.Latitude;
                row["Longitude"] = customer.CustomerAdress.Longitude;

                row["CreatedAt"] = customer.CreatedAt;
                row["UpdatedAt"] = customer.UpdatedAt;
                row["DeletedAt"] = customer.DeletedAt;

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }
}
