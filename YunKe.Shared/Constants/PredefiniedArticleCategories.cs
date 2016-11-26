using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunKe.Shared.Constants
{
    public class PredefiniedArticleCategories
    {
        /// <summary>
        /// Gets the help article root category code.
        /// </summary>
        /// <value>
        /// The help article root category code.
        /// </value>
        public static string HelpArticleRootCategoryCode { get; } = "helps";

        /// <summary>
        /// Gets the talk article root category code.
        /// </summary>
        /// <value>
        /// The talk article root category code.
        /// </value>
        public static string TalkArticleRootCategoryCode { get; } = "talks";
    }
}
