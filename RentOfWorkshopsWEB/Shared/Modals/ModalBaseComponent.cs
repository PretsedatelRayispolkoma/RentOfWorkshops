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

        public virtual void Close()
        {
            ModalDisplay = "display:none";
            ModalClass = "";
            ShowBackdrop = false;
            StateHasChanged();
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            int seq = 0;
            base.BuildRenderTree(builder);

            builder.OpenElement(seq, "div");
                builder.AddAttribute(++seq, "class", ModalClass);
                builder.AddAttribute(++seq, "tabindex", "-1");
                builder.AddAttribute(++seq, "role", "dialog");
                builder.AddAttribute(++seq, "style", ModalDisplay);

                builder.OpenElement(++seq, "div");
                    builder.AddAttribute(++seq, "class", "modal-dialog");
                    builder.AddAttribute(++seq, "role", "document");

                    builder.OpenElement(++seq, "div");
                        builder.AddAttribute(++seq, "class", "modal-content");

                        builder.OpenElement(++seq, "div");
                            builder.AddAttribute(++seq, "class", "modal-header");
                            builder.OpenElement(++seq, "h5");
                                builder.AddAttribute(++seq, "class", "modal-title unselectable");
                                builder.AddContent(++seq, "Defult header");
                            builder.CloseElement();
                        builder.CloseElement();

                        builder.OpenElement(++seq, "div");
                            builder.AddAttribute(++seq, "class", "modal-body");
                            builder.OpenElement(++seq, "div");
                                builder.AddAttribute(++seq, "class", "container");
                                builder.AddAttribute(++seq, "margin", "20");
                                builder.AddContent(++seq, "Defult body");
                            builder.CloseElement();
                        builder.CloseElement();

                        builder.OpenElement(++seq, "div");
                            builder.AddAttribute(++seq, "class", "modal-footer");
                            builder.OpenElement(++seq, "button");
                                builder.AddAttribute(++seq, "type", "button");
                                builder.AddAttribute(++seq, "class", "btn btn-secondary");
                                builder.AddAttribute(++seq, "data-dismiss", "modal");
                                builder.AddContent(++seq, "Close");
                            builder.CloseElement();
                        builder.CloseElement();

                    builder.CloseElement();
                builder.CloseElement();
            builder.CloseElement();

            if (ShowBackdrop)
            {
                builder.OpenElement(++seq, "div");
                    builder.AddAttribute(++seq, "class", "modal-backdrop fade show");
                builder.CloseElement();
            }
        }
    }
}
