using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NotesApp.Models;

public class Note
{
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string Title { get; set; } = string.Empty;
    [Required]
    [MaxLength(1000)]
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public Note(string title, string content)
    {
        Title = title;
        Content = content;
        CreatedAt = DateTime.Now;
    }
}
