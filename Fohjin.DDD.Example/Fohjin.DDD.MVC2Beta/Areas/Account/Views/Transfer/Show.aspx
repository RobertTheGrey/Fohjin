<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Fohjin.DDD.MVC2Beta.Areas.Account.Models.TransferViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Make a Transfer
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Make a Transfer</h2>
    <%=Html.ValidationSummary() %>
    <% using (Html.BeginForm(MVC.Account.Transfer.Save(), FormMethod.Post))
       {%>
    <fieldset>
        <legend>Amount</legend>
        <%=Html.HiddenFor(model => model.AccountId) %>
        <p>
            <%= Html.LabelFor(model => model.Amount) %>
            <%= Html.TextBoxFor(model => model.Amount) %>
            <%= Html.ValidationMessageFor(model => model.Amount) %>
        </p>
        <p>
            <%= Html.LabelFor(model => model.TargetAccountNumber) %>
            <%= Html.DropDownListFor(model => model.TargetAccountNumber, new SelectList(Model.TargetAccounts), "--Select target account--")%>
            <%= Html.ValidationMessageFor(model => model.TargetAccountNumber) %>
        </p>
        <p>
            <input type="submit" value="Transfer" />
        </p>
    </fieldset>
    <% } %>
    <div>
        <%=Html.ActionLink("Cancel", MVC.Account.Details.Show(Model.AccountId)) %>
    </div>
</asp:Content>
