using BirdApi.Dto;
using FordApi.Base;

namespace BirdApi.Service.Abstract;

public interface ITokenManagementService
{
    BaseResponse<TokenResponse> GenerateToken(TokenRequest request);
}
