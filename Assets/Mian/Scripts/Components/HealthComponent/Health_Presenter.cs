

namespace Assets.Mian.Scripts.Components.HealthComponent
{
    public class Health_Presenter
    {
        private Health_View _view;
        public Health_Presenter(Health_View healthView)
        {
            this._view = healthView;
        }
        public void UpdateView(int curenHp, int maxHp)
        {
            _view?.UpdateView(curenHp, maxHp);
        }
      
    }
}
