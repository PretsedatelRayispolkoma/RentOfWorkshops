using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;

namespace RentOfWorkshopsWEB.Shared.Modals
{
    public class ModalBaseComponent : ComponentBase
    {
        protected Guid Guid = Guid.NewGuid();
        protected string ModalDisplay = "display:none";
        protected string ModalClass = "";
        protected bool ShowBackdrop = false;

        public virtual void Open()
        {
            ModalDisplay = "display:block";
            ModalClass = "modal Show";
            ShowBackdrop = true;
            StateHasChanged();
        }

        protected virtual void Close()
        {
            ModalDisplay = "display:none";
            ModalClass = "";
            ShowBackdrop = false;
            StateHasChanged();
        }
    }
}
