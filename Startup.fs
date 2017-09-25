﻿namespace FsPages

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection

open FsPages.PostProvider
open FsPages.PostProvider.DiskPostProvider


type Startup private () =
    new (configuration: IConfiguration) as this =
        Startup() then
        this.Configuration <- configuration

    // This method gets called by the runtime. Use this method to add services to the container.
    member this.ConfigureServices(services: IServiceCollection) =
        services.AddScoped<IPostProvider,DiskPostProvider.DiskPostProvider>() |> ignore
        // Add framework services.
        services.AddMvc() |> ignore

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    member this.Configure(app: IApplicationBuilder, env: IHostingEnvironment) =

        if (env.IsDevelopment()) then
            app.UseDeveloperExceptionPage() |> ignore
        else
            app.UseExceptionHandler("/Error") |> ignore

        app.UseStaticFiles() |> ignore

        app.UseMvc(fun routes ->
            routes.MapRoute(
                name = "default",
                template = "{controller}/{action=Index}/{id?}") |> ignore
            ) |> ignore

    member val Configuration : IConfiguration = null with get, set