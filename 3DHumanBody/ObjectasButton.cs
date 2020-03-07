
using System;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace UnityEngine.UI
{
    //initialierung des Buttons. Wir aus der UnityEnginge.UI importiert.
    [AddComponentMenu("UI/Button", 30)]
    public class ObjectasButton : Selectable, IPointerClickHandler, ISubmitHandler
    {
        [Serializable]
        public class ButtonClickedEvent : UnityEvent { }

        // On click Funktion. Im Logger wird bei Click „onclick “ angezeigt.
        [FormerlySerializedAs("onClick")]
        [SerializeField]
        private ButtonClickedEvent m_OnClick = new ButtonClickedEvent();

        protected ObjectasButton()
        { }

        public ButtonClickedEvent onClick
        {
            //On CLick Event
            get { return m_OnClick; }
            set { m_OnClick = value; }
        }

        private void Press()
        {
            if (!IsActive() || !IsInteractable())
                return;

            UISystemProfilerApi.AddMarker("Button.onClick", this);
            m_OnClick.Invoke();
        }

       

        public virtual void OnPointerClick(PointerEventData eventData)
        {
            //on Pointerclick event
            if (eventData.button != PointerEventData.InputButton.Left)
                return;

            Press();
        }

        
 
        public virtual void OnSubmit(BaseEventData eventData)
        {
            Press();

            
            if (!IsActive() || !IsInteractable())
                return;

            DoStateTransition(SelectionState.Pressed, false);
            StartCoroutine(OnFinishSubmit());
        }

        private IEnumerator OnFinishSubmit()
        {
            var fadeTime = colors.fadeDuration;
            var elapsedTime = 0f;

            while (elapsedTime < fadeTime)
            {
                elapsedTime += Time.unscaledDeltaTime;
                yield return null;
            }

            DoStateTransition(currentSelectionState, false);
        }
    }
}
