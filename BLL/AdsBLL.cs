using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AdsBLL
    {
        AdsDAO dao=new AdsDAO();
        public void AddAds(AdsDTO model)
        {
            Ad ads = new Ad();
            ads.Name = model.Name;
            ads.Link = model.Link;
            ads.ImagePath = model.ImagePath;
            ads.Size=model.ImageSize;
            ads.AddDate=DateTime.Now;
            ads.LastUpdateUserID = UserStatic.UserID;
            ads.LastUpdateDate = DateTime.Now;
            //for log operation we need the id parameter.
            int ID = dao.AddAds(ads);
            LogDAO.AddLog(General.ProcessType.AdsAdd,General.TablesName.Ads,ID);
        }
    }
}
