using CourseManagement.DTO;
using FluentValidation;

namespace CourseManagement.Services
{
    public class CourseRequestValidator : AbstractValidator<CourseRequest>
    {
        public CourseRequestValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required")
                .MaximumLength(100);

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required");

            RuleFor(x => x.Instructor)
                .NotEmpty().WithMessage("Instructor is required");

            RuleFor(x => x.EndDate)
                .GreaterThan(x => x.StartDate).WithMessage("EndDate must be after StartDate");
        }
    }

}
