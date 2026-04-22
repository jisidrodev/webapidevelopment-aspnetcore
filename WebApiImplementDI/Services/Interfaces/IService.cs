using System;

namespace WebApiImplementDI.Services.Interfaces;

public interface IService
{
    string Name { get; }
    string SayHello();
}
