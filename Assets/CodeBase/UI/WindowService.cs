using System;
using System.Collections.Generic;
using CodeBase.Extensions;
using Zenject;

namespace CodeBase.UI
{
    public class WindowService : IWindowService, IInitializable
    {
        private readonly IInstantiator _instantiator;
        private readonly IUIStaticDataService _uiStaticDataService;
        private readonly IUIProvider _uiProvider;
        private Dictionary<Type, IController> _controllers = new();
        private Dictionary<Type, AbstractWindowBase> _windows = new();

        public WindowService(IInstantiator instantiator, IUIStaticDataService uiStaticDataService, IUIProvider uiProvider)
        {
            _uiProvider = uiProvider;
            _instantiator = instantiator;
            _uiStaticDataService = uiStaticDataService;
        }

        public void Initialize() { }

        public void Bind<TWindow, TController, TModel>()
            where TWindow : AbstractWindowBase
            where TModel : AbstractWindowModel
            where TController : IController<TModel, TWindow>
        {
            TModel model = _instantiator.Instantiate<TModel>();

            var prefab = _uiStaticDataService.GetWindow<TWindow>();
            TWindow window = _instantiator.InstantiatePrefabForComponent<TWindow>(prefab,_uiProvider.MainUI.transform);

            TController createdController = _instantiator.Instantiate<TController>()
                    .With(x => x.BindModel(model))
                    .With(x => x.BindView(window))
                    .With(x => x.Initialize())
                ;
        
            _controllers[typeof(TController)] = createdController;

            _windows[typeof(TWindow)] = window;
        }
    
        public TWindow OpenWindow<TWindow>() where TWindow : AbstractWindowBase
        {
            if (_windows.TryGetValue(typeof(TWindow), out var window))
            {
                return (TWindow)window;
            }

            throw new InvalidOperationException($"No binding found for window type {typeof(TWindow).Name}");
        }

        public TController OpenWindowByController<TController>() where TController : IController
        {
            if (_controllers.TryGetValue(typeof(TController), out var controller))
            {
                return (TController)controller;
            }

            throw new InvalidOperationException($"No binding found for controller type {typeof(TController).Name}");
        }
    }
}

