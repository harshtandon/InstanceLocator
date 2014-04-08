Supported Types

Bool
String
Datetime
Numerical Types : byte, short, int, long, float, double, decimal
Enum
Arrays

Untested Types

Structs

Planned for future

SortedSet
Dictionary
List

IDL supported types

{ "bool", "byte", "short", "int", "long", "float", "double", "decimal", "datetime" };
{ "datetime", "DateTime" }, { "set", "SortedSet" }, { "list", "List" }, { "map", "Dictionary" } }

Notes -

- Multiple bindings for the same type in the same scope is not supported. ie. no support for IEnumerable<T> GetServices<T>()
- Target types (excluding root) that are of type array will only have one element in the array. This is due to the way Ninject handles arrays. A resolution is possible by modifying the Ninject src as follows -
  In Ninject.Planning.Targets.Target<T>.ResolveWithin() comment the logic for arrays - Ninject uses this logic for handling multiple bindings whihch we don't support anyways.