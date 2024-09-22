using MediatR;
using MT.Blog.Common.Functional;

namespace MT.Blog.Common.Infrastructure;

public interface ICommand : IRequest<Result<Unit>>;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>;
