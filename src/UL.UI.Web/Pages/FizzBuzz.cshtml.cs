// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="FizzBuzz.cshtml.cs" company="Bugail Consulting Ltd">
//      Copyright 2023 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UL.UI.Web.Pages
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc;
    using UL.Abstractions.Interfaces;

    public class FizzBuzzModel : PageModel
    {
        private readonly IFizzBuzzService service;
        private readonly ILogger<FizzBuzzModel> logger;

        public FizzBuzzModel(IFizzBuzzService service, ILogger<FizzBuzzModel>logger)
        {
            this.service = service;
            this.logger = logger;
            this.Start = 1;
            this.End = 100;
        }

        public void OnGet()
        {
            try
            {
                this.logger.LogInformation("OnGet - Running FizzBuzz - Start: {Start}, End: {End}", this.Start, this.End);
                var collection = Enumerable.Range(this.Start, this.End);
                this.Results = this.service.GetFizzBuzzList(collection);
            }
            catch (Exception e)
            {
                this.ErrorMessage = e.Message;
                this.logger.LogError(e, "OnGet - Error - Start: {Start}, End: {End}", this.Start, this.End);
            }
        }

        public IEnumerable<string> Results { get; set; }

        [FromQuery]
        [Range(1,100)]
        public int Start { get; set; }

        [FromQuery]
        [Range(1, 100)]
        public int End { get; set; }

        public string ErrorMessage { get; set; }
    }
}