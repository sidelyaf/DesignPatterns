using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern
{
    public class Dinner
    {
    }

    /// <summary>
    /// Orderup()
    /// </summary>
    public interface Command
    {
        void Execute();
    }
}
