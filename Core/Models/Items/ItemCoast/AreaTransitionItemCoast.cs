using System;
using System.Runtime.Serialization;
using Core.Models.Elements.BaseTypes;

namespace Core.Models.Elements.Items.ItemCoast
{
    [Serializable]
    public class AreaTransitionItemCoast : NotificationObject
    {
        private TransitionItemsCoast _coast;
        private TransitionItemsCoast _ground;
        private string _name;

        public AreaTransitionItemCoast()
        {
            Coast = new TransitionItemsCoast();
            Ground = new TransitionItemsCoast();
            Name = "";
        }

        protected AreaTransitionItemCoast(SerializationInfo info, StreamingContext context)
        {
            Name = Deserialize(() => Name, info);
            Coast = Deserialize(() => Coast, info);
            Ground = Deserialize(() => Ground, info);
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

        public TransitionItemsCoast Coast
        {
            get => _coast;
            set
            {
                _coast = value;
                RaisePropertyChanged(() => Coast);
            }
        }

        public TransitionItemsCoast Ground
        {
            get => _ground;
            set
            {
                _ground = value;
                RaisePropertyChanged(() => Ground);
            }
        }


        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Serialize(() => Name, info);
            Serialize(() => Coast, info);
            Serialize(() => Ground, info);
        }
    }
}