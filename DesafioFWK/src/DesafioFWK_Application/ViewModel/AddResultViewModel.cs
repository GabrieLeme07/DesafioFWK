using FluentValidation.Results;
using System;
using System.Linq;

namespace DesafioFWK_Application.ViewModel
{
    public class AddResultViewModel
    {
        #region :: Properties

        /// <summary>
        /// Entity Identifier
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// Validation Result
        /// </summary>
        public ValidationResult ValidationResult { get; set; }

        /// <summary>
        /// If the add operation was successful, returns true
        /// </summary>
        public bool Success => (ValidationResult?.IsValid) ?? false;

        #endregion

        #region :: Constructors

        public AddResultViewModel(params ValidationResult[] validationResults)
        {
            Id = null;
            ValidationResult = new ValidationResult();
            var errors = validationResults.
                SelectMany(e => e.Errors).ToList();

            foreach (var error in errors)
                ValidationResult.Errors.Add(error);

        }

        public AddResultViewModel(string propertyName, string errorMessage)
        {
            Id = null;
            ValidationResult = new ValidationResult();
            ValidationResult.Errors.Add(new ValidationFailure(propertyName, errorMessage));
        }

        public AddResultViewModel(Guid id)
        {
            Id = id;
            ValidationResult = new ValidationResult();
        }

        #endregion
    }
}
