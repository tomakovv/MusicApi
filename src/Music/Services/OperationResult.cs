using AutoMapper;
using Music.Data.Entities;
using Music.Data.Repositories.Interfaces;
using Music.Dto.Genre;
using Music.Dto.Song;
using Music.Services.Interfaces;

namespace Music.Services
{
    public enum OperationStatus
    {
        Success,
        Fail
    }

    public class OperationResult
    {
        protected OperationResult(OperationStatus status, string errorMessage = null)
        {
            Status = status;    
            ErrorMessage = errorMessage;
        }

        public OperationStatus Status { get; private set; }
        public string ErrorMessage { get; private set; }

        public static OperationResult Success() => new OperationResult(OperationStatus.Success);
        public static OperationResult Fail(string errorMessage) => new OperationResult(OperationStatus.Fail, errorMessage);
    }

    public class OperationResult<T> : OperationResult
    {
        private OperationResult(T value) : base(OperationStatus.Success)
        {
            Value = value;
        }

        private OperationResult(string errorMessage) : base(OperationStatus.Fail, errorMessage)
        {
        }

        public T Value { get; private set; }

        public static OperationResult<T> Success<T>(T value) => new OperationResult<T>( value);
        public static OperationResult<T> Fail(string errorMessage) => new OperationResult<T>(errorMessage);

    }
}