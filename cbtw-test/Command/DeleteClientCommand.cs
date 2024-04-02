using MediatR;

namespace cbtw_test.Command
{
    public class DeleteClientCommand : IRequest<bool>
    {
        public Guid Id { get; }

        public DeleteClientCommand(Guid id)
        {
            Id = id;
        }
    }
}
