using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using Core.Models.Elements.BaseTypes;

namespace Core.Models.Elements.Items.ItemText
{
    [Serializable]
    public class AreaItems : NotificationObject
    {
        private Color _color;
        private List<CollectionItem> _list;
        private string _name;

        #region Ctor

        public AreaItems()
        {
            Color = Color.Black;
            List = new List<CollectionItem>();
            Name = "";
        }

        #endregion //Ctor

        #region Props

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                RaisePropertyChanged(() => Name);
            }
        }

        public Color Color
        {
            get => _color;
            set
            {
                _color = value;
                RaisePropertyChanged(() => Color);
            }
        }

        public List<CollectionItem> List
        {
            get => _list;
            set
            {
                _list = value;
                RaisePropertyChanged(() => List);
            }
        }

        #endregion //Props

        #region Serialization

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Serialize(() => Name, info);
            Serialize(() => Color, info);
            Serialize(() => List, info);
        }

        protected AreaItems(SerializationInfo info, StreamingContext context)
        {
            Name = Deserialize(() => Name, info);
            Color = Deserialize(() => Color, info);
            List = new List<CollectionItem>(Deserialize(() => List, info));
        }

        #endregion //Serialization
    }
}