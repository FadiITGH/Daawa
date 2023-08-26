using Daawa.Data;
using Daawa.BackEnd.Interfaces;
using Daawa.Models;
using Microsoft.EntityFrameworkCore;

namespace Daawa.BackEnd.Repos
{
    public class DawaRepo : IDawa
    {
        private readonly ApplicationDbContext _db;
        public DawaRepo(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<string> AddNewDawaToTheSystem (DaawaModel NewDawa)
        {
            await _db.DawaTable.AddAsync (NewDawa);
            await _db.SaveChangesAsync();
            return "تم اضافة الدعوى الى النظام";
        }
        public async Task<bool> CheckIfDawaExistsInDB(string DawaNumber)
        {
            var CheckIfDawaExistsInDB = await _db.DawaTable.FirstOrDefaultAsync(a => a.DawaNumber == DawaNumber.Trim());

            if (CheckIfDawaExistsInDB is null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }




        public async Task<string> DeleteDawa(int DawaId)
        {
            try
            {
                var DeletedDawa = await _db.DawaTable.FirstOrDefaultAsync(a => a.Id == DawaId);
                _db.DawaTable.Remove(DeletedDawa);
                await _db.SaveChangesAsync();
                return $"{DawaId} deleted Successfully";
            }
            catch (Exception Error)
            {

                return Error.Message;
            }

        }

        public async Task<string> DeleteListOfDawas(List<int> ListOfDeletedDawas)
        {
            try
            {
                var ListOfDeletedDawa = new List<DaawaModel>();

                foreach (var item in ListOfDeletedDawa)
                {
                    var Dawa = await _db.DawaTable.FirstOrDefaultAsync(a => a.Id == item);
                    ListOfDeletedDawa.Add(Dawa);
                }
                _db.DawaTable.RemoveRange(ListOfDeletedDawa);
                await _db.SaveChangesAsync();
                return "تم الحذف بنجاح ";

            }
            catch (Exception Error)
            {

                return Error.Message;
            }
        }

        public async Task<List<DaawaModel>> GetAllDawas()
        {
            var ListOfDawas = await _db.DawaTable.Include(a => a.DeptTable).ToListAsync();
            return ListOfDawas;
        }

    }
}
