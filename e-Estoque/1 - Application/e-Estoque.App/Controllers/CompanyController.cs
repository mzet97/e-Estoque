using AutoMapper;
using ClosedXML.Excel;
using ClosedXML.Extensions;
using e_Estoque.App.ViewModels.Company;
using e_Estoque.CrossCutting.Notifications;
using e_Estoque.Domain.Entities;
using e_Estoque.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Data;

namespace e_Estoque.App.Controllers
{
    public class CompanyController : BaseController
    {
        private readonly ICompanyService _companyService;

        public CompanyController(
            INotifier notifier,
            IMapper mapper,
            ICompanyService companyService) : base(notifier, mapper)
        {
            _companyService = companyService;
        }

        // GET: CompanyController
        public async Task<IActionResult> Index()
        {
            var list = await _companyService.GetAll();
            return View(_mapper.Map<IEnumerable<CompanyViewModel>>(list));
        }

        // GET: CompanyController/Create
        public ActionResult Create()
        {
            return View(new CompanyCreatedViewModel());
        }

        // POST: CompanyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CompanyCreatedViewModel viewModel)
        {
            try
            {
                var entity = _mapper.Map<Company>(viewModel);
                await _companyService.Create(entity);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);

                return View();
            }
        }

        // GET: CompanyController/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var entity = await _companyService.GetById(id);

            return View(_mapper.Map<CompanyViewModel>(entity));
        }

        // POST: CompanyController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, CompanyViewModel viewModel)
        {
            try
            {
                var entity = _mapper.Map<Company>(viewModel);
                await _companyService.Update(id, entity);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);

                return View();
            }
        }

        // GET: CompanyController/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var entity = await _companyService.GetById(id);

            return View(_mapper.Map<CompanyViewModel>(entity));
        }

        // POST: CompanyController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, CompanyViewModel viewModel)
        {
            try
            {
                var entity = _mapper.Map<Company>(viewModel);
                await _companyService.Remove(id, entity);

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
            var list = await _companyService.GetAll();

            var wb = new XLWorkbook();
            wb.Worksheets.Add(GetDataTable(list.ToList()));

            return wb.Deliver($"companies-{DateTime.Now.ToString()}.xlsx");
        }

        public DataTable GetDataTable(List<Company> Companies)
        {
            DataTable dataTable = new DataTable("Categories");
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

            foreach (var company in Companies)
            {
                var row = dataTable.NewRow();
                row["Id"] = company.Id;
                row["Name"] = company.Name;
                row["DocId"] = company.DocId;
                row["Email"] = company.Email;
                row["Description"] = company.Description;
                row["PhoneNumber"] = company.PhoneNumber;

                row["Street"] = company.CompanyAddress.Street;
                row["Number"] = company.CompanyAddress.Number;
                row["Complement"] = company.CompanyAddress.Complement;
                row["Neighborhood"] = company.CompanyAddress.Neighborhood;
                row["District"] = company.CompanyAddress.District;
                row["City"] = company.CompanyAddress.City;
                row["County"] = company.CompanyAddress.County;
                row["ZipCode"] = company.CompanyAddress.ZipCode;
                row["Latitude"] = company.CompanyAddress.Latitude;
                row["Longitude"] = company.CompanyAddress.Longitude;

                row["CreatedAt"] = company.CreatedAt;
                row["UpdatedAt"] = company.UpdatedAt;
                row["DeletedAt"] = company.DeletedAt;

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }
}