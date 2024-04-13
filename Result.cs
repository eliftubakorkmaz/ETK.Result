﻿using System.Net;

namespace ETK.Result;
public sealed class Result<T>
{
    public T? Data { get; set; }
    public List<string?> ErrorMessages { get; set; }
    public bool IsSucceessful { get; set; } = true;
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
    public Result(T data)
    {
        Data = data;
    }
    public Result(HttpStatusCode statusCode, List<string> errorMessages)
    {
        IsSucceessful = false;
        StatusCode = statusCode;
        ErrorMessages = errorMessages;
    }
    public Result(HttpStatusCode statusCode, string errorMessage)
    {
        IsSucceessful = false;
        StatusCode = statusCode;
        ErrorMessages = new() { errorMessage };
    }
    public static implicit operator Result<T>(T data)
    {
        return new(data);
    }

    public static implicit operator Result<T>((HttpStatusCode statusCode, List<string> errorMessages) parameters)
    {
        return new(parameters.statusCode, parameters.errorMessages);
    }

    public static implicit operator Result<T>((HttpStatusCode statusCode, string errorMessage) parameters)
    {
        return new(parameters.statusCode, parameters.errorMessage);
    }
}
