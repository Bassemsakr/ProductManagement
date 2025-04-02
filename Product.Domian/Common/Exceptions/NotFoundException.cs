﻿namespace ProductManagement.Domain.Common.Exceptions;
public class NotFoundException : Exception
{
    public NotFoundException()
        : base()
    {
    }

    public NotFoundException(string message)
        : base(message)
    {
    }

    public NotFoundException(string entityName, object key)
        : base($"Entity \"{entityName}\" ({key}) was not found.")
    {
    }

    public NotFoundException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}