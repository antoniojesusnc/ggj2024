using System.Collections.Generic;
using UnityEngine;

namespace Trials
{
    public class Trial<TTrialDataType> : MonoBehaviour where TTrialDataType : PlayerTrialData
    {
        protected readonly Dictionary<int, TTrialDataType> PlayerTrialDatas = new();
        
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
