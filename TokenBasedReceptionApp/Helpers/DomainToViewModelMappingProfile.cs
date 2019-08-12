using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using TokenBasedReception.Core.Entity;
using TokenBasedReceptionApp.Extensions;
using TokenBasedReception.ViewModel;

namespace TokenBasedReceptionApp.Helpers
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Appointment, AppointmentViewModel>()
                .ForMember(dest => dest.AddedOn, m => m.ResolveUsing(x => x.AddedOn.ToLocalDateTime()))
                .ForMember(dest => dest.DeletedOn, m => m.ResolveUsing(x => x.DeletedOn.ToLocalDateTime()))
                .ForMember(dest => dest.ModifiedOn, m => m.ResolveUsing(x => x.ModifiedOn.ToLocalDateTime()));
            Mapper.CreateMap<Disease, DiseaseViewModel>()
                .ForMember(dest => dest.AddedOn, m => m.ResolveUsing(x => x.AddedOn.ToLocalDateTime()))
                .ForMember(dest => dest.DeletedOn, m => m.ResolveUsing(x => x.DeletedOn.ToLocalDateTime()))
                .ForMember(dest => dest.ModifiedOn, m => m.ResolveUsing(x => x.ModifiedOn.ToLocalDateTime()));
            Mapper.CreateMap<Doctor, DoctorViewModel>()
                .ForMember(dest => dest.AddedOn, m => m.ResolveUsing(x => x.AddedOn.ToLocalDateTime()))
                .ForMember(dest => dest.DeletedOn, m => m.ResolveUsing(x => x.DeletedOn.ToLocalDateTime()))
                .ForMember(dest => dest.ModifiedOn, m => m.ResolveUsing(x => x.ModifiedOn.ToLocalDateTime()));
            Mapper.CreateMap<Patient, PatientViewModel>()
                .ForMember(dest => dest.AddedOn, m => m.ResolveUsing(x => x.AddedOn.ToLocalDateTime()))
                .ForMember(dest => dest.DeletedOn, m => m.ResolveUsing(x => x.DeletedOn.ToLocalDateTime()))
                .ForMember(dest => dest.ModifiedOn, m => m.ResolveUsing(x => x.ModifiedOn.ToLocalDateTime()));
            Mapper.CreateMap<WaitingQueue, WaitingQueueViewModel>()
               .ForMember(dest => dest.AddedOn, m => m.ResolveUsing(x => x.AddedOn.ToLocalDateTime()))
               .ForMember(dest => dest.DeletedOn, m => m.ResolveUsing(x => x.DeletedOn.ToLocalDateTime()))
               .ForMember(dest => dest.ModifiedOn, m => m.ResolveUsing(x => x.ModifiedOn.ToLocalDateTime()));
        }
    }
}