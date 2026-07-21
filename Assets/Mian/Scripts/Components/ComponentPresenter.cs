using UnityEngine;

public class ComponentPresenter : MonoBehaviour
{

    [SerializeField] private ComponentManger _managerController;
    [SerializeField] private ComponentUIController _uiController;

    public void DropCellOn(PanelSide side, ComponentDefinition component)
    {
        //поместить обьект 
        _managerController.PutComponentOnSide(side, component);
        _uiController.UpdateApplyedPanel(_managerController.GetAppliedComponents());
        _uiController.UpdateNotApplyedPanel(_managerController.GetNotAppliedComponents()); 


        //применить компонент
        //отобразить изменения на сущности 

    }
    private void Start()
    {
        _managerController.Init();
        _uiController.UpdateApplyedPanel(_managerController.GetAppliedComponents());
        _uiController.UpdateNotApplyedPanel(_managerController.GetNotAppliedComponents());
        //отобразиь это 
    }

}
