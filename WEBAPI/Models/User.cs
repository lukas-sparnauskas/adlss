﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WEBAPI.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Naudotojo duomenų klasė.
    /// </summary>
    public partial class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string card_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public int access_level { get; set; }
        public int work_hours_in_week { get; set; }
    }
}
