using Constants = ConfigAgent.API.Common.Constants;

namespace ConfigAgent.API.Services;

public class CredentialsService : ICredentialsService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICipherService _cipherService;
    private readonly IMapper _mapper;

    public CredentialsService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper  ?? throw new ArgumentNullException(nameof(mapper));
        _cipherService = CipherLocator.GetService<ICipherService>();
    }

    public async Task<CredentialsModel> Get()
    {
        IReadOnlyList<Credentials> databaseCredentials = await _unitOfWork.Credentials.GetAllAsync();

        if (!databaseCredentials.Any())
        {
            throw new KeyNotFoundException(Constants.Credentials.NotFoundException);
        }
        
        return _mapper.Map<CredentialsModel>(databaseCredentials.FirstOrDefault());
    }

    public async Task InsertOne(CredentialsModel entity)
    {
        string credentialsToEncrypt = $"{entity.ApiKey};{entity.BaseUrl}";
        string encryptedData = _cipherService.Encrypt(credentialsToEncrypt);

        Credentials databaseCredentials = new ()
        {
            Id = Guid.NewGuid(),
            EncryptedCredentials = encryptedData,
            CoinApiType = CoinApiType.CoinMarketCap
        };
        await _unitOfWork.Credentials.InsertOneAsync(databaseCredentials);
    }

    public async Task Update(CredentialsModel entity)
    {
        Credentials existedCredentials = await _unitOfWork.Credentials.GetByCoinApiType(entity.CoinApiType);

        if (existedCredentials is null)
        {
            throw new KeyNotFoundException(Constants.Credentials.NotFoundException);
        }
        
        Credentials credentialsToUpdate = _mapper.Map(entity, existedCredentials);
        
        await _unitOfWork.Credentials.UpdateAsync(credentialsToUpdate);
    }

    public async Task Delete(Guid id)
    {
        Credentials? existedCredentials = await _unitOfWork.Credentials.GetByIdAsync(id);

        if (existedCredentials is not null)
        {
            await _unitOfWork.Credentials.DeleteAsync(id);
        }
        else
        {
            throw new KeyNotFoundException(Constants.Credentials.NotFoundException);
        }
    }
}