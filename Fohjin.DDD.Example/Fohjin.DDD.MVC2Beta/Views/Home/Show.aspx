<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Banking Application
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Welcome</h2>
    <p>
        This application is a demonstration of ASP.Net MVC 2 Beta in action on top of a
        Command-Query Responsibility Segregation (CQRS) middle->backend tier implementation.
        To find more detail about this application, see the following list of information:</p>
    <ul>
        <li><a href="http://elegantcode.com/2009/11/11/cqrs-la-greg-young/">Opening blog post
            in a series detailing the design</a> </li>
        <li><a href="http://elegantcode.com/2009/11/19/recording-of-my-e-van-presentation-about-cqrs/">
            Screencast going into detail of the example code</a> </li>
    </ul>
    <p>
        Or, just
        <%=Html.ActionLink("click here", MVC.Client.List.Show()) %>
        to start playing with the example.</p>
</asp:Content>
