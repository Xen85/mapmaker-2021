using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using Core.Models.Elements.BaseTypes;

namespace Core.Models.Elements.Textures.TexureCliff
{
    [Serializable]
    public class AreaTransitionCliffTexture : NotificationObject
    {
        #region Ctor

        public AreaTransitionCliffTexture()
        {
            Directions = DirectionCliff.EastEnd;
            ColorTo = Color.Black;
            ColorFrom = Color.Black;
            ColorEdge = Color.Black;
            List = new List<int>();
            _idTo = -1;
            _idFrom = -1;
            _idEdge = -1;
        }

        #endregion

        protected AreaTransitionCliffTexture(SerializationInfo info, StreamingContext context)
        {
            Name = Deserialize(() => Name, info);
            ColorFrom = Deserialize(() => ColorFrom, info);
            ColorTo = Deserialize(() => ColorTo, info);
            IdFrom = Deserialize(() => IdFrom, info);
            ColorTo = Deserialize(() => ColorTo, info);
            ColorEdge = Deserialize(() => ColorEdge, info);
            List = new List<int>(Deserialize(() => List, info));
            Directions = Deserialize(() => Directions, info);
        }

        #region Methods

        #region Override Methods

        public override string ToString()
        {
            return Directions + " " + ColorFrom + " " + ColorTo + " " + ColorEdge;
        }

        #endregion

        #endregion

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Serialize(() => Name, info);
            Serialize(() => ColorFrom, info);
            Serialize(() => ColorTo, info);
            Serialize(() => IdFrom, info);
            Serialize(() => ColorEdge, info);
            Serialize(() => List, info);
            Serialize(() => Directions, info);
        }

        #region Fields

        private DirectionCliff _direction;

        private int _idFrom, _idTo, _idEdge;

        private Color _colorFrom, _colorTo, _colorEdge;

        private List<int> _list;

        private string _name;

        #endregion //Fields


        #region Props

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                RaisePropertyChanged(() => Name);
            }
        }

        public DirectionCliff Directions
        {
            get => _direction;
            set
            {
                _direction = value;
                RaisePropertyChanged(() => Directions);
            }
        }

        #region From

        public Color ColorFrom
        {
            get => _colorFrom;
            set
            {
                _colorFrom = value;
                RaisePropertyChanged(() => ColorFrom);
            }
        }

        public int IdFrom
        {
            get => _idFrom;
            set
            {
                _idFrom = value;
                RaisePropertyChanged(() => IdFrom);
            }
        }

        #endregion //From


        #region To

        public Color ColorTo
        {
            get => _colorTo;
            set
            {
                _colorTo = value;
                RaisePropertyChanged(() => ColorTo);
            }
        }

        // public int IdTo
        // {
        //     get => _idTo;
        //     set
        //     {
        //         _idTo = value;
        //         ColorTo = MapSdk.Colors[value];
        //         RaisePropertyChanged(() => IdTo);
        //     }
        // }

        #endregion //to


        #region Edge

        public Color ColorEdge
        {
            get => _colorEdge;
            set
            {
                _colorEdge = value;
                RaisePropertyChanged(() => ColorEdge);
            }
        }

        public int IdEdge
        {
            get => _idEdge;
            set
            {
                _idEdge = value;
                RaisePropertyChanged(() => IdEdge);
            }
        }

        #endregion //Edge


        public List<int> List
        {
            get => _list;
            set
            {
                _list = value;
                RaisePropertyChanged(() => List);
            }
        }

        #endregion //Props
    }
}