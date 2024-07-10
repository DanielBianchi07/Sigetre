namespace Sigetre.Core.Requests.Instructor;

public class GetInstructorBySpecialityRequest : PagedRequest
{
    public long SpecialityId { get; set; }
}