using Microsoft.AspNetCore.Mvc;
using EDIMonitorDemoData.Repositories.Interfaces;

namespace EDIMonitorDemoCore.Controllers
{
    public class KonturOrderController : Controller
    {
        private readonly IKonturOrderRepository _repository;
        private readonly ILogger<KonturOrderController> _logger;

        public KonturOrderController(IKonturOrderRepository repository, ILogger<KonturOrderController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        [Route("kontur/inbox")]
        public JsonResult Inbox()
        {
            return Json(_repository.LoadInbox());
        }

        [HttpGet]
        [Route("kontur/fromch")]
        public JsonResult FromCH()
        {
            return Json(_repository.LoadFromCH());
        }
    }
}
