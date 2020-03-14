using AdminForm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminForm.Interfaces
{
    public interface ISong
    {
        songs songs { get; set; }

        BindingList<songs> songlist { get; set; }

        string errorMsg { get; set; }
    }
}
