namespace API.Utilities.Handlers;

public class ResponseValidatorHandler
{
    public int Code { get; set; }
    public string Status { get; set; }
    public string Message { get; set; }
    public string[] Errors { get; set; }
}