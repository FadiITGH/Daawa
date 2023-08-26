using Daawa.Models;

namespace Daawa.BackEnd.Interfaces
{
    public interface IDawa
    {
        public Task<bool> CheckIfDawaExistsInDB(string DawaNumber);
        public Task<string> AddNewDawaToTheSystem(DaawaModel NewDawa);
        public Task<List<DaawaModel>> GetAllDawas();
        public Task<string> DeleteDawa(int DawaId);
        public Task<string> DeleteListOfDawas(List<int> ListOfDeletedDawas);
    }
}
