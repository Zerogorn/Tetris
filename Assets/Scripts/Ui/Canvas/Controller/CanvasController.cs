using System;
using System.Collections.Generic;
using Ui.Canvas.Containers.Base;
using UnityEngine;
using UnityEngine.Assertions;

namespace Ui.Canvas.Controller
{
    public sealed class CanvasController : MonoBehaviour, ICanvasController
    {
        private readonly Dictionary<Type, IContainer> _containers = new Dictionary<Type, IContainer>();

        public TContainer GetContainer<TContainer>()
            where TContainer : IContainer
        {
            Assert.IsTrue(_containers.ContainsKey(typeof(TContainer)));

            return (TContainer)_containers[typeof(TContainer)];
        }

        public void Initialize()
        {
            GetContainers();
        }

        private void GetContainers()
        {
            var containers = transform.GetComponentsInChildren<IContainer>();

            for (int i = 0; i < containers.Length; i++)
            {
                var container = containers[i];
                _containers.Add(container.GetType(), container);
            }
        }
    }
}