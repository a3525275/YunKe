namespace YunKe.Commerce.OptimizationKeyWords.Domain
{
    /// <summary>
    /// 每天排名结果
    /// </summary>
    public class SearchEngineRanking
    {
        public int PageOfBaidu { get; set; }

        public int PageOfGoogle { get; set; }

        public int PageOf360 { get; set; }

        public int PageOfSouGou { get; set; }

        public int PageOfMobileBaidu { get; set; }

        public int PageOfShengMa { get; set; }

        public int PageOfBing { get; set; }
    }
}