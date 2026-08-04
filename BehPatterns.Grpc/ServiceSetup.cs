using System.Collections.Generic;
using System.Threading.Tasks;

using BehPatterns.Grpc.DomainServices;
using BehPatterns.Grpc.DomainServices.CheckCanPostingExemplarsMoveToReverseFlow;
using BehPatterns.Grpc.DomainServices.GetPostingExemplarRegradingRequirements;
using BehPatterns.Grpc.DomainServices.GetPostingReturnOperations;
using BehPatterns.Grpc.DomainServices.GetPostingReturnState;
using BehPatterns.Grpc.Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;

namespace BehPatterns.Grpc
{
    public static class ServiceSetup
    {
        public static async Task Run()
        {
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddGrpc();
            builder.Services.AddGrpcReflection();

            var mediator = new MyMediator();
            mediator.Register<GetPostingReturnStateQuery, PostingReturnState>(new GetPostingReturnStateHandler());
            mediator.Register<GetPostingReturnOperationsQuery, List<PostingReturnOperation>>(new GetPostingReturnOperationsHandler());
            mediator.Register<GetPostingExemplarRegradingRequirementsQuery, List<ExemplarRegradingRequirement>>(new GetPostingExemplarRegradingRequirementsHandler());
            mediator.Register<CheckCanPostingExemplarsMoveToReverseFlowQuery, ExemplarsReverseFlowCheck>(new CheckCanPostingExemplarsMoveToReverseFlowHandler());

            builder.Services.AddSingleton<IMediator>(mediator);
            builder.Services.AddSingleton<GetPostingReturnStateHandler>();
            builder.Services.AddSingleton<GetPostingReturnOperationsHandler>();
            builder.Services.AddSingleton<GetPostingExemplarRegradingRequirementsHandler>();
            builder.Services.AddSingleton<CheckCanPostingExemplarsMoveToReverseFlowHandler>();

            builder.WebHost.UseUrls("http://127.0.0.1:5126");
            builder.WebHost.ConfigureKestrel(o => o.ConfigureEndpointDefaults(lo => lo.Protocols = HttpProtocols.Http2));

            var app = builder.Build();
            app.MapGrpcService<PostingReturnsServiceGrpc>();
            //app.MapGrpcService<PostingReturnsServiceGrpc0>();
            app.MapGrpcReflectionService();

            await app.RunAsync();
        }
    }
}
