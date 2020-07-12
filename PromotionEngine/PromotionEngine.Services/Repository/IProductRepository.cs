using System;
using System.Text;

namespace PromotionEngine.Services.Repository
{
    public interface IProductRepository
    {
        Product Get(string name);
    }
}
