using System.Collections.Generic;
using Core.Models.Elements.BaseTypes.ComplexTypes;

namespace Core.Models.Elements.Interfaces
{
    public interface ITransition
    {
        List<CollectionLine> Lines { get; set; }
    }
}