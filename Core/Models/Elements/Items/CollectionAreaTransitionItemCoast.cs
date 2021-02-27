using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using Core.Models.Elements.BaseTypes;
using Core.Models.Elements.Items.ItemCoast;

namespace Core.Models.Elements.Items
{
    [Serializable]
    public class CollectionAreaTransitionItemCoast : NotificationObject, IContainerSet
    {
        private List<AreaTransitionItemCoast> _list;

        #region Ctor

        public CollectionAreaTransitionItemCoast()
        {
            List = new List<AreaTransitionItemCoast>();
        }

        #endregion //Ctor

        protected CollectionAreaTransitionItemCoast(SerializationInfo info, StreamingContext context)
        {
            List = new List<AreaTransitionItemCoast>(Deserialize(() => List, info));
        }

        #region Props

        public List<AreaTransitionItemCoast> List
        {
            get => _list;
            set
            {
                _list = value;
                RaisePropertyChanged(() => List);
            }
        }

        #endregion //Props

        #region IContainerSet Implementation

        public void InitializeSeaches()
        {
            _coastses = new Dictionary<Color, AreaTransitionItemCoast>();
            _dictionaryColorCoast = new Dictionary<Color, bool>();

            foreach (var itemsCoastse in List)
            {
                try
                {
                    _coastses.Add(itemsCoastse.Ground.Color, itemsCoastse);
                }
                catch (Exception)
                {
                }

                try
                {
                    _dictionaryColorCoast.Add(itemsCoastse.Coast.Color, true);
                }
                catch (Exception)
                {
                }
            }
        }

        #endregion //IContainerSet Implementation

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Serialize(() => List, info);
        }

        #region Fields

        [NonSerialized] private Dictionary<Color, AreaTransitionItemCoast> _coastses;
        [NonSerialized] private Dictionary<Color, bool> _dictionaryColorCoast;

        #endregion //Fields

        #region search methods

        public AreaTransitionItemCoast FindGroundByColor(Color color)
        {
            AreaTransitionItemCoast coast = null;

            _coastses.TryGetValue(color, out coast);

            return coast;
        }

        public bool FindCoastByColor(Color color)
        {
            bool ret;
            _dictionaryColorCoast.TryGetValue(color, out ret);

            return ret;
        }

        public AreaTransitionItemCoast FindByColor(Color color)
        {
            AreaTransitionItemCoast c;
            _coastses.TryGetValue(color, out c);
            return c;
        }

        #endregion //seach Methods
    }
}