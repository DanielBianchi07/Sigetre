namespace Sigetre.Api.Common.Api;

public interface IEndPoint
{
    static abstract void Map(IEndpointRouteBuilder app);
}