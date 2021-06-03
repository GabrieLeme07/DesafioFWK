using FluentValidation.Results;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DesafioFWK_Domain.CommandHandlers
{
    public abstract class CommandHandler
    {
        protected ValidationResult ValidationResult;

        protected CommandHandler()
        {
            ValidationResult = new ValidationResult();
        }

        protected ValidationResult AddError(int errorCode, string message)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, message)
            {
                ErrorCode = errorCode.ToString("X")
            });
            return ValidationResult;
        }

        protected ValidationResult AddError<TEntity, TKey>(TEntity entity, Expression<Func<TEntity, TKey>> propertyKey, string message)
            where TEntity : class
        {
            var expression = (MemberExpression)propertyKey.Body;
            var propertyName = expression.Member.Name;
            ValidationResult.Errors.Add(new ValidationFailure(propertyName, message));
            return ValidationResult;
        }

        protected async Task<ValidationResult> Commit(Interfaces.IUnitOfWork uow, string message)
        {
            if (!await uow.Commit())
                AddError(0xC0001, message);

            return ValidationResult;
        }

        protected async Task<ValidationResult> Commit(Interfaces.IUnitOfWork uow)
        {
            return await Commit(uow, "There was an error saving data").ConfigureAwait(false);
        }
    }
}
