using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        UserBLL bll = new UserBLL();

        public ActionResult UserList()
        {
            List<UserDTO> model = new List<UserDTO>();
            model = bll.GetUsers();
            return View(model);
        }
        // GET: Admin/User
        public ActionResult AddUser()
        {

            UserDTO model = new UserDTO();

            return View(model);
        }

        [HttpPost]
        public ActionResult AddUser(UserDTO model)
        {
            if (model.UserImage == null)
            {
                ViewBag.ProcessState = General.Message.ImageMissing;
            }
            else if (ModelState.IsValid)
            {
                string filename = "";
                HttpPostedFileBase postedfile = model.UserImage;
                Bitmap UserImage = new Bitmap(postedfile.InputStream);
                Bitmap resizeImage = new Bitmap(UserImage, 128, 128);
                string ext = Path.GetExtension(postedfile.FileName);
                if (ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".gif")
                {
                    string UniqueNumber = Guid.NewGuid().ToString();
                    filename = UniqueNumber + postedfile.FileName;
                    resizeImage.Save(Server.MapPath("~/Areas/Admin/Content/UserImage/" + filename));
              
                    model.ImagePath = filename;
                    //model.ImagePath = resizeImage;
                    bll.AddUser(model);
                    ViewBag.ProcessState = General.Message.AddSuccess;
                    ModelState.Clear();
                    model = new UserDTO();
                }
                else
                {
                    ViewBag.ProcessState = General.Message.ExtensionErorr;
                }
            }
            else
            {
                ViewBag.ProcessState = General.Message.EmptyArea;
            }
            return View(model);
        }

    }


}