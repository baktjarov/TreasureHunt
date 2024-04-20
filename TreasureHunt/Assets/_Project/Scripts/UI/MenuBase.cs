using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MenuBase : MonoBehaviour
    {
        private static Action<MenuBase> onMenuOpenned;

        protected MenuBase _backMenu;

        public void Construct(MenuBase backMenu)
        {
            _backMenu = backMenu;
        }

        private void Reset()
        {
            CanvasScaler canvasScaler = GetComponentInChildren<CanvasScaler>(true);

            canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            canvasScaler.referenceResolution = new Vector2(1920, 1080);
        }

        protected virtual void Awake()
        {
            Close();

            onMenuOpenned -= OnMenuOpenned;
            onMenuOpenned += OnMenuOpenned;
        }

        protected virtual void OnDestroy()
        {
            onMenuOpenned -= OnMenuOpenned;
        }

        public virtual void OnMenuOpenned(MenuBase menu)
        {
            if (menu != this) { Close(); }
        }

        public virtual void Open()
        {
            gameObject.SetActive(true);

            onMenuOpenned?.Invoke(this);
        }

        public virtual void Close()
        {
            gameObject.SetActive(false);
        }
    }
}