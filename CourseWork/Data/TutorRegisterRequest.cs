using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CourseWork.Models;
using System.ComponentModel.DataAnnotations;

namespace CourseWork.Data
{
    public class TutorRegisterRequest
    {
        [Key]
        public string  RequestId { get; set; }
        //public virtual ApplicationUser ReqestedUser { get; set; }
    }
}