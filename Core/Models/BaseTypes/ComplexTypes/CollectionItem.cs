using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Core.Models.Elements.BaseTypes.ComplexTypes
{
    [Serializable]
    public class CollectionItem : NotificationObject
    {
        private int _hue;
        private List<int> _list;

        public CollectionItem()
        {
            List = new List<int>();
        }

        protected CollectionItem(SerializationInfo info, StreamingContext context)
        {
            List = new List<int>(Deserialize(() => List, info));
        }

        public List<int> List
        {
            get => _list;
            set
            {
                _list = value;
                RaisePropertyChanged(() => List);
            }
        }

        public void Add(int element)
        {
            List.Add(element);
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Serialize(() => List, info);
        }
    }
}