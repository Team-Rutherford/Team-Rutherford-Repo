//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JasenOracle
{
    using System;
    using System.Collections.Generic;
    
    public partial class ORA_ASPNET_MEMBERSHIP
    {
        public System.Guid APPLICATIONID { get; set; }
        public System.Guid USERID { get; set; }
        public string PASSWORD { get; set; }
        public decimal PASSWORDFORMAT { get; set; }
        public string PASSWORDSALT { get; set; }
        public string MOBILEPIN { get; set; }
        public string EMAIL { get; set; }
        public string LOWEREDEMAIL { get; set; }
        public string PASSWORDQUESTION { get; set; }
        public string PASSWORDANSWER { get; set; }
        public decimal ISAPPROVED { get; set; }
        public decimal ISLOCKEDOUT { get; set; }
        public System.DateTime CREATEDATE { get; set; }
        public System.DateTime LASTLOGINDATE { get; set; }
        public System.DateTime LASTPASSWORDCHANGEDDATE { get; set; }
        public System.DateTime LASTLOCKOUTDATE { get; set; }
        public decimal FAILEDPWDATTEMPTCOUNT { get; set; }
        public System.DateTime FAILEDPWDATTEMPTWINSTART { get; set; }
        public decimal FAILEDPWDANSWERATTEMPTCOUNT { get; set; }
        public System.DateTime FAILEDPWDANSWERATTEMPTWINSTART { get; set; }
        public string COMMENTS { get; set; }
    
        public virtual ORA_ASPNET_APPLICATIONS ORA_ASPNET_APPLICATIONS { get; set; }
        public virtual ORA_ASPNET_USERS ORA_ASPNET_USERS { get; set; }
    }
}
