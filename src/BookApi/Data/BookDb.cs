using Microsoft.EntityFrameworkCore;
using BookApi.Models;

namespace BookApi.Data;

public class BookDb : DbContext
{
    public BookDb(DbContextOptions<BookDb> options) : base(options) { }

    // TODO: Ajouter le DbSet pour les livres
    public DbSet<Book> Books => Set<Book>();
}