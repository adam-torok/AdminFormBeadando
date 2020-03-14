using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminForm.Models
{
    public partial class felhasznalo { 
        public felhasznalo(int id, string felhnev, string jelszo, string email, string profile_image, DateTime time, string bio)
        {
            this.id = id;
            this.felhnev = felhnev;
            this.jelszo = jelszo;
            this.email = email;
            this.profile_image = profile_image;
            this.time = time;
            this.bio = bio;
        }      
    }
}
