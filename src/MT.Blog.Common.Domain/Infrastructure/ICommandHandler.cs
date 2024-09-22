using MediatR;
using MT.Blog.Common.Functional;

namespace MT.Blog.Common.Infrastructure;

public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result<Unit>>
    where TCommand : ICommand;

public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse>;
