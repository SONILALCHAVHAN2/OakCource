using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class UserDAO:PostContext
    {
        public int AddUser(T_User user)
        {
            try
            {
                db.T_User.Add(user);
                db.SaveChanges();
                return user.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<UserDTO> GetUsers()
        {
            List<T_User> List = db.T_User.Where(X => X.IsDeleted == false).OrderBy(X=>X.AdDate).ToList();

            List<UserDTO> UserList = new List<UserDTO>();
            foreach (T_User user in List)
            {
                UserDTO dto=new UserDTO();
                dto.ID = user.ID;
                dto.Name=user.Username;
                dto.Username=user.Username;
                dto.ImagePath = user.ImagePath;
                //WE DONT NEED OTHER INFORMATION TO SHOW.
                UserList.Add(dto);
            }


            return UserList;

        }

        public UserDTO GetUserWithUsernameAndPassword(UserDTO model)
        {
            UserDTO dto = new UserDTO();
            T_User user = db.T_User.FirstOrDefault(X=>X.Username==model.Username && X.Password==model.Password);
            if(user!=null && user.ID != 0)
            {
                dto.ID = user.ID;
                dto.Username = user.Username;
                dto.Name = user.NamSurname;
                dto.ImagePath=user.ImagePath;
                dto.IsAdmin=user.IsAdmin;
            }
            return dto;
        }
    }
}
