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

        public FizzBuzzModel(IFizzBuzzService service)
        {
            this.service = service;
            this.Start = 1;
            this.End = 100;
        }

        public void OnGet()
        {
            try
            {
                var collection = Enumerable.Range(this.Start, this.End);
                this.Results = this.service.GetFizzBuzzList(collection);
            }
            catch (Exception e)
            {
                this.ErrorMessage = e.Message;
            }
        }

        public IList<string> Results { get; set; }

        [FromQuery]
        [Range(1,100)]
        public int Start { get; set; }

        [FromQuery]
        [Range(1, 100)]
        public int End { get; set; }

        public string ErrorMessage { get; set; }
    }
}