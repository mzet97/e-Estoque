using e_Estoque.CrossCutting.Notifications;
using e_Estoque.Domain.Interfaces.Data;
using e_Estoque.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Estoque.Service
{
    public class CompanyService : BaseService, ICompanyService
    {
        public CompanyService(
            INotifier notifier, 
            IUnitOfWork unitOfWork) : base(notifier, unitOfWork)
        {
        }
    }
}
