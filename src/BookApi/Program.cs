using BookApi.Data;
using BookApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BookDb>(opt => opt.UseInMemoryDatabase("BookList"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.MapGet("/", () => "Hello World!");

app.MapGet("/books", async (BookDb db) =>
{
    // Récupérer tous les livres depuis la base de données
    var books = await db.Books.ToListAsync();

});


app.MapPost("/books", async (Book book, BookDb db) => {
    db.Books.Add(book);
    await db.SaveChangesAsync();
    return Results.Created($"/books/{book.Id}", book);
});

// app.MapPut("/books/{id}", async (int id, BookDb db) => {
//     throw new NotImplementedException("This is a test exception.");
// });
 app.MapPut("/books/{id}", async (int id, Book updatedBook, BookDb db) =>
 {
     
     var existingBook = await db.Books.FindAsync(id);

     await db.SaveChangesAsync();

     return Results.Ok(existingBook);
 });


app.Run();