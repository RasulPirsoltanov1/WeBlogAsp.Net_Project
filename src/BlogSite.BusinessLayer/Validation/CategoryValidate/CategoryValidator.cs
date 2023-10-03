using BlogSite.EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.BusinessLayer.Validation.CategoryValidate
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().NotNull().MinimumLength(2).MaximumLength(50);
            RuleFor(x=>x.Description).NotEmpty().NotNull().MinimumLength(2).MaximumLength(500);
        }
    }
}
