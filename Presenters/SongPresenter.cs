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
    class SongPresenter
    {
        ISong view;
        SongRepo sr = new SongRepo();

        public SongPresenter(ISong param)
        {
            view = param;
        }
        public void LoadData()
        {

        }
        public void Add(songs song)
        {
            view.songlist.Add(song);
            sr.Insert(song);
        }
        public void Save(songs song)
        {
            if (sr.Exists(song))
            {
                try
                {
                    sr.Update(song);
                }
                catch (Exception ex)
                {
                    view.errorMsg = ex.Message;
                }
            }
            else
            {
                try
                {
                    sr.Insert(song);
                }
                catch (Exception ex)
                {
                    view.errorMsg = ex.Message;
                }
            }
        }
    }
}
