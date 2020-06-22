using OasisWebApp.DTOs;
using OasisWebApp.Interfaces;
using OasisWebApp.Services.SessionService.Repository.Filter;

namespace OasisWebApp.Services.SessionService.Services.Interface
{
    public interface ISessionService :
        ICreate<SessionDto>,
        IGet<SessionDto, SessionFilter, int>,
        IFind<SessionDto, SessionFilter>,
        IUpdate<SessionDto>,
        IDelete<int>
    {
    }
}
