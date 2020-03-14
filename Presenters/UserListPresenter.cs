using AdminForm.Interfaces;
using AdminForm.Models;
using AdminForm.Repositories;
using AdminForm.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminForm.Presenters
{
    class UserListPresenter
    {
        private IUserList view;
        private UserRepo ur = new UserRepo();
        private AddUserForm addUserForm;

        public UserListPresenter(IUserList param)
        {
            view = param;
        }

        public UserListPresenter(AddUserForm addUserForm)
        {
            this.addUserForm = addUserForm;
        }

        public void LoadData()
        {
            view.bindingList = ur.getAllUser(view.pageNumber, view.itemsPerPage, view.search, view.sortBy, view.ascending);
            view.totalItems = ur.Count();
        }

        public void Save()
        {
            ur.Save();
        }

        public void Modify(felhasznalo user)
        {
            ur.Update(user);
        }

        public void Add(felhasznalo user)
        {
            view.bindingList.Add(user);

            ur.Insert(user);
        }

        public void Remove(int index)
        {
            try
            {
                var toDelete = view.bindingList.ElementAt(index);
                view.bindingList.RemoveAt(index);
                if (toDelete.id > 0)
                {
                    ur.Delete(toDelete.id);
                }
            }
            catch
            {

            }
        }
    }
}
