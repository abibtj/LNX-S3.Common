using System;

namespace S3.Common.Types
{
    public interface IIdentifiable
    {
         Guid Id { get; }
    }
}