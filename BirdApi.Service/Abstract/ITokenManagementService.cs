using BirdApi.Dto;
using BirdApi.Base;

namespace BirdApi.Service.Abstract;

public interface ITokenManagementService
{
    BaseResponse<TokenResponse> GenerateToken(TokenRequest request);
}
