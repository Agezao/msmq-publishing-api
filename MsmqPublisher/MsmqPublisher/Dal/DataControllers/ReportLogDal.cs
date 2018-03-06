using MsmqPublisher.Dal.Contexts;
using MsmqPublisher.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MsmqPublisher.Dal.DataControllers
{
    public class ReportLogDal : PostgresContext
    {
        public ReportLogDal() { }

        public LogReportAsyncModel Save(LogReportAsyncModel logReport)
        {
            LogReportAsyncModel result = null;

            var query = $@"
                insert into {MainSchema}.""logrelatoriosasync"" (protocolo, clientid, destinationmail, codpessoa, relatorios, senddate, status, Descricao)
                values(
                    @Protocolo, 
                    @ClientId, 
                    @DestinationMail, 
                    @CodPessoa, 
                    @Relatorios,
                    @SendDate, 
                    @Status,
                    @Descricao)
                    RETURNING Id;
            ";

            // Execute & parse query
            using (NpgsqlCommand command = new NpgsqlCommand(query, base._conn))
            {
                command.Parameters.AddWithValue("@Protocolo", NpgsqlTypes.NpgsqlDbType.Varchar, (object)logReport.Protocolo);
                command.Parameters.AddWithValue("@ClientId", NpgsqlTypes.NpgsqlDbType.Integer, (object)logReport.ClientID);
                command.Parameters.AddWithValue("@DestinationMail", NpgsqlTypes.NpgsqlDbType.Varchar, (object)logReport.DestinationMail);
                command.Parameters.AddWithValue("@CodPessoa", NpgsqlTypes.NpgsqlDbType.Integer, (object)logReport.CodPessoa);
                command.Parameters.AddWithValue("@Relatorios", NpgsqlTypes.NpgsqlDbType.Varchar, (object)logReport.Relatorios);
                command.Parameters.AddWithValue("@SendDate", NpgsqlTypes.NpgsqlDbType.Date, (object)logReport.SendDate);
                command.Parameters.AddWithValue("@Status", NpgsqlTypes.NpgsqlDbType.Integer, (object)logReport.Status);
                command.Parameters.AddWithValue("@Descricao", NpgsqlTypes.NpgsqlDbType.Varchar, !string.IsNullOrEmpty(logReport.Descricao) ? (object)logReport.Descricao : DBNull.Value);

                try
                {
                    var dbId = (int)command.ExecuteScalar();
                    result = logReport;
                    result.Id = dbId;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return result;
        }
    }
}