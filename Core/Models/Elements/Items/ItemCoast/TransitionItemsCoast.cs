using System;
using System.Drawing;
using System.Runtime.Serialization;
using Core.Models.Elements.BaseTypes.ComplexTypes;

namespace Core.Models.Elements.Items.ItemCoast
{
    [Serializable]
    public class TransitionItemsCoast : Transition
    {
        #region Ctor

        public TransitionItemsCoast()
        {
            Color = Color.Black;
            Texture = 0;
        }

        #endregion //Ctor

        #region Fields

        private Color _color;

        private int _texture;
        private int _hue;

        #endregion //Fields

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

        public int Texture
        {
            get => _texture;
            set
            {
                _texture = value;
                RaisePropertyChanged(() => Texture);
            }
        }


        public int Hue
        {
            get => _hue;
            set
            {
                _hue = value;
                RaisePropertyChanged(() => Hue);
            }
        }

        #endregion //Props


        #region Serialization

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            Serialize(() => Color, info);
            Serialize(() => Texture, info);
            Serialize(() => Hue, info);
        }

        protected TransitionItemsCoast(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            Color = Deserialize(() => Color, info);
            Texture = Deserialize(() => Texture, info);
            try
            {
                Hue = Deserialize(() => Hue, info);
            }
            catch (Exception)
            {
            }
        }

        #endregion //Serialization
    }
}