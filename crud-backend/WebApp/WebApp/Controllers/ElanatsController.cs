using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Entity;
using Services;
using Microsoft.Extensions.Hosting;
using ViewModels;

namespace Controllers
{
   // [Route("api/[controller]")]
    [ApiController]
    public class ElanatsController : ControllerBase
    {
        public readonly IElanatService _elanatsService;
        public readonly IHostEnvironment _hostingEnvironment;

        public ElanatsController(IElanatService elanatsService, IHostEnvironment hostingEnvironment)
        {
            _elanatsService = elanatsService;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        [Route("api/Elanats/GetAllElanats")]
        public async Task<IActionResult> GetAllElanatsPaged(int pageNum = 1, int pageSize = 10, string expression = "", string sortBy = "", string sortMethod = "asc")
        {
            var paggingData = new paggingData()
            {
                PageSize = pageSize,
                PageNum = pageNum,
                SortBy = sortBy,
                Expression = expression,
                SortMethod = sortMethod
            };
            var elanats = await _elanatsService.GetAllElanatsPaged(paggingData);

            var list = new List<ElanatViewModel>();
            if (!elanats.Any())
            {
                return NoContent();
            }
            foreach (var item in elanats)
            {
                list.Add(new ElanatViewModel()
                {
                    ElanatId = item.ElanatId,
                   
                    messageText = item.MessageText,
                    messageTopic = item.MessageTopic,
                    dateFrom = item.DateFrom,
                    dateTo = item.DateTo
                     
                });
            }

            var pagedList = new PagedList<ElanatViewModel>()
            {
                list = list,
                PageSize = paggingData.PageSize,
                Count = paggingData.Count,
                Expression = paggingData.Expression,
                SortBy = paggingData.SortBy,
                PageNum = paggingData.PageNum,
                SortMethod = paggingData.SortMethod,
            };

            return Ok(pagedList);
        }





        // GET: api/ManagementMessages/5
        [HttpGet("{id}")]
        public Elanat GetElanatById(int id)
        {
            var elanat = _elanatsService.GetElanatById(id);

            if (elanat == null)
            {
               // return NotFound();
            }

            return elanat;
        }

        // PUT: api/ManagementMessages/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut]
        [Route("api/Elanats/UpdateElanat")]
        public async Task UpdateElanat(int id, Elanat elanat)
        {
           await _elanatsService.UpdateElanat(id, elanat);
        }

        //public IActionResult SaveUser(
        //[Required, EmailAddress] string Email

        //[Required, StringLength(1000)] string Name)
        //      { ..... }



        // POST: api/ManagementMessages
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        [Route("api/Elanats/CreateElanat")]
        public async Task CreateElanat([FromBody]Elanat elanat)
        {

    

                await _elanatsService.CreateElanat(elanat);
        }

        // DELETE: api/ManagementMessages/5
        [HttpDelete]
        [Route("api/Elanats/DeleteElanat/{id}")]
        public async Task DeleteElanat(int id)
        {
            await _elanatsService.DeleteElanat(id);
        }

        private  bool ElanatExists(int id)
        {
            return _elanatsService.ElanatExists(id);
        }
    }
}
