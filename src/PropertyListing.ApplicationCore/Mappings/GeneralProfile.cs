using AutoMapper;
using PropertyListing.ApplicationCore.DTOs;
using PropertyListing.ApplicationCore.Entities;

namespace PropertyListing.ApplicationCore.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<CreatePropertyRequest, Property>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.PropertyName, opt => opt.Ignore())
                .ForMember(dest => dest.NearestTown, opt => opt.Ignore())
                .ForMember(dest => dest.Description, opt => opt.Ignore())
                .ForMember(dest => dest.FloorArea, opt => opt.Ignore())
                .ForMember(dest => dest.LandArea, opt => opt.Ignore())
                .ForMember(dest => dest.Rooms, opt => opt.Ignore())
                .ForMember(dest => dest.Bedrooms, opt => opt.Ignore())
                .ForMember(dest => dest.TotalBathrooms, opt => opt.Ignore())
                .ForMember(dest => dest.Ensuite, opt => opt.Ignore())
                .ForMember(dest => dest.IsOpenKitchen, opt => opt.Ignore())
                .ForMember(dest => dest.IsFurnished, opt => opt.Ignore())
                .ForMember(dest => dest.YearBuilt, opt => opt.Ignore())
                .ForMember(dest => dest.ForRent, opt => opt.Ignore())
                .ForMember(dest => dest.Rent, opt => opt.Ignore())
                .ForMember(dest => dest.SaleValue, opt => opt.Ignore())
                .ForMember(dest => dest.IsFeatured, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());
            CreateMap<Property, PropertyResponse>();

            CreateMap<CreateOwnerRequest, Owner>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Userid, opt => opt.Ignore());
            CreateMap<Owner, OwnerResponse>();

            CreateMap<CreateCategoryRequest, Category>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.Ignore());
            CreateMap<Category, CategoryResponse>();

            CreateMap<CreateImageRequest, Image>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Path, opt => opt.Ignore())
                .ForMember(dest => dest.IsCover, opt => opt.Ignore());
            CreateMap<Image, ImageResponse>();

            CreateMap<CreateAmenityRequest, Amenity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.AmenityType, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.Ignore());
            CreateMap<Amenity, AmenityResponse>();

            CreateMap<CreateLocationAmenityRequest, LocationAmenity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.AmenityType, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.Ignore())
                .ForMember(dest => dest.Lat, opt => opt.Ignore())
                .ForMember(dest => dest.Lng, opt => opt.Ignore());
            CreateMap<Amenity, AmenityResponse>();
        }
    }
}
