using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingConfig : ScriptableObject
{
   public List<LaughRanges> _laughRanges;

   public KingController.Animations GetLaugh(int slapCount)
   {
      for (int i = 0; i < _laughRanges.Count; i++)
      {
         if (_laughRanges[i].MinValue < slapCount
             && slapCount > _laughRanges[i].MaxValue)
         {
            return _laughRanges[i].Animation;
         }
      }

      return KingController.Animations.smile;
   }
   
   [Serializable]
   public class LaughRanges
   {
      [field: SerializeField]
      public float MinValue { get; private set; }
      [field: SerializeField]
      public float MaxValue { get; private set; }
      [field: SerializeField]
      public KingController.Animations Animation { get; private set; }
   }
}

