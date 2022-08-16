﻿using Infera_WebApi.Requests.Base;
using System.ComponentModel.DataAnnotations;

namespace Infera_WebApi.Requests.UserRole
{
    public class UserRoleDeleteRequest : BaseRequest
    {
        [Required]
        public int RoleId { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
