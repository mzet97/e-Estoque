using e_Estoque.CrossCutting.Notifications;
using e_Estoque.Domain.Entities;
using e_Estoque.Domain.Entities.Validations;
using e_Estoque.Domain.Interfaces.Data;
using e_Estoque.Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Estoque.Service
{
    public class CategoryService : BaseService, ICategoryService
    {
        private readonly ILogger<CategoryService> _logger;
        public CategoryService(
            INotifier notifier,
            IUnitOfWork unitOfWork,
            ILogger<CategoryService> logger) : base(notifier, unitOfWork)
        {
            _logger = logger;
        }

        public async Task<Category> GetById(Guid id)
        {
            return await _unitOfWork.RepositoryFactory.CategoryRepository.GetById(id);
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _unitOfWork.RepositoryFactory.CategoryRepository.GetAll();
        }

        public async Task Create(Category entity)
        {
            if (!Validate(new CategoryValidation(), entity))
            {
                _notifier.Handle("Categoria não está valida!", NotificationType.ERROR);
                return;
            }

            await _unitOfWork.RepositoryFactory.CategoryRepository.Add(entity);

            var result =  await _unitOfWork.RepositoryFactory.CategoryRepository.Commit();
        }

        public async Task Edit(Guid id, Category entity)
        {
            if(id != entity.Id)
            {
                _notifier.Handle("Categoria invalida", NotificationType.ERROR);
                return;
            }

            if (!Validate(new CategoryValidation(), entity))
            {
                _notifier.Handle("Categoria não está valida!", NotificationType.ERROR);
                return;
            }

            var entityDB = await GetById(id);

            if(entityDB == null)
            {
                _notifier.Handle("Categoria não encontrada", NotificationType.ERROR);
                return;
            }

            _unitOfWork.RepositoryFactory.CategoryRepository.Update(entity);

            var result = await _unitOfWork.RepositoryFactory.CategoryRepository.Commit();

        }

        public async Task Delete(Guid id, Category entity)
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

            var result =  await _unitOfWork.RepositoryFactory.CategoryRepository.Commit();
        }
    }
}
