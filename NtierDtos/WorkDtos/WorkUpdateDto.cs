

namespace NtierDtos.WorkDtos;

public class WorkUpdateDto : IDto
{
    public int Id { get; set; }
    public string Definition { get; set; }

    public bool isCompleted { get; set; }
}
