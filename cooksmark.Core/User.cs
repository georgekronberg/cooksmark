using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cooksmark.Core
{
    public class User
    {
        public Guid Id { get; protected set; }
        public String FirstName { get; set; }
    }
}
