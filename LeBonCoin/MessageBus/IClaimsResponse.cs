using CocoriCore;

namespace LeBonCoin
{
    public interface IClaimsResponse
    {
        IClaims GetClaims();
        object GetResponse();
    }
}