using NotesApp.Models;
using NotesApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Services;

public class NoteService(INoteRepository repo) : INoteService
{
    public async Task AddAsync(string title, string content) 
        => await repo.AddNoteAsync(new Note(title, content));

    public async Task DeleteAsync(Note? note)
    {
        if (note == null) return;
        await repo.DeleteNoteAsync(note);
    }

    public async Task<List<Note>> GetAllAsync()
    {
        return await repo.GetNotesAsync();
    }

    public async Task<Note?> GetByIdAsync(int id)
    {
        return await repo.GetNoteAsync(id);
    }

}
