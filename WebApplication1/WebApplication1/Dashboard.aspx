<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Dashboard.aspx.vb" Inherits="WebApplication1.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <style>
      h5{
          text-align:center;
      }
      .bi{
          font-size:23px;
      }
      .dash{
          font-size:50px;
      }
      .cu{
          font-size:15px;
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
                            <span class="ms-1 d-none d-sm-inline">Set Budget</span> 

                        </a>
                        
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
                                <a href="datewise.aspx" class="nav-link px-0"> <span class="d-none d-sm-inline">Datewise Report</span></a>
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

    


    <%-- Dashboard top --%>

<div class="col py-3 bg-secondary">
    <asp:TextBox runat="server" ID="user_ID" CssClass="form-control" ></asp:TextBox>
    <div class="row row-cols-1 row-cols-md-3 g-4">
          <div class="col">
            <div class="card h-100">
                
              <div class="card-body">
                  <div class="text-center">
                      <i class="dash bi bi-list-check"></i>
                      </div>
                <h5 class="card-title">Today's Expenses</h5>
                  <div class="icsize">
                <p class="card-text"></p>
                      </div>
              </div>
              <div class="card-footer">
                  <div class="text-center">
                        <i class="cu bi bi-currency-dollar">
                            <asp:TextBox ID="expenses1" runat="server" Enabled="False"></asp:TextBox>
                        </i>
                 </div>
              </div>
            </div>
          </div>
          <div class="col">
            <div class="card h-100">
              
              <div class="card-body">
                  <div class="text-center">
                    <i class="dash bi bi-arrow-counterclockwise"></i>
                    </div>
                <h5 class="card-title">Yesterday's Expenses</h5>
                <p class="card-text"></p>
              </div>
              <div class="card-footer">
               <div class="text-center">
                        <i class="cu bi bi-currency-dollar">
                            <asp:TextBox ID="yesterday" runat="server" Enabled="False"></asp:TextBox>
                        </i>
                 </div>
              </div>
            </div>
          </div>
          <div class="col">
            <div class="card h-100">
              
              <div class="card-body">
                  <div class="text-center">
                  <i class="dash bi bi-calendar-week-fill"></i>
                  </div>
                <h5 class="card-title">Last 7 day's expenses</h5>
                <p class="card-text"></p>
              </div>
              <div class="card-footer">
                <div class="text-center">
                     <i class="cu bi bi-currency-dollar">
                         <asp:TextBox ID="week" runat="server" Enabled="False"></asp:TextBox>
                     </i>
              </div>
              </div>
            </div>
          </div>
        </div>
    <%-- dashboard bottom --%>
    <div class="col py-3">
    Content area...
    <div class="row row-cols-1 row-cols-md-3 g-4">
          <div class="col">
            <div class="card h-100">
              
              <div class="card-body">
                  <div class="text-center">
                    <i class="dash bi bi-calendar2-fill"></i>
                    </div>
                <h5 class="card-title">Last 30 day's expenses</h5>
                <p class="card-text"></p>
              </div>
              <div class="card-footer">
                  <div class="text-center">
                       <i class="cu bi bi-currency-dollar">
                           <asp:TextBox ID="a_month" runat="server" Enabled="False"></asp:TextBox>
                       </i>
                </div>
              </div>
            </div>
          </div>
          <div class="col">
            <div class="card h-100">
              
              <div class="card-body">
                  <div class="text-center">
                  <i class="dash bi bi-cash"></i>
                  </div>
                <h5 class="card-title">Monthly Budget Left</h5>
                <p class="card-text"></p>
              </div>
              <div class="card-footer">
                <div class="text-center">
                       <i class="cu bi bi-currency-dollar">
                           <asp:TextBox ID="expenses" runat="server" Enabled="False"></asp:TextBox>
                       </i>
                </div>
              </div>
            </div>
          </div>
          <div class="col">
            <div class="card h-100">
              
              <div class="card-body">
                  <div class="text-center">
                    <i class="dash bi bi-receipt"></i>
                    </div>
                <h5 class="card-title">Total Expenses</h5>
                <p class="card-text"></p>
              </div>
              <div class="card-footer">
                <div class="text-center">
                   <i class="cu bi bi-currency-dollar">
                       <asp:TextBox ID="total_cost" runat="server" Enabled="False"></asp:TextBox>
                   </i>
            </div>
              </div>
            </div>
          </div>
        </div>
     </div>
    </div>
  </div>
             </div>      
</asp:Content>
