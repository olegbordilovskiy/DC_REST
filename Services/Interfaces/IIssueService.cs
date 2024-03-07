using DC_REST.DTOs;

namespace DC_REST.Services.Interfaces
{
    public interface IIssueService
    {
        IssueDTO CreateIssue(IssueDTO issueRequestDto);
        IssueDTO GetIssueById(int id);
        IEnumerable<IssueDTO> GetAllIssues();
        IssueDTO UpdateIssue(int id, IssueDTO issueRequestDto);
        bool DeleteIssue(int id);
    }
}
