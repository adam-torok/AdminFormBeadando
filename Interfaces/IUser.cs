using AdminForm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminForm.Interfaces
{
    public interface IUser
    {
        felhasznalo felhasznalo { get; set; }

        BindingList<felhasznalo> felhlist { get; set; }

        string errorMsg { get; set; }
    }
}
