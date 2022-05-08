using static WebdriverClass.WidgetsAtClass.SearchWidget;

namespace WebdriverClass.WidgetsAtClass
{
    public class SearchModel
    {
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public string ViaCity { get; set; }
        public SearchOptions SearchOption { get; set; }
        public Reductions Reduction { get; set; }
    }
}