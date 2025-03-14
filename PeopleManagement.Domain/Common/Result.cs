using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManagement.Domain.Common
{
    public class Result<T> {
        public bool IsSuccess { get; }
        public bool HasError => !IsSuccess;
        public T Value { get; }
        public string Error { get; }
        public string ErrorDescription { get; }

        private Result(bool isSuccess, T value, string error, string errorDescription = "") {
            IsSuccess = isSuccess;
            Value = value;
            Error = error;
            ErrorDescription = errorDescription;
        }

        public static Result<T> Success(T value) => new Result<T>(true, value, string.Empty);
        public static Result<T> Failure(string error, string errorDescription = "") => new Result<T>(false, default, error, errorDescription);
    }

}
