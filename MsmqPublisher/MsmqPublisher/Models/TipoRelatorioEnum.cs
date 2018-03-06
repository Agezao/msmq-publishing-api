using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MsmqPublisher.Models
{
    public enum TipoRelatorioEnum
    {
        ExportacaoMaritimo = 1,
        ImportacaoMaritimo = 2,
        ExportacaoAereo = 3,
        ImportacaoAereo = 4,
        Desembaraco = 5
    }
}