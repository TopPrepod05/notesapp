using Moq;
using NotesApp.Services;
using NotesApp.Repositories;
using Microsoft.EntityFrameworkCore;
using NotesApp.Models;

namespace NotesApp.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            var repository = new Mock<INoteRepository>();
            var service = new NoteService(repository.Object);
            int id = 1;
            var expected = new Note("Заголовок", "контент");

            repository.Setup(x => x.GetNoteAsync(id)).ReturnsAsync(expected);
            var result = await service.GetByIdAsync(id);

            Assert.Equivalent(expected, result, strict: true);

            repository.Verify(x => x.GetNoteAsync(id), Times.Once());

        }
    }
}
