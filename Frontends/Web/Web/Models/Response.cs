﻿namespace TaskManagementApp.Frontends.Web.Models
{
    public class Response
    {
        public object? Body { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
