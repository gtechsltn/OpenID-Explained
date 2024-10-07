using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.OAuth;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
})
.AddCookie("Cookies")
.AddGoogle(options =>
{
    options.ClientId = ""; // Replace with your Client ID
    options.ClientSecret = ""; // Replace with your Client Secret
    options.Scope.Add("openid");
    options.Scope.Add("profile");
    options.Scope.Add("email");
    options.CallbackPath = new PathString("/signin-google"); // Ensure this matches with the Google Cloud Console
                                                             // Increase the timeout
    /// options.Backchannel.Timeout = TimeSpan.FromSeconds(120); // Increase timeout to 120 seconds


    // Optional: Configure events
    options.Events = new OAuthEvents
    {
        OnCreatingTicket = context =>
        {
            // You can add custom logic here after the user is authenticated
            return Task.CompletedTask;
        }
    };
});

builder.Services.AddRazorPages();


builder.Logging.ClearProviders();
builder.Logging.AddConsole(); // Log to the console
builder.Logging.ClearProviders();
builder.Logging.AddConsole(); // Log to the console


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();