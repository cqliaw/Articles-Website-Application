using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Articles_Website_Application.Class
{
    public class AWSCredentials
    {
        [Key]
        public int ID { get; set; }
        public string AccessKey{get;set;}

        public string SecretKey { get; set; }
    }
}