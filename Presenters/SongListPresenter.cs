﻿using AdminForm.Interfaces;
using AdminForm.Models;
using AdminForm.Repositories;
using AdminForm.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminForm.Presenters
{
    class SongListPresenter
    {
        private ISongList view;
        private SongRepo ur = new SongRepo();

        public SongListPresenter(ISongList param)
        {
            view = param;
        }

        public void LoadData()
        {
            view.songLista = ur.getAllSongs(view.pageNumber, view.itemsPerPage, view.search, view.sortBy, view.ascending);
            view.totalItems = ur.Count();
        }

        public void Save()
        {
            ur.Save();
        }

        public void Add(songs song)
        {
            view.songLista.Add(song);
            ur.Insert(song);
        }

        public void Modify(songs song)
        {
            ur.Update(song);
        }


        public void Remove(int index)
        {
            var toDelete = view.songLista.ElementAt(index);
            view.songLista.RemoveAt(index);
            if (toDelete.id > 0)
            {
                ur.Delete(toDelete.id);
            }
        }
    }
}
