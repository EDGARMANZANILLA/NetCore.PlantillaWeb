using Microsoft.EntityFrameworkCore;
using NetCore.Datos.CPMexicoDBConsultas;
using NetCore.Datos.Repos;
using NetCore.Negocios.CPMexicoNegocios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

/***********************************************************************************************/
/***    USA EL HTTP CLIENT EN LA INYECION DE DEPENDENCIAS PARA USAR EL IHttpClientFactory    ***/
/***********************************************************************************************/
builder.Services.AddHttpClient();



/************************************************************
 *          CARGA DE LA PRIMERA BASE DE CPMexicoDb
 ************************************************************/
builder.Services.AddDbContext<NetCore.Datos.CPMexicoDBContext.CpmexicoContext>(opciones =>
{
    opciones.UseSqlServer(builder.Configuration.GetConnectionString("CPMexicoCadenaConexion"));
});


builder.Services.AddTransient(typeof(NetCore.Datos.Repos.Interfaces._IRepositoryCPMexicoDb<>), typeof(NetCore.Datos.Repos.Repositorios.RepositorioCPMexicoDb<>));
builder.Services.AddTransient(typeof(NetCore.Datos.Repos.Interfaces._IRepositoryArdalisCPMexicoDb<>), typeof(NetCore.Datos.Repos.Repositorios.RepositorioCPMexicoDb_Ardalis<>));


/************************************************************
 *          INYENCIONES DE DEPENDENCIAS 
 ************************************************************/
builder.Services.AddTransient<DboAsentamientosConsultas>();
builder.Services.AddTransient<DboEstadosConsultas>();
builder.Services.AddTransient<DboMunicipiosConsultas>();


builder.Services.AddTransient<AsentamientosNegocios>();
builder.Services.AddTransient<EstadosNegocios>();
builder.Services.AddTransient<MunicipiosNegocios>();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
