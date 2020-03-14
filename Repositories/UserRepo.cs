using AdminForm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminForm.Repositories
{
    class UserRepo
    {
        private adatbazis context = new adatbazis();
        private int _totalItems;

        public BindingList<felhasznalo> getAllUser(
            int page = 0,
            int itemsPerPage = 0,
            string search = null,
            string sortBy = null,
            bool ascending = true)
        {
            var query = context.felhasznalo.OrderBy(x => x.id).AsQueryable();

                
            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower();
                    query = query.Where(x => x.bio.ToLower().Contains(search) ||
                                         x.email.ToLower().Contains(search) ||
                                         x.felhnev.ToLower().Contains(search));
            }

            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                switch (sortBy)
                {
                    default:
                        query = ascending ? query.OrderBy(x => x.id) : query.OrderByDescending(x => x.id);
                        break;
                    case "felhnev":
                        query = ascending ? query.OrderBy(x => x.felhnev) : query.OrderByDescending(x => x.felhnev);
                        break;
                    case "password":
                        query = ascending ? query.OrderBy(x => x.jelszo) : query.OrderByDescending(x => x.jelszo);
                        break;
                    case "email":
                        query = ascending ? query.OrderBy(x => x.email) : query.OrderByDescending(x => x.email);
                        break;
                    case "time":
                        query = ascending ? query.OrderBy(x => x.time) : query.OrderByDescending(x => x.time);
                        break;
                    case "bio":
                        query = ascending ? query.OrderBy(x => x.bio) : query.OrderByDescending(x => x.bio);
                        break;
                }
            }
            _totalItems = query.Count();

            if (page + itemsPerPage > 0)
            {
                query = query.Skip((page - 1) * itemsPerPage).Take(itemsPerPage);
            }
            return new BindingList<felhasznalo>(query.ToList());
        }
        public int Count()
        {
            return _totalItems;
        }
        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(felhasznalo user)
        {
            var felh = context.felhasznalo.Find(user.id);
            if(felh != null)
            {
                context.Entry(felh).CurrentValues.SetValues(user);
            }
        }
        public bool Exists(felhasznalo user)
        {
            return context.felhasznalo.Any(x => x.id == user.id);
        }

        public void Delete(int id)
        {
            var user = context.felhasznalo.Find(id);
            context.felhasznalo.Remove(user);
        }

        public void Insert(felhasznalo user)
        {
            if(context.felhasznalo.Any(x => x.email == user.email) || context.felhasznalo.Any(x => x.felhnev == user.felhnev))
            {
              throw new Exception("Már létezik ilyen felhasználó!");
            }
            context.felhasznalo.Add(user);
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
