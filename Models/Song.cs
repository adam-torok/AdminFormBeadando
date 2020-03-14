using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminForm.Models
{
    public partial class songs
    {
        public songs(int id, string artist, string name, string genre, string filename, string covername, string uploadedby, DateTime time, bool approved)
        {
            this.id = id;
            this.artist = artist;
            this.name = name;
            this.genre = genre;
            this.filename = filename;
            this.covername = covername;
            this.uploadedby = uploadedby;
            this.time = time;
            this.approved = approved;
        }

 
    }
}
