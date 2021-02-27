using System;
using System.Runtime.Serialization;
using Core.Models.Elements.BaseTypes;

namespace Core.Models.Elements.Items.Items
{
    [Serializable]
    public class SingleItem : NotificationObject
    {
        private int _hue;
        private int _id;
        private string _name;
        private int _x;
        private int _y;
        private int _z;


        public SingleItem()
        {
            _id = -1;
            _name = "";
            _hue = 0;
            _x = 0;
            _y = 0;
            _z = 0;
        }


        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                RaisePropertyChanged(() => Id);
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                RaisePropertyChanged(() => Name);
            }
        }

        public int Hue
        {
            get => _hue;
            set
            {
                _hue = value;
                RaisePropertyChanged(() => Hue);
            }
        }

        public int X
        {
            get => _x;
            set
            {
                _x = value;
                RaisePropertyChanged(() => X);
            }
        }

        public int Y
        {
            get => _y;
            set
            {
                _y = value;
                RaisePropertyChanged(() => Y);
            }
        }

        public int Z
        {
            get => _z;
            set
            {
                _z = value;
                RaisePropertyChanged(() => Z);
            }
        }

        #region Serialization

        protected SingleItem(SerializationInfo info, StreamingContext context)
        {
            _id = Deserialize(() => Id, info);
            _name = Deserialize(() => Name, info);
            _hue = Deserialize(() => Hue, info);
            _x = Deserialize(() => X, info);
            _y = Deserialize(() => Y, info);
            _z = Deserialize(() => Z, info);
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Serialize(() => Id, info);
            Serialize(() => Name, info);
            Serialize(() => Hue, info);
            Serialize(() => X, info);
            Serialize(() => Y, info);
            Serialize(() => Z, info);
        }

        #endregion //Serialization
    }
}