using DesafioFWK_Application.Interfaces;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFWK.API.Fruit.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        public ValidationResult validation = new ValidationResult();
        public readonly IUser AppUser;
        protected Guid UsuarioId { get; set; }
        protected bool UsuarioAutenticado { get; set; }

        protected MainController(IUser appUser)
        {
            AppUser = appUser;

            if (appUser.IsAuthenticated())
            {
                UsuarioId = appUser.GetUserId();
                UsuarioAutenticado = true;
            }
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (validation.IsValid)
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = validation.Errors
            });
        }
    }
}
