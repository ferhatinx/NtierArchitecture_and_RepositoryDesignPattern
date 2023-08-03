

namespace NtierDtos.WorkDtos;

public class WorkListDto : IDto
{
    public int Id { get; set; }
    public string Definition { get; set; }

    public bool isCompleted { get; set; }
}
