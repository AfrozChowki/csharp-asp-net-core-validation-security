using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ConferenceTracker.Entities
{
	public class Speaker : IValidatableObject
	{
		[Required]
		public int Id { get; set; }

		[Required]
		[Display(Name = "First name")]
		[DataType(DataType.Text)]
		[StringLength(100, MinimumLength = 2, ErrorMessage = "First name should be at least 2 characters long, but no longer than 100 characters.")]
		public string FirstName { get; set; }

		[Required]
		[Display(Name = "Last name")]
		[DataType(DataType.Text)]
		[StringLength(100, MinimumLength = 2, ErrorMessage = "Last name should be at least 2 characters long, but no longer than 100 characters.")]
		public string LastName { get; set; }

		[Required]
		[DataType(DataType.MultilineText)]
		[StringLength(500, MinimumLength = 10, ErrorMessage = "Name should be at least 10 characters long, but no longer than 500 characters.")]
		public string Description { get; set; }

		[DataType(DataType.EmailAddress)]
		[Display(Name = "Email Address")]
		public string EmailAddress { get; set; }

		[DataType(DataType.PhoneNumber)]
		[Display(Name = "Phone Number")]
		public string PhoneNumber { get; set; }

		public bool IsStaff { get; set; }
		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			List<ValidationResult> validationResults = new List<ValidationResult>();
			if (!string.IsNullOrEmpty(this.EmailAddress) && this.EmailAddress.Contains("TechnologyLiveConference.com",
					 StringComparison.InvariantCulture))
			{
				validationResults.Add(new ValidationResult("Technology Live Conference staff should not use their conference email addresses."));
			}

			return validationResults;
		}
	}
}
