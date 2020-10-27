using System;
using System.Net;
using Codexoft.CrossLib.Architecture.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace Codexoft.CrossLib.WebTemplate.Middlewares
{
    public static class ApplicationBuilderExtension
    {
        public static void UserMyExceptionHandler(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    IExceptionHandlerFeature exFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (exFeature != null)
                    {
                        switch (exFeature.Error.GetType().Name)
                        {
                            case nameof(ValidationFailedException):
                                {
                                    context.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                                    string response = JsonConvert.SerializeObject(((ValidationFailedException)exFeature.Error).ValidationErrors);
                                    await context.Response.WriteAsync(response).ConfigureAwait(false);
                                    break;
                                }
                            case nameof(EntityNotFoundException):
                                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                                break;
                            case nameof(UnauthorizedAccessException):
                                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                                break;
                            default:
                                {
                                    if (env.IsDevelopment())
                                    {
                                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                                        await context.Response.WriteAsync(JsonConvert.SerializeObject(exFeature.Error)).ConfigureAwait(false);
                                    }
                                    else
                                    {
                                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                                    }

                                    break;
                                }
                        }
                    }
                });
            });
        }
    }
}