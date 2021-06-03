using DesafioFWK_Application.Interfaces;
using DesafioFWK_Application.ViewModel.Fruits;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DesafioFWK.API.Fruit.Controllers
{
    [ApiController]
    [Authorize]
    [Produces("application/json")]
    public class FruitController : MainController
    {
        private readonly IFruitAppService _fruitAppService;

        public FruitController(IFruitAppService fruitAppService, IUser user) : base(user)
        {
            _fruitAppService = fruitAppService;
        }

        [HttpGet]
        [Route("v1/desafio/fruits")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _fruitAppService.GetAll();

            return Ok(result);
        }

        [HttpGet]
        [Route("v1/desafio/fruit/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _fruitAppService.GetById(id);

            return (result != null)
                ? Ok(result)
                : NoContent();
        }

        [HttpPost]
        [Route("v1/desafio/fruit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromBody] FruitAddViewModel fruit)
        {

            var imagemNome = Guid.NewGuid() + "_" + fruit.Imagem;
            if (!UploadArquivo(fruit.ImagemUpload, imagemNome))
                BadRequest(fruit);

            fruit.Imagem = imagemNome;

            var result = await _fruitAppService.Add(fruit);
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpPut]
        [Route("v1/desafio/fruit/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromBody] FruitUpdateViewModel fruit)
        {
            var result = await _fruitAppService.Update(fruit);
            return result.IsValid
                ? Ok()
                : BadRequest(result);
        }

        [HttpPut]
        [Route("v1/desafio/fruit/sell/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> SellFruit(Guid id)
        {
            var result = await _fruitAppService.SellFruit(id);

            return (result != null)
                ? Ok(result)
                : NoContent();
        }

        [HttpDelete]
        [Route("v1/desafio/fruit/delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _fruitAppService.Delete(id);

            return (result != null)
                ? Ok(result)
                : NoContent();
        }

        private bool UploadArquivo(string arquivo, string imgNome)
        {
            if (string.IsNullOrEmpty(arquivo))
                return false;

            var imageDataByteArray = Convert.FromBase64String(arquivo);

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", imgNome);

            if (System.IO.File.Exists(filePath))
                return false;


            System.IO.File.WriteAllBytes(filePath, imageDataByteArray);

            return true;
        }
    }
}
