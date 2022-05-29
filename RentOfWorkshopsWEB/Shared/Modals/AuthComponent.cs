using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using RentOfWorkshopsCore.DBConnection;
using RentOfWorkshopsCore.DBContext;
using System;

namespace RentOfWorkshopsWEB.Shared.Modals
{
    public class AuthComponent : ModalBaseComponent
    {
        [Parameter]
        public EventCallback<User> UserCallback { get; set; }

        UserContext UserContext = new UserContext();

        private string _login = "";
        private string _password = "";
        private string _logInputClass = "form-control";
        private string _passInputClass = "form-control";
        private string _invalidLogMessage = "";
        private string _invalidPassMessage = "";

        private void Authorize()
        {
            if (String.IsNullOrEmpty(_login) || String.IsNullOrEmpty(_password))
            {
                _logInputClass = "form-control is-invalid";
                _invalidLogMessage = "";
                _passInputClass = "form-control is-invalid";
                _invalidPassMessage = "Enter the data";
            }
            else
            {
                _logInputClass = "form-control";
                _passInputClass = "form-control";
                if (SQLConnection.GetRole(_login, _password) != null)
                {
                    UserCallback.InvokeAsync(SQLConnection.GetRole(_login, _password));
                    Close();
                    _login = "";
                    _password = "";

                }
                else
                {
                    _logInputClass = "form-control  ";
                    _invalidLogMessage = "";
                    _passInputClass = "form-control is-invalid";
                    _invalidPassMessage = "Incorrect login or password";
                }
            }
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
            builder.AddContent(++seq, "Войти");
            builder.CloseElement();
            builder.CloseElement();

            builder.OpenElement(++seq, "div");
            builder.AddAttribute(++seq, "class", "modal-body modal-body-size");

            builder.OpenElement(++seq, "div");
            builder.AddAttribute(++seq, "class", "container");
            builder.AddAttribute(++seq, "margin", "20");

            builder.OpenElement(++seq, "label");
            builder.AddAttribute(++seq, "class", "unselectable");
            builder.AddContent(++seq, "Логин");
            builder.CloseElement();
            builder.CloseElement();

            builder.OpenElement(++seq, "div");
            builder.AddAttribute(++seq, "class", "container");

            builder.OpenElement(++seq, "input");
            builder.AddAttribute(++seq, "class", $"{_logInputClass} unselectable");
            builder.AddAttribute(++seq, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(_login));
            builder.AddAttribute(++seq, "oninput", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => _login = __value, _login));
            builder.CloseElement();

            builder.OpenElement(++seq, "div");
            builder.AddAttribute(++seq, "class", "invalid-feedback");
            builder.AddContent(++seq, $"{_invalidLogMessage}");
            builder.CloseElement();

            builder.OpenElement(++seq, "label");
            builder.AddAttribute(++seq, "class", "unselectable");
            builder.AddContent(++seq, "Пароль");
            builder.CloseElement();

            builder.OpenElement(++seq, "input");
            builder.AddAttribute(++seq, "class", $"{_passInputClass} unselectable");
            builder.AddAttribute(++seq, "type", "password");
            builder.AddAttribute(++seq, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(_password));
            builder.AddAttribute(++seq, "oninput", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => _password = __value, _password));
            builder.CloseElement();

            builder.OpenElement(++seq, "div");
            builder.AddAttribute(++seq, "class", "invalid-feedback");
            builder.AddContent(++seq, $"{_invalidPassMessage}");
            builder.CloseElement();

            builder.CloseElement();
            builder.CloseElement();

            builder.OpenElement(++seq, "div");
            builder.AddAttribute(++seq, "class", "modal-footer");

            builder.OpenElement(++seq, "button");
            builder.AddAttribute(++seq, "type", "button");
            builder.AddAttribute(++seq, "class", "btn btn-primary");
            builder.AddAttribute(++seq, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, Authorize));
            builder.AddContent(++seq, "Войти");
            builder.CloseElement();

            builder.OpenElement(++seq, "button");
            builder.AddAttribute(++seq, "type", "button");
            builder.AddAttribute(++seq, "class", "btn btn-secondary");
            builder.AddAttribute(++seq, "data-dismiss", "modal");
            builder.AddAttribute(++seq, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, Close));
            builder.AddContent(++seq, "Отмена");
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
