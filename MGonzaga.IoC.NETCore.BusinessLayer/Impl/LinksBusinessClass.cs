﻿using AutoMapper;
using MGonzaga.IoC.NETCore.BusinessLayer.Interfaces;
using MGonzaga.IoC.NETCore.Common.Exceptions;
using MGonzaga.IoC.NETCore.Common.Resources.Enuns;
using MGonzaga.IoC.NETCore.Common.Resources.Models;
using MGonzaga.IoC.NETCore.Domain.Interfaces.Repositories;
using System;
namespace MGonzaga.IoC.NETCore.BusinessLayer.Impl
{
    public class LinksBusinessClass : DefaultBusinessClass<Common.Resources.Models.Links, Domain.Models.Links> , ILinksBusinessClass
    {
        private readonly ILinksRepository _linksRepository;
        private readonly IMapper _mapper;
        public LinksBusinessClass(ILinksRepository linksRepository, IMapper mapper) : base(linksRepository, mapper)
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
                UsedLink = false,
                UniqueId = Guid.NewGuid()
            };
            return this.Insert(newLink);
        }
        public Links GetByUniqueId(Guid uniqueId)
        {
            return _mapper.Map<Links>(_linksRepository.GetByUniqueId(uniqueId));
        }
        public bool IsValidLink(Guid uniqueId)
        {
            var model = _linksRepository.GetByUniqueId(uniqueId);
            Common.Resources.Models.Links selectedLink = _mapper.Map<Common.Resources.Models.Links>(model);
            if (selectedLink == null) throw new ValidationException("Link not found");
            if (selectedLink.UsedLink) throw new ValidationException("This link cannot be used at this time.");
            if (selectedLink.ExpireDate <= DateTime.Now) throw new ValidationException("this link is expired");
            return true;
        }
        public void UpdateUsedLink(Links link)
        {
            link.UsedLink = true;
            _linksRepository.UpdateUsedLink(_mapper.Map<Domain.Models.Links>(link));
            _linksRepository.SaveChanges();
        }
    }
}
