using System.Text;
using System.Text.Json.Serialization;
using System.Reflection;
using BibCorp.Application.Services.Contracts.Acervos;
using BibCorp.Application.Services.Contracts.Emprestimos;
using BibCorp.Application.Services.Contracts.Patrimonios;
using BibCorp.Application.Services.Contracts.Usuarios;
using BibCorp.Application.Services.Packages;
using BibCorp.Application.Services.Packages.Acervos;
using BibCorp.Application.Services.Packages.Emprestimos;
using BibCorp.Application.Services.Packages.Patrimonios;
using BibCorp.Application.Services.Packages.Usuarios;
using BibCorp.Domain.Models.Usuarios;
using BibCorp.Persistence.Interfaces.Contexts;
using BibCorp.Persistence.Interfaces.Contracts.Acervos;
using BibCorp.Persistence.Interfaces.Contracts.Emprestimos;
using BibCorp.Persistence.Interfaces.Contracts.Patrimonios;
using BibCorp.Persistence.Interfaces.Contracts.Shared;
using BibCorp.Persistence.Interfaces.Contracts.Usuarios;
using BibCorp.Persistence.Interfaces.Packages.Acervos;
using BibCorp.Persistence.Interfaces.Packages.Patrimonios;
using BibCorp.Persistence.Interfaces.Packages.Shared;
using BibCorp.Persistence.Interfaces.Packages.Usuarios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;


namespace BibiCorp.API
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      // Injeção do DBCONTEXT no projeto
      services
        .AddDbContext<BibCorpContext>(
          context => context.UseSqlite(Configuration.GetConnectionString("DefaultConnection"))
      );

      // Injeção Identity
      services
        .AddIdentityCore<Usuario>(options =>
          {
            options.Password.RequireDigit = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 4;
          })
        .AddRoles<Papel>()
        .AddRoleManager<RoleManager<Papel>>()
        .AddSignInManager<SignInManager<Usuario>>()
        .AddRoleValidator<RoleValidator<Papel>>()
        .AddEntityFrameworkStores<BibCorpContext>()
        .AddDefaultTokenProviders();

      //Injeção de autenticação
      services
        .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
          {
            options.TokenValidationParameters = new TokenValidationParameters
              {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["TokenKey"])),
                ValidateIssuer = false,
                ValidateAudience = false
              };
          });

      //Injeção das controllers
      services
          .AddControllers()

          // Já leva os enum convertidos na query
          .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()))

          // Eliminar loop infinito da estrutura
          .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

      //InjeÇão do mapeamento automático de campos (DTO)
      services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

      //Injeção dos serviços de persistencias
      services
          .AddScoped<IAcervoService, AcervoService>()
          .AddScoped<IPatrimonioService, PatrimonioService>()
          .AddScoped<IEmprestimoService, EmprestimoService>()
          .AddScoped<IUsuarioService, UsuarioService>()
          .AddScoped<ITokenService, TokenService>();


      //Injeção das interfaces de Persistencias
      services
          .AddScoped<IAcervoPersistence, AcervoPersistence>()
          .AddScoped<IPatrimonioPersistence, PatrimonioPersistence>()
          .AddScoped<IEmprestimoPersistence, EmprestimoPersistence>()
          .AddScoped<IUsuarioPersistence, UsuarioPersistence>()
          .AddScoped<ISharedPersistence, SharedPersistence>();


      services
      .AddSwaggerGen(options =>
      {
        options.SwaggerDoc("v1", new OpenApiInfo { Title = "BibCorp.API", Version = "v1", Description = "API responsável por implementar as funcionalidades de backend do sistema Biblioteca Corporativa Prevenir Assistencial LTDA" });

        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        options.IncludeXmlComments(xmlPath);
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
      }
      app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BibCorp.API v1"));

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthentication();
      app.UseAuthorization();

      app.UseCors(cors =>
          cors.AllowAnyHeader()
              .AllowAnyMethod()
              .AllowAnyOrigin()
              );

      app.UseHttpsRedirection();  

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
