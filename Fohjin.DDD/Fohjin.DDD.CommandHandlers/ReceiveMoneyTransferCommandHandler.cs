using Fohjin.DDD.Commands;
using Fohjin.DDD.Domain.Account;
using Fohjin.DDD.EventStore;

namespace Fohjin.DDD.CommandHandlers
{
    public class ReceiveMoneyTransferCommandHandler : ICommandHandler<ReceiveMoneyTransferCommand>
    {
        private readonly IDomainRepository<IDomainEvent> _repository;

        public ReceiveMoneyTransferCommandHandler(IDomainRepository<IDomainEvent> repository)
        {
            _repository = repository;
        }

        public void Execute(ReceiveMoneyTransferCommand compensatingCommand)
        {
            var activeAccount = _repository.GetById<ActiveAccount>(compensatingCommand.Id);

            activeAccount.ReceiveTransferFrom(new AccountNumber(compensatingCommand.AccountNumber), new Amount(compensatingCommand.Amount));
        }
    }
}