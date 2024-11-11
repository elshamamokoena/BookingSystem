using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Components.Base
{
    public partial class CustomComponentBase: ComponentBase
    {
       protected bool IsLoading { get; set; } = false;
        protected bool IsError { get; set; } = false;
        protected bool IsSuccess { get; set; } = false;
        protected string Message { get; set; } = string.Empty;  
        protected void ShowLoading(string message = "Loading...")
        {
            IsLoading = true;
            Message = message;
            IsError = false;
            IsSuccess = false;
        }
        protected void ShowError(string message)
        {
            IsLoading = false;
            Message = message;
            IsError = true;
            IsSuccess = false;
        }
        protected void ShowSuccess(string message)
        {
            IsLoading = false;
            Message = message;
            IsError = false;
            IsSuccess = true;
        }
        protected void HideLoading()
        {
            IsLoading = false;
            IsError = false;
            IsSuccess = false;
        }


    }
    public partial class CustomComponentBase:ComponentBase
    {
        protected  int _pageSize=5;
        protected int ? _pageNumber = 1;
        protected  string _searchQuery = string.Empty;
        protected  string _orderBy = string.Empty;

    }
}
