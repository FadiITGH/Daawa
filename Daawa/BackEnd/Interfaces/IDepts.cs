using Daawa.Models;

namespace Daawa.BackEnd.Interfaces
{
    public interface IDepts
    {
        public Task<string> AddNewDepartment(DepModel NewDep);
    }
}
