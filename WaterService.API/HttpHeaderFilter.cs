using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WaterService.API
{
    public class HttpHeaderFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            operation.Parameters = new List<IParameter>();
            operation.Parameters.Add(new BodyParameter()
            {
                Name = @"Authorization",
                Description = @"Token",
                Required = true,
                In = @"header"
            });
        }
    }
}
