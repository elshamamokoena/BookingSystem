using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Responses
{

    //This class is used to return a response from the API
    public class BaseResponse
    {
        public BaseResponse()
        {
            //success is true by default, only set to false when there are validation errors
            Success = true;
        }

        

        //if the response is successful, the message will be set to the message passed in the constructor
        //useful if you wanna send a specific message to the user when request is successful
        public BaseResponse(string message)
        {
            Success = true;
            Message = message;
        }
        public BaseResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }
        public bool Success { get; set; }
        public string Message { get; set; }=string.Empty;
        public List<string>? ValidationErrors { get; set; }
    }
}
