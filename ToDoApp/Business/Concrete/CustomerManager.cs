using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        IMapper _mapper;
        public CustomerManager(ICustomerDal customerDal,IMapper mapper)
        {
            _customerDal = customerDal;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            //ValidationTool.Validate(new CustomerValidator(), customer);
            if (!customer.Email.Contains("@"))
            {
                throw new Exception("log exception");
            }
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<List<CustomerDto>> GetAll()
        {
            var result = _customerDal.GetAll();
            var mappedResult = new List<CustomerDto>();
            foreach (var item in result)
            {
                var mapResult = _mapper.Map<CustomerDto>(item);
                mappedResult.Add(mapResult);
            }
            return new SuccessDataResult<List<CustomerDto>>(mappedResult);
        }

        public IDataResult<CustomerDto> GetById(int id)
        {
            var result = _customerDal.GetById(c => c.CustomerId == id);
            var mappedResult = _mapper.Map<CustomerDto>(result);
            return new SuccessDataResult<CustomerDto>(mappedResult);
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
