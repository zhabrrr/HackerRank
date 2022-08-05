using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    internal class FraudulentActivityNotifications
    {
        const int MaxExpend = 200;

        internal class Frame
        {
            readonly List<int> source;
            readonly int size;
            readonly int medianIdx1;
            readonly int medianIdx2;
            int[] eCounts =  new int[MaxExpend + 1];
            int begIdx = 0;
            int endIdx;

            public Frame(List<int> expenditures, int frameSize)
            {
                source = expenditures;
                size = frameSize;

                medianIdx1 = (size - 1) / 2;
                medianIdx2 = medianIdx1 + (size - 1) % 2;
                endIdx = size;

                for (int i = 0; i < size; i++)
                    ++eCounts[source[i]];
            }

            public int GetDoubledMedian()
            {
                int cur = -1;
                int i = -1;
                do
                    cur += eCounts[++i];
                while (cur < medianIdx1);
                int result = i;
                while (cur < medianIdx2)
                    cur += eCounts[++i];
                return result + i;
            }

            public void Shift()
            {
                --eCounts[source[begIdx++]];
                ++eCounts[source[endIdx++]];
            }
        }

        public int CalcNotifications(List<int> expenditures, int frameSize)
        {
            Frame frame = new Frame(expenditures, frameSize);
            int notificationsCount = 0;
            for(int curIdx = frameSize; curIdx < expenditures.Count; ++curIdx)
            {
                if(frame.GetDoubledMedian() <= expenditures[curIdx])
                    ++notificationsCount;
                frame.Shift();
            }
            return notificationsCount;
        }
    }
}
