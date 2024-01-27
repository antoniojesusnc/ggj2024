using System.Collections.Generic;
using Trials.Data;
using UnityEngine;

namespace Trials
{
    public class Trial<TTrialDataType> : MonoBehaviour where TTrialDataType : PlayerTrialData
    {
        protected readonly Dictionary<int, TTrialDataType> PlayerTrialDatas = new();
    }
}
