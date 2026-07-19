using System;
using UnityEngine;

namespace Assets.Mian.Scripts.Components.HealthComponent
{
    public class Health_Component : MonoBehaviour, IComponentEntity
    {

        public int curentHealth { get; private set; }
        public int maxHealth = 100;
        public bool imAlive => curentHealth > 0;
        public Action<int, int> OnHealthChanged;

        private Health_Presenter _Presenter;
        private Health_View _View;

        public void TakeDamage(int damage)
        {
            curentHealth = Mathf.Max(curentHealth - damage, 0);
            OnHealthChanged?.Invoke(curentHealth, maxHealth);
        }
        public void Initialize(Entity entity)
        {
            curentHealth = maxHealth;
            _View = GetComponent<Health_View>();
            _Presenter = new Health_Presenter(_View);
            OnHealthChanged += _Presenter.UpdateView;
            OnHealthChanged?.Invoke(curentHealth, maxHealth);
        }

        public void Tick()
        {

        }
        public void OnAddNewComponent(IComponentEntity component)
        {

        }
        public void OnRemoveComponent(IComponentEntity component)
        {

        }
        public void Disable()
        {
            //остановить всю отрисовку перед удалением 
        }
    }
}