using System;
using System.Collections.Generic;

namespace JwtTokenSample.Entity
{
    public partial class UserInfo
    {
        public string UserId { get; set; } = null!;
        public string? EmailId { get; set; }
        public string? UserName { get; set; }
        public int CompanyId { get; set; }
        public int? Location { get; set; }      
        public bool? IsActive { get; set; }
        public string? Roles { get; set; }
    }
}
