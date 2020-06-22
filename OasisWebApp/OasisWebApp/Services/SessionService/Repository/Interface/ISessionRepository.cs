using OasisWebApp.Database.Entities;
using OasisWebApp.Interfaces;
using OasisWebApp.Services.SessionService.Repository.Filter;

namespace OasisWebApp.Services.SessionService.Repository.Interface
{
    public interface ISessionRepository :
        ICreate<Session>,
        IGet<Session, SessionFilter, int>,
        IFind<Session, SessionFilter>,
        IUpdate<Session>,
        IDelete<int>
    {
    }
}
