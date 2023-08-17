using AutoMapper;
using TerrageApi.Models;
using TerrageApi.Models.DTO;

namespace TerrageApi.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<UserCreateDTO, User>();

            CreateMap<User, UserReadDTO>()
                .ForMember(dto => dto.AchievementIDs, opt => opt
                    .MapFrom(u => u.Achievements
                        .Select(a => a.ID).ToArray()))
                .ForMember(dto => dto.SettingsID, opt => opt
                    .MapFrom(u => u.Settings.ID))
                .ForMember(dto => dto.VillageID, opt => opt
                    .MapFrom(u => u.Village.ID))
                .ForMember(dto => dto.FriendIDs, opt => opt
                    .MapFrom(u => u.Friends
                        .Select(f => f.ID).ToArray()))
                .ForMember(dto => dto.ClanID, opt => opt
                    .MapFrom(u => u.Clan.ID));
        }
    }
}