using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Core.Models.Elements.BaseTypes;
using Core.Models.Elements.Items.Items;

namespace Core.Models.Elements.Items
{
    [Serializable]
    public class CollectionItem : NotificationObject
    {
        private List<SingleItem> _list;
        private string _name;
        private double _percent;

        #region Ctor

        public CollectionItem()
        {
            Percent = 0;
            List = new List<SingleItem>();
            Name = "";
        }

        #endregion //Ctor

        protected CollectionItem(SerializationInfo info, StreamingContext context)
        {
            Name = Deserialize(() => Name, info);
            Percent = Deserialize(() => Percent, info);
            List = new List<SingleItem>(Deserialize(() => List, info));
        }


        #region Methods

        public override string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "Percent":
                    {
                        if (Percent > 100 || Percent < 0) return "Percent must be between 100 and 0";
                    }
                        break;
                }

                return null;
            }
        }

        #endregion //Methods

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Serialize(() => Name, info);
            Serialize(() => Percent, info);
            Serialize(() => List, info);
        }

        #region Props

        public double Percent
        {
            get => _percent;
            set
            {
                _percent = value;
                RaisePropertyChanged(() => Percent);
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

        public List<SingleItem> List
        {
            get => _list;
            set
            {
                _list = value;
                RaisePropertyChanged(() => List);
            }
        }

        #endregion //Props
    }
}