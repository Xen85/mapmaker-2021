using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.Serialization;
using Core.Models.Elements.BaseTypes;
using Core.Models.Elements.ColorArea.ColorMountains;
using Core.Models.Elements.Items.ItemCoast;
using Core.Models.Elements.Items.Items;
using Core.Models.Elements.Items.ItemsTransition;
using Core.Models.Elements.Textures.TextureTransition;
using Core.Models.Elements.Textures.TexureCliff;

namespace Core.Models.Elements.ColorArea.ColorArea
{
    [Serializable]
    public class AreaColor : NotificationObject
    {
        #region Ctor

        public AreaColor()
        {
            Color = Color.Black;
            TextureIndex = 0;
            Index = 0;
            Min = 0;
            Max = 0;
            Name = "";
            _list = new List<CircleMountain>();
            Type = TypeColor.None;
            _items = new AreaItems();
            _transitionTexture = new List<AreaTransitionTexture>();
            _transitionItems = new List<AreaTransitionItem>();
            _coast = new AreaTransitionItemCoast();
            _transitionCliff = new List<AreaTransitionCliffTexture>();
            _smoothCoast = new List<CircleMountain>();
            _coastAltitude = 0;
            _cliffCoast = false;
        }

        #endregion //ctor

        #region ISerializable Ctor

        protected AreaColor(SerializationInfo info, StreamingContext context)
        {
            Index = Deserialize(() => Index, info);
            Min = Deserialize(() => Min, info);
            Max = Deserialize(() => Max, info);
            //Type = Deserialize(() => Type, info);
            _typeColor = (TypeColor) info.GetInt32("Type");
            TextureIndex = Deserialize(() => TextureIndex, info);
            Name = Deserialize(() => Name, info);
            Color = Deserialize(() => Color, info);
            List = new List<CircleMountain>(Deserialize(() => List, info));
            ColorTopMountain = Deserialize(() => ColorTopMountain, info);
            // _indexColorTop = Deserialize(() => IndexColorTopMountain, info);
            IndexTextureTop = Deserialize(() => IndexTextureTop, info);
            ModeAutomatic = Deserialize(() => ModeAutomatic, info);
            Coasts = Deserialize(() => Coasts, info);
            TransitionItems = new List<AreaTransitionItem>(Deserialize(() => TransitionItems, info));
            Items = Deserialize(() => Items, info);
            TextureTransitions =
                new List<AreaTransitionTexture>(Deserialize(() => TextureTransitions, info));
            TransitionCliffTextures =
                new List<AreaTransitionCliffTexture>(Deserialize(() => TransitionCliffTextures, info));
            try
            {
                CoastSmoothCircles =
                    new List<CircleMountain>(Deserialize(() => CoastSmoothCircles, info));
            }
            catch (Exception)
            {
                CoastSmoothCircles = new List<CircleMountain>();
            }

            try
            {
                CoastAltitude = Deserialize(() => CoastAltitude, info);
            }
            catch (Exception)
            {
                CoastAltitude = 0;
            }

            try
            {
                ItemsAltitude = Deserialize(() => CoastAltitude, info);
                CliffCoast = Deserialize(() => CliffCoast, info);
            }
            catch (Exception)
            {
                ItemsAltitude = 0;
                CliffCoast = true;
            }

            try
            {
                MinCoastTextureZ = Deserialize(() => MinCoastTextureZ, info);
            }
            catch (Exception)
            {
                MinCoastTextureZ = -15;
            }
        }

        #endregion //ISerializable Ctor

        #region Override

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Serialize(() => Index, info);
            Serialize(() => Min, info);
            Serialize(() => Max, info);
            //Serialize(() => Type, info);
            info.AddValue("Type", (int) _typeColor);
            Serialize(() => TextureIndex, info);
            Serialize(() => Name, info);
            Serialize(() => Color, info);
            Serialize(() => List, info);
            Serialize(() => ColorTopMountain, info);
            // Serialize(() => IndexColorTopMountain, info);
            Serialize(() => IndexTextureTop, info);
            Serialize(() => ModeAutomatic, info);
            Serialize(() => Coasts, info);
            Serialize(() => TransitionItems, info);
            Serialize(() => Items, info);
            Serialize(() => TextureTransitions, info);
            Serialize(() => TransitionCliffTextures, info);
            Serialize(() => CoastAltitude, info);
            Serialize(() => CoastSmoothCircles, info);
            Serialize(() => ItemsAltitude, info);
            Serialize(() => CliffCoast, info);
            Serialize(() => MinCoastTextureZ, info);
        }

        #endregion //Override


        #region Declaration

        private bool _automaticMode;
        private int _textureIndex, _index, _min, _max, _indexTextureTop, _indexColorTop;
        private string _name;
        private TypeColor _typeColor;
        private Color _color, _colorMountain;
        private int _coastAltitude;
        private int _itemsAltitude;
        private bool _cliffCoast;
        private int _minCoastTextureZ;


        private AreaTransitionItemCoast _coast;
        private List<AreaTransitionItem> _transitionItems;
        private AreaItems _items;
        private List<AreaTransitionTexture> _transitionTexture;
        private List<AreaTransitionCliffTexture> _transitionCliff;
        private List<CircleMountain> _list;
        private List<CircleMountain> _smoothCoast;
        private Dictionary<Color, AreaTransitionTexture> _transitionTextureFinding;
        private Dictionary<Color, AreaTransitionItem> _transitionItemsFinding;

        public bool Initialized { get; private set; }

        #endregion

        #region Props

        #region Item Part

        public int ItemsAltitude
        {
            get => _itemsAltitude;
            set
            {
                _itemsAltitude = value;
                RaisePropertyChanged(() => ItemsAltitude);
            }
        }

        #endregion //itemParts

        #region Coast Info

        [Description("Item Coast Altitude")]
        [Category("Area Color")]
        [DisplayName("Coast Altitude")]
        public int CoastAltitude
        {
            get => _coastAltitude;
            set
            {
                _coastAltitude = value;
                RaisePropertyChanged(() => CoastAltitude);
            }
        }

        [Description("Coast Smooth Circles")]
        [Category("Area Color")]
        [DisplayName(@"Coast Smooth Circles")]
        public List<CircleMountain> CoastSmoothCircles
        {
            get => _smoothCoast;
            set
            {
                _smoothCoast = value;
                RaisePropertyChanged(() => CoastSmoothCircles);
            }
        }

        public bool CliffCoast
        {
            get => _cliffCoast;
            set
            {
                _cliffCoast = value;
                RaisePropertyChanged(() => CliffCoast);
            }
        }

        #endregion

        #region ColorArea Generical part

        [Description("Index of Textures")]
        [Category("Area Color")]
        [DisplayName(@"Texture Index")]
        public int TextureIndex
        {
            get => _textureIndex;
            set
            {
                _textureIndex = value;
                RaisePropertyChanged(() => TextureIndex);
            }
        }

        [Description("Index of Color")]
        [Category("Area Color")]
        [DisplayName(@"Id")]
        public int Index
        {
            get => _index;
            set
            {
                _index = value;
                RaisePropertyChanged(() => Index);
            }
        }

        [Description("Mimimum of Randon Height in map making")]
        [Category("Map Making References")]
        [DisplayName(@"Minimal Height")]
        public int Min
        {
            get => _min;
            set
            {
                _min = value;
                RaisePropertyChanged(() => Min);
            }
        }

        [Description("Maximum of Randon Height in map making")]
        [Category("Map Making References")]
        [DisplayName(@"Maximum Height")]
        public int Max
        {
            get => _max;
            set
            {
                _max = value;
                RaisePropertyChanged(() => Max);
            }
        }

        [Description("Name of the Color Area")]
        [Category("Area Color")]
        [DisplayName(@"Name")]
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                RaisePropertyChanged(() => Name);
            }
        }

        [Description("Color of the Area Color")]
        [Category("Area Color")]
        [DisplayName(@"Color")]
        public Color Color
        {
            get => _color;
            set
            {
                _color = value;
                RaisePropertyChanged(() => Color);
            }
        }

        [Description("It describes what Area Color Represents")]
        [Category("Area Color")]
        [DisplayName(@"Type of Area")]
        public TypeColor Type
        {
            get => _typeColor;
            set
            {
                _typeColor = value;
                RaisePropertyChanged(() => Type);
            }
        }


        public int MinCoastTextureZ
        {
            get => _minCoastTextureZ;
            set
            {
                _minCoastTextureZ = value;
                RaisePropertyChanged(() => MinCoastTextureZ);
            }
        }

        #endregion

        #region Mountain Part

        [Description("It's the List of Circles of automatic grown in Map Making")]
        [Category("Rocks")]
        [DisplayName(@"Auto Circles")]
        public List<CircleMountain> List
        {
            get => _list;
            set
            {
                _list = value;
                RaisePropertyChanged(() => List);
            }
        }

        [Description("It refers to the Area Color at the top of the Rock")]
        [Category("Rocks")]
        [DisplayName(@"Color Top")]
        public Color ColorTopMountain
        {
            get => _colorMountain;
            set
            {
                _colorMountain = value;
                RaisePropertyChanged(() => ColorTopMountain);
            }
        }

        // [Description("It refers to the Area Color at the top of the Rock")]
        // [Category("Rocks")]
        // [DisplayName(@"Index Top")]
        // public int IndexColorTopMountain
        // {
        //     get => _indexColorTop;
        //     set
        //     {
        //         _indexColorTop = value;
        //         ColorTopMountain = MapSdk.Colors[value];
        //         RaisePropertyChanged(() => IndexColorTopMountain);
        //     }
        // }

        [Description("It refers to the Texture used at the Top of the Rock")]
        [Category("Rocks")]
        [DisplayName(@"Index Texture Top")]
        public int IndexTextureTop
        {
            get => _indexTextureTop;
            set
            {
                _indexTextureTop = value;
                RaisePropertyChanged(() => _indexTextureTop);
            }
        }

        [Description("It means if the automatic grown of the mountains is set or not")]
        [Category("Rocks")]
        [DisplayName(@"Automatic Rock Growning")]
        public bool ModeAutomatic
        {
            get => _automaticMode;
            set
            {
                _automaticMode = value;
                RaisePropertyChanged(() => ModeAutomatic);
            }
        }

        #endregion

        #region Added Collections

        public AreaTransitionItemCoast Coasts
        {
            get => _coast;
            set => _coast = value;
        }

        public List<AreaTransitionItem> TransitionItems
        {
            get => _transitionItems;
            set => _transitionItems = value;
        }

        public AreaItems Items
        {
            get => _items;
            set => _items = value;
        }

        public List<AreaTransitionTexture> TextureTransitions
        {
            get => _transitionTexture;
            set => _transitionTexture = value;
        }

        public List<AreaTransitionCliffTexture> TransitionCliffTextures
        {
            get => _transitionCliff;
            set => _transitionCliff = value;
        }

        #endregion

        #region Coast Info

        #endregion //Coast Info

        #endregion //props

        #region Searches

        public void InizializeSearches()
        {
            Initialized = true;
            _transitionTextureFinding = new Dictionary<Color, AreaTransitionTexture>();
            _transitionItemsFinding = new Dictionary<Color, AreaTransitionItem>();
            foreach (var areaTransitionTexture in TextureTransitions)
                try
                {
                    _transitionTextureFinding.Add(areaTransitionTexture.ColorTo, areaTransitionTexture);
                }
                catch (Exception)
                {
                }

            foreach (var areaTransitionItem in TransitionItems)
                try
                {
                    _transitionItemsFinding.Add(areaTransitionItem.ColorTo, areaTransitionItem);
                }
                catch (Exception)
                {
                }
        }

        public AreaTransitionTexture FindTransitionTexture(Color color)
        {
            AreaTransitionTexture found;
            _transitionTextureFinding.TryGetValue(color, out found);
            return found;
        }

        public AreaTransitionItem FindTransationItemByColor(Color color)
        {
            AreaTransitionItem transitionItem;
            _transitionItemsFinding.TryGetValue(color, out transitionItem);
            return transitionItem;
        }

        #endregion
    }

    public enum TypeColor
    {
        None,
        Water,
        Moutains,
        Land,
        Cliff,
        Special,
        WaterCoast,
        TransparentFluid
    }
}