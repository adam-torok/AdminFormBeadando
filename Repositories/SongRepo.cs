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
            string search = null,
            string sortBy = null,
            bool ascending = true)
        {
            var query = context.songs.OrderBy(x => x.id).AsQueryable();


            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower();
                query = query.Where(x => x.artist.ToLower().Contains(search) ||
                                     x.covername.ToLower().Contains(search) ||
                                     x.filename.ToLower().Contains(search) ||
                                     x.genre.ToLower().Contains(search) ||
                                     x.name.ToLower().Contains(search) ||
                                     x.uploadedby.ToLower().Contains(search));
            }

            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                switch (sortBy)
                {
                    default:
                        query = ascending ? query.OrderBy(x => x.id) : query.OrderByDescending(x => x.id);
                        break;
                    case "artist":
                        query = ascending ? query.OrderBy(x => x.artist) : query.OrderByDescending(x => x.artist);
                        break;
                    case "covername":
                        query = ascending ? query.OrderBy(x => x.covername) : query.OrderByDescending(x => x.covername);
                        break;
                    case "filename":
                        query = ascending ? query.OrderBy(x => x.filename) : query.OrderByDescending(x => x.filename);
                        break;
                    case "genre":
                        query = ascending ? query.OrderBy(x => x.genre) : query.OrderByDescending(x => x.genre);
                        break;
                    case "name":
                        query = ascending ? query.OrderBy(x => x.name) : query.OrderByDescending(x => x.name);
                        break;
                    case "time":
                        query = ascending ? query.OrderBy(x => x.time) : query.OrderByDescending(x => x.time);
                        break;
                    case "uploadedby":
                        query = ascending ? query.OrderBy(x => x.uploadedby) : query.OrderByDescending(x => x.uploadedby);
                        break;
                }
            }

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

        public List<songs> getGenre()
        {
            using (var ctx = new adatbazis())
            {
                var songLista = ctx.songs
                                    .SqlQuery("Select * from songs")
                                    .ToList<songs>();
                return songLista;

            }
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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
    }
 }


