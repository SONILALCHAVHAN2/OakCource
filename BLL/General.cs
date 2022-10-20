using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class General
    {
        public static class ProcessType
        {
            public static int Login = 1;
            public static int AddresSAdd = 2;
            public static int AddresUpdated = 3;
            public static int AddressDeleted = 4;


            public static int AdsAdd = 5;
            public static int AdsUpdated = 6;
            public static int AdsDeleted = 7;

            public static int CategoryAdded = 8;
            public static int CategoryUpdated = 9;
            public static int Categorydeleted = 10;

            public static int IconAdded = 11;
            public static int IconUpdated = 12;
            public static int IconDeleted = 13;
            public static int MetaAdd = 14;
            public static int MetaUpdated = 15;
            public static int MetaDeleted = 16;
            public static int SocialAdd = 17;
            public static int SocialUpdated = 18;
            public static int SocialDeleted = 19;
            public static int UserAdded = 20;
            public static int UserUpdated = 21;
            public static int UserDeleted = 22;

            public static int VideoAdded = 23;
            public static int VideosUpdated = 24;
            public static int VideoDeleted = 25;
            public static int PostAdded = 26;
            public static int PostUpdated = 27;
            public static int PostDeleted = 28;
            public static int ImageAdded = 29;
            public static int ImageUpdated = 30;
            public static int ImageDeleted = 31;
            public static int TagAdded = 32;
            public static int TagUpdated = 33;
            public static int TagDeleted = 34;
            public static int CommentAproved = 35;
            public static int CommentDelete = 36;
            public static int ContactRead = 37;
            public static int ContactDelete = 38;


        }
        public static class TablesName
        {
            public static string Login = "Login";
            public static string Address = "Address";
            public static string Ads = "Ads";
            public static string Category = "Category";
            public static string Icon = "Icon";
            public static string Meta = "Meta";
            public static string Social = "Social";
            public static string User = "User";
            public static string Post = "Post";
            public static string Image = "Image";
            public static string Tag = "Tag";
            public static string Comment = "Comment";
            public static string Contatct = "Contact";
        }
        public static class Message
        {
            public static int AddSuccess = 1;
            public static int EmptyArea = 2;
            public static int UpdateSuccess = 3;
            public static int ImageMissing = 4;
            public static int ExtensionErorr = 5;
            public static int GenaralErorr = 6;
        }
    }
}
