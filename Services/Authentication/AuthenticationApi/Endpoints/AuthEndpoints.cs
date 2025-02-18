﻿namespace TaskManagementApp.Services.AuthenticationApi.Endpoints
{
    public class AuthEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            ApiVersionSet apiVersionSet = app.NewApiVersionSet()
                .HasApiVersion(new ApiVersion(1))
                .ReportApiVersions()
                .Build();

            var group = app.MapGroup("/api/v{version:apiVersion}/auth")
                .WithApiVersionSet(apiVersionSet);

            group.MapPost("/login", Login);
            group.MapPost("/register", Register);
        }

        public async Task<Results<Ok<LoginResponse>, NotFound<string>, BadRequest<string>>>
            Login(
                [FromBody] LoginRequest request,
                [FromServices] IAuthRepository repository,
                [FromServices] ITokenProvider tokenProvider,
                UserManager<AppUser> userManager,
                IMapper mapper,
                [FromServices] ILogger<AuthEndpoints> logger)
        {
            try
            {
                logger.LogInformation("Signing the user in...");

                var user = await repository.GetUserAsync(u => u.UserName == request.UserName);

                bool isUserValid = await userManager.CheckPasswordAsync(user, request.Password);

                if (user is null || isUserValid == false)
                {
                    logger.LogError("Invalid credential!");
                    return TypedResults.BadRequest("Username or password is wrong!");
                }

                // If credential is valid, generate JWT token
                IEnumerable<Role> roles = (await userManager.GetRolesAsync(user))
                    .Select(r => (Role)Enum.Parse(typeof(Role), r));
                var token = tokenProvider.CreateToken(user, roles);

                AppUserDto userDto = mapper.Map<AppUserDto>(user);

                LoginResponse response = new LoginResponse()
                {
                    User = userDto,
                    Token = token
                };

                return TypedResults.Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError("\n---\nError(s) occured: \n---\n{error}", ex);

                return TypedResults.BadRequest("Error(s) occured when signing the user in!");
            }
        }

        public async Task<Results<Ok<string>, BadRequest<string>>> 
            Register(
                [FromBody] RegistrationRequest request,
                [FromServices] IAuthRepository repository,
                [FromServices] ILogger<AuthEndpoints> logger,
                IMapper mapper,
                UserManager<AppUser> userManager)
        {
            try
            {
                logger.LogInformation("Registering the user...");

                AppUser user = mapper.Map<AppUser>(request);

                var result = await userManager.CreateAsync(user, request.Password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, request.Role.ToString());
                }

                return TypedResults.Ok("Register successfully!");
            }
            catch (Exception ex)
            {
                logger.LogError("\n---\nError(s) occured: \n---\n{error}", ex);

                return TypedResults.BadRequest("Error(s) occured when registering the user!");
            }
        }
    }


}
