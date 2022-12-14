using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SocialMediaBLL
    {
        SocialMediaDAO dao=new SocialMediaDAO();

        public bool AddSocialMedia(SocialMediaDTO model)
        {
            SocialMedia social = new SocialMedia();
            social.Name=model.Name;
            social.Link=model.Link;
            social.ImagePath=model.ImagePath;
            social.AddDate=DateTime.Now;
            social.LastUpdateUserID = UserStatic.UserID;
            social.LastUpdateDate=DateTime.Now;
            int ID = dao.AddSocialMedia(social);
            LogDAO.AddLog(General.ProcessType.ImageAdded,General.TablesName.Social,ID);
            return true;
        }
        //dtail list
        public List<SocialMediaDTO> GetSocialMedias()
        {
           List<SocialMediaDTO> dtolist = new List<SocialMediaDTO>();
            dtolist = dao.GetSocialMedias();
            return dtolist;
        }

        //update
        public SocialMediaDTO GetSocialMediaWithID(int ID)
        {
            SocialMediaDTO dto = dao.GetSocialMediaWithID(ID);
            return dto;
        }

        public string UpdateSocialMedia(SocialMediaDTO model)
        {
            string oldImagePath = dao.UpdateSocialMedia(model);
            LogDAO.AddLog(General.ProcessType.SocialUpdated,General.TablesName.Social,model.ID);
            return oldImagePath;
        }
    }
}
