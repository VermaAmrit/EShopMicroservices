using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBocks.CQRS
{
    public interface ICommandHandler<in TComand>
       : IRequestHandler<TComand, Unit>
         where TComand : ICommand<Unit>
    {

    }
    public interface ICommandHandler<in TComand, TResponse>
        : IRequestHandler<TComand, TResponse>
        where TComand : ICommand<TResponse>
        where TResponse : notnull
    {
    }
}
