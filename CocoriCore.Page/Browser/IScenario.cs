namespace CocoriCore.LeBonCoin
{
    public interface IScenario<TPageFrom, TPageTo>
    {
        BrowserFluent<TPageTo> Play(BrowserFluent<TPageFrom> browserFluent);
    }
}
