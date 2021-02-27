using System;

namespace Core.Models.Elements
{
    public class ProgressEventArgs : EventArgs
    {
        public string PayLoad { get; set; }
        public int Progress { get; set; }
    }
}