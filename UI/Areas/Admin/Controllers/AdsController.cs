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
   
    public class AdsController : Controller
    {
        AdsBLL bll = new AdsBLL();
        // GET: Admin/Ads
        public ActionResult AddAds()
        {
            AdsDTO dto = new AdsDTO();
            return View(dto);
        }
        [HttpPost]
        public ActionResult AddAds(AdsDTO model)
        {

            //Add ads Image oparation.
            if (model.AdsImage == null)
            {
                ViewBag.ProcessState = General.Message.ImageMissing;
            }
            else if (ModelState.IsValid)
            {

                string filename = "";
                HttpPostedFileBase postedfile = model.AdsImage;
                Bitmap UserImage = new Bitmap(postedfile.InputStream);
                Bitmap resizeImage = new Bitmap(UserImage, 128, 128);
                string ext = Path.GetExtension(postedfile.FileName);
                if (ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".gif")
                {
                    string UniqueNumber = Guid.NewGuid().ToString();
                    filename = UniqueNumber + postedfile.FileName;
                    resizeImage.Save(Server.MapPath("~/Areas/Admin/Content/AdsImage/" + filename));

                    model.ImagePath = filename;
                    //SQL OPRATION
                    bll.AddAds(model);
                    ViewBag.ProcessState=General.Message.AddSuccess;
                    ModelState.Clear();
                    model=new AdsDTO();
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
