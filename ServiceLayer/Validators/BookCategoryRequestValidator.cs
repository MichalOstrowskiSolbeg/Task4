using FluentValidation;
using ServiceLayer.DTO.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Validators
{
    public class BookCategoryRequestValidator : AbstractValidator<BookCategoryRequest>
    {
        public BookCategoryRequestValidator() {
            RuleFor(x => x.BookId).NotEmpty().WithMessage("This field cannot be empty");

            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("This field cannot be empty");

            RuleFor(x => x.IsRead).NotNull().WithMessage("This field cannot be null");
        }
    }
}
