using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities.Logging
{
    /// <summary>
    /// 
    /// </summary>
    public class ConsoleLogger : TextWriterLogger
    {
        /// <summary>
        /// 
        /// </summary>
        public static ConsoleLogger Current = new ConsoleLogger();

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleLogger"/> class.
        /// </summary>
        public ConsoleLogger()
            : base(Console.Out)
        {
        }
    }
}
