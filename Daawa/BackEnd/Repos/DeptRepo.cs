using Daawa.BackEnd.Interfaces;
using Daawa.Data;
using Daawa.Models;
using Microsoft.EntityFrameworkCore;

namespace Daawa.BackEnd.Repos
{
    public class DeptRepo : IDepts
    {
        private readonly ApplicationDbContext _db;
        public DeptRepo(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<string> AddNewDepartment(DepModel NewDept)
        {
            var CheckIfDeptsExistsInDataBase = await _db.DeptTable.FirstOrDefaultAsync(a => a.DepName == NewDept.DepName);

            if (CheckIfDeptsExistsInDataBase is null)
            {
                await _db.DeptTable.AddAsync(NewDept);
                await _db.SaveChangesAsync();
                return $"The Department :{NewDept.DepName} Has Been Added Successfuly to The System";
            }
            else
            {
                return $"The Department : {NewDept.DepName} already Exists in The System, Please add another Office";
            }


        }

    }
}
