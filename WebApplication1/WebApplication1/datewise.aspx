<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="datewise.aspx.vb" Inherits="WebApplication1.datewise" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
         <style>
h5{
    text-align:center;
}
.bi{
    font-size:23px;
}
  
 .mar{
     margin-top:40px;
 }
 .dash{
     font-size:60px;
 }
 
 .mgtbl{
     margin-top:50px;
 }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <%-- navbar --%>

        <div class="container-fluid">
<div class="row flex-nowrap">
    <div class="col-auto col-md-3 col-xl-2 px-sm-2 px-0 bg-dark">
        <div class="d-flex flex-column align-items-center align-items-sm-start px-3 pt-2 text-white min-vh-100">
            <a href="Dashboard.aspx" class="d-flex align-items-center pb-3 mb-md-0 me-md-auto text-white text-decoration-none">
                <span class="fs-5 d-none d-sm-inline"><i class="bi bi-wallet2"></i></span>
            </a>
            <ul class="nav nav-pills flex-column mb-sm-auto mb-0 align-items-center align-items-sm-start" id="menu">
                <li class="nav-item">
                    <a href="Dashboard.aspx" class="nav-link align-middle px-0">
                        <i class="fs-4 bi-house"></i> <span class="ms-1 d-none d-sm-inline">Dashboard</span>
                    </a>
                </li>
                <li>
                    <a href="SetBudget.aspx" class="nav-link px-0 align-middle">
                        <i class="bi bi-piggy-bank-fill "></i>
                        <span class="ms-1 d-none d-sm-inline">Set Budget</span> </a>
                    
                </li>
                <%--<li>
                    <a href="#" class="nav-link px-0 align-middle">
                        <i class="fs-4 bi-table"></i> <span class="ms-1 d-none d-sm-inline">Expenses</span></a>
                </li>--%>
                <li>
                    <a href="#submenu2" data-bs-toggle="collapse" class="nav-link px-0 align-middle ">
                        <i class="bi bi-journal-plus"></i> <span class="ms-1 d-none d-sm-inline">Expenses</span></a>
                    <ul class="collapse nav flex-column ms-1" id="submenu2" data-bs-parent="#menu">
                        <li class="w-100">
                            <a href="addexpenses.aspx" class="nav-link px-0"> <span class="d-none d-sm-inline">Add Expenses</span></a>
                        </li>
                        <li>
                            <a href="#" class="nav-link px-0"> <span class="d-none d-sm-inline">Manage Expenses</span></a>
                        </li>
                    </ul>
                </li>
                <li>
                    <a href="#submenu3" data-bs-toggle="collapse" class="nav-link px-0 align-middle">
                        <i class="fs-4 bi-grid"></i> <span class="ms-1 d-none d-sm-inline">Expense Report</span> </a>
                        
                        <ul class="collapse nav flex-column ms-1" id="submenu3" data-bs-parent="#menu">
                        <li class="w-100">
                            <a href="#" class="nav-link px-0"> <span class="d-none d-sm-inline">Datewise Report</span></a>
                        </li>
                        <li>
                            <a href="#" class="nav-link px-0"> <span class="d-none d-sm-inline">Monthly Report</span></a>
                        </li>
                        <li>
                            <a href="#" class="nav-link px-0"> <span class="d-none d-sm-inline">Yearly Report</span></a>
                        </li>
                        
                    </ul>
                </li>
                
            </ul>
            <hr>
            <div class="dropdown pb-4">
                <a href="#" class="d-flex align-items-center text-white text-decoration-none dropdown-toggle" id="dropdownUser1" data-bs-toggle="dropdown" aria-expanded="false">
                    <img src="img/1659454872088.jpg" alt="hugenerd" width="30" height="30" class="rounded-circle">
                    <span class="d-none d-sm-inline mx-1">Profile</span>
                </a>
                <ul class="dropdown-menu dropdown-menu-dark text-small shadow">
                    <li><a class="dropdown-item" href="#">New project...</a></li>
                    <li><a class="dropdown-item" href="#">Settings</a></li>
                    <li><a class="dropdown-item" href="#">Profile</a></li>
                    <li>
                        <hr class="dropdown-divider">
                    </li>
                    <li><a class="dropdown-item" href="#">Sign out</a></li>
                </ul>
            </div>
        </div>
    </div>
    
<div class="col bg-secondary">
    <asp:TextBox runat="server" ID="user_ID" CssClass="form-control" ></asp:TextBox>
    <asp:TextBox runat="server" ID="user_balance" CssClass="form-control" ></asp:TextBox>

    <div class="card mar mx-auto" style="max-width: 400px;"> <!-- Adjust max-width as needed -->
        <div class="card-body">
            <div class="text-center">
                
                <label for="Datewise">Datewise Expense Report</label>
                <br><br>
                <label for="Datewise">From:</label>
                
                <input  class="text-input" type="datetime-local" value="" name="date_from" required="true" style="width: 100%; padding-top: 8px;" ><br><br>
                <label for="Datewise">To:</label>
                <br>
                <input  class="text-input" type="datetime-local" value="" name="date_to" required="true" style="width: 100%; padding-top: 8px; " ><br><br>
            
            </div>
            <p class="card-text"></p>
        </div>
        <div class="text-center">
            <div class="card-footer">
                
                <asp:Button runat="server" ID="Button1" Text="Submit" CssClass="btn btn-success" OnClick="Button1_Click" />

            </div>
        </div>

    </div>
   <div class="text-center">
       <table class="table table-dark table-hover mgtbl" id="Table_Expense" runat="server">

           <thead>
              <tr>
                <th scope="col">Balance</th>
                <th scope="col">Cost</th>
                <th scope="col">Item</th>
                  <th scope="col">Date</th>
               </tr>
            </thead>
           <tbody>
  
            </tbody>
           </table>
       </div>

</div>
   

</div> 
            
    </div>
     
</asp:Content>

