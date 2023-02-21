using AutoMapper;
using Lab.DTOs;
using Lab.Models;

namespace Lab
{
    public static class AutoMapperExpression
    {
        //Price
        public static List<PriceGetDTO> AutoMapPriceGetDTO(IQueryable<Price> entities)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Price, PriceGetDTO>()
                    .ForMember(dist => dist.Kind, opt => opt.MapFrom(x => x.Kind.Name));
            });

            var mapper = new Mapper(config);
            return mapper.Map<List<PriceGetDTO>>(entities);
        }

        //SuperDictionary
        public static List<SuperDictionaryDTO> AutoMapSuperDictionaryDTO(IQueryable<SuperDictionary> entities)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<SuperDictionary, SuperDictionaryDTO>();
            });

            var mapper = new Mapper(config);
            return mapper.Map<List<SuperDictionaryDTO>>(entities);
        }

        //Transport
        public static List<TransportGetDTO> AutoMapTransportGetDTO(IQueryable<Transport> entities)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Transport, TransportGetDTO>()
                    .ForMember(dist => dist.Price, opt => opt.MapFrom(x => x.Price.TripPrice));
            });

            var mapper = new Mapper(config);
            return mapper.Map<List<TransportGetDTO>>(entities);
        }

        //Trip
        public static List<TripGetDTO> AutoMapTripGetDTO(IQueryable<Trip> entities)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Trip, TripGetDTO>()
                    .ForMember(dist => dist.User, opt => opt.MapFrom(x => $"{x.User.Surname} {x.User.Name} {x.User.Patronymic}"))
                    .ForMember(dist => dist.Transport, opt => opt.MapFrom(x => $"{x.Transport.Kind.Name} {x.Transport.Number}"));
            });

            var mapper = new Mapper(config);
            return mapper.Map<List<TripGetDTO>>(entities);
        }

        //UserTransportChoice
        public static List<UserTransportChoiceGetDTO> AutoMapUserTransportChoiceGetDTO(IQueryable<UserTransportChoice> entities)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UserTransportChoice, UserTransportChoiceGetDTO>()
                    .ForMember(dist => dist.Transport, opt => opt.MapFrom(x => $"{x.Transport.Kind.Name} {x.Transport.Number}"));
            });

            var mapper = new Mapper(config);
            return mapper.Map<List<UserTransportChoiceGetDTO>>(entities);
        }

        //User
        public static List<UserDTO> AutoMapUserDTO(IQueryable<User> entities)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<User, UserDTO>();
            });

            var mapper = new Mapper(config);
            return mapper.Map<List<UserDTO>>(entities);
        }
    }
}
