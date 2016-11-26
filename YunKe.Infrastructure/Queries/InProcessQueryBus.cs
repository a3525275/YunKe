using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunKe.Infrastructure.Queries
{
    public class InProcessQueryBus : IQueryBus
    {
        private readonly Container _componentContext;

        public InProcessQueryBus(Container container)
        {
            _componentContext = container;
        }

        public TQueryResult Send<TQuery, TQueryResult>(TQuery query)
        {
            IQueryHandler<TQuery, TQueryResult> queryHandler = _componentContext.GetInstance<IQueryHandler<TQuery, TQueryResult>>();
            Contract.Assert(queryHandler != null);

            return queryHandler.Handle(query);
        }
    }
}