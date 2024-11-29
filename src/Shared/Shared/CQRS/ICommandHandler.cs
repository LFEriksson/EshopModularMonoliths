using MediatR;

namespace Shared.CQRS;

public interface ICommandHandler<in TCommand> : ICommandHandler<TCommand, Unit>
    where TCommand : ICommand<Unit>
{
}

public interface ICommandHandler<in TCommand, TRespose> : IRequestHandler<TCommand, TRespose>
    where TCommand : ICommand<TRespose>
    where TRespose : notnull
{
}
