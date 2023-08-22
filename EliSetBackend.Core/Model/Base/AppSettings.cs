using System;
using System.Collections.Generic;
using System.Text;

namespace EliSetBackend.Core.Model.Base
{
    public class AppSettings
    {
        public string TokenSecret { get; set; }
        public int TokenValidateInMinutes { get; set; }
        public string AppUserName { get; set; }
        public string AppPassword { get; set; }
        public string PublishImagePath { get; set; }
        public string SaveImagePath { get; set; }


    }
}
