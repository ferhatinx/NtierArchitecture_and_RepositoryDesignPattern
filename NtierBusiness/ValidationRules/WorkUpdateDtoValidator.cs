

using FluentValidation;
using NtierDtos.WorkDtos;

namespace NtierBusiness.ValidationRules;

public class WorkUpdateDtoValidator : AbstractValidator<WorkUpdateDto>
{
	public WorkUpdateDtoValidator()
	{
		RuleFor(x=>x.Definition).NotEmpty().WithMessage("Tanım Alanı Boş Olamaz");
	}
}
