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
    public class UserPresenter
    {
        private IUser user;
        private IUserRepo ur;

        public UserPresenter(IUser param, IUserRepo userRepo)
        {
            ur = userRepo;
            user = param;
        }

        public void Save(felhasznalo felh)
        {
            user.errorMsg = null;
           
            if (ur.Exists(felh))
            {
                try
                {
                    ur.Update(felh);
                }
                catch (Exception ex)
                {
                    user.errorMsg = ex.Message;
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
                    user.errorMsg = ex.Message;
                }
            }
        }
    }
}
