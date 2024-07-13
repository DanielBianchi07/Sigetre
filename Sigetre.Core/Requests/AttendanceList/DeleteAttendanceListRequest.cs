using System.ComponentModel.DataAnnotations;

namespace Sigetre.Core.Requests.AttendanceList;

public class DeleteAttendanceListRequest : Request
{
    [Required]
    public long Id { get; set; }
}