using System;
using System.Collections.Generic;
using Ui.Elements.Base;
using UnityEngine.Assertions;
using Zenject;

namespace Ui.Elements
{
    public class ElementsCreatorBase
    {
        protected readonly IDictionary<Type, IFactory<ViewBase>> Views;

        public ElementsCreatorBase()
        {
            Views = new Dictionary<Type, IFactory<ViewBase>>();
        }

        public TView Create<TView>()
            where TView : ViewBase
        {
            Assert.IsTrue(Views.ContainsKey(typeof(TView)));

            return (TView)Views[typeof(TView)].Create();
        }
    }
}