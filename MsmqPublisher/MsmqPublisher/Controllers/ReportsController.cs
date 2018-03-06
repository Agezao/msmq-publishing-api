using MsmqPublisher.Dal.DataControllers;
using MsmqPublisher.Helpers;
using MsmqPublisher.Messaging;
using MsmqPublisher.Models;
using MsmqPublisher.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MsmqPublisher.Controllers
{
    public class ReportsController : ApiController
    {
        // POST api/reports
        public string Post([FromBody]List<TipoRelatorioEnum> reports)
        {
            var requestedReports = reports.Select(r => (TipoRelatorioEnum)r).ToList();
            // Fake User`s data
            var clientId = 999999;
            var codPessoa = 9898989;
            var protocolo = Guid.NewGuid().ToString();
            var destinationMail = "user.email@foobar.com";
            var relatoriosString = "";
            var sendDate = DateTime.Now;
            relatoriosString = string.Join(",", reports);

            // Used for test purposes
            // Use this program to send messages so you can test if the MsmqConsumer is working properly
            try
            {
                var mQueue = new MQueue<ReportParamsModel>();

                // Sending a message for testing
                ReportParamsModel messageTest = new ReportParamsModel
                {
                    DestinationMail = destinationMail,
                    ClientId = clientId,
                    CodPessoa = codPessoa,
                    Protocolo = protocolo,
                    SendDate = sendDate,
                    Relatorios = requestedReports
                };
                mQueue.Queue.Send(messageTest);

                var dal = new ReportLogDal();
                dal.Save(new LogReportAsyncModel
                {
                    ClientID = clientId,
                    CodPessoa = codPessoa,
                    DestinationMail = destinationMail,
                    Protocolo = protocolo,
                    Relatorios = relatoriosString,
                    SendDate = sendDate,
                    Status = (int)StatusLogRelatorioEnum.Solicitado
                });
                dal.Dispose();

                return "success";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
