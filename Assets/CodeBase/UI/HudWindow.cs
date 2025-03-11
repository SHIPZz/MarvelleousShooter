using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.UI
{
    public class HudWindow : AbstractWindowBase
    {
        public Image Image;

        public override void Open()
        {
            base.Open();

            Image.color = Color.magenta;
        }
    }

    public class HudWindowModel : AbstractWindowModel
    {
        public float A = 5;
    }

    public interface IController : IInitializable { }

    public interface IController<in TModel, in TWindow> : IController
        where TModel : AbstractWindowModel
        where TWindow : AbstractWindowBase

    {
        void BindModel(TModel value);
        void BindView(TWindow value);

    }

    public class HudWindowController : IController<HudWindowModel, HudWindow>
    {
        public HudWindowModel Model;
        public HudWindow Window;


        public void Initialize()
        {
            Model.A = 5;
            Window.Image.DOColor(Color.yellow, 0f);
        }

        public void BindModel(HudWindowModel value)
        {
            Model = value;
        }

        public void BindView(HudWindow value)
        {
            Window = value;
        }
    }

}