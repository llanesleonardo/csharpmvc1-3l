using Tresele.crmbe.Models;
using Tresele.crmbe.Services.Interfaces;
namespace Tresele.crmbe.Endpoints;
public static class UserEndpoints
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/users", (IUserService service) => Results.Ok(service.GetAll()));

        app.MapGet("/users/{id}", (int id, IUserService service) =>
        {
            var user = service.GetById(id);
            return user != null ? Results.Ok(user) : Results.NotFound();
        });

        app.MapPost("/users", (User user, IUserService service) =>
        {
            service.Add(user);
            return Results.Created($"/users/{user.Id}", user);
        });

        app.MapPut("/users/{id}", (int id, User updatedUser, IUserService service) =>
        {
            return service.Update(id, updatedUser) ? Results.NoContent() : Results.NotFound();
        });

        app.MapDelete("/users/{id}", (int id, IUserService service) =>
        {
            return service.Delete(id) ? Results.Ok() : Results.NotFound();
        });
    }
}
