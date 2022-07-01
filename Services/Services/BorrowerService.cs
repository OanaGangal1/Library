using AutoMapper;
using DataLayer;
using DataLayer.Entities;
using Services.Dtos.Borrower;
using Services.Exceptions;
using Services.Interfaces;
using Services.Utilities;

namespace Services.Services;

public class BorrowerService : IBorrowerService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BorrowerService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public BorrowerDto Add(BorrowerDto borrowerDto)
    {
        var borrower = _unitOfWork.Borrowers.GetByIdentityNum(borrowerDto.IdentityNumber);
        if (borrower != null)
            throw new BadRequestException(ErrorMessages.ReaderAlreadyRegistered);

        borrower = _mapper.Map<Borrower>(borrowerDto);
        _unitOfWork.Borrowers.Insert(borrower, true);

        borrowerDto.Id = borrower.Id;

        return borrowerDto;
    }

    public BorrowerDto GetByIdentityNum(string identityNum) => 
        _mapper.Map<BorrowerDto>(_unitOfWork.Borrowers.GetByIdentityNum(identityNum));
}