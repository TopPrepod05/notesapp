using Microsoft.EntityFrameworkCore;
using NotesApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NotesApp;

public class AppDbContext : DbContext
{
    public DbSet<Note> Notes => Set<Note>();
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        var folder = Path.Combine(appdata, "NotesApp");
        Directory.CreateDirectory(folder);
        var path = Path.Combine(folder, "app.db");
        optionsBuilder.UseSqlite($"Data Source={path}");
    }
}
