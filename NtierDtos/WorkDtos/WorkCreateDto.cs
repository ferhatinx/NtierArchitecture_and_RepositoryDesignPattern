
namespace NtierDtos.WorkDtos
{
    public class WorkCreateDto : IDto
    {
        public string Definition { get; set; }

        public bool isCompleted { get; set; }
    }
}
