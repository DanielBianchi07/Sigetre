using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.AttendanceList;

public class GetAttendanceListByIdRequest : Request
{
    [Required]
    public long Id { get; set; }
}