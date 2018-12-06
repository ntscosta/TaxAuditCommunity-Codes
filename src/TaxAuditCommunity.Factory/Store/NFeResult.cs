using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaxAuditCommunity.Factory.Store
{
    public class NFeResult
    {
        private static readonly NFeResult _success = new NFeResult { Succeeded = true };

        public bool Succeeded { get; protected set; }
        public Exception Exception { get; protected set; }
        public DbUpdateConcurrencyException DbUpdateConcurrencyException { get; protected set; }
        public DbUpdateException DbUpdateException { get; protected set; }
        public int ErrorNumber { get; protected set; }
        public NFeResultException NFeResultException { get; protected set; }

        public static NFeResult Success => _success;

        public static NFeResult Failed(Exception exception)
        {
            var result = new NFeResult
            {
                Succeeded = false,
                Exception = exception,
                NFeResultException = NFeResultException.Exception
            };
            return result;
        }
        public static NFeResult Failed(DbUpdateConcurrencyException exception)
        {
            var result = new NFeResult
            {
                Succeeded = false,
                DbUpdateConcurrencyException = exception,
                NFeResultException = NFeResultException.DbUpdateConcurrencyException
            };
            return result;
        }
        public static NFeResult Failed(DbUpdateException exception)
        {
            var result = new NFeResult
            {
                Succeeded = false,
                DbUpdateException = exception,
                NFeResultException = NFeResultException.DbUpdateException,
                ErrorNumber = ((System.Data.SqlClient.SqlException)exception.InnerException).Number
            };
            return result;
        }
    }

    public enum NFeResultException
    {
        Exception,
        DbUpdateConcurrencyException,
        DbUpdateException

    }
}
