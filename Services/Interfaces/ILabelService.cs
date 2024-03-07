using DC_REST.DTOs;

namespace DC_REST.Services.Interfaces
{
	public interface ILabelService
	{
		LabelDTO CreateLabel(LabelDTO labelRequestDto);
		LabelDTO GetLabelById(int id);
		IEnumerable<LabelDTO> GetAllLabels();
		LabelDTO UpdateLabel(int id, LabelDTO labelRequestDto);
		bool DeleteLabel(int id);
	}
}
