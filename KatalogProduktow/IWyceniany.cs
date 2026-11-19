using System;
using System.Collections.Generic;
using System.Text;

namespace KatalogProduktow
{
    public interface IWyceniany
    {
        string Nazwa { get; }
        double Cena { get; }
    }
}
