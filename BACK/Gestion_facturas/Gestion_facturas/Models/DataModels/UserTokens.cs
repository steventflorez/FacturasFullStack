﻿using NuGet.Common;

namespace Gestion_facturas.Models.DataModels
{
    public class UserTokens
    { 
        public int Id { get; set; }
        public string? Token { get; set; }
        public string? UserName { get; set; }
        public TimeSpan Validity { get; set; }
        public string? RedreshToken { get; set; }
        public string? EmailId { get; set; }
        public Guid GuidId { get; set; }
        public DateTime ExpiredTime { get; set; }

    }
}
