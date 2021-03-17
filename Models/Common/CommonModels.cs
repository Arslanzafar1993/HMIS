using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Common
{
    public class CommonModels
    {
        public class DDLModel
        {
            public long Id { get; set; }
            public string Code { get; set; }
            public string Name { get; set; }
        }
        public class DDLRolesModel
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }
    }
}
