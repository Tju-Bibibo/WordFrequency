using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordFrequency
{
    public class WordFrequencyGame
    {
        public string GetResult(string inputStr)
        {
            var words = Regex.Split(inputStr, @"\s+");

            if (words.Length == 1)
            {
                return $"{inputStr} 1";
            }

            var wordCount = words.GroupBy(w => w)
                                 .Select(g => new WordCountItem(g.Key, g.Count()))
                                 .OrderByDescending(w => w.Count);

            return string.Join("\n", wordCount.Select(w => $"{w.Word} {w.Count}"));
        }
    }
}
