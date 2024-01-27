using UnityEngine;

public class AreYouSurePopup : MonoBehaviour
{
   public void ClickInNo()
    {
        gameObject.SetActive(false);
    }

   public void ClickInYes()
   {
       GameManager.Instance.CloseGame();
   }
}


