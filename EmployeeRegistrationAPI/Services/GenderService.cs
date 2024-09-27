using AutoMapper;
using EmployeeRegistrationAPI.Models;
using EmployeeRegistrationAPI.Repository;

namespace EmployeeRegistrationAPI.Services
{
    public class GenderService:IGenderService
    {
        private readonly IMapper _mapper;
        private readonly IGenderRepository _genderRepository;
        public GenderService(IMapper _mapper, IGenderRepository _genderRepository)
        {
            this._mapper = _mapper;
            this._genderRepository = _genderRepository;
            
        }

        public async Task CreateAsync(GenderDTO model)
        {
            Gender genderDTO = _mapper.Map<Gender>(model);
               var id = await _genderRepository.CreateAsync(genderDTO);
               model.GenderId = genderDTO.GenderId;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var gender = await  _genderRepository.GetByIdAsync(id);
            if (gender == null)
            {
                throw new ArgumentException("The gender with id {id} not found");
            }
            await _genderRepository.DeleteAsync(gender);
            return true;
        }
        public async Task<List<GenderDTO>> GetAllAsync()
        {
            var gender = await _genderRepository.GetAllAsync();
                   var genderDTOData = _mapper.Map<List<GenderDTO>>(gender);
                   return genderDTOData;
        }

        public async Task<GenderDTO> GetByIdAsync(int id)
        {
            var gender = _genderRepository.GetByIdAsync(id);
                    if (gender == null)
                   {

                        throw new ArgumentException("The Gender with id {id} not found");
                    }
                    var genderDTO = _mapper.Map<GenderDTO>(gender);


                    return genderDTO;
        }

        public async Task UpdateAsync(GenderDTO model)
        {
            var existingGender = await _genderRepository.GetByIdAsync(model.GenderId);
               if (existingGender == null)
                    throw new ArgumentException();
                var newRecord = _mapper.Map<Gender>(model);
                    await _genderRepository.UpdateAsync(newRecord);
        }

        
    }
}
