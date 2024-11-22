using System.Text.Json.Serialization;

namespace ApplicationCore.Responses;

public class Response<TData>
{
    private readonly int _code = Configuration.DefaultStatusCode;

    [JsonConstructor]
    public Response()
        => _code = Configuration.DefaultStatusCode;
    
    public Response(
        TData? data,
        int code = Configuration.DefaultStatusCode,
        string? message = null)
    {
        Data = data;
        _code = code;
        Message = message;
    }

    public TData? Data { get; protected set; }
    public string? Message { get; protected set; }

    [JsonIgnore]
    public bool IsSuccess => _code is >= 200 and <= 299;
}