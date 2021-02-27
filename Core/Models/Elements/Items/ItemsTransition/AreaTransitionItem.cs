using System;
using System.Drawing;
using System.Runtime.Serialization;
using Core.Models.Elements.BaseTypes.ComplexTypes;
using Core.Models.Elements.Interfaces;

namespace Core.Models.Elements.Items.ItemsTransition
{
    [Serializable]
    public class AreaTransitionItem : Transition, ITransition
    {
        #region Ctor

        public AreaTransitionItem()
        {
            ColorFrom = Color.Black;
            ColorTo = Color.Black;
        }

        #endregion //Ctor

        #region Fields

        private Color _colorFrom, _colorTo;

        private int _idTo;
        private int _textureIdTo;

        private string _name;

        #endregion //Fields

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

        // public int IndexTo
        // {
        //     get => _idTo;
        //     set
        //     {
        //         _idTo = value;
        //         ColorTo = MapSdk.Colors[value];
        //         RaisePropertyChanged(() => IndexTo);
        //     }
        // }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                RaisePropertyChanged(() => Name);
            }
        }

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

        #region Methods

        #region Serialization

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            Serialize(() => ColorFrom, info);
            Serialize(() => ColorTo, info);
            Serialize(() => Name, info);
            Serialize(() => TextureIdTo, info);
        }

        protected AreaTransitionItem(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            ColorFrom = Deserialize(() => ColorFrom, info);
            ColorTo = Deserialize(() => ColorTo, info);
            Name = Deserialize(() => Name, info);
            try
            {
                TextureIdTo = Deserialize(() => TextureIdTo, info);
            }
            catch (Exception)
            {
                TextureIdTo = -1;
            }
        }

        #endregion //Serialization

        #endregion //Methods
    }
}