﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Users.ViewModels.IdentityViewModels
{
    public class RoleModificationViewModel
    {
        [Required]
        public string RoleName { get; set; }

        [Required]
        public bool IsAvailableForAdministrators { get; set; }

        public string[] IdsToAdd { get; set; }

        public string[]IdsToDelete { get; set; }
    }
}