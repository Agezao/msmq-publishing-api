using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MsmqPublisher.Models
{
    /// <summary>
    /// Example of a report filters/params that will be received via the queue
    /// </summary>
    public class ReportParamsModel
    {
        public string Protocolo { get; set; }
        public int ClientId { get; set; }
        public string DestinationMail { get; set; }
        public int CodPessoa { get; set; }
        public List<TipoRelatorioEnum> Relatorios { get; set; }
        public DateTime SendDate { get; set; }
        public string Status { get; set; }
        public string Descricao { get; set; }

    }
}