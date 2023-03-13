using System;
using System.Collections.Generic;
using System.Text;

namespace BookLibraryAPI.Domain.DTOs
{
    public class Response
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public DateTime? ExpireTime { get; set; }
    }
}
