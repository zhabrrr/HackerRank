using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    internal class LilysHomework
    {
        int CalcDiff(List<int> array)
        {
            Dictionary<int, int> dic = array.Select((v, i) => new { Value = v, Idx = i }).ToDictionary(v => v.Value, v => v.Idx);
            int[] arr = array.ToArray();
            int cnt = 0;
            for (int i = 0; i < arr.Length; ++i)
                if (arr[i] != i)
                {
                    int i1 = dic[i];    //the index where current element will be moved to
                    dic[arr[i]] = i1;
                    arr[i1] = arr[i];
                    cnt++;
                }
            return cnt;
        }

        public int Do(List<int> arr)
        {
            Dictionary<int, int> dic = arr.OrderBy(v => v).Select((v, i) => new { Value = v, Idx = i }).ToDictionary(v => v.Value, v => v.Idx);
            
            for(int i = 0; i < arr.Count; ++i)
                arr[i] = dic[arr[i]];
            int cnt1 = CalcDiff(arr);
            arr.Reverse();
            return Math.Min(cnt1, CalcDiff(arr));
        }
    }
}
