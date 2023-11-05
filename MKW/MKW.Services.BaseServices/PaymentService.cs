using MKW.Domain.Interface.Repository.ReviewAggregate;
using MKW.Domain.Interface.Services.BaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Services.BaseServices
{
    public class PaymentService : IPaymentService
    {
        private readonly IAwardRepository _awardRepository;

        public PaymentService(IAwardRepository awardRepository)
        {
            _awardRepository = awardRepository;
        }
    }
}
