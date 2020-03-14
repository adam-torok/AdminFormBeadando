using AdminForm.Interfaces;
using AdminForm.Models;
using AdminForm.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminForm.Presenters
{
    class UserPresenter
    {
        IUser view;
        UserRepo ur = new UserRepo();

        public UserPresenter(IUser param)
        {
            view = param;
        }

        public void Save(felhasznalo felh)
        {
            view.errorMsg = null;
           
            if (ur.Exists(felh))
            {
                try
                {
                    ur.Update(felh);
                }
                catch (Exception ex)
                {
                    view.errorMsg = ex.Message;
                }
            }
            else
            {
                try
                {
                    ur.Insert(felh);
                }
                catch(Exception ex)
                {
                    view.errorMsg = ex.Message;
                }
            }
        }
       
    }
}
