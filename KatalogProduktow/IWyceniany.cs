using System;
using System.Collections.Generic;
using System.Text;

namespace KatalogProduktow
{
    public interface IWyceniany
    {
        string Name { get; }
        double Price { get; }
    }
}
