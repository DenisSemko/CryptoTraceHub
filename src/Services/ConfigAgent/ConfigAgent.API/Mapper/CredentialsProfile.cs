namespace ConfigAgent.API.Mapper;

public class CredentialsProfile : Profile
{
    public CredentialsProfile()
    {
        CreateMap<Credentials, CredentialsModel>()
            .ConvertUsing(new CredentialsToCredentialsModel());
        CreateMap<CredentialsModel, Credentials>()
            .ConvertUsing(new CredentialsModelToCredentials());
    }
}