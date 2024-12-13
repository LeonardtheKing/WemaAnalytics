﻿namespace Uplift.Application.Constants;

    public record BaseResponse<T>
    {
        public bool IsSuccess { get; set; } = true;
        public string StatusCode { get; set; } = ResponseCodes.Ok;
        public string Message { get; set; } = ResponseMessages.Ok;
        public T? Data { get; set; }
        public object? MetaData { get; set; }

        public static BaseResponse<T> Success(T data, string message = ResponseMessages.Ok, object? metaData = null)
        {
            return new BaseResponse<T>
            {
                StatusCode = ResponseCodes.Ok,
                IsSuccess = true,
                Message = message,
                Data = data,
                MetaData = metaData
            };
        }

        public static BaseResponse<T> NotFound(string message, object? metaData = null)
        {
            return new BaseResponse<T>
            {
                StatusCode = ResponseCodes.NotFound,
                IsSuccess = false,
                Message = message,
                Data = default,
                MetaData = metaData
            };
        }



        public static BaseResponse<T> BadRequest(string message, object? metaData = null)
        {
            return new BaseResponse<T>
            {
                StatusCode = ResponseCodes.BadRequest,
                IsSuccess = false,
                Message = message,
                Data = default,
                MetaData = metaData
            };
        }

        public static BaseResponse<T> Unauthorized(string message, object? metaData = null)
        {
            return new BaseResponse<T>
            {
                StatusCode = ResponseCodes.Unauthorized,
                IsSuccess = false,
                Message = message,
                Data = default,
                MetaData = metaData
            };
        }
    }

    public record BaseResponse
    {
        public bool IsSuccess { get; set; } = true;
        public string StatusCode { get; set; } = ResponseCodes.Ok;
        public string Message { get; set; } = ResponseMessages.Ok;
        public object? MetaData { get; set; }

        public static BaseResponse Success(string message = ResponseMessages.Ok, object? metaData = null)
        {
            return new BaseResponse
            {
                StatusCode = ResponseCodes.Ok,
                IsSuccess = true,
                Message = message,
                MetaData = metaData
            };
        }

        public static BaseResponse NotFound(string message, object? metaData = null)
        {
            return new BaseResponse
            {
                StatusCode = ResponseCodes.NotFound,
                IsSuccess = false,
                Message = message,
                MetaData = metaData
            };
        }

        public static BaseResponse BadRequest(string message, object? metaData = null)
        {
            return new BaseResponse
            {
                StatusCode = ResponseCodes.BadRequest,
                IsSuccess = false,
                Message = message,
                MetaData = metaData
            };
        }

        public static BaseResponse Unauthorized(string message, object? metaData = null)
        {
            return new BaseResponse
            {
                StatusCode = ResponseCodes.Unauthorized,
                IsSuccess = false,
                Message = message,
                MetaData = metaData
            };
        }
    }



