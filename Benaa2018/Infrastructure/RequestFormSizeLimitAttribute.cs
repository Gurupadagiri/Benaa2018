using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Infrastructure
{
    public class RequestFormSizeLimitAttribute : Attribute, IAuthorizationFilter,IOrderedFilter
    {
        private readonly FormOptions _formOptions;
        public RequestFormSizeLimitAttribute(int valueCountLimit)
        {
            _formOptions = new FormOptions()
            {
                // tip: you can use different arguments to set each properties instead of single argument
                KeyLengthLimit = valueCountLimit,
                ValueCountLimit = valueCountLimit,
                ValueLengthLimit = valueCountLimit

                // uncomment this line below if you want to set multipart body limit too
                // MultipartBodyLengthLimit = valueCountLimit
            };
        }
        public int Order { get; set; }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var features = context.HttpContext.Features;
            var formFeature = features.Get<IFormFeature>();
            if (formFeature == null || formFeature.Form == null)
            {
                features.Set<IFormFeature>(new FormFeature(context.HttpContext.Request, _formOptions));
            }
        }
    }
}
