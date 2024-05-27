using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces.Repositories;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PhoneService : IPhoneService
    {
        private readonly IPhoneRepository _phoneRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public PhoneService(IPhoneRepository phoneRepository, IUserRepository userRepository, IMapper mapper)
        {
            _phoneRepository = phoneRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<int> AddPhoneAsync(int userId, PhoneDTO phoneDTO)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                throw new InvalidOperationException("User not found.");
            }

            var phone = _mapper.Map<Phone>(phoneDTO);
            phone.UserId = userId;

            await _phoneRepository.AddAsync(phone);

            return phone.Id;
        }

        public async Task UpdatePhoneAsync(int id, PhoneDTO phoneDTO)
        {
            var phone = await _phoneRepository.GetByIdAsync(id);
            if (phone == null)
            {
                throw new InvalidOperationException("Phone not found.");
            }

            _mapper.Map(phoneDTO, phone);
            await _phoneRepository.UpdateAsync(phone);
        }

        public async Task DeletePhoneAsync(int id)
        {
            var phone = await _phoneRepository.GetByIdAsync(id);
            if (phone == null)
            {
                throw new InvalidOperationException("Phone not found.");
            }

            await _phoneRepository.DeleteAsync(id);
        }

        public async Task<PhoneDTO> GetPhoneByIdAsync(int id)
        {
            var phone = await _phoneRepository.GetByIdAsync(id);
            if (phone == null)
            {
                throw new InvalidOperationException("Phone not found.");
            }

            return _mapper.Map<PhoneDTO>(phone);
        }

        public async Task<PhoneDTO> GetPhoneByNumberAsync(string ddd, string number)
        {
            var phone = await _phoneRepository.GetByPhoneNumberAsync(ddd, number);
            if (phone == null)
            {
                throw new InvalidOperationException("Phone not found.");
            }

            return _mapper.Map<PhoneDTO>(phone);
        }

        public async Task<List<PhoneDTO>> GetPhonesByUserIdAsync(int userId)
        {
            var phones = await _phoneRepository.GetPhonesByUserIdAsync(userId);
            return _mapper.Map<List<PhoneDTO>>(phones);
        }

    }
}
