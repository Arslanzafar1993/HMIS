using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMIS.Authentication
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public ApplicationRole() : base() { }

        public ApplicationRole(string name) : base(name) { }

        public int ProgramId { get; set; }

        public int CategoryId { get; set; }
    }
}
