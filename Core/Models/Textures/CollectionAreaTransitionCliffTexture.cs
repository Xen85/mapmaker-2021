using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using Core.Models.Elements.BaseTypes;
using Core.Models.Elements.Textures.TexureCliff;

namespace Core.Models.Elements.Textures
{
    [Serializable]
    public class CollectionAreaTransitionCliffTexture : NotificationObject, IContainerSet
    {
        private Color _color;
        private List<AreaTransitionCliffTexture> _list;

        #region Ctor

        public CollectionAreaTransitionCliffTexture()
        {
            Color = Color.White;
            List = new List<AreaTransitionCliffTexture>();
        }

        #endregion //Ctor

        protected CollectionAreaTransitionCliffTexture(SerializationInfo info, StreamingContext context)
        {
            List = new List<AreaTransitionCliffTexture>(Deserialize(() => List, info));
        }

        #region IContainerSet

        public void InitializeSeaches()
        {
        }

        #endregion

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Serialize(() => List, info);
        }

        #region Props

        public Color Color
        {
            get => _color;
            set
            {
                _color = value;
                RaisePropertyChanged(() => Color);
            }
        }

        public List<AreaTransitionCliffTexture> List
        {
            get => _list;
            set
            {
                _list = value;
                RaisePropertyChanged(() => List);
            }
        }

        #endregion // Props

        #region Search Methods

        public IEnumerable<AreaTransitionCliffTexture> FindFromByColor(Color color)
        {
            return List.Where(textureCliff => textureCliff.ColorFrom == color);
        }

        public IEnumerable<AreaTransitionCliffTexture> FindToByColor(Color color)
        {
            return List.Where(textureCliff => textureCliff.ColorFrom != color &&
                                              (textureCliff.ColorTo.Equals(color) ||
                                               textureCliff.ColorEdge.Equals(color)));
        }

        public IEnumerable<AreaTransitionCliffTexture> FindByColor(Color color)
        {
            return List.Where(textureCliff => textureCliff.ColorTo.Equals(color) ||
                                              textureCliff.ColorFrom.Equals(color) ||
                                              textureCliff.ColorEdge.Equals(color));
        }

        public IEnumerable<Color> AllColors()
        {
            return List.Select(t => t.ColorFrom).Union(List.Select(t => t.ColorTo)).Union(List.Select(t => t.ColorEdge))
                .Distinct();
        }

        #endregion //Search Methods
    }
}