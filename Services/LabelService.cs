using AutoMapper;
using DC_REST.DTOs.Request;
using DC_REST.DTOs.Response;
using DC_REST.Entities;
using DC_REST.Repositories;
using DC_REST.Services.Interfaces;
using System.Collections.Generic;

namespace DC_REST.Services
{
	public class LabelService : ILabelService
	{
		private readonly IRepository<Label> _labelRepository;
		private readonly IMapper _mapper;

		public LabelService(IRepository<Label> labelRepository, IMapper mapper)
		{
			_labelRepository = labelRepository;
			_mapper = mapper;
		}

		public LabelResponseTo CreateLabel(LabelRequestTo labelRequestDto)
		{
			var label = _mapper.Map<Label>(labelRequestDto);
			var createdLabel = _labelRepository.Add(label);
			var responseDto = _mapper.Map<LabelResponseTo>(createdLabel);

			return responseDto;
		}

		public LabelResponseTo GetLabelById(int id)
		{
			var label = _labelRepository.GetById(id);
			var labelDto = _mapper.Map<LabelResponseTo>(label);

			return labelDto;
		}

		public IEnumerable<LabelResponseTo> GetAllLabels()
		{
			var labels = _labelRepository.GetAll();
			var labelDtos = _mapper.Map<IEnumerable<LabelResponseTo>>(labels);

			return labelDtos;
		}

		public LabelResponseTo UpdateLabel(int id, LabelRequestTo labelRequestDto)
		{
			var existingLabel = _labelRepository.GetById(id);
			if (existingLabel == null)
			{
				// Обработка ситуации, когда метка не найдена
				return null;
			}

			_mapper.Map(labelRequestDto, existingLabel);
			var updatedLabel = _labelRepository.Update(id, existingLabel);
			var responseDto = _mapper.Map<LabelResponseTo>(updatedLabel);

			return responseDto;
		}

		public bool DeleteLabel(int id)
		{
			var labelToDelete = _labelRepository.GetById(id);
			if (labelToDelete == null)
			{
				// Обработка ситуации, когда метка не найдена
				return false;
			}

			_labelRepository.Delete(id);
			return true;
		}
	}
}
