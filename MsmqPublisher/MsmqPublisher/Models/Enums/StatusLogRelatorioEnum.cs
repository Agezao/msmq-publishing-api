using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MsmqPublisher.Models.Enums
{
    public enum StatusLogRelatorioEnum
    {
        /// 0 - Erro
        Erro = 0,
        /// 1 - Solicitado. 2 - Enviado. 3 - Erro
        Solicitado = 1,
        /// 2 - Enviado. 3 - Erro
        Enviado = 2
    }
}