<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="SampleWebApp.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    <h1>Register the Restaurant</h1>
    <div>
        <p>
            Enter the Name:
            <asp:TextBox runat="server" ID="txtName"/>
            <asp:RequiredFieldValidator ErrorMessage="Name is mandatory" ControlToValidate="txtName" runat="server" ForeColor="IndianRed" />
        </p>
        <p>
            Enter the Email:
            <asp:TextBox runat="server" ID="txtEmail" TextMode="Email"/>
            <asp:RegularExpressionValidator ErrorMessage="Invalid Email Format" ControlToValidate="txtEmail" runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"/>
        </p>
        <p>
            Enter the Address:
            <asp:TextBox runat="server" ID="txtAddress"/>
            <asp:RequiredFieldValidator ErrorMessage="Address is must" ControlToValidate="txtAddress" runat="server" />
        </p>
        <p>
            Enter the Contact No:
            <asp:TextBox runat="server" ID="txtPhone" TextMode="Phone"/>
            <asp:RequiredFieldValidator ErrorMessage="Phone no is mandatory" ControlToValidate="txtPhone" runat="server" />           
        </p>
        <p>
            Enter UR Username:
            <asp:TextBox runat="server" ID="txtUserName" />
            <asp:RequiredFieldValidator ErrorMessage="Username is must" ControlToValidate="txtUserName" runat="server" />
            <asp:CustomValidator ErrorMessage="User already exists" ControlToValidate="txtUserName" runat="server" OnServerValidate="Unnamed6_ServerValidate" />
        </p>
         <p>
            Enter UR Password:
            <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" />
             <asp:RequiredFieldValidator ErrorMessage="Password is must" ControlToValidate="txtPassword" runat="server" />
        </p>
        <p>
            Retype UR Password:
            <asp:TextBox runat="server" ID="txtRetype" TextMode="Password" />
            <asp:CompareValidator ErrorMessage="Password Mismatch" Type="String" ControlToValidate="txtRetype" ControlToCompare="txtPassword" runat="server" />
        </p>
        <p>
            <asp:Button Text="Register" runat="server" OnClick="Unnamed1_Click" />
        </p>
        <p>
            <asp:Label Text="" ID="lblError" ForeColor="Red" BorderColor="Blue" BorderStyle="Dotted" runat="server" />
        </p>
    </div>
</asp:Content>
