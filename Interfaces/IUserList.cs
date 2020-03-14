using AdminForm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminForm.Interfaces
{
    interface IUserList : IDataGridList<felhasznalo>
    {
        BindingList<felhasznalo> userLista { get; set; }
    }
}
