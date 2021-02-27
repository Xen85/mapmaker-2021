using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Core.Models.Elements.BaseTypes;
using Core.Models.Elements.Items.ItemsTransition;

namespace Core.Models.Elements.Items
{
    [Serializable]
    public class CollectionAreaTransitionItems : NotificationObject, IContainerSet
    {
        #region Fields

        //[NonSerialized] private Dictionary<Color, AreaTransitionItem> _dictionarySmooth;
        //[NonSerialized] private Dictionary<Color, bool> _dictionaryColorTo;
        [NonSerialized] private Dictionary<int, AreaTransitionItem> _dictionaryFindById;

        #endregion //Fields

        private List<AreaTransitionItem> _list;
        private bool init;

        #region Ctor

        public CollectionAreaTransitionItems()
        {
            List = new List<AreaTransitionItem>();
        }

        #endregion

        protected CollectionAreaTransitionItems(SerializationInfo info, StreamingContext context)
        {
            List = new List<AreaTransitionItem>(Deserialize(() => List, info));
        }

        #region Props

        public List<AreaTransitionItem> List
        {
            get => _list;
            set
            {
                _list = value;
                RaisePropertyChanged(() => List);
            }
        }

        #endregion //Props

        #region IContainerSet

        public void InitializeSeaches()
        {
            if (init)
                return;
            //_dictionarySmooth = new Dictionary<Color, AreaTransitionItem>();
            //_dictionaryColorTo = new Dictionary<Color, bool>();
            _dictionaryFindById = new Dictionary<int, AreaTransitionItem>();
            foreach (var itemsSmooth in List)
                //try
                //{
                //    _dictionarySmooth.Add(itemsSmooth.ColorFrom, itemsSmooth);
                //}
                //catch (Exception)
                //{
                //}

                //try
                //{
                //    _dictionaryColorTo.Add(itemsSmooth.ColorTo,true);
                //}
                //catch (Exception)
                //{
                //}
                try
                {
                    _dictionaryFindById.Add(itemsSmooth.TextureIdTo, itemsSmooth);
                }
                catch (Exception)
                {
                }

            init = true;
        }

        #endregion //IContainerSet


        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Serialize(() => List, info);
        }

        public AreaTransitionItem FindById(int index)
        {
            AreaTransitionItem tmp;
            _dictionaryFindById.TryGetValue(index, out tmp);
            return tmp;
        }

        #region Search Methods

        //public AreaTransitionItem FindFromByColor(Color color)
        //{
        //    AreaTransitionItem smooth;

        //    _dictionarySmooth.TryGetValue(color, out smooth);

        //    return smooth;
        //}


        //public bool ContainsColorTo(Color color)
        //{
        //    bool ret;
        //    _dictionaryColorTo.TryGetValue(color, out ret);
        //    return ret;
        //}

        #endregion
    }
}