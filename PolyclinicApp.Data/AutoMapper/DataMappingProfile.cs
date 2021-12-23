using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PolyclinicApp.Data.DataTransferObjects;
using PolyclinicApp.Data.Models;

namespace PolyclinicApp.Data.AutoMapper
{
    public class DataMappingProfile : Profile
    {
        public DataMappingProfile()
        {
            CreateMap<Doctor, DoctorDTO>()
                .ForMember(dto => dto.SpecializationName,
                    conf => conf
                        .MapFrom(s => s.Specialization.SpecializationName));
        }
    }
}
