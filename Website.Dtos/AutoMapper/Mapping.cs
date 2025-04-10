using System;
using AutoMapper;
using Website.Dtos.Concrete.AccountDtos;
using Website.Dtos.Concrete.ContactDtos;
using Website.Entities.Concrete;

namespace Website.Dtos.AutoMapper
{
	public class Mapping : Profile
	{
		public Mapping()
		{
			CreateMap<DenemeDto, User>().ReverseMap();

			CreateMap<ResultContactDto, Contact>().ReverseMap();
            CreateMap<CreateContactDto, Contact>().ReverseMap();
            CreateMap<UpdateContactDto, Contact>().ReverseMap();
        }
	}
}

