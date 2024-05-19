using Microsoft.EntityFrameworkCore;
using Minimal_API_Prac.DB;
using Minimal_API_Prac.Interface;
using Minimal_API_Prac.Model;
using Minimal_API_Prac.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BookDB>(opt => opt.UseInMemoryDatabase("BookDB"));
builder.Services.AddScoped<IBookService, BookService>();

var app = builder.Build();


app.MapGet("/book", async (IBookService bookService) => 
  Results.Ok( await bookService.GetBooks())
).WithName("GetBooks");

app.MapGet("book/{id}", (IBookService bookService, int id) => (
  Results.Ok(bookService.GetBook(id))
)).WithName("GetBook"); ;

app.MapPost("/book", (IBookService bookService, Book book) => (
  Results.Ok(bookService.AddBook(book))
)).WithName("AddBook");

app.MapPut("/book/{id}", (IBookService bookService, int id, Book book) => (
  Results.Ok(bookService.UpdateBook(id,book))
)).WithName("UpdateBook");

app.MapDelete("/book/{id}", (IBookService bookService, int id) => (
  Results.Ok(bookService.DeleteBook(id))
)).WithName("DeleteBook");


// app.MapGet("/", () => "Hello World!");

app.Run();

public partial class Program { }
