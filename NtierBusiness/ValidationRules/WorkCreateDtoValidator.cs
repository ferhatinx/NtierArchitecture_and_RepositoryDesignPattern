

using FluentValidation;
using NtierDtos.WorkDtos;

namespace NtierBusiness.ValidationRules;

public class WorkCreateDtoValidator : AbstractValidator<WorkCreateDto>
{
	public WorkCreateDtoValidator()
	{
		RuleFor(x => x.Definition)
			.NotEmpty().WithMessage("Tanım Yeri Boş Olamaz")
			.MinimumLength(3).WithMessage("en az 3 karakter olmalı");
			
	}
}
