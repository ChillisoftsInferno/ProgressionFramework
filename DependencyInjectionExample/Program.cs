using DependencyInjectionExample.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSingleton<RandomNumberService>();

// Dependency Injection:
//----------------------------------------------------------------------------------------------------------------------

// Types of services:

// - Singleton
// - Transient
// - Scoped

// These terms essentially describe how objects managed by dependency injection containers behave and their lifecycle 
// within the application.

//----------------------------------------------------------------------------------------------------------------------
