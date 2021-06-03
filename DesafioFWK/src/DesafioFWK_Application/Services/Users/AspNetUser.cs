﻿using System;
using System.Collections.Generic;
using System.Security.Claims;
using DesafioFWK_Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace DesafioFWK_Application.Services.Users
{
    public class AspNetUser : IUser
    {
        private readonly IHttpContextAccessor _accessor;

        public AspNetUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string Name => _accessor.HttpContext.User.Identity.Name;

        public Guid GetUserId()
            => IsAuthenticated() ? Guid.Parse(_accessor.HttpContext.User.GetUserId()) : Guid.Empty;


        public string GetUserEmail()
            => IsAuthenticated() ? _accessor.HttpContext.User.GetUserEmail() : "";


        public bool IsAuthenticated()
            => _accessor.HttpContext.User.Identity.IsAuthenticated;


        public bool IsInRole(string role)
            => _accessor.HttpContext.User.IsInRole(role);


        public IEnumerable<Claim> GetClaimsIdentity()
            => _accessor.HttpContext.User.Claims;

    }

    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentException(nameof(principal));


            var claim = principal.FindFirst(ClaimTypes.NameIdentifier);
            return claim?.Value;
        }

        public static string GetUserEmail(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentException(nameof(principal));


            var claim = principal.FindFirst(ClaimTypes.Email);
            return claim?.Value;
        }
    }
}
