//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _4H_VFMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class tblUserList
    {
        public int Id { get; set; }
        [DisplayName("Title")]
        public int uTitle { get; set; }
        [DisplayName("Firstname")]
        public string uFirstName { get; set; }
        [DisplayName("Lastname")]
        public string uLastName { get; set; }
        [DisplayName("Gender")]
        public int uGender { get; set; }
        [DisplayName("Position")]
        public int uPosition { get; set; }
        [DisplayName("TRN #")]
        public string uTrn { get; set; }
        [DisplayName("UserLogin")]
        public string uLogin { get; set; }
        [DisplayName("Password")]
        public string uPassword { get; set; }
        [DisplayName("CreatedBy")]
        public string createdBy { get; set; }
        [DisplayName("DateCreated")]
        public Nullable<System.DateTime> dateCreated { get; set; }
        [DisplayName("UpdatedBy")]
        public string updatedBy { get; set; }
        [DisplayName("DateUpdated")]
        public Nullable<System.DateTime> dateUpdated { get; set; }
        [DisplayName("DeletedBy")]
        public string deletedBy { get; set; }
        [DisplayName("DeleteFlag")]
        public string deleteFlag { get; set; }
        [DisplayName("DateDeleted")]
        public Nullable<System.DateTime> dateDeleted { get; set; }
    
        public virtual gender gender { get; set; }
        public virtual position position { get; set; }
        public virtual title title { get; set; }
    }
}