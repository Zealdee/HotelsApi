using HotelsApi.Dtos;
using HotelsApi.Repositories;
using FluentValidation;
using HotelsApi.Entities;

namespace HotelsApi.Validators
{
    public class CreateCityValidator : AbstractValidator<CreateCity>
    {
        public CreateCityValidator(ICityRepository cityRepository)
        {
            RuleFor(x => x.CityName)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here")
                .Must(CityName => cityRepository.GetCityName(CityName).Result == null)
                    .WithMessage("{PropertyName} already exists.");

            RuleFor(x => x.CityCode)
                .NotEmpty()
                .WithMessage("must not be empty here");
            RuleFor(x => x.StateId)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here");
        }

    }
    public class UpdateCityValidator : AbstractValidator<UpdateCity>
    {
        public UpdateCityValidator(ICityRepository cityRepository)
        {
            RuleFor(x => x.CityId)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here");
            RuleFor(x => x.CityName)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here")
                .Must(CityName => cityRepository.GetCityName(CityName).Result == null)
                    .WithMessage("{PropertyName} already exists.");

            RuleFor(x => x.CityCode)
                .NotEmpty()
                .WithMessage("must not be empty here");
            RuleFor(x => x.StateId)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here");
        }
    }
}
