using AutoMapper;
using EmployeeRegistrationAPI.Models;
using EmployeeRegistrationAPI.Repository;
using System.Collections.Generic;

namespace EmployeeRegistrationAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IMapper _mapper, IEmployeeRepository _employeeRepository)
        {
            this._mapper = _mapper;
            this._employeeRepository = _employeeRepository;

        }

        public async Task CreateAsync(EmployeeDTO model)
        {
            // Employee employeeDTO = _mapper.Map<Employee>(model);
            var employee = new Employee
            {
                EmployeeId = model.EmployeeId,
                EmployeeCode = model.EmployeeCode,
                SalutationId = model.SalutationId,
                DepartmentId = model.DepartmentId,
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                Lastname = model.Lastname,
                DisplayName = model.DisplayName,
                FatherName = model.FatherName,
                MotherName = model.MotherName,
                SpouseName = model.SpouseName,
                GenderId = model.GenderId,
                MaritalStatus = model.MaritalStatus,
                Dob = model.Dob,
                Doj = model.Doj,
                Panno = model.Panno,
                Aadharno = model.Aadharno,
                Description = model.Description,


            };

            await _employeeRepository.CreateAsync(employee);
            model.EmployeeId = employee.EmployeeId;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null)
            {
                throw new ArgumentException("The Employee with id {id} not found");
            }

            await _employeeRepository.DeleteAsync(employee);
            return true;
        }

        public async Task<List<EmployeeDTO>> GetAllAsync()
        {
            var employee = await _employeeRepository.GetAllAsync();
           // var employeeDTOData = _mapper.Map<List<EmployeeDTO>>(employee);
           // return employeeDTOData;
        
            //EmployeeDTO obj = new EmployeeDTO();
           var result = employee.Select(e => new EmployeeDTO
            {
               EmployeeId = e.EmployeeId,
               EmployeeCode = e.EmployeeCode,
              SalutationId = e.SalutationId,
               DepartmentId = e.DepartmentId,
              FirstName = e.FirstName,
              MiddleName = e.MiddleName,
               Lastname = e.Lastname,
                DisplayName = e.DisplayName,
              FatherName = e.FatherName,
               MotherName = e.MotherName,
               SpouseName = e.SpouseName,
               GenderId = e.GenderId,
                MaritalStatus = e.MaritalStatus,
               Dob = e.Dob,
               Doj = e.Doj,
               Panno = e.Panno,
                Aadharno = e.Aadharno,
               Description = e.Description,
               DepartmentName = e.Department.DepartmentName,
              SalutationName = e.Salutation.SalutationName,
               GenderName = e.Gender.GenderName,

            }).ToList();
            return result;
        }



        public async Task<EmployeeDTO> GetByIdAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null)
            {

                throw new ArgumentException("The Department with id {id} not found");
            }
           // var employeeDTO = _mapper.Map<EmployeeDTO>(employee);
            var emplo = new EmployeeDTO
            {
                   EmployeeId = employee.EmployeeId,
                  EmployeeCode = employee.EmployeeCode,
                  SalutationId = employee.SalutationId,
                  DepartmentId = employee.DepartmentId,
                  FirstName = employee.FirstName,
                  MiddleName = employee.MiddleName,
                  Lastname = employee.Lastname,
                  DisplayName = employee.DisplayName,
                  FatherName = employee.FatherName,
                   MotherName = employee.MotherName,
                  SpouseName = employee.SpouseName,
                   GenderId = employee.GenderId,
                  MaritalStatus = employee.MaritalStatus,
                  Dob = employee.Dob,
                  Doj = employee.Doj,
                  Panno = employee.Panno,
                  Aadharno = employee.Aadharno,
                  Description = employee.Description,
                  DepartmentName = employee.Department.DepartmentName,
                 SalutationName = employee.Salutation.SalutationName,
               GenderName = employee.Gender.GenderName,
            };
            return emplo;
            //return employeeDTO ;
        }

        public async Task<EmployeeDTO> GetByNameAsync(string name)
        {
            var employee = await _employeeRepository.GetByNameAsync(name);
            if (employee == null)
            {
                throw new ArgumentException("The Employee with name {name} not found");
            }
            //var employeeDTO = _mapper.Map<EmployeeDTO>(employee);

            //return employeeDTO;
            var emplo = new EmployeeDTO
            {
                EmployeeId = employee.EmployeeId,
                EmployeeCode = employee.EmployeeCode,
                SalutationId = employee.SalutationId,
                DepartmentId = employee.DepartmentId,
                FirstName = employee.FirstName,
                MiddleName = employee.MiddleName,
                Lastname = employee.Lastname,
                DisplayName = employee.DisplayName,
                FatherName = employee.FatherName,
                MotherName = employee.MotherName,
                SpouseName = employee.SpouseName,
                GenderId = employee.GenderId,
                MaritalStatus = employee.MaritalStatus,
                Dob = employee.Dob,
                Doj = employee.Doj,
                Panno = employee.Panno,
                Aadharno = employee.Aadharno,
                Description = employee.Description,
                DepartmentName = employee.Department.DepartmentName,
                SalutationName = employee.Salutation.SalutationName,
                GenderName = employee.Gender.GenderName,
            };
            return emplo;
        }

        public async Task<Employee> UpdateAsync(EmployeeUpdateDTO model)
        {
            var existingEmployee = await _employeeRepository.GetByIdAsync(model.EmployeeId);
            ArgumentNullException.ThrowIfNull(model);
            //var newRecord = _mapper.Map<Employee>(model);
            //EmployeeDTO obj = new EmployeeDTO();


            var employee= new Employee
            {
               EmployeeId = model.EmployeeId,
               EmployeeCode = model.EmployeeCode,
               SalutationId = model.SalutationId,
               DepartmentId = model.DepartmentId,
               FirstName = model.FirstName,
                MiddleName = model.MiddleName,
               Lastname = model.Lastname,
                DisplayName = model.DisplayName,
                FatherName = model.FatherName,
                MotherName = model.MotherName,
                SpouseName = model.SpouseName,
               GenderId = model.GenderId,
               MaritalStatus = model.MaritalStatus,
               Dob = model.Dob,
               Doj = model.Doj,
               Panno = model.Panno,
               Aadharno = model.Aadharno,
               Description = model.Description,


            };
            
            var data = await _employeeRepository.UpdateAsync(employee);
            
            return data;
            
        } 
    }
            
 }

       
   
