//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Contact
    {
        public int ID { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public Nullable<bool> ReadUserID { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<System.DateTime> DeleteDate { get; set; }
        public Nullable<int> LastUpdateUserID { get; set; }
        public Nullable<System.DateTime> LastUpadateDate { get; set; }
        public System.DateTime AddDate { get; set; }
    
        public virtual T_User T_User { get; set; }
    }
}
