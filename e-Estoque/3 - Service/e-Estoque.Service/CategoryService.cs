using e_Estoque.CrossCutting.Notifications;
using e_Estoque.Domain.Entities;
using e_Estoque.Domain.Entities.Validations;
using e_Estoque.Domain.Interfaces.Data;
using e_Estoque.Domain.Interfaces.Services;
using System.Linq.Expressions;

namespace e_Estoque.Service
{
    public class CategoryService : BaseService, ICategoryService
    {

        public CategoryService(
            INotifier notifier,
            IUnitOfWork unitOfWork) : base(notifier, unitOfWork)
        {
        }

        public async Task Create(Category entity)
        {
            if (!Validate(new CategoryValidation(), entity))
            {
                _notifier.Handle("Categoria não está valida!", NotificationType.ERROR);
                return;
            }

            await _unitOfWork.RepositoryFactory.CategoryRepository.Create(entity);

            await _unitOfWork.RepositoryFactory.CategoryRepository.Commit();
        }

        public async Task<Category> GetById(Guid id)
        {
            return await _unitOfWork.RepositoryFactory.CategoryRepository.GetById(id);
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _unitOfWork.RepositoryFactory.CategoryRepository.GetAll();
        }

        public async Task<IEnumerable<Category>> Find(Expression<Func<Category, bool>> predicate)
        {
            return await _unitOfWork.RepositoryFactory.CategoryRepository.Find(predicate);
        }

        public async Task Update(Guid id, Category entity)
        {
            if (id != entity.Id)
            {
                _notifier.Handle("Categoria invalida", NotificationType.ERROR);
                return;
            }

            if (!Validate(new CategoryValidation(), entity))
            {
                _notifier.Handle("Categoria não está valida!", NotificationType.ERROR);
                return;
            }

            var entityDB = await GetById(entity.Id);

            if (entityDB == null)
            {
                _notifier.Handle("Categoria não encontrada", NotificationType.ERROR);
                return;
            }

            _unitOfWork.RepositoryFactory.CategoryRepository.Update(entity);

            await _unitOfWork.RepositoryFactory.CategoryRepository.Commit();
        }

        public async Task Remove(Guid id, Category entity)
        {
            if (id != entity.Id)
            {
                _notifier.Handle("Categoria invalida", NotificationType.ERROR);
                return;
            }

            var entityDB = await GetById(id);

            if (entityDB == null)
            {
                _notifier.Handle("Categoria não encontrada", NotificationType.ERROR);
                return;
            }

            await _unitOfWork.RepositoryFactory.CategoryRepository.Remove(id);

            await _unitOfWork.RepositoryFactory.CategoryRepository.Commit();
        }

        public async Task<IEnumerable<Category>> Search(
            Expression<Func<Category, bool>> predicate = null,
            Func<IQueryable<Category>, IOrderedQueryable<Category>> orderBy = null,
            int? pageSize = null,
            int? pageIndex = null)
        {
            return await _unitOfWork.RepositoryFactory.CategoryRepository.Search(predicate, orderBy, pageSize, pageIndex);
        }
    }
}