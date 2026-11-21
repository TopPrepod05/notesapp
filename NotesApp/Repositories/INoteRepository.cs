using NotesApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Repositories;

public interface INoteRepository
{
    Task AddNoteAsync(Note note);
    Task DeleteNoteAsync(Note note);
    Task<List<Note>> GetNotesAsync();
    Task<Note?> GetNoteAsync(int id);
}
