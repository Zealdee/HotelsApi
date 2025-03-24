using HotelsApi.Dtos;
using HotelsApi.Repositories;
using FluentValidation;
using HotelsApi.Entities;

namespace HotelsApi.Validators
{
    public class CreateTransactionValidator : AbstractValidator<CreateTransaction>
    {
        public CreateTransactionValidator(ITransactionRepository transactionRepository)
        {
            RuleFor(x => x.HotelId)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here");
            RuleFor(x => x.HotelName)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here");
            RuleFor(x => x.HotelCode)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here");
            RuleFor(x => x.DateTo)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here");
            RuleFor(x => x.DateFrom)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here");
            RuleFor(x => x.FullName)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here")
                .Must(FullName => transactionRepository.GetTransactionName(FullName).Result == null)
                .WithMessage("{PropertyName} already exists.");
            RuleFor(x => x.EmailAddress)
                .NotEmpty()
                .WithMessage("must not be empty here");

        }

    }
    public class UpdateTransactionValidator : AbstractValidator<UpdateTransaction>
    {
        public UpdateTransactionValidator(ITransactionRepository transactionRepository)
        {
            RuleFor(x => x.TransactionId)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here")
                .Must(TransactionId => transactionRepository.GetTransactionById(TransactionId).Result == null);
            RuleFor(x => x.HotelId)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here");
            RuleFor(x => x.HotelName)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here");
            RuleFor(x => x.HotelCode)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here");
            RuleFor(x => x.DateTo)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here");
            RuleFor(x => x.DateFrom)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here");
            RuleFor(x => x.FullName)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here")
                .Must(FullName => transactionRepository.GetTransactionName(FullName).Result == null)
                .WithMessage("{PropertyName} already exists.");
            RuleFor(x => x.EmailAddress)
                .NotEmpty()
                .WithMessage("must not be empty here");

        }
    }
}
