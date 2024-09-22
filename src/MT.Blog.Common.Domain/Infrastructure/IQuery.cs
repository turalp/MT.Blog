using MediatR;
using MT.Blog.Common.Functional;

namespace MT.Blog.Common.Infrastructure;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
