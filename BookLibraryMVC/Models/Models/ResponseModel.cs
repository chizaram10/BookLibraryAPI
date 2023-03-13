using System.Collections.Generic;
using System;

namespace BookLibraryMVC.Models.Models
{
    public class ResponseModel
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public DateTime? ExpireTime { get; set; }
    }
}
