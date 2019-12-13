﻿using System;
namespace graphConnect.Models
{
    public class GraphAuth
    {
        public string GrantType { get; set; }
        public string ClientID { get; set; }
        public string ClientSecret { get; set; }
        public string Scope { get; set; }
        public string TenatID { get; set; }
    }
}
