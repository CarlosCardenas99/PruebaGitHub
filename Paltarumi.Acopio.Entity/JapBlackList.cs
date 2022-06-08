using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Entity
{
    public partial class JapBlackList
    {
        public int JapBlackListId { get; set; }
        public string ObjectType { get; set; } = null!;
        public string ObjectSchema { get; set; } = null!;
        public string ObjectName { get; set; } = null!;
        public bool Active { get; set; }
    }
}
