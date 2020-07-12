using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Services
{
    public interface IPromotionEngineController
    {
        void Run(IEnumerable<string> productIds);
    }
}
