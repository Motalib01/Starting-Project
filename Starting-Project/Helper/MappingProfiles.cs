using AutoMapper;
using Starting_Project.Dtos;
using Starting_Project.Models;

namespace Starting_Project.Helper
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<Candidate, CandidateDto>().ReverseMap();
            CreateMap<Program, ProgramDto>().ReverseMap();
            CreateMap<Questions, QuestionsDto>().ReverseMap();
        }
    }
}
