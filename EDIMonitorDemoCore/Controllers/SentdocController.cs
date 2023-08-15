using Microsoft.AspNetCore.Mvc;
using EDIMonitorDemoData.Repositories.Interfaces;
using Newtonsoft.Json;

namespace EDIMonitorDemoCore.Controllers
{
    public class SentdocController : Controller
    {
        private readonly ISentDocRepository _repository;
        private readonly ILogger<SentdocController> _logger;

        public SentdocController(ISentDocRepository repository, ILogger<SentdocController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        [Route("[controller]/all/{docType}")]
        public async Task<JsonResult> Index(int docType)
        {
            var result = Json(await _repository.GetSentDocsWhere(sd => (sd.DtVrOtpr > DateTime.Today.AddDays(-1)) && (sd.Doc == docType)));
            return result;
        }

        [HttpGet]
        [Route("[controller]/{docId}")]
        public async Task<JsonResult> GetOne(long docId)
        {
            var result = Json(await _repository.GetSentDocById(docId));
            return result;
        }
    }
}
