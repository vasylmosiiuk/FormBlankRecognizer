using System;
using System.Threading.Tasks;
using FormVision.Services.Abstractions.Repositories;
using Realms;

namespace FormVision.Services.Implementation.Repositories
{
    internal class RealmUnitOfWork : IUnitOfWork
    {
        private readonly Realm _realm;

        public RealmUnitOfWork(Realm realm)
        {
            _realm = realm;
        }

        public void ExecuteInTransactionScope(Action operationsToExecute)
        {
            _realm.Write(()=>operationsToExecute?.Invoke());
        }
    }
}