using HotelsApi.Dtos;
using HotelsApi.Repositories;
using FluentValidation;
using HotelsApi.Entities;

namespace HotelsApi.Validators
{
    public class CreateHotelValidator : AbstractValidator<CreateHotel>
    {
        public CreateHotelValidator(IHotelRepository hotelRepository)
        {
            RuleFor(x => x.HotelName)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here")
                .Must(HotelName => hotelRepository.GetHotelName(HotelName).Result == null)
                    .WithMessage("{PropertyName} already exists.");

            RuleFor(x => x.hotelCode)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here");
            RuleFor(x => x.HotelDescription)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here");
            RuleFor(x => x.BarangayId)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here");
        }

    }
    public class UpdateHotelValidator : AbstractValidator<UpdateHotel>
    {
        public UpdateHotelValidator(IHotelRepository hotelRepository)
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
                .WithMessage("{PropertyName} must not be null test here")
                .Must(HotelName => hotelRepository.GetHotelName(HotelName).Result == null)
                    .WithMessage("{PropertyName} already exists.");
            RuleFor(x => x.hotelCode)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull();
            RuleFor(x => x.HotelDescription)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here");
            RuleFor(x => x.BarangayId)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here");
        }
    }
}
