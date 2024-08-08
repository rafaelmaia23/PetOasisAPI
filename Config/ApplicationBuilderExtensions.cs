using PetOasisAPI.Data;
using PetOasisAPI.Models.Users;

namespace PetOasisAPI.Config;

public static class ApplicationBuilderExtensions
{
    public static async Task InitializeEmployeeNumberAsync(this IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            await Employee.InitializeEmployeeNumberAsync(context);
        }
    }
}