using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokenBasedReception.Core.Entity;
using TokenBasedReceptionApp.Extensions;
using TokenBasedReception.ViewModel;

namespace TokenBasedReceptionApp.Helpers
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<AppointmentViewModel, Appointment>()
               .ForMember(dest => dest.AddedOn, m => m.ResolveUsing(x => x.AddedOn.ToUTCDateTime()))
               .ForMember(dest => dest.DeletedOn, m => m.ResolveUsing(x => x.DeletedOn.ToUTCDateTime()))
               .ForMember(dest => dest.ModifiedOn, m => m.ResolveUsing(x => x.ModifiedOn.ToUTCDateTime()));
            Mapper.CreateMap<DiseaseViewModel, Disease>()
               .ForMember(dest => dest.AddedOn, m => m.ResolveUsing(x => x.AddedOn.ToUTCDateTime()))
               .ForMember(dest => dest.DeletedOn, m => m.ResolveUsing(x => x.DeletedOn.ToUTCDateTime()))
               .ForMember(dest => dest.ModifiedOn, m => m.ResolveUsing(x => x.ModifiedOn.ToUTCDateTime()));
            Mapper.CreateMap<DoctorViewModel, Doctor>()
               .ForMember(dest => dest.AddedOn, m => m.ResolveUsing(x => x.AddedOn.ToUTCDateTime()))
               .ForMember(dest => dest.DeletedOn, m => m.ResolveUsing(x => x.DeletedOn.ToUTCDateTime()))
               .ForMember(dest => dest.ModifiedOn, m => m.ResolveUsing(x => x.ModifiedOn.ToUTCDateTime()));
            Mapper.CreateMap<PatientViewModel, Patient>()
                .ForMember(dest => dest.AddedOn, m => m.ResolveUsing(x => x.AddedOn.ToUTCDateTime()))
                .ForMember(dest => dest.DeletedOn, m => m.ResolveUsing(x => x.DeletedOn.ToUTCDateTime()))
                .ForMember(dest => dest.ModifiedOn, m => m.ResolveUsing(x => x.ModifiedOn.ToUTCDateTime()));
            Mapper.CreateMap<WaitingQueueViewModel, WaitingQueue>()
                .ForMember(dest => dest.AddedOn, m => m.ResolveUsing(x => x.AddedOn.ToUTCDateTime()))
                .ForMember(dest => dest.DeletedOn, m => m.ResolveUsing(x => x.DeletedOn.ToUTCDateTime()))
                .ForMember(dest => dest.ModifiedOn, m => m.ResolveUsing(x => x.ModifiedOn.ToUTCDateTime()));

        }
    }
}