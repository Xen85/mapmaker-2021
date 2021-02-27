using System;
using System.Collections.Generic;
using System.Drawing;
using Core.Models.Elements.BaseTypes;

namespace Core.Models.Elements.ColorArea.ColorMountains
{
    [Serializable]
    public class AreaColorMountain : NotificationObject
    {
        #region Ctor

        public AreaColorMountain()
        {
            List = new List<CircleMountain>();
            ModeAutomatic = false;
            Color = Color.Black;
            IndexGroupTop = 0;
            ColorMountain = Color.Black;
            IndexMountainGroup = 0;
            Name = "";
        }

        #endregion //Ctor

        #region Props

        /// <summary>
        ///     Color in the bitmap written in ColorArea
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        ///     index of the group in ColorArea
        /// </summary>
        public int IndexMountainGroup { get; set; }

        /// <summary>
        ///     Circles of automatic raise
        /// </summary>
        public List<CircleMountain> List { get; set; }

        /// <summary>
        ///     Color of the mountains in the top
        /// </summary>
        public Color ColorMountain { get; set; }

        /// <summary>
        ///     Index of what group is drawn in the top
        /// </summary>
        public int IndexGroupTop { get; set; }

        /// <summary>
        ///     If the automatic raise is off or on
        /// </summary>
        public bool ModeAutomatic { get; set; }

        public string Name { get; set; }

        #endregion //Props
    }
}