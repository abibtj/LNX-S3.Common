using System;

namespace S3.Common.Vault
{
    public class VaultAuthTypeNotSupportedException : Exception
    {
        public string AuthType { get; set; }
        
        public VaultAuthTypeNotSupportedException(string authType) : this(string.Empty, authType)
        {
        }

        public VaultAuthTypeNotSupportedException(string message, string authType) : base(message)
        {
            AuthType = authType;
        }
    }
}