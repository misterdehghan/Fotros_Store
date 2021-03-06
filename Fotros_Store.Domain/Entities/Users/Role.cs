using System.Collections.Generic;

namespace Fotros_Store.Domain.Entities.Users
{
    public class Role
    {
        public long Id { get; set; }
        public string  Name { get; set; }
        public ICollection<UserInRole > UserInRoles { get; set; }
    }
}
