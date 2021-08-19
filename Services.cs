using System;
using System.Collections.Generic;
using System.Linq;

using CRUD_ENTITY.NET_CORE.Context;
using CRUD_ENTITY.NET_CORE.Models;

using Microsoft.EntityFrameworkCore;

namespace CRUD_ENTITY.NET_CORE
{

    public class Services
    {
        private List<Account> _lstAccounts;
        private readonly DatabaseContext _dbcontext;
        private List<Role> lstRoles;

        public Services()
        {
            _lstAccounts = new List<Account>();
            _dbcontext = new DatabaseContext();
            getListACCFromDB();
            lstRoles = _dbcontext.Roles.AsNoTracking().ToList();
        }

        public List<Role> GetRoles()
        {
            return lstRoles;
        }
        public List<Account> GetListService()
        {
            return _lstAccounts;
        }

        public void getListACCFromDB()
        {
            _lstAccounts = _dbcontext.Accounts.AsNoTracking().ToList();
        }
        public string AddnewACC(Account acc)
        {
            _dbcontext.Accounts.Add(acc);
            _dbcontext.SaveChanges();
            return "thêm thành Công";
        }
        // phương thức Sửa -- trog table
        public string UpdateAcc(Account acc)
        {
            _dbcontext.Accounts.Update(acc);
            _dbcontext.SaveChanges();
            return "Sửa thành Công";
        }

        public string DeleteACC(Guid id)
        {
            // đối tượng ACC trong bảng CSDL sau đó tiên hành Xóa
            Account acc = _dbcontext.Accounts.ToList().FirstOrDefault(c => c.Id == id);
            _dbcontext.Accounts.Remove(acc);
            _dbcontext.SaveChanges();
            return "Xóa thành Công";
        }
        // phương thức tỉm kiếm gần đúng
        public List<Account> GetListACCByStartWith(string Acc)
        {
            List<Account> temp = _dbcontext.Accounts.Where(c => c.Acc.StartsWith(Acc)).ToList();
            return temp;
        }
        // Lấy dữ liệu từ Table trong DB

    }
}