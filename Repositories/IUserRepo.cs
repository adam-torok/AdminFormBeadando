using AdminForm.Models;
using System.ComponentModel;

namespace AdminForm.Repositories
{
    public interface IUserRepo
    {
        int Count();
        void Delete(int id);
        void Dispose();
        bool Exists(felhasznalo user);
        BindingList<felhasznalo> getAllUser(int page = 0, int itemsPerPage = 0, string search = null, string sortBy = null, bool ascending = true);
        void Insert(felhasznalo user);
        void Save();
        void Update(felhasznalo user);
    }
}