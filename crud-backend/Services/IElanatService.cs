using Entity;
using ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Services
{
    public interface IElanatService
    {
        Task CreateElanat(Elanat elanat);
        Elanat GetElanatById(int id);
        Task UpdateElanat(int id, Elanat elanat);
        Task DeleteElanat(int id);
        IEnumerable<Elanat> GetAllElanats();

        Task<ICollection<Elanat>> GetAllElanatsPaged(paggingData paggingData);

      

        bool ElanatExists(int id);

    }
}
