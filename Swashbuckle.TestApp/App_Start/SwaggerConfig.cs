﻿using System.Net.Http;
using Swashbuckle.Models;
using Swashbuckle.TestApp.SwaggerExtensions;

namespace Swashbuckle.TestApp.App_Start
{
    public class SwaggerConfig
    {
        public static void Customize()
        {
            SwaggerSpecConfig.Customize(c =>
                {
                    c.PostFilter<AddStandardErrorCodes>();
                    c.PostFilter<AddAuthorizationErrorCodes>();

                    // Uncomment below to support documentation from Xml Comments
                    // c.PostFilter(new ExtractXmlComments());
                });

            SwaggerUiConfig.Customize(c =>
                {
                    c.SupportHeaderParams = true;
                    c.DocExpansion = DocExpansion.List;
                    c.SupportedSubmitMethods = new[] {HttpMethod.Get, HttpMethod.Post, HttpMethod.Put, HttpMethod.Head};
                    c.AddOnCompleteScript(typeof (SwaggerConfig).Assembly, "Swashbuckle.TestApp.SwaggerExtensions.onComplete.js");
                    c.AddStylesheet(typeof(SwaggerConfig).Assembly, "Swashbuckle.TestApp.SwaggerExtensions.customStyles.css");
                });
        }
    }
}