using Application.DTOs;
using Application.Generics;
using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces.Repositories;
using Entities.Entities;
using Infrastructure.Repository.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPhoneRepository _phoneRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IPhoneRepository phoneRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _phoneRepository = phoneRepository;
            _mapper = mapper;
        }

        public async Task<int> CreateUser(UserDTO userDTO)
        {
            User user = _mapper.Map<User>(userDTO);
            user.IsActive = true;

            await _userRepository.AddAsync(user);

            await _phoneRepository.SaveChangesAsync();

            return user.Id;
        }

        public async Task<PagedUserDTO> GetPagedUsers(int pageNumber, int pageSize)
        {
            var pagedResult = await _userRepository.GetUsersWithPhonesPagedAsync(pageNumber, pageSize);

            var userDTOs = pagedResult.Items.Select(user =>
            {
                var phonesDTO = _mapper.Map<List<PhoneDTO>>(user.Phones);
                var userDTO = _mapper.Map<UserDTO>(user);
                userDTO.Phones = phonesDTO;
                return userDTO;
            }).ToList();

            var pagedUserDTO = new PagedUserDTO
            {
                Users = userDTOs,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalItems = pagedResult.TotalItems,
                TotalPages = pagedResult.TotalPages
            };

            return pagedUserDTO;
        }

        private string CleanPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                return string.Empty;
            }
            StringBuilder cleanedPhoneNumber = new StringBuilder();
            foreach (char c in phoneNumber)
            {
                if (char.IsDigit(c))
                {
                    cleanedPhoneNumber.Append(c);
                }
            }

            return cleanedPhoneNumber.ToString();
        }

        public async Task<List<UserDTO>> GetUserByPhoneNumber(string phoneNumber, string ddd)
        {
            string cleanedPhoneNumber = CleanPhoneNumber(phoneNumber);
            string dddClear = CleanPhoneNumber(ddd);

            var users = await _userRepository.GetUsersByPhoneNumberAsync(cleanedPhoneNumber, ddd);

            var userDTOs = users.Select(user =>
            {
                var userDTO = _mapper.Map<UserDTO>(user);
                userDTO.Phones = _mapper.Map<List<PhoneDTO>>(user.Phones);
                return userDTO;
            }).ToList();

            return userDTOs;
        }

        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(@"
                                + @"(([-a-z0-9]|(?<!\.)\.)+)"
                                + @"\.[a-z]{2,6})$";
            Regex regex = new Regex(emailPattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }


        public async Task UpdateUserEmail(int userId, string newEmail)
        {
            if (!IsValidEmail(newEmail))
            {
                throw new ArgumentException("Invalid email format.");
            }

            var user = await _userRepository.GetByIdAsync(userId);

            if (user == null)
            {
                throw new InvalidOperationException("User not found.");
            }

            user.Email = newEmail;
            await _userRepository.UpdateAsync(user);
        }

        public async Task UpdateUserPhone(int userId, int idPhone, PhoneDTO updatePhoneDTO)
        {
            var user = await _userRepository.GetByIdWithPhonesAsync(userId);


            if (user == null)
            {
                throw new InvalidOperationException("User not found.");
            }

            var phone = user.Phones.FirstOrDefault(p => p.Id == idPhone);

            if (phone == null)
            {
                throw new InvalidOperationException("Phone not found for the user.");
            }

            phone.DDD = updatePhoneDTO.DDD;
            phone.Number = updatePhoneDTO.Number;

            await _phoneRepository.UpdateAsync(phone);
        }

        public async Task<bool> DeleteUserByEmail(string email)
        {
            if (!IsValidEmail(email))
            {
                throw new ArgumentException("Invalid email format.");
            }

            var user = await _userRepository.GetByEmailAsync(email);

         
            if (user == null)
            {
                return false;
            }

            await _userRepository.RemoveAsync(email);
            return true;
        }

    }

}
