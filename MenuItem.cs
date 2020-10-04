using System;

namespace Utilities
{
    public class MenuItem
    {
        
        public string Description { get; set; }
        public Func<bool> Execute {get;set;}
    }
}
