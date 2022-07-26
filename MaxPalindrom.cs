using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    internal class MaxPalindrom
    {
        public static string highestValuePalindrome(string s, int n, int k)
        {
            int isOdd = n % 2;

            List<char> h1 = s.Take(n / 2).ToList();
            List<char> h2 = s.Skip(n / 2 + isOdd).Reverse().ToList();

            int countToChange = h1.Zip(h2, (first, second) => first == second ? 0 : 1).Sum();

            if (countToChange > k)
                return "-1";

            for (int i = 0; i < n / 2; ++i)
            {
                int toChangeTo9 = 2 - (h1[i] == '9' ? 1 : 0) - (h2[i] == '9' ? 1 : 0);
                bool areDifferent = h1[i] != h2[i];
                int cntForUseNow = k - countToChange + (areDifferent ? 1 : 0);
                if (toChangeTo9 > cntForUseNow)
                {
                    if (areDifferent)
                    {
                        if (cntForUseNow == 0)
                            throw new("bullshit");

                        --countToChange;
                        --k;
                    }
                }
                else
                {
                    h1[i] = '9';
                    if(areDifferent)
                        --countToChange;
                    k -= toChangeTo9;
                }
            }

            IEnumerable<char> resCharsHalf = h1.Zip(h2, (ch1, ch2) => ch1 > ch2 ? ch1 : ch2);
            IEnumerable<char> resChars = resCharsHalf;
            if (isOdd > 0)
            {
                resChars = resChars.Append(k > 0 ? '9' : s[n / 2]);
            }
            resChars = resChars.Concat(resCharsHalf.Reverse());
            string res = new string(resChars.ToArray());

            return res;
        }

    }
}
//