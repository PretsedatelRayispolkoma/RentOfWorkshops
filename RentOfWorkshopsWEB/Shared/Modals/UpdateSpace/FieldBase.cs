using Microsoft.AspNetCore.Components;

namespace RentOfWorkshopsWEB.Shared.Modals.UpdateSpace
{
    public abstract class FieldBase : ComponentBase
    {
        [Parameter]
        public EventCallback<string> ValueCallback { get; set; }

        [Parameter]
        public string Value { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public string InputType { get; set; }

        protected object _value;

        protected string _invalidValueMessage = "";
        protected string _inputClass = "";

        protected abstract void ValueValidation();
    }
}
