using System.Collections.Generic;
using System.Threading.Tasks;

using BehPatterns.Grpc.DomainServices;
using BehPatterns.Grpc.DomainServices.CheckCanPostingExemplarsMoveToReverseFlow;
using BehPatterns.Grpc.DomainServices.GetPostingExemplarRegradingRequirements;
using BehPatterns.Grpc.DomainServices.GetPostingReturnOperations;
using BehPatterns.Grpc.DomainServices.GetPostingReturnState;

using Grpc.Core;

using Proto = BehPatterns.Grpc.PostingReturns;

namespace BehPatterns.Grpc
{
    public class PostingReturnsServiceGrpc0 : Proto.PostingReturnsService.PostingReturnsServiceBase
    {
        private readonly GetPostingReturnStateHandler _getStateHandler;
        private readonly GetPostingReturnOperationsHandler _getOperationsHandler;
        private readonly GetPostingExemplarRegradingRequirementsHandler _getRegradingRequirementsHandler;
        private readonly CheckCanPostingExemplarsMoveToReverseFlowHandler _checkReverseFlowHandler;

        public PostingReturnsServiceGrpc0(
            GetPostingReturnStateHandler getStateHandler,
            GetPostingReturnOperationsHandler getOperationsHandler,
            GetPostingExemplarRegradingRequirementsHandler getRegradingRequirementsHandler,
            CheckCanPostingExemplarsMoveToReverseFlowHandler checkReverseFlowHandler)
        {
            _getStateHandler = getStateHandler;
            _getOperationsHandler = getOperationsHandler;
            _getRegradingRequirementsHandler = getRegradingRequirementsHandler;
            _checkReverseFlowHandler = checkReverseFlowHandler;
        }

        public override async Task<Proto.PostingReturnStateMessage> GetPostingReturnState(Proto.GetPostingReturnStateQuery request, ServerCallContext context)
        {
            var result = await _getStateHandler.Handle(new GetPostingReturnStateQuery { PostingReturnId = request.PostingReturnId });
            return new Proto.PostingReturnStateMessage
            {
                PostingReturnId = result.PostingReturnId,
                Status = result.Status,
                Reason = result.Reason,
                CreatedAt = result.CreatedAt
            };
        }

        public override async Task<Proto.GetPostingReturnOperationsResponse> GetPostingReturnOperations(Proto.GetPostingReturnOperationsQuery request, ServerCallContext context)
        {
            var result = await _getOperationsHandler.Handle(new GetPostingReturnOperationsQuery { PostingReturnId = request.PostingReturnId });
            var response = new Proto.GetPostingReturnOperationsResponse();
            foreach (var op in result)
            {
                response.Operations.Add(new Proto.PostingReturnOperationMessage
                {
                    OperationId = op.OperationId,
                    PostingReturnId = op.PostingReturnId,
                    Type = op.Type,
                    Status = op.Status,
                    PerformedAt = op.PerformedAt
                });
            }
            return response;
        }

        public override async Task<Proto.GetPostingExemplarRegradingRequirementsResponse> GetPostingExemplarRegradingRequirements(Proto.GetPostingExemplarRegradingRequirementsQuery request, ServerCallContext context)
        {
            var result = await _getRegradingRequirementsHandler.Handle(new GetPostingExemplarRegradingRequirementsQuery { PostingReturnId = request.PostingReturnId });
            var response = new Proto.GetPostingExemplarRegradingRequirementsResponse();
            foreach (var req in result)
            {
                response.Requirements.Add(new Proto.ExemplarRegradingRequirementMessage
                {
                    ExemplarId = req.ExemplarId,
                    CurrentSku = req.CurrentSku,
                    RequiredSku = req.RequiredSku,
                    Reason = req.Reason
                });
            }
            return response;
        }

        public override async Task<Proto.ExemplarsReverseFlowCheckMessage> CheckCanPostingExemplarsMoveToReverseFlow(Proto.CheckCanPostingExemplarsMoveToReverseFlowQuery request, ServerCallContext context)
        {
            var result = await _checkReverseFlowHandler.Handle(new CheckCanPostingExemplarsMoveToReverseFlowQuery
            {
                PostingReturnId = request.PostingReturnId,
                ExemplarIds = new List<string>(request.ExemplarIds)
            });
            var msg = new Proto.ExemplarsReverseFlowCheckMessage { CanMove = result.CanMove };
            msg.BlockingReasons.AddRange(result.BlockingReasons);
            return msg;
        }
    }
}
