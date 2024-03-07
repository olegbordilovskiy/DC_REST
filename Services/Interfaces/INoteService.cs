using DC_REST.DTOs;

namespace DC_REST.Services.Interfaces
{
	public interface INoteService
	{
		NoteDTO CreateNote(NoteDTO noteRequestDto);
		NoteDTO GetNoteById(int id);
		IEnumerable<NoteDTO> GetAllNotes();
		NoteDTO UpdateNote(int id, NoteDTO noteRequestDto);
		bool DeleteNote(int id);
	}
}
