using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using NotesApp.Models;
using NotesApp.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace NotesApp.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] private string _title = "";
    [ObservableProperty] private string _content = "";
    [ObservableProperty] private Note? _selectedNote;
    [ObservableProperty] private string _search = "";
    private INoteService noteService;
    public ObservableCollection<Note> Notes { get; set; } = [];

    public MainViewModel(INoteService _ns)
    {
        noteService = _ns;
        _ = Load();
    }

    private async Task Load()
    {
        Notes.Clear();
        var nts = await noteService.GetAllAsync();
        var sorted = nts.OrderByDescending(el => el.CreatedAt);
        if (!string.IsNullOrWhiteSpace(Search))
        {
            foreach (var n in sorted)
            {
                if (n.Title.Contains(Search, StringComparison.OrdinalIgnoreCase))
                {
                    Notes.Add(n);
                }
            }
        }
        else
        {
            foreach (var n in sorted) Notes.Add(n);
        }
    }

    partial void OnSearchChanged(string value)
    {
        _ = Load();
    }


    [RelayCommand] private async Task AddNote()
    {
        if (SelectedNote == null)
            await noteService.AddAsync(Title, Content);
        else
        {
            await noteService.DeleteAsync(SelectedNote);
            await noteService.AddAsync(Title, Content);
        }

        await Load();
    }

    [RelayCommand] private async Task DeleteNote()
    {
        if (SelectedNote == null) return;
        await noteService.DeleteAsync(SelectedNote);
        await Load();
    }

    partial void OnSelectedNoteChanged(Note? oldValue, Note? newValue)
    {
        if (SelectedNote == null) return;
        Title = SelectedNote.Title;
        Content = SelectedNote.Content;
    }

}



