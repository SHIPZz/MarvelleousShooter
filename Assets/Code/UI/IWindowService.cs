namespace Code.UI
{
    public interface IWindowService
    {
        void Bind<TWindow, TController, TModel>()
            where TWindow : AbstractWindowBase
            where TModel : AbstractWindowModel
            where TController : IController<TModel, TWindow>;

        TController OpenWindowByController<TController>() where TController : IController;
        TWindow OpenWindow<TWindow>() where TWindow : AbstractWindowBase;
    }
}