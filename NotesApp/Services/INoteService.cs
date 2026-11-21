using NotesApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Services;

public interface INoteService
{
    Task AddAsync(string title, string content);
    Task DeleteAsync(Note? note);
    Task<Note?> GetByIdAsync(int id);
    Task<List<Note>> GetAllAsync();
}
