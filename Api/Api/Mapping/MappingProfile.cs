using AutoMapper;
using Project_mobile_app.Models;
using Api.Resources.UserResources;
using Api.Resources.AdminResources;
using Api.Resources.GameResources.GameWithUser;
using Api.Resources.GameResources.FullGame;

namespace Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Admin, AdminResource>();


            CreateMap<User, UserResource>();
            CreateMap<User, UserWithStatAndGamesResource>();
            CreateMap<Statistics, StatisticsResource>();
            CreateMap<Game, GameForUserResource>();


            CreateMap<Game, GameWithUserResource>();
            CreateMap<User, UserForGameResource>();

            CreateMap<Question, QuestionResource>().IncludeAllDerived();
            CreateMap<Choice, ChoiceResource>().IncludeAllDerived();
            CreateMap<DisplayObject, DisplayObjectResource>().IncludeAllDerived();

            CreateMap<DefaultChoice, DefaultChoiceResource>();
            CreateMap<DisplayObjectStopDisplayAfterDisplay, DisplayObjectStopDisplayAfterDisplayResource>();
            CreateMap<DisplayObjectStopDisplayAfterUnlock, DisplayObjectStopDisplayAfterUnlockResource>();
            CreateMap<GamePassword, GamePasswordResource>();
            CreateMap<Game, GameResource>();
            CreateMap<ChoiceForChoiceQuestion, ChoiceForChoiceQuestionResource>();
            CreateMap<ChoiceForTextQuestion, ChoiceForTextQuestionResource>();
            CreateMap<ChoiceQuestion, ChoiceQuestionResource>();
            CreateMap<ChoiceStop, ChoiceStopResource>();
            CreateMap<Introduction, IntroductionResource>();
            CreateMap<MapPosition, MapPositionResource>();
            CreateMap<PasswordGameRequirement, PasswordGameRequirementResource>();
            CreateMap<Picture, PictureResource>();
            CreateMap<Stop, StopResource>();
            CreateMap<Stop, StopOnlyIdResource>();
            CreateMap<StopStop, StopStopResource>();
            CreateMap<TextQuestion, TextQuestionResource>();
            CreateMap<Text, TextResource>();
            CreateMap<User, UserResourceForFullGame>();

            // Resource to Domain
            CreateMap<AdminSaveResource, Admin>();


            CreateMap<UserSaveResource, User>();
            CreateMap<UserSaveWithStatResource, User>();
            CreateMap<StatisticsSaveResource, Statistics>();
        }
    }
}
