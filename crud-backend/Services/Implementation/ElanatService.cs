using Castle.Core.Internal;
using Microsoft.EntityFrameworkCore;
using Entity;
using Infrastructure;
using ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Common;

namespace Services.Implementation
{
  public class ElanatService : IElanatService
    {
        private readonly ApplicationDbContext _context;
        private readonly Microsoft.EntityFrameworkCore.DbSet<Elanat> _entity;

        public ElanatService(ApplicationDbContext context)
        {
            _context = context;
            _entity = _context.Set<Elanat>();
        }

        public async Task CreateElanat(Elanat elanat) 
        {
            await _context.Elanats.AddAsync(elanat);
            await _context.SaveChangesAsync();
        }
        public Elanat GetElanatById(int id) =>
            _context.Elanats.Where(e => e.ElanatId == id).FirstOrDefault();

        public async Task UpdateElanat(int id, Elanat elanat)
        {
            if (id != elanat.ElanatId)
            {
                //return BadRequest();
            }

            _context.Entry(elanat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElanatExists(id))
                {
                    //return NotFound();
                }
                else
                {
                    throw;
                }
            }

           // return NoContent();
            //var managementMessage2 = GetManagementMessageById(id);
            //_context.Update(managementMessage2);
            //await _context.SaveChangesAsync();
        }
        public async Task DeleteElanat(int id) 
        {
            var elanat = await _context.Elanats.FindAsync(id);
            if (elanat != null)
            {
             _context.Elanats.Remove(elanat);
            await _context.SaveChangesAsync();
            }
        }
       public IEnumerable<Elanat> GetAllElanats() => _context.Elanats.OrderBy(m => m.ElanatId).ToList();

        public async Task<ICollection<Elanat>> GetAllElanatsPaged(paggingData paggingData)
        {
            if (paggingData.Expression.IsNullOrEmpty())
            {
                paggingData.Expression = "";
            }
            if (paggingData.SortBy.IsNullOrEmpty())
            {
                paggingData.SortBy = "ElanatId";
            }
            var list = _entity.Where(c =>  c.MessageTopic.Contains(paggingData.Expression) || c.MessageText.Contains(paggingData.Expression))
           .OrderBy(c => c.ElanatId);

            

            if (paggingData.SortMethod == "asc")
            {
                switch (paggingData.SortBy)
                {
                    case "messageTopic":
                        list = list.OrderBy(c => c.MessageTopic);
                        break;
                    case "messageText":
                        list = list.OrderBy(c => c.MessageText);
                        break;
                    case "dateFrom":
                        list = list.OrderBy(c => c.DateFrom);
                        break;
                    case "dateTo":
                        list = list.OrderBy(c => c.DateTo);
                        break;
                    //case "DesLevel":
                    //    list = list.OrderBy(c => c.DesLevel);
                    //    break;
                        
                    default:
                        list = list.OrderBy<Elanat>(paggingData.SortBy);
                        break;
                }
            }
            else
            {
                switch (paggingData.SortBy)
                {
                    case "messageTopic":
                        list = list.OrderByDescending(c => c.MessageTopic);
                        break;
                    case "messageText":
                        list = list.OrderByDescending(c => c.MessageText);
                        break;
                    case "dateFrom":
                        list = list.OrderByDescending(c => c.DateFrom);
                        break;
                    case "dateTo":
                        list = list.OrderByDescending(c => c.DateTo);
                        break;
                    default:

                        list = list.OrderBy<Elanat>(paggingData.SortBy + " descending");
                        break;
                }
            }

            return await Pagging.PagedResult(list, paggingData).ToListAsync();
        }

       

        public bool ElanatExists(int id)
        {
            return _context.Elanats.Any(e => e.ElanatId == id);
        }

    }
}
