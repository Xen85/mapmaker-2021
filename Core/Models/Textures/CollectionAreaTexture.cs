using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Core.Models.Elements.BaseTypes;
using Core.Models.Elements.Textures.TextureArea;

namespace Core.Models.Elements.Textures
{
    [Serializable]
    public class CollectionAreaTexture : NotificationObject, IContainerSet
    {
        [XmlIgnore] [NonSerialized] public Dictionary<int, AreaTextures> _fast;

        private List<AreaTextures> _list;

        public CollectionAreaTexture()
        {
            List = new List<AreaTextures>();
            Update();
        }

        protected CollectionAreaTexture(SerializationInfo info, StreamingContext context)
        {
            List = new List<AreaTextures>(Deserialize(() => List, info));
        }

        public List<AreaTextures> List
        {
            get => _list;
            set
            {
                _list = value;
                Update();
                RaisePropertyChanged(() => List);
            }
        }

        public List<int> Indexes
        {
            get
            {
                var list = List.Select(element => element.Index).ToList();
                return list;
            }
        }

        public void InitializeSeaches()
        {
            _fast = new Dictionary<int, AreaTextures>();
            foreach (var texturese in List) _fast.Add(texturese.Index, texturese);
        }

        #region Search Methods

        public AreaTextures FindByIndex(int id)
        {
            AreaTextures text = null;
            if (_fast != null)
                _fast.TryGetValue(id, out text);
            return text;
        }

        #endregion

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Serialize(() => List, info);
        }

        private void Update()
        {
            // if (List != null)
            //     List.CollectionChanged += (element, arg) =>
            //     {
            //         InitializeSeaches();
            //         RaisePropertyChanged(() => Indexes);
            //     };
        }
    }
}