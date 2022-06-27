using Fotros_Store.Application.Interfaces.Contexts;
using Fotros_Store.Common.Dto;
using Fotros_Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fotros_Store.Application.Services.Users.Commands.RgegisterUser
{
    public interface IRgegisterUserService
    {
        ResultDto<ResultRgegisterUserDto> Execute(ReqestRgegisterUserDto request);
    }
    public class RgegisterUserService : IRgegisterUserService
    {
        private readonly IDataBaseContext _context;
        public RgegisterUserService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultRgegisterUserDto> Execute(ReqestRgegisterUserDto request)
        {
            User user = new User()
            {
                Email = request.Email,
                FullName = request.FullName,
            };
            List<UserInRole> userInRoles = new List<UserInRole>();
            foreach (var item in request.roles)
            {
                var roles = _context.Roles.Find(item.Id);
                userInRoles.Add(new UserInRole
                {
                    Role = roles,
                    RoleId = roles.Id,
                    User = user,
                    UserId = user.Id,
                });
            }
            user.UserInRoles = userInRoles;
            _context.Users.Add(user);
            _context.SaveChanges();

            return new ResultDto<ResultRgegisterUserDto>()
            {
                Data = new ResultRgegisterUserDto()
                {
                    UserId = user.Id,

                },
                IsSuccess = true,
                Message = "ثبت نام کاربر انجام شد",
            };
        }
    }

    public class ReqestRgegisterUserDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<RolesInRgegisterUserDto> roles { get; set; }
    }
    public class RolesInRgegisterUserDto
    {
        public long Id { get; set; }
    }
    public class ResultRgegisterUserDto
    {
        public long UserId { get; set; }
    }
}
