using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities.Logging
{
    /// <summary>
    /// 
    /// </summary>
    public class UtcLogTimestampProvider : ILogTimestampProvider
    {
        /// <summary>
        /// Gets the now.
        /// </summary>
        /// <value>The now.</value>
        public virtual DateTime Now
        {
            get
            {
                return DateTime.UtcNow;
            }
        }

        /// <summary>
        /// Gets the offset of the DateTime provided by Now from UTC.
        /// If unknown, returns null.
        /// </summary>
        /// <value>The utc offset.</value>
        public virtual TimeSpan? UtcOffset
        {
            get
            {
                return TimeSpan.Zero;
            }
        }
    }
}
