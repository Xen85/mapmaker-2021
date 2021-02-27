using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Core.Models.Elements.BaseTypes.ComplexTypes
{
    [Serializable]
    public class CollectionLine : NotificationObject
    {
        private List<CollectionItem> _list;

        #region Ctor

        public CollectionLine()
        {
            List = new List<CollectionItem>();

            for (var i = 0; i < 4; i++) List.Add(new CollectionItem());
        }

        #endregion //Ctor

        protected CollectionLine(SerializationInfo info, StreamingContext context)
        {
            List = new List<CollectionItem>(Deserialize(() => List, info));
        }

        #region Methods

        public void AddElement(int direction, int element)
        {
            List[direction].Add(element);
        }

        #endregion //Methods

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Serialize(() => List, info);
        }

        #region Props

        public List<CollectionItem> List
        {
            get => _list;
            set
            {
                _list = value;
                RaisePropertyChanged(() => List);
            }
        }

        public CollectionItem CollectionFirst
        {
            get => List[0];
            set
            {
                List[0] = value;
                RaisePropertyChanged(() => CollectionFirst);
                RaisePropertyChanged(() => List);
            }
        }

        public CollectionItem CollectionSecond
        {
            get => List[1];
            set
            {
                List[1] = value;
                RaisePropertyChanged(() => CollectionSecond);
                RaisePropertyChanged(() => List);
            }
        }

        public CollectionItem CollectionThird
        {
            get => List[2];
            set
            {
                List[2] = value;
                RaisePropertyChanged(() => CollectionThird);
                RaisePropertyChanged(() => List);
            }
        }

        public CollectionItem CollectionForth
        {
            get => List[3];
            set
            {
                List[3] = value;
                RaisePropertyChanged(() => CollectionForth);
                RaisePropertyChanged(() => List);
            }
        }

        #endregion //Props
    }
}