using UnityEngine;
using UnityEngine.UI;

namespace AHLike.UI.HealthBar
{
    public class HealthBar : MonoBehaviour 
    {
        [SerializeField] Image _healthImage;

        public void ChangeHealth(float percent)
        {
            if(_healthImage != null)
            {
                _healthImage.fillAmount = Mathf.Clamp(percent, 0, 1);
            }
        }
    }
}