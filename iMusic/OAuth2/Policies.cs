﻿using System;
using Microsoft.AspNetCore.Authorization;

namespace iMusic.OAuth2
{
    public static class Policies
    {
        public const string User = "User";

        public static AuthorizationPolicy UserPolicty()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(User).Build();
        }
    }
}
