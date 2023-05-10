// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Factorial.cshtml.cs" company="Bugail Consulting Ltd">
//      Copyright 2023 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UL.UI.Web.Pages
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc;
    using UL.Abstractions.Interfaces;

    public class FactorialModel : PageModel
    {
        private readonly ILogger<FizzBuzzModel> logger;
        private readonly IFactorialService service;

        public FactorialModel(IFactorialService service, ILogger<FizzBuzzModel>logger)
        {
            this.service = service;
            this.logger = logger;
            this.Value = 3;
        }

        public void OnGet()
        {
            try
            {
                this.logger.LogInformation("OnGet - Running Factorial - Value: {Value}", this.Value);
                this.Result = this.service.Calculate(this.Value).ToString();
            }
            catch (Exception e)
            {
                this.ErrorMessage = e.Message;
                this.logger.LogError(e, "OnGet - Error - Value: {Value}, End: {End}", this.Value );
            }
        }

        [FromQuery]
        [Range(1,100)]
        public int Value { get; set; }

        public string Result { get; set; }

        public string ErrorMessage { get; set; }
    }
}