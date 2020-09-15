using Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
    public abstract class AbstractFactoryData : IDisposable, IConn
    {

        protected DbConnection conn;

        protected DbTransaction trans;

        protected IConfiguration _configuration { get; }

        public DbCommand ObterCommand()
        {
            return conn.CreateCommand();
        }

        protected abstract DbConnection CriarConeccao();

        bool disposed = false;

        public DbConnection GetCon { get => conn; }

        protected AbstractFactoryData(IConfiguration configuration)
        {
            _configuration = configuration;
            conn = CriarConeccao();
        }



        #region " Métodos Assincronos "


        public async Task ExecReaderAsync(DbCommand command, Action<DbDataReader> Event)
        {

            if (!VerificarTypesCommand(command))
                return;
            DbDataReader leitura = null;
            try
            {
                AssociarCommandTransaction(command);
                await OpenConnectionAsync();
                //OpenConnection();
                leitura = await command.ExecuteReaderAsync();
                Event?.Invoke(leitura);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                leitura.Close();
                leitura = null;
            }
        }


        public async Task ExecCommandAsync(DbCommand command)
        {

            if (!VerificarTypesCommand(command))
                return;

            AssociarCommandTransaction(command);
            await OpenConnectionAsync();
            await command.ExecuteNonQueryAsync();
        }

        public async Task<object> ExecEscalarAsync(DbCommand command)
        {

            if (!VerificarTypesCommand(command))
                return null;

            AssociarCommandTransaction(command);
            await OpenConnectionAsync();
            return await command.ExecuteScalarAsync();
        }



        protected async Task OpenConnectionAsync()
        {
            if (conn.State != System.Data.ConnectionState.Open)
                await conn.OpenAsync();
        }

        #endregion

        #region " Métodos Privados "

        bool VerificarTypesCommand(DbCommand command)
        {


            return conn.CreateCommand().GetType() == command.GetType();
        }

        void AssociarCommandTransaction(DbCommand command)
        {
            command.Connection = conn;
            if (trans != null)
                command.Transaction = trans;
        }


        #endregion



        public DbParameter ObterParametro(DbCommand dbCommand, string nome, object value)
        {
            var par = dbCommand.CreateParameter();
            par.ParameterName = nome;
            par.Value = value;
            return par;

        }

        public void ExecReader(DbCommand command, Action<DbDataReader> Event)
        {


            if (!VerificarTypesCommand(command))
                return;
            DbDataReader leitura = null;
            try
            {

                AssociarCommandTransaction(command);
                OpenConnection();
                leitura = command.ExecuteReader();
                Event?.Invoke(leitura);

            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                leitura.Close();
                leitura = null;
            }
        }

        public void ExecCommand(DbCommand command)
        {
            if (!VerificarTypesCommand(command))
                return;

            command.Connection = conn;
            if (trans != null)
                command.Transaction = trans;
            OpenConnection();
            command.ExecuteNonQuery();
        }

        public object ExecEscalar(DbCommand command)
        {

            if (!VerificarTypesCommand(command))
                return null;

            command.Connection = conn;
            if (trans != null)
                command.Transaction = trans;
            OpenConnection();
            return command.ExecuteScalar();
        }

        protected void OpenConnection()
        {

            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
        }

        public void IniciarTransacao()
        {
            OpenConnection();
            trans = conn.BeginTransaction(isolationLevel: System.Data.IsolationLevel.ReadUncommitted);
        }

        public async Task IniciarTransacaoAsync()
        {
            OpenConnection();
            trans = await conn.BeginTransactionAsync(isolationLevel: System.Data.IsolationLevel.ReadUncommitted);
        }


        public void CommitarTransacao()
        {
            if (trans != null)
                trans.Commit();
        }

        public async Task CommitarTransacaoAsync()
        {
            if (trans != null)
                await trans.CommitAsync();
        }

        public void RollbackTransaction()
        {
            if (trans != null)
                trans.Rollback();
        }

        public async Task RollbackTransactionAsync()
        {
            if (trans != null)
                await trans.RollbackAsync();
        }

        protected void FecharConnection()
        {
            if (conn != null && conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
                conn = null;
            }
        }

        protected async Task FecharConnectionAsync()
        {
            if (conn != null && conn.State == System.Data.ConnectionState.Open)
            {
                await conn.CloseAsync();
                conn = null;
            }
        }
        public void Dispose()
        {

            FecharConnection();
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {

                RollbackTransaction();
                FecharConnection();
                // Free any other managed objects here.
                //
            }
            disposed = true;
        }

    }
}
