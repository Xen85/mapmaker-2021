using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Core.Models.Elements.BaseTypes;
using Core.Models.Elements.Textures.TextureTransition;

namespace Core.Models.Elements.Textures
{
    [Serializable]
    public class CollectionAreaTransitionTexture : NotificationObject, IContainerSet
    {
        private List<AreaTransitionTexture> _list;

        #region Ctor

        public CollectionAreaTransitionTexture()
        {
            List = new List<AreaTransitionTexture>();
            Update();
        }

        #endregion

        protected CollectionAreaTransitionTexture(SerializationInfo info, StreamingContext context)
        {
            List = new List<AreaTransitionTexture>(Deserialize(() => List, info));
        }

        #region Props

        public List<AreaTransitionTexture> List
        {
            get => _list;
            set
            {
                _list = value;
                Update();
                RaisePropertyChanged(() => List);
            }
        }

        #endregion


        private List<int> TextureToIndexes
        {
            get { return List.Select(o => o.TextureIdTo).ToList(); }
        }

        #region IContainerSet

        public void InitializeSeaches()
        {
            if (init)
                return;
            m_DictionaryFindIndex = new Dictionary<int, AreaTransitionTexture>();
            foreach (var textureSmooth in List)
                try
                {
                    m_DictionaryFindIndex.Add(textureSmooth.TextureIdTo, textureSmooth);
                }
                catch (Exception)
                {
                }

            init = true;
        }

        #endregion //IContainerSet

        #region Search Methods

        public AreaTransitionTexture FindById(int id)
        {
            AreaTransitionTexture result;
            m_DictionaryFindIndex.TryGetValue(id, out result);
            return result;
        }

        #endregion

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Serialize(() => List, info);
        }


        private void Update()
        {
            // if (List != null)
            //     List.CollectionChanged += (sender, arg) =>
            //     {
            //         InitializeSeaches();
            //         RaisePropertyChanged(() => TextureToIndexes);
            //     };
        }

        #region Fields

        [NonSerialized] private Dictionary<int, AreaTransitionTexture> m_DictionaryFindIndex;
        private bool init;

        #endregion
    }
}