using AutoMapper;
using EmployeeRegistrationAPI.Models;
using EmployeeRegistrationAPI.Repository;

namespace EmployeeRegistrationAPI.Services
{
    public class DepartmentService:IDepartmentService
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IMapper _mapper, IDepartmentRepository _departmentRepository)
        {
            this._mapper = _mapper;
            this._departmentRepository = _departmentRepository;
            
        }

        public async Task CreateAsync(DepartmentDTO model)
        {
            Department departmentDTO = _mapper.Map<Department>(model);
            await _departmentRepository.CreateAsync(departmentDTO);
            model.DepartmentId = departmentDTO.DepartmentId;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var department = await _departmentRepository.GetByIdAsync(id);
            if (department == null)
            {
                throw new ArgumentException("The Department with id {id} not found");
            }
            await _departmentRepository.DeleteAsync(department);
            return true;

        }

        public async Task<List<DepartmentDTO>> GetAllAsync()
        {
            var department = await _departmentRepository.GetAllAsync();
            var departmentDTOData = _mapper.Map<List<DepartmentDTO>>(department);
            return departmentDTOData;
        }

        public async Task<DepartmentDTO> GetByIdAsync(int id)
        {
            var department = await _departmentRepository.GetByIdAsync(id);
            if (department == null)
            {

                throw new ArgumentException("The Department with id {id} not found");
            }
            var departmentDTO = _mapper.Map<DepartmentDTO>(department);

            return departmentDTO;
        }

        public async Task UpdateAsync(DepartmentDTO model)
        {
            var existingDepartment = await _departmentRepository.GetByIdAsync(model.DepartmentId);
            if (existingDepartment == null)
                throw new ArgumentException();
            var newRecord = _mapper.Map<Department>(model);
             _departmentRepository.UpdateAsync(newRecord);
        }
    }
}
