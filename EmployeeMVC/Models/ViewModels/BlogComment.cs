﻿namespace EmployeeMVC.Models.ViewModels
{
    public class BlogComment
    {
       public string Description { get; set; }
        public string Username {  get; set; }
        public DateTime DateAdded { get; set; }
        public Guid Id { get; set; }
    }
}
