using System;
using System.Collections.Generic;

namespace NTracer.Communication
{
    public class TracerValue
    {
        public TracerValue()
        {
        }

        public TracerValue(string key, TracerValue value)
        {
        }

        public static implicit operator TracerValue(string str)
        {
            return new TracerValue();
        }

        public static implicit operator TracerValue(int value)
        {
            return new TracerValue();
        }

    }
}
