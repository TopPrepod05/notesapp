using Microsoft.EntityFrameworkCore;
using NotesApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Repositories;

public class NoteRepository(IDbContextFactory<AppDbContext> factory) : INoteRepository
{
    public async Task AddNoteAsync(Note note)
    {
        using var db = await factory.CreateDbContextAsync();
        await db.Notes.AddAsync(note);
        await db.SaveChangesAsync();
    }

    public async Task DeleteNoteAsync(Note note)
    {
        using var db = await factory.CreateDbContextAsync();
        db.Notes.Remove(note);
        await db.SaveChangesAsync();
    }

    public async Task<Note?> GetNoteAsync(int id)
    {
        using var db = await factory.CreateDbContextAsync();
        return await db.Notes.FindAsync(id);
    }

    public async Task<List<Note>> GetNotesAsync()
    {
        using var db = await factory.CreateDbContextAsync();
        return await db.Notes.ToListAsync();
    }
}
