using System;

namespace MonoCelesteClassic
{
    public class Scene
    {
        public bool Paused;
        public float TimeActive;
        public float RawTimeActive;
        public bool Focused { get; private set; }

        public event Action OnEndOfFrame;

        public Scene() { }

        public virtual void Begin()
        {
            Focused = true;
        }

        public virtual void End()
        {
            Focused = false;
        }

        public virtual void BeforeUpdate()
        {
            if (!Paused)
                TimeActive += Engine.DeltaTime;
            RawTimeActive += Engine.RawDeltaTime;
        }

        public virtual void Update()
        {
            //
        }

        public virtual void AfterUpdate()
        {
            if (OnEndOfFrame != null) {
                OnEndOfFrame();
                OnEndOfFrame = null;
            }
        }

        public virtual void BeforeRender()
        {
            //
        }

        public virtual void Render()
        {
            //
        }

        public virtual void AfterRender()
        {
            //
        }
    }
}
