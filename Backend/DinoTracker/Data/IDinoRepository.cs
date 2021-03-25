using System.Collections;
using System.Collections.Generic;
using DinoTracker.Core;

namespace DinoTracker.Data
{
    public interface IDinoRepository
    {
        IEnumerable<Dino> GetAll();
    }
}