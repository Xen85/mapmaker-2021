using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Core.Models.Elements.BaseTypes;
using Core.Models.Elements.ColorArea.ColorArea;

namespace Core.Models.Elements.ColorArea
{
    [Serializable]
    [XmlInclude(typeof(AreaColorCoast))]
    public sealed class CollectionAreaColor : NotificationObject, IContainerSet
    {
        private List<AreaColor> _list;

        #region Ctor

        public CollectionAreaColor()
        {
            _list = new List<AreaColor>();
            _findfastcolor = null;
            _findfastid = null;
            _colordic = null;
            // Update();
        }

        #endregion //Ctor

        protected CollectionAreaColor(SerializationInfo info, StreamingContext context)
        {
            List = new List<AreaColor>(Deserialize(() => List, info));
        }

        #region Props

        public List<AreaColor> List
        {
            get => _list;
            set
            {
                _list = value;
                // Update();
                RaisePropertyChanged(null);
            }
        }

        #endregion //Props


        public List<int> Indexes
        {
            get
            {
                var list = List.Select(element => element.Index).ToList();
                return list;
            }
        }


        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Serialize(() => List, info);
        }

        // private void Update()
        // {
        //     if (List != null)
        //         List.CollectionChanged += (element, arg) =>
        //         {
        //             InitializeSeaches();
        //             RaisePropertyChanged(() => Indexes);
        //         };
        // }

        #region Fields

        [NonSerialized] private Dictionary<Color, AreaColor> _findfastcolor;
        [NonSerialized] private Dictionary<int, AreaColor> _findfastid;
        [NonSerialized] private Dictionary<Color, bool> _colordic;

        #endregion //Fields

        #region SearchMethods

        public AreaColor FindByColor(Color color)
        {
            AreaColor a;
            _findfastcolor.TryGetValue(color, out a);
            return a;
        }

        public AreaColor FindByIndex(int index)
        {
            AreaColor a;
            _findfastid.TryGetValue(index, out a);
            return a;
        }

        public AreaColor FindByByteArray(byte[] arrayRGB)
        {
            AreaColor area;

            _findfastcolor.TryGetValue(Color.FromArgb(arrayRGB[0], arrayRGB[1], arrayRGB[2]), out area);
            return area;
        }

        public void InitializeSeaches()
        {
            _findfastid = new Dictionary<int, AreaColor>();
            _colordic = new Dictionary<Color, bool>();
            _findfastcolor = new Dictionary<Color, AreaColor>();

            foreach (var area in List)
                try
                {
                    _colordic.Add(area.Color, true);
                    _findfastcolor.Add(area.Color, area);
                    _findfastid.Add(area.Index, area);
                }
                catch (Exception)
                {
                }
        }

        #endregion //SearchMethods
    }
}