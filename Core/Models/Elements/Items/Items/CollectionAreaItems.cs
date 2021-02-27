using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using Core.Models.Elements.BaseTypes;

namespace Core.Models.Elements.Items.Items
{
    [Serializable]
    public class CollectionAreaItems : NotificationObject, IContainerSet
    {
        #region Fields

        [NonSerialized] private Dictionary<Color, AreaItems> _items;

        #endregion //Fields

        private List<AreaItems> _list;

        #region Ctor

        public CollectionAreaItems()
        {
            List = new List<AreaItems>();
            _items = null;
        }

        #endregion //ctor

        protected CollectionAreaItems(SerializationInfo info, StreamingContext context)
        {
            List = new List<AreaItems>(Deserialize(() => List, info));
        }

        #region Props

        public List<AreaItems> List
        {
            get => _list;
            set
            {
                _list = value;
                RaisePropertyChanged(() => List);
            }
        }

        #endregion // Props

        #region IContainerSet Implementation

        public void InitializeSeaches()
        {
            _items = new Dictionary<Color, AreaItems>();

            foreach (var itemse in List)
                try
                {
                    _items.Add(itemse.Color, itemse);
                }
                catch (Exception)
                {
                }
        }

        #endregion //IContainerSet Implementation

        #region Search Methods

        public AreaItems SearchByColor(Color color)
        {
            AreaItems i;
            _items.TryGetValue(color, out i);
            return i;
        }

        #endregion //Search Methods


        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Serialize(() => List, info);
        }
    }
}