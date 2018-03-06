using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MsmqPublisher.Models
{
    public class LogReportAsyncModel
    {
        public int Id { get; set; }
        public string Protocolo { get; set; }
        public int CodPessoa { get; set; }
        public int ClientID { get; set; }
        public string DestinationMail { get; set; }
        public string Relatorios { get; set; }
        public DateTime SendDate { get; set; }
        /// <summary>
        /// Status. 1 - Solicitado. 2 - Enviado. 3 - Erro
        /// </summary>
        public int? Status { get; set; }
        public string Descricao { get; set; }

    }
}