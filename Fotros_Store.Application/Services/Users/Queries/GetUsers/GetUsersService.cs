﻿using Fotros_Store.Application.Interfaces.Contexts;
using Fotros_Store.Common;
using System.Collections.Generic;
using System.Linq;

namespace Fotros_Store.Application.Services.Users.Queries.GetUsers
{
    public class GetUsersService : IGetUsersService
    {
        private readonly IDataBaseContext _context;
        public GetUsersService(IDataBaseContext context)
        {
            _context = context;
        }
        public ReslutGetUserDto Execute(RequestGetUserDto request)
        {
            var users = _context.Users.AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.SearchKey))
            {
                users = users.Where(p => p.FullName.Contains(request.SearchKey) && p.Email.Contains(request.SearchKey));
            }
            int rowsCount = 0;
            var usersList = users.ToPaged(request.Page, 20, out rowsCount).Select(p => new GetUsersDto
            {
                Email = p.Email,
                FullName = p.FullName,
                Id = p.Id,
            }).ToList();
            return new ReslutGetUserDto
            {
                Rows = rowsCount,
                Users = usersList,
            };
        }
    }
}
