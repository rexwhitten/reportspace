namespace ReportSpace.CustomerDashboard.Web.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using ReportSpace.CustomerDashboard.Core.Models;

    using AutoMapper;

    public class UserProfileViewModel
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string CompanyLogoFileName { get; set; }

        public string Clients { get; set; }

        public bool IsConfirmed { get; set; }

        public IList<int> ClientIds
        {
            get
            {
                var clients = Clients ?? string.Empty;
                return clients.Split(',').Where(n => !string.IsNullOrEmpty(n)).Select(n => Convert.ToInt32(n)).ToList();
            }
        }

        public string Roles { get; set; }

        public IList<int> RoleIds
        {
            get
            {
                var roles = Roles ?? string.Empty;
                return roles.Split(',').Where(n => !string.IsNullOrEmpty(n)).Select(n => Convert.ToInt32(n)).ToList();
            }
        }

        public UserProfileViewModel()
        {
        }

        public UserProfileViewModel(UserProfile userProfile)
        {
            Mapper.Map(userProfile, this);
        }
    }
}