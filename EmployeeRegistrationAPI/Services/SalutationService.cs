using AutoMapper;
using EmployeeRegistrationAPI.Models;
using EmployeeRegistrationAPI.Repository;

namespace EmployeeRegistrationAPI.Services
{
    public class SalutationService:ISalutationService
    {
        private readonly IMapper _mapper;
        private readonly ISalutationRepository _salutationRepository;
        public SalutationService(IMapper _mapper, ISalutationRepository _salutationRepository)
        {
            this._mapper = _mapper;
            this._salutationRepository = _salutationRepository;
            
        }

        public  async Task CreateAsync(SalutationDTO model)
        {
            Salutation salutationDTO = _mapper.Map<Salutation>(model);
            var id = await _salutationRepository.CreateAsync(salutationDTO);
            model.SalutationId = salutationDTO.SalutationId;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var salutation = await _salutationRepository.GetByIdAsync(id);
            if (salutation == null)
            {
                throw new ArgumentException("The Salutation with id {id} not found");
            }
            await _salutationRepository.DeleteAsync(salutation);
            return true;

        }

        public async Task<List<SalutationDTO>> GetAllAsync()
        {
            var salutation = await _salutationRepository.GetAllAsync();
            var salutationDTOData = _mapper.Map<List<SalutationDTO>>(salutation);
            return salutationDTOData;
        }
        public async Task<SalutationDTO> GetByIdAsync(int id)
        {
                var salutation = await _salutationRepository.GetByIdAsync(id);

                if (salutation == null)
                {

                    throw new ArgumentException("The Salutation with id {id} not found");
                }
                var salutationDTO = _mapper.Map<SalutationDTO>(salutation);

                return salutationDTO;
        }

        public async  Task UpdateAsync(SalutationDTO model)
        {
            var existingSalutation = await _salutationRepository.GetByIdAsync(model.SalutationId);
            if (existingSalutation == null)
                throw new ArgumentException();
            var newRecord = _mapper.Map<Salutation>(model);
            await _salutationRepository.UpdateAsync(newRecord);
        }
    }
}
