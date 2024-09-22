using MT.Blog.Common.Functional.Optional;

namespace MT.Blog.Common.Functional;

public sealed class Result<T>
{
    private Result(bool isSuccess, Error error, T? value = default)
    {
        if (isSuccess && error != Error.None || !isSuccess && error == Error.None)
        {
            throw new ArgumentException("Attempt to create invalid error.", nameof(error));
        }

        IsSuccess = isSuccess;
        Error = error;
        Value = value is null ? None.Of<T>() : value;
    }

    public bool IsSuccess { get; }

    public bool IsError => !IsSuccess;

    public Error Error { get; }

    public Option<T> Value { get; }

    public static Result<T> Success(T? value = default) => new(true, Error.None, value);

    public static Result<T> Failure(Error error) => new(false, error);

    public static implicit operator Option<T>(Result<T> result) => result.Value;

    public static implicit operator Result<T>(T value) => Result<T>.Success(value);

    public static implicit operator Result<T>(Error error) => Result<T>.Failure(error);
}
