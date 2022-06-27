using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fotros_Store.Application.Services.Users.Queries.GetUsers
{
    public interface IGetUsersService
    {
        ReslutGetUserDto Execute(RequestGetUserDto request);
    }
}
