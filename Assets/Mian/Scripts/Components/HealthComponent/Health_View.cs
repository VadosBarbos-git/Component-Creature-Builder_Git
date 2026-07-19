 
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Mian.Scripts.Components.HealthComponent
{
    public class Health_View : MonoBehaviour
    {
        [SerializeField] private RectTransform CanvasHpBar;
        [SerializeField] private Image HPBarFieled;
        internal void UpdateView(int curenHp, int maxHp)
        {
            float fill = curenHp / (float)maxHp;
            HPBarFieled.fillAmount = fill;
        }
        private void LateUpdate()
        { 
            if (CanvasHpBar != null)
            {
                CanvasHpBar.transform.LookAt(new Vector3(CanvasHpBar.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z));
                CanvasHpBar.transform.Rotate(0, 180, 0);
            }
        }
    }
}
