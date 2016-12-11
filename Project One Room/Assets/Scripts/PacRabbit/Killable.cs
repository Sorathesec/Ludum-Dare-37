using UnityEngine;
using System.Collections;

namespace LudumDare37
{
    public interface Killable
    {
        void Revive();

        void Kill();

        GameObject ReturnGameobject();

        void Reset();
    }
}