using System;

namespace CounterStrike
{
    [Flags]
    public enum Teams
    {
        Terrorist = 1 << 0,
        Counter_Terrorist = 1 << 1,
        Any = Terrorist | Counter_Terrorist
    }
}