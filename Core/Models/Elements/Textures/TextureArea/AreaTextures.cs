using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Core.Models.Elements.BaseTypes;
using Core.Models.Elements.Items;

namespace Core.Models.Elements.Textures.TextureArea
{
    [Serializable]
    public class AreaTextures : NotificationObject
    {
        private CollectionAreaTransitionTexture _areaTransitionTexture;
        private CollectionAreaTransitionItems _collectionAreaItems;
        private int _index;
        private List<int> _list;
        private string _name;

        #region Props

        public int Index
        {
            get => _index;
            set
            {
                _index = value;
                RaisePropertyChanged(() => Index);
            }
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

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                RaisePropertyChanged(() => Name);
            }
        }

        public CollectionAreaTransitionTexture AreaTransitionTexture
        {
            get => _areaTransitionTexture;
            set
            {
                _areaTransitionTexture = value;
                RaisePropertyChanged(() => AreaTransitionTexture);
            }
        }

        public CollectionAreaTransitionItems CollectionAreaItems
        {
            get => _collectionAreaItems;
            set
            {
                _collectionAreaItems = value;
                RaisePropertyChanged(() => CollectionAreaItems);
            }
        }

        #endregion //Props

        #region Ctor

        public AreaTextures()
        {
            Index = 0;
            List = new List<int>();
            AreaTransitionTexture = new CollectionAreaTransitionTexture();
            CollectionAreaItems = new CollectionAreaTransitionItems();
            Name = "";
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Serialize(() => List, info);
            Serialize(() => Name, info);
            Serialize(() => Index, info);
            Serialize(() => AreaTransitionTexture, info);
            Serialize(() => CollectionAreaItems, info);
        }

        protected AreaTextures(SerializationInfo info, StreamingContext context)
        {
            List = new List<int>(Deserialize(() => List, info));
            Name = Deserialize(() => Name, info);
            Index = Deserialize(() => Index, info);
            try
            {
                AreaTransitionTexture = Deserialize(() => AreaTransitionTexture, info);
                CollectionAreaItems = Deserialize(() => CollectionAreaItems, info);
            }
            catch (Exception)
            {
                CollectionAreaItems = new CollectionAreaTransitionItems();
                AreaTransitionTexture = new CollectionAreaTransitionTexture();
            }
        }

        #endregion ctor
    }
}