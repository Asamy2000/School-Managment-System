using SchoolManagment.Contexts;
using SchoolManagment.Interfaces;
using SchoolManagment.MappingProfile;
using SchoolManagment.Reposatories;

namespace SchoolManagment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();

            //Session Configurations
            builder.Services.AddSession(S => { S.IdleTimeout = TimeSpan.FromDays(1); });
            //enable DI
            builder.Services.AddDbContext<SchoolDbContext>();
            builder.Services.AddAutoMapper(I => I.AddProfile(new InstructorProfile()));
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
            //Session MiddleWare
            app.UseSession();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}