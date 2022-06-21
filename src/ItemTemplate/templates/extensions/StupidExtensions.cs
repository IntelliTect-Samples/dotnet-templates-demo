using System;

namespace System;

public static class StupidExtensions
{
    public static T WhenTrue<T>(this T me, bool condition) where T : class
    {
        return condition ? me : default(T);
    }

    public static int Write(this object _, string msg)
    {
        Console.WriteLine(msg);
        return 0;
    }
}