using AdminForm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminForm.Repositories
{
    class SongRepo
    {
        private adatbazis context = new adatbazis();
        private int _totalItems;

        public BindingList<songs> getAllSongs
        (
             int page = 0,
            int itemsPerPage = 0,
            string sortBy = null,
            bool ascending = true)
        {
            var query = context.songs.OrderBy(x => x.id).AsQueryable();

            _totalItems = query.Count();

            if (page + itemsPerPage > 0)
            {
                query = query.Skip((page - 1) * itemsPerPage).Take(itemsPerPage);
            }
            return new BindingList<songs>(query.ToList());
        }

        public int Count()
        {
            return _totalItems;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(songs song)
        {
            var csong = context.songs.Find(song.id);
                if(csong != null)
                {
                    context.Entry(csong).CurrentValues.SetValues(song);
                }
        }

        public bool Exists(songs song)
        {
            return context.songs.Any(x => x.id == song.id);
        }
        
        public void Delete(int id)
        {
            var csong = context.songs.Find(id);
            context.songs.Remove(csong);
        }

        public void Insert(songs song)
        {
            if(context.songs.Any(x=> x.name == song.name))
            {
                throw new Exception("Már létezik ilyen nevű szám!");
            }
            context.songs.Add(song);
        }
     }
 }


