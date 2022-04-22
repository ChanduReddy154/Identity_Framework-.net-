﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Hrms.Repository.Models
{
    public partial class RefreshToken
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public string JwtId { get; set; }
        public bool IsRevoked { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateExpire { get; set; }
        public string UserId { get; set; }

        public virtual AspNetUser User { get; set; }
    }
}
