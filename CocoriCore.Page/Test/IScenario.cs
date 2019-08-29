namespace CocoriCore.LeBonCoin
{
    public interface IScenario<TPageFrom, TPageTo>
    {
        TestBrowserFluent<TPageTo> Play(TestBrowserFluent<TPageFrom> browserFluent);
    }
}
