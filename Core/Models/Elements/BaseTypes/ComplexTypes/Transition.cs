using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Core.Models.Elements.BaseTypes.ComplexTypes.Enum;
using Core.Models.Elements.Interfaces;

namespace Core.Models.Elements.BaseTypes.ComplexTypes
{
    [Serializable]
    public class Transition : NotificationObject, ITransition
    {
        private List<CollectionLine> _lines;

        #region Ctor

        public Transition()
        {
            _lines = new List<CollectionLine>();

            for (var i = 0; i < 3; i++) _lines.Add(new CollectionLine());
        }

        #endregion //Ctor

        protected Transition(SerializationInfo info, StreamingContext context)
        {
            Lines = new List<CollectionLine>(Deserialize(() => Lines, info));
        }

        #region Props

        public List<CollectionLine> Lines
        {
            get => _lines;
            set
            {
                _lines = value;
                RaisePropertyChanged(() => Lines);
            }
        }

        #endregion //Props

        #region methods

        public void AddElement(LineType line, int direction, int element)
        {
            Lines[(int) line].AddElement(direction, element);
        }

        #endregion

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Serialize(() => Lines, info);
        }

        #region Lists

        /// <summary>
        ///     Pointer to the right Linear List
        /// </summary>
        public CollectionLine Line => Lines[(int) LineType.Line];

        #region LinearTexures

        /// <summary>
        /// </summary>
        public CollectionItem LineNorth => Line.List[(int) LinearDirection.North];

        /// <summary>
        /// </summary>
        public CollectionItem LineEast => Line.List[(int) LinearDirection.East];

        /// <summary>
        /// </summary>
        public CollectionItem LineWest => Line.List[(int) LinearDirection.West];

        /// <summary>
        /// </summary>
        public CollectionItem LineSouth => Line.List[(int) LinearDirection.South];

        #endregion //LinearTextures

        /// <summary>
        ///     Pointer to the right Big edge List
        /// </summary>
        public CollectionLine Border => Lines[(int) LineType.Border];

        #region BigEdge Lists

        /// <summary>
        /// </summary>
        public CollectionItem BorderNorthEast => Border.List[(int) EdgeDirection.NortEast];

        /// <summary>
        /// </summary>
        public CollectionItem BorderNorthWest => Border.List[(int) EdgeDirection.NortWest];

        /// <summary>
        /// </summary>
        public CollectionItem BorderSouthEast => Border.List[(int) EdgeDirection.SouthEast];

        /// <summary>
        /// </summary>
        public CollectionItem BorderSouthWest => Border.List[(int) EdgeDirection.SoutWest];

        #endregion //BigEdge Lists

        /// <summary>
        ///     Pointer to the right Little Edge List
        /// </summary>
        public CollectionLine Edge => Lines[(int) LineType.Edge];

        #region little edge Lists

        /// <summary>
        /// </summary>
        public CollectionItem EdgeNorthWest => Edge.List[(int) EdgeDirection.NortWest];

        /// <summary>
        /// </summary>
        public CollectionItem EdgeNorthEast => Edge.List[(int) EdgeDirection.NortEast];

        /// <summary>
        /// </summary>
        public CollectionItem EdgeSouthEast => Edge.List[(int) EdgeDirection.SouthEast];

        /// <summary>
        /// </summary>
        public CollectionItem EdgeSouthWest => Edge.List[(int) EdgeDirection.SoutWest];

        #endregion //little edge Lists

        #endregion //Lists
    }
}