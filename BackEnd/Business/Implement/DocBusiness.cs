using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PracticeEnglish.Business.Interface;
using PracticeEnglish.Contracts.Request;
using PracticeEnglish.Contracts.Response;
using PracticeEnglish.Data.Interface;
using PracticeEnglish.Entity;
using PracticeEnglish.Models;

namespace PracticeEnglish.Business.Implement
{
    public class DocBusiness : IDocBusiness
    {
        private readonly IDocRepository _docRepository;
        private readonly ICauHoiRepository _cauHoiRepository;

        public DocBusiness(IDocRepository docRepository,ICauHoiRepository cauHoiRepository)
        {
            _docRepository = docRepository;
            _cauHoiRepository = cauHoiRepository;
        }

        public async Task<IEnumerable<DocEntity>> GetDSDoc_CauHoi(int maTopic)
        {
            List<DocEntity> list = new List<DocEntity>();
            GetListDoanVanRequest r = new GetListDoanVanRequest();
            r.idTopic=maTopic;
            var listNghe = await _docRepository.LayDSDoanVan(r);
            foreach (var item in listNghe)
            {
                var listCH = await _cauHoiRepository.GetListCauHoi_IDNghe(item.ID) as List<CauHoi>;
                list.Add(new DocEntity
                {
                    doc = item,
                    CauHois = listCH
                });
            }
            return list;
        }
        public async Task<int> Add(ThemDoanVanRequest r)
        {
           return await _docRepository.ThemDoanVan(r);
        }
        public async Task<int> Update(SuaDoanVanRequest r)
        {
           return await _docRepository.SuaDoanVan(r);
        }
        public async Task<bool> Delete(XoaDoanVanRequest r)
        {
           return await _docRepository.XoaDoanVan(r);
        }
    }
}
