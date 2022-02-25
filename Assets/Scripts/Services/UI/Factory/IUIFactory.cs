using System;
using UI.Base;
using UnityEngine;

namespace Services.UI.Factory
{
  public interface IUIFactory : IService
  {
    event Action<WindowId,BaseWindow> Spawned;
    Transform UIRoot { get; }
    void CreateWindow(WindowId id);
    void CreateUIRoot();
  }
}