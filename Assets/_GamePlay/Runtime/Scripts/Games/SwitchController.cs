using System;
using System.Collections.Generic;
using UnityEngine;

namespace CatAdventure.GamePlay
{
    public class SwitchController : MonoBehaviour
    {
        public event Action<bool> OnStatusChanged;
        private bool _status = false;

    }
}
