using BlogSite.EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.BusinessLayer.Validation.BlogValidate
{
    public class BlogValidator:AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x=>x.Title).NotEmpty().NotNull();
            RuleFor(x=>x.Content).MinimumLength(10).MaximumLength(2000).NotEmpty().NotNull();
        }
    }
}
