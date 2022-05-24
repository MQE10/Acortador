using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcortadorApi.Helpers
{
    public class FiltroErrores : ExceptionFilterAttribute
    {
        //errores
        private readonly ILogger<FiltroErrores> logger;

        public FiltroErrores(ILogger<FiltroErrores> logger)
        {
            this.logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            if (context.Exception.InnerException != null)
                logger.LogError(context.Exception, context.Exception.InnerException.Message);
            else
                logger.LogError(context.Exception, context.Exception.Message);

            base.OnException(context);
        }


    }
}
