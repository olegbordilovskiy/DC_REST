using AutoMapper;
using DC_REST.DTOs.Request;
using DC_REST.DTOs.Response;
using DC_REST.Entities;
using DC_REST.Repositories;
using DC_REST.Services.Interfaces;
using System.Collections.Generic;

namespace DC_REST.Services
{
	public class NoteService : INoteService
	{
		private readonly IRepository<Note> _noteRepository;
		private readonly IMapper _mapper;

		public NoteService(IRepository<Note> noteRepository, IMapper mapper)
		{
			_noteRepository = noteRepository;
			_mapper = mapper;
		}

		public NoteResponseTo CreateNote(NoteRequestTo noteRequestDto)
		{
			var note = _mapper.Map<Note>(noteRequestDto);
			var createdNote = _noteRepository.Add(note);
			var responseDto = _mapper.Map<NoteResponseTo>(createdNote);

			return responseDto;
		}

		public NoteResponseTo GetNoteById(int id)
		{
			var note = _noteRepository.GetById(id);
			var noteDto = _mapper.Map<NoteResponseTo>(note);

			return noteDto;
		}

		public List<NoteResponseTo> GetAllNotes()
		{
			var notes = _noteRepository.GetAll();
			var noteDtos = _mapper.Map<List<NoteResponseTo>>(notes);

			return noteDtos;
		}

		public NoteResponseTo UpdateNote(int id, NoteRequestTo noteRequestDto)
		{
			var existingNote = _noteRepository.GetById(id);
			if (existingNote == null)
			{
				// Обработка ситуации, когда заметка не найдена
				return null;
			}

			_mapper.Map(noteRequestDto, existingNote);
			var updatedNote = _noteRepository.Update(id, existingNote);
			var responseDto = _mapper.Map<NoteResponseTo>(updatedNote);

			return responseDto;
		}

		public bool DeleteNote(int id)
		{
			var noteToDelete = _noteRepository.GetById(id);
			if (noteToDelete == null)
			{
				// Обработка ситуации, когда заметка не найдена
				return false;
			}

			_noteRepository.Delete(id);
			return true;
		}
	}
}
