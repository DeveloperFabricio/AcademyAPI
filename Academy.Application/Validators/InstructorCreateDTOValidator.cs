using Academy.Application.DTO_s;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Application.Validators
{ 
    public class InstructorCreateDTOValidator : AbstractValidator<InstructorCreateDTO>
    {
        public InstructorCreateDTOValidator()
        {
            RuleFor(dto => dto.SportId).NotEmpty().WithMessage("The type of sport is mandatory.");
            RuleFor(dto => dto.StudentId).NotEmpty().WithMessage("Student is mandatory.");
            RuleFor(dto => dto.PaymentId).NotEmpty().WithMessage("Payment is mandatory.");
        }
    }
}
