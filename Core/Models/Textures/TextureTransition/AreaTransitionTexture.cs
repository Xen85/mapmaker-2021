using System;
using System.Drawing;
using System.Runtime.Serialization;
using Core.Models.Elements.BaseTypes.ComplexTypes;
using Core.Models.Elements.Interfaces;

namespace Core.Models.Elements.Textures.TextureTransition
{
    [Serializable]
    public class AreaTransitionTexture : Transition, ITransition
    {
        private Color _colorFrom, _colorTo;
        private int _indexTo;
        private string _name;
        private int _textureIdTo;

        #region Ctor

        public AreaTransitionTexture()
        {
            ColorFrom = Color.Black;
            ColorTo = Color.Black;
            Name = "";
        }

        #endregion //Ctor

        protected AreaTransitionTexture(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            Name = Deserialize(() => Name, info);
            ColorFrom = Deserialize(() => ColorFrom, info);
            ColorTo = Deserialize(() => ColorTo, info);
            _indexTo = info.GetInt32("IndexTo");

            try
            {
                TextureIdTo = Deserialize(() => TextureIdTo, info);
            }
            catch (Exception)
            {
                TextureIdTo = 0;
            }
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            Serialize(() => Name, info);
            Serialize(() => ColorFrom, info);
            Serialize(() => ColorTo, info);
            // Serialize(() => IndexTo, info);
            Serialize(() => TextureIdTo, info);
        }


        #region Props

        public Color ColorFrom
        {
            get => _colorFrom;
            set
            {
                _colorFrom = value;
                RaisePropertyChanged(() => ColorFrom);
            }
        }

        public Color ColorTo
        {
            get => _colorTo;
            set
            {
                _colorTo = value;
                RaisePropertyChanged(() => ColorTo);
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

        // public int IndexTo
        // {
        //     get => _indexTo;
        //     set
        //     {
        //         _indexTo = value;
        //         ColorTo = MapSdk.Colors[value];
        //         RaisePropertyChanged(() => IndexTo);
        //     }
        // }

        public int TextureIdTo
        {
            get => _textureIdTo;
            set
            {
                _textureIdTo = value;
                RaisePropertyChanged(() => TextureIdTo);
            }
        }

        #endregion //Props
    }
}