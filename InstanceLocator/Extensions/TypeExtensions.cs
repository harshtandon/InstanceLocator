using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstanceLocator.Extensions
{
    public static class TypeExtensions
    {
        // { "bool", "byte", "short", "int", "long", "float", "double", "decimal", "datetime" };

        // { "datetime", "DateTime" }, { "set", "SortedSet" }, { "list", "List" }, { "map", "Dictionary" } }


        public static readonly string[] StringPool = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum".Replace(".", "").Replace(",", "").Split(' ');

        public static void Some()
        {
            
        }

    }
}
