using api.database;
using api.models;
using Microsoft.AspNetCore.Cors;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("OpenPolicy",
    builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();




app.UseAuthorization();

app.UseCors("OpenPolicy");

app.MapControllers();

app.Run();

// Clothing myClothing = new Clothing() { Title = "My Title", Type = "My Type", Occasion = "My Occasion", Size = "My Size" };

// myClothing.Save.CreateClothing(myClothing);

// User myUser = new User() { FullName = "My Full Name", Password = "My Password", Email = "My Email", Role = 1, IsBanned = false };

// myUser.Save.CreateUser(myUser);

// Promotion myPromotion = new Promotion() { promoterID = 1, promoteeID = 2, promotionDate = new DateOnly(2021, 10, 10), newRole = 1 };

// myPromotion.Save.CreatePromotion(myPromotion);

// Offer myOffer = new Offer() { CustomerID = 1, ClothingID = 1 };
// myOffer.Save.CreateOffer(myOffer);

List<User> allUsers = new List<User>();
ReadUser readUser = new ReadUser();
allUsers = readUser.GetAllUsers();
foreach (User user in allUsers)
{
    if (user.Email == "My Email" || user.Email == "ryanrcahill@gmail.com")
    {
        user.IsBanned = true;
        user.Update.EditUser(user);
    }

}