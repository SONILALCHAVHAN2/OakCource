using BLL;
using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace UI.Areas.Admin.Controllers
{
    public class SocialMediaController : Controller
    {
        SocialMediaBLL bll = new SocialMediaBLL();
        // GET: Admin/SocialMedia
        public ActionResult AddSocialMedia()
        {
            SocialMediaDTO model = new SocialMediaDTO();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddSocialMedia(SocialMediaDTO model)
        {
            if (model.SocialImage == null)
            {
                ViewBag.ProcessState = General.Message.ImageMissing;

            }
            else if (ModelState.IsValid)
            {
                HttpPostedFileBase postedFile = model.SocialImage;
                //GET IMAGE FROM INPUT STRING
                Bitmap SocialMedia = new Bitmap(postedFile.InputStream);
                string ext = Path.GetExtension(postedFile.FileName);
                string filename = "";

                if (ext == ".jpg" || ext == ".jpeg" || ext == ".gif")
                {
                    string uniquenumber = Guid.NewGuid().ToString();
                    filename = uniquenumber + postedFile.FileName;
                    SocialMedia.Save(Server.MapPath("~/Areas/Admin/Content/SocialMediaImages/" + filename));
                    model.ImagePath = filename;

                    if (bll.AddSocialMedia(model))
                    {
                        ViewBag.ProcessState = General.Message.AddSuccess;
                        model = new SocialMediaDTO();
                        ModelState.Clear();
                    }
                    else
                    {
                        ViewBag.ProcessState = General.Message.GenaralErorr;
                    }
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

        public ActionResult SocialMediaList()
        {
            List<SocialMediaDTO> dtolist = new List<SocialMediaDTO>();
            dtolist = bll.GetSocialMedias();
            return View(dtolist);
        }

        public ActionResult UpdateSocialMedia(int ID)
        {
            SocialMediaDTO dto = bll.GetSocialMediaWithID(ID);
            return View(dto);
        }

        [HttpPost]
        public ActionResult UpdateSocialMedia(SocialMediaDTO model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ProcessState = General.Message.EmptyArea;
            }
            else
            {
                if (model.SocialImage != null)
                {

                    HttpPostedFileBase postedFile = model.SocialImage;
                    //GET IMAGE FROM INPUT STRING
                    Bitmap SocialMedia = new Bitmap(postedFile.InputStream);
                    string ext = Path.GetExtension(postedFile.FileName);
                    string filename = "";

                    if (ext == ".jpg" || ext == ".jpeg" || ext == ".gif")
                    {
                        string uniquenumber = Guid.NewGuid().ToString();
                        filename = uniquenumber + postedFile.FileName;
                        SocialMedia.Save(Server.MapPath("~/Areas/Admin/Content/SocialMediaImages/" + filename));
                        model.ImagePath = filename;

                    }
                }
                string oldImagePath = bll.UpdateSocialMedia(model);
                if (model.SocialImage != null)
                {
                    if (System.IO.File.Exists(Server.MapPath("~/Areas/Admin/Content/SocialMediaImages/" + oldImagePath)))
                    {
                        System.IO.File.Delete(Server.MapPath("~/Areas/Admin/Content/SocialMediaImages/" + oldImagePath));
                    }
                }
                ViewBag.ProcessState=General.Message.UpdateSuccess;
            }

            return View(model);
        }
    }
}