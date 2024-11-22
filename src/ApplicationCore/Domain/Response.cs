using System.Text.Json.Serialization;

namespace ApplicationCore.Domain;

public class Response<TData>
{
    private readonly int _code = Configuration.DefaultStatusCode;

    public TData? Data { get; protected set; }
    public string? Message { get; protected set; }

    [JsonIgnore]
    public bool IsSuccess => _code is >= 200 and <= 299;
    
    [JsonConstructor]
    public Response() => _code = Configuration.DefaultStatusCode;
    
    public Response(
        TData? data,
        int code = Configuration.DefaultStatusCode,
        string? message = null)
    {
        Data = data;
        _code = code;
        Message = message;
    }
}