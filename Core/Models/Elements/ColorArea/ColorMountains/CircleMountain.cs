using System;
using System.Runtime.Serialization;
using Core.Models.Elements.BaseTypes;

namespace Core.Models.Elements.ColorArea.ColorMountains
{
    [Serializable]
    public class CircleMountain : NotificationObject
    {
        private int _from, _to;

        public CircleMountain()
        {
            From = 0;
            To = 0;
        }

        protected CircleMountain(SerializationInfo info, StreamingContext context)
        {
            From = Deserialize(() => From, info);
            To = Deserialize(() => To, info);
        }

        public int From
        {
            get => _from;
            set
            {
                _from = value;
                RaisePropertyChanged(() => From);
            }
        }

        public int To
        {
            get => _to;
            set
            {
                _to = value;
                RaisePropertyChanged(() => To);
            }
        }

        public override string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "From":
                    {
                        if (_from > 127 || _from < -128) return "From MUST be between -128 and 127";
                    }
                        break;
                    case "To":
                    {
                        if (_to > 127 || _to < -128) return "To MUST be between -128 and 127";
                    }
                        break;
                }

                return null;
            }
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Serialize(() => From, info);
            Serialize(() => To, info);
        }
    }
}