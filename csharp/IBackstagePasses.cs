namespace GildedRoseApp
{
    public interface IBackstagePasses
    {
        int GetBackStagePassQualityFactorBasedOnSellInValue(int sellIn, int currentQuality);
    }
}
