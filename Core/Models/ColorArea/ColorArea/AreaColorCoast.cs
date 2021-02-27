using System;
using System.Runtime.Serialization;

namespace Core.Models.Elements.ColorArea.ColorArea
{
    [Serializable]
    public class AreaColorCoast : AreaColor
    {
        public AreaColorCoast()
        {
        }

        protected AreaColorCoast(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}