using Academy.Application.DTO_s;
using Academy.Core.Interface;
using Academy.Core.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Application.Commands.PaymentStudentCommand
{
    public class PaymentStudentCommandHandler : IRequestHandler<PaymentStudentCommand, bool>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IPaymentService _paymentService;

        public PaymentStudentCommandHandler(IPaymentRepository paymentRepository, IPaymentService paymentService, IStudentRepository studentRepository)
        {
            _paymentRepository = paymentRepository;
            _paymentService = paymentService;
            _studentRepository = studentRepository;
        }

        public async Task<bool> Handle(PaymentStudentCommand request, CancellationToken cancellationToken)
        {
            var payment = await _paymentRepository.GetByIdAsync(request.Id);

            decimal amount = 0.0m;
            var paymentInfoDto = new PaymentInfoDTO(request.Id, request.CreditCardNumber, request.Cvv, request.ExpiresAt, request.FullName, amount);

            _paymentService.ProcessPayment(paymentInfoDto);

            await _paymentRepository.Finish(payment);

            return true;
        }
    }
    
    
}
