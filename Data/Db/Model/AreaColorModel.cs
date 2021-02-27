// **********
// MapMaker2021 - AreaColorModel.cs
// **********

using System.Collections.Generic;
using System.Drawing;
using Core.Models.Elements.ColorArea.ColorArea;
using Core.Models.Elements.ColorArea.ColorMountains;
using Core.Models.Elements.Items.ItemsTransition;
using Core.Models.Elements.Textures.TextureTransition;
using Core.Models.Elements.Textures.TexureCliff;

namespace Data.Db.Model
{
    public class AreaColorModel
    {
        private bool _automaticMode;
        private bool _cliffCoast;


        private AreaTransitionItemCoast _coast;
        private int _coastAltitude;
        private Color _color, _colorMountain;
        private AreaItems _items;
        private int _itemsAltitude;
        private List<CircleMountain> _list;
        private int _minCoastTextureZ;
        private string _name;
        private List<CircleMountain> _smoothCoast;
        private int _textureIndex, _index, _min, _max, _indexTextureTop, _indexColorTop;
        private List<AreaTransitionCliffTexture> _transitionCliff;
        private List<AreaTransitionItem> _transitionItems;
        private List<AreaTransitionTexture> _transitionTexture;

        private TypeColor _typeColor;
        // private Dictionary<Color, AreaTransitionTexture> _transitionTextureFinding;
        // private Dictionary<Color, AreaTransitionItem> _transitionItemsFinding;
    }

    public class AreaColorMountainsModel
    {
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
    }

    public class AreaTransitionItemModel
    {
        public int IdTo { get; set; }

        public Color ColorFrom { get; set; }

        public Color ColorTo { get; set; }

        public string Name { get; set; }

        public int TextureIdTo { get; set; }
    }

    public class AreaTransitionItemCoast
    {
        public TransitionItemCoastModel Coast { get; set; }
        public TransitionItemCoastModel Ground { get; set; }
    }

    public class TransitionItem
    {
        public int Hue { get; set; }
        public List<int> Ids { get; set; }
    }

    public class TransitionItemCoastModel
    {
        public Color Color { get; set; }

        public int Texture { get; set; }
        public int Hue { get; set; }
    }

    public class SingleItemModel
    {
        public int Hue { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
    }
}