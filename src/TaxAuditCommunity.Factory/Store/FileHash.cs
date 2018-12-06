using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace TaxAuditCommunity.Factory.Store
{
    public static class FileHash
    {
        public static byte[] CreateHash(this FileInfo file)
        {
            if (file == null)
                throw new ArgumentNullException(nameof(CreateHash));

            Stream stream = file.OpenRead();

            byte[] result = MD5.Create().ComputeHash(stream);

            stream.Close();

            return result;
        }
    }
}
