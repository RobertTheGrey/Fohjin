<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Fohjin.DDD.Reporting.Dto.ClientDetailsReport>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Change Phone Number
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Change Phone Number (<%=Model.ClientName %>)</h2>
    <%=Html.ValidationSummary() %>
    <% using (Html.BeginForm(MVC.Client.ChangePhoneNumber.Save(), FormMethod.Post))
       {%>
    <fieldset>
        <legend>Fields</legend>
        <%=Html.HiddenFor(model => model.Id) %>
        <p>
            <%= Html.LabelFor(model => model.PhoneNumber) %>
            <%= Html.TextBoxFor(model => model.PhoneNumber) %>
            <%= Html.ValidationMessageFor(model => model.PhoneNumber) %>
        </p>
        <p>
            <input type="submit" value="Change Phone Number" />
        </p>
    </fieldset>
    <% } %>
    <div>
        <%=Html.ActionLink("Cancel", MVC.Client.Details.Show(Model.Id)) %>
    </div>
</asp:Content>
