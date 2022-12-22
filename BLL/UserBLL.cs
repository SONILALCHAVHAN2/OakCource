using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserBLL
    {
        UserDAO userdao=new UserDAO();

        public void AddUser(UserDTO model)
        {
            T_User user = new T_User();
            user.Username = model.Username;
             
            user.Password = model.Password;
            user.Email = model.Email;
            user.ImagePath = model.ImagePath;
            user.NamSurname=model.Name;
            user.IsAdmin=model.IsAdmin;
            user.AdDate = DateTime.Now;
            user.LastUpdate = DateTime.Now;
            user.IsDeleted = false;
            user.LastUpdateUserID = UserStatic.UserID;
            int ID = userdao.AddUser(user);
            LogDAO.AddLog(General.ProcessType.UserAdded,General.TablesName.User,ID);
        }

        public List<UserDTO> GetUsers()
        {
            return userdao.GetUsers();
        }

        public UserDTO GetUserWithID(int ID)
        {
            return userdao.GetUserWithID(ID);
        }

        public UserDTO GetUserWithUsernameAndPassword(UserDTO model)
        {
            UserDTO dto=new UserDTO();
            dto=userdao.GetUserWithUsernameAndPassword(model);
            return dto;
        }

        public string UpdateUser(UserDTO model)
        {
            string oldImagePath = userdao.UpdateUser(model);
            LogDAO.AddLog(General.ProcessType.UserUpdated,General.TablesName.User,model.ID);
            return oldImagePath;
        }
    }
}

