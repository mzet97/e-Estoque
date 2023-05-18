using AutoMapper;
using e_Estoque.CrossCutting.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace e_Estoque.App.Controllers
{
    public class BaseController : Controller
    {
        protected INotifier _notifier;
        protected readonly IMapper _mapper;
        
        public BaseController(
            INotifier notifier, 
            IMapper mapper)
        {
            _notifier = notifier;
            _mapper = mapper;
        }
    }
}
