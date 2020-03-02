using AutoMapper;
using MGonzaga.IoC.NETCore.BussinessLayer.Interfaces;
using MGonzaga.IoC.NETCore.Common.Exceptions;
using MGonzaga.IoC.NETCore.Common.Resources.Enuns;
using MGonzaga.IoC.NETCore.Common.Resources.Models;
using MGonzaga.IoC.NETCore.Domain.Interfaces.Repositories;
using System;
namespace MGonzaga.IoC.NETCore.BussinessLayer.Impl
{
    public class LinksBussinessClass : DefaultBussinessClass<Common.Resources.Models.Links, Domain.Models.Links> , ILinksBussinessClass
    {
        private readonly ILinksRepository _linksRepository;
        private readonly IMapper _mapper;
        public LinksBussinessClass(ILinksRepository linksRepository, IMapper mapper) : base(linksRepository, mapper)
        {
            _linksRepository = linksRepository;
            _mapper = mapper;
        }

        public Links AddNewLink(int objectId, AcceptedLinksTypeEnum linkType)
        {
            var newLink = new Links()
            {
                Type = linkType,
                ObjectId = objectId,
                CreateDate = DateTime.Now,
                ExpireDate = DateTime.Now.AddHours(24),
                UniqueId = Guid.NewGuid()
            };
            return this.Insert(newLink);
        }
        public Links GetByUniqueId(Guid uniqueId)
        {
            return _mapper.Map<Links>(_linksRepository.GetByUniqueId(uniqueId));
        }
        public bool IsValidLink(Guid uniqueId, AcceptedLinksTypeEnum type)
        {
            var model = _linksRepository.GetByUniqueId(uniqueId);
            Common.Resources.Models.Links selectedLink = _mapper.Map<Common.Resources.Models.Links>(model);
            if (selectedLink == null) throw new ValidationException("Link not found");
            if (selectedLink.Type != type) throw new ValidationException("this link is invalid for operation");
            if (selectedLink.ExpireDate <= DateTime.Now) throw new ValidationException("this link is expired");
            return true;
        }
    }
}
