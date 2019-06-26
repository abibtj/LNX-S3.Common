using System;

namespace S3.Common.Types
{
    public class S3Exception : Exception
    {
        public string Code { get; }

        public S3Exception()
        {
        }

        public S3Exception(string code)
        {
            Code = code;
        }

        public S3Exception(string message, params object[] args) 
            : this(string.Empty, message, args)
        {
        }

        public S3Exception(string code, string message, params object[] args) 
            : this(null, code, message, args)
        {
        }

        public S3Exception(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        public S3Exception(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }        
    }
}