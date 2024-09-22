using MediatR;
using MT.Blog.Common.Functional;

namespace MT.Blog.Common.Infrastructure;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;
