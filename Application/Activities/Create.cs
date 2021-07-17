using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Create
    {
        //It does not return anything, but it needs the actual Activity
        public class Comand : IRequest
        {
            public Activity Activity { get; set; }
        }

        public class Handler : IRequestHandler<Comand>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Comand request, CancellationToken cancellationToken)
            {
                _context.Activities.Add(request.Activity);

                await _context.SaveChangesAsync();
                
                return Unit.Value;
            }
        }

    }
}