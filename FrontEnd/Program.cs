using Sistema_de_Gestion_de_Hospitales.FrontEnd;
using Sistema_de_Gestion_de_Hospitales.FrontEnd.Interfaces;
using Sistema_de_Gestion_de_Hospitales.FrontEnd.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Blazorise;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5432")});
builder.Services.AddScoped<ICategoriasCitasService, CategoriasCitasService>();
builder.Services.AddScoped<ICitasService, CitasService>();
builder.Services.AddScoped<IDepartamentosService, DepartamentosService>();
builder.Services.AddScoped<IDiagnosticosService, DiagnosticosService>();
builder.Services.AddScoped<IDoctoresService, DoctoresService>();
builder.Services.AddScoped<IEnfermerasService, EnfermerasService>();
builder.Services.AddScoped<IEspecialidadesService, EspecialidadesService>();
builder.Services.AddScoped<IEstadosService, EstadosService>();
builder.Services.AddScoped<IHabitacionesService, HabitacionesService>();
builder.Services.AddScoped<ITratamientosService, TratamientosService>();
builder.Services.AddScoped<IPacientesService, PacientesService>();

builder.Services
    .AddBlazorise();

await builder.Build().RunAsync();
