using e_Estoque.CrossCutting.Notifications;
using e_Estoque.Domain.Entities;
using e_Estoque.Domain.Entities.Validations;
using e_Estoque.Domain.Interfaces.Data;
using e_Estoque.Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace e_Estoque.Service
{
    public class ProductService : BaseService, IProductService
    {

        public ProductService(
            INotifier notifier,
            IUnitOfWork unitOfWork) : base(notifier, unitOfWork)
        {
        }

        public async Task Create(Product entity)
        {
            if (!Validate(new ProductValidation(), entity))
            {
                _notifier.Handle("Product não está valida!", NotificationType.ERROR);
                return;
            }

            var category = await _unitOfWork
                .RepositoryFactory
                .CategoryRepository
                .GetById(entity.IdCategory);

            if (category == null)
            {
                _notifier.Handle("Categoria não encontrada", NotificationType.ERROR);
                return;
            }

            var company = await _unitOfWork
                .RepositoryFactory
                .CompanyRepository
                .GetById(entity.IdCompany);

            if (company == null)
            {
                _notifier.Handle("Company não encontrada", NotificationType.ERROR);
                return;
            }

            entity.Company = null;

            await _unitOfWork
                .RepositoryFactory
                .ProductRepository
                .Create(entity);

            await _unitOfWork
                .RepositoryFactory
                .ProductRepository
                .Commit();
        }

        public async Task<IEnumerable<Product>> Find(Expression<Func<Product, bool>> predicate)
        {
            return await _unitOfWork.RepositoryFactory.ProductRepository.Find(predicate);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _unitOfWork.RepositoryFactory.ProductRepository.GetAll();
        }

        public async Task<Product> GetById(Guid id)
        {
            return await _unitOfWork.RepositoryFactory.ProductRepository.GetById(id);
        }

        public async Task Remove(Guid id, Product entity)
        {
            if (id != entity.Id)
            {
                _notifier.Handle("Product invalida", NotificationType.ERROR);
                return;
            }

            var entityDB = await GetById(entity.Id);

            if (entityDB == null)
            {
                _notifier.Handle("Product não encontrada", NotificationType.ERROR);
                return;
            }

            await _unitOfWork.RepositoryFactory.ProductRepository.Remove(id);

            await _unitOfWork.RepositoryFactory.ProductRepository.Commit();
        }

        public async Task<IEnumerable<Product>> Search(Expression<Func<Product, bool>> predicate = null, Func<IQueryable<Product>, IOrderedQueryable<Product>> orderBy = null, int? pageSize = null, int? pageIndex = null)
        {
            return await _unitOfWork.RepositoryFactory.ProductRepository.Search(predicate, orderBy, pageSize, pageIndex);
        }

        public async Task Update(Guid id, Product entity)
        {
            if (id != entity.Id)
            {
                _notifier.Handle("Product invalida", NotificationType.ERROR);
                return;
            }

            if (!Validate(new ProductValidation(), entity))
            {
                _notifier.Handle("Product não está valida!", NotificationType.ERROR);
                return;
            }

            var entityDB = await GetById(entity.Id);

            if (entityDB == null)
            {
                _notifier.Handle("Product não encontrada", NotificationType.ERROR);
                return;
            }

            var category = await _unitOfWork.RepositoryFactory.CategoryRepository.GetById(entity.IdCategory);

            if (category == null)
            {
                _notifier.Handle("Categoria não encontrada", NotificationType.ERROR);
                return;
            }

            entity.Category = null;

            var company = await _unitOfWork
               .RepositoryFactory
               .CompanyRepository
               .GetById(entity.IdCompany);

            if (company == null)
            {
                _notifier.Handle("Company não encontrada", NotificationType.ERROR);
                return;
            }

            entity.Company = null;

            _unitOfWork.RepositoryFactory.ProductRepository.Update(entity);

            await _unitOfWork.RepositoryFactory.ProductRepository.Commit();
        }
    }
}