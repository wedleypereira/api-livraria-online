namespace LivrariaOnline.Communication.Responses;

public class ResponseSuccessJson
{
    public string Message { get; set; } = string.Empty;

    public ResponseSuccessJson(string message)
    {
        Message = message;
    }
}
