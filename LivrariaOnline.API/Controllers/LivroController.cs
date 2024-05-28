using LivrariaOnline.Application.UseCases.Livros;
using LivrariaOnline.Application.UseCases.Livros.DeleteById;
using LivrariaOnline.Application.UseCases.Livros.GetById;
using LivrariaOnline.Application.UseCases.Livros.Register;
using LivrariaOnline.Application.UseCases.Livros.UpdateById;
using LivrariaOnline.Communication.Requests;
using LivrariaOnline.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace LivrariaOnline.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LivroController : ControllerBase
{
    [HttpGet]
    [Route("{idLivro}")]
    [ProducesResponseType(typeof(ResponseGetLivroByIdJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public IActionResult Get([FromRoute] Guid idLivro)
    {
        var useCase = new GetLivroByIdUseCase();
        var response = useCase.Execute(idLivro);

        return Ok(response);
    }

    [HttpGet("get-all-livros")]
    [ProducesResponseType(typeof(ResponseAllLivrosJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public IActionResult GetAll()
    {
        var useCase = new GetAllLivrosUseCase();
        var response = useCase.Execute();

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status409Conflict)]
    public IActionResult Register([FromBody] RequestRegisterLivroJson request)
    {
        var useCase = new RegisterLivroUseCase();
        var response = useCase.Execute(request);

        return Created(string.Empty, response);
    }

    [HttpPut]
    [Route("{idLivro}")]
    [ProducesResponseType(typeof(ResponseUpdateLivroJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public IActionResult Update([FromRoute] Guid idLivro, [FromBody] RequestUpdateLivroJson request)
    {
        var useCase = new UpdateLivroByIdUseCase();
        var response = useCase.Execute(idLivro, request);

        return Ok(response);
    }

    [HttpDelete]
    [Route("{idLivro}")]
    [ProducesResponseType(typeof(ResponseSuccessJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public IActionResult Delete([FromRoute] Guid idLivro)
    {
        var useCase = new DeleteLivroByIdUseCase();
        var response = useCase.Execute(idLivro);

        return Ok(response);
    }
}
