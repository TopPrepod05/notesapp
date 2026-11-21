using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NotesApp.Repositories;
using NotesApp.Services;
using NotesApp.ViewModels;
using NotesApp.Views;

namespace NotesApp;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {

        var services = new ServiceCollection();
        services.AddDbContextFactory<AppDbContext>();
        services.AddTransient<INoteRepository, NoteRepository>();
        services.AddTransient<INoteService, NoteService>();
        services.AddTransient<MainViewModel>();

        var provider = services.BuildServiceProvider();
        var dbfactory = provider.GetRequiredService<IDbContextFactory<AppDbContext>>();
        using var db = dbfactory.CreateDbContext();
        db.Database.Migrate();


        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = provider.GetRequiredService<MainViewModel>()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}