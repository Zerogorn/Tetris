using System;
using Ui.Canvas.Controller;
using UnityEngine;

namespace Ui.Obj
{
    [Serializable]
    public sealed class CanvasObj
    {
        [SerializeField]
        private CanvasController _canvasController = null;

        public CanvasController CanvasController => _canvasController;
    }
}