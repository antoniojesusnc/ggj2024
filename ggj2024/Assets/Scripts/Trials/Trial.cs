using System.Collections.Generic;
using Trials.Data;

namespace Trials
{
    public class Trial<TTrialDataType> : Singleton<Trial<TTrialDataType>> where TTrialDataType : PlayerTrialData
    {
        public readonly Dictionary<int, TTrialDataType> PlayerTrialDatas = new();
    }
}
