using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    internal class SherlockValidString
    {
        public string Check(string input)
        {
            int lettersCnt = 'z' - 'a' + 1;
            int[] counts = new int[lettersCnt];
            foreach (char c in input)
                ++counts[c - 'a'];
            List<int> result = counts.Where(cnt => cnt > 0).OrderBy(cnt => cnt).ToList();
            int len = result.Count;
            bool isValid = (len == 1) || (counts[len - 2] == counts[0]) && (counts[len - 1] - counts[len - 2] < 2);
            return isValid ? "YES" : "NO";
        }
    }
}
