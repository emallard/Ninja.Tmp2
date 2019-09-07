namespace CocoriCore.LeBonCoin
{
    public interface IClaimsResponse
    {
        IClaims GetClaims();
        object GetResponse();
    }
}