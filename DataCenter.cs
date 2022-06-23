using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    internal class DataCenter
    {
        List<int> bootingPwr;
        List<int> processingPwr;
        long powerLimit;

        int clusterBegin;
        int clusterEnd;

        long bootingPwrMax;
        long processingPwrSum;

        bool TryExtend()
        {
            if (clusterEnd == bootingPwr.Count)
                return false;

            long bootingNew = Math.Max(bootingPwrMax, bootingPwr[clusterEnd]);
            long processingNew = processingPwrSum + processingPwr[clusterEnd];
            long power = bootingNew + processingNew * (clusterEnd - clusterBegin + 1);
            if (power < powerLimit)
            {
                ++clusterEnd;
                bootingPwrMax = bootingNew;
                processingPwrSum = processingNew;
                return true;
            }
            return false;
        }

        bool Shift()
        {
            if (clusterEnd == bootingPwr.Count)
                return false;

            ++clusterBegin;
            ++clusterEnd;

            if (clusterEnd == clusterBegin)
                return true;

            if (bootingPwr[clusterEnd - 1] > bootingPwrMax)
            {
                bootingPwrMax = bootingPwr[clusterEnd - 1];
            }
            else if (bootingPwr[clusterBegin - 1] == bootingPwrMax)
            {
                bootingPwrMax = bootingPwr.GetRange(clusterBegin, clusterEnd - clusterBegin).Max();
            }

            processingPwrSum += processingPwr[clusterEnd - 1] - processingPwr[clusterBegin - 1];
            return bootingPwrMax + processingPwrSum * (clusterEnd - clusterBegin) < powerLimit;
        }

        public int SearchCluster(long powerMax, List<int> bootingPower, List<int> processingPower)
        {
            clusterBegin = 0;
            clusterEnd = 0;
            bootingPwrMax = 0;
            processingPwrSum = 0;
            bootingPwr = bootingPower;
            processingPwr = processingPower;
            powerLimit = powerMax;

            while (TryExtend())
                ;
            while (clusterEnd < bootingPwr.Count)
            {
                if (Shift())
                    while (TryExtend())
                        ;
            }

            return clusterEnd - clusterBegin;
        }
    }
}
