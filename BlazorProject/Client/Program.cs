using Blazor.IndexedDB.Framework;
using BlazorProject.Client;
using BlazorProject.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Syncfusion.Blazor;

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTU4NTg4QDMxMzkyZTM0MmUzMFIzWk15dUk1UmFSelFvVk5DY1hZcEZNRVpxdTRQYW1PMVhNbGRUdEszOVE9");
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient<IEmployeeService, EmployeeService>(client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});

builder.Services.AddHttpClient<IDepartmentService, DepartmentService>(client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});

//builder.Services.AddScoped<IIndexedDbFactory, IndexedDbFactory>();

builder.Services.AddMudServices();
builder.Services.AddScoped<IndexedEdbStore>();

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSyncfusionBlazor();
builder.Services.AddScoped<EmployeeAdaptor>();
await builder.Build().RunAsync();
