using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NotesApp.Models;
using NotesApp.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace NotesApp.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] private string _title = "";
    [ObservableProperty] private string _content = "";
    [ObservableProperty] private Note? _selectedNote;
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
        foreach (var n in nts) Notes.Add(n);
    }

    [RelayCommand] private async Task AddNote()
    {
        await noteService.AddAsync(Title, Content);
    }

    [RelayCommand] private async Task DeleteNote()
    {
        if (SelectedNote == null) return;
        await noteService.DeleteAsync(SelectedNote);
    }

}



