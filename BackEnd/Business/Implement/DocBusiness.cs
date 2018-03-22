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
            var listDoc = await _docRepository.LayDSDoanVan(maTopic);
            foreach (var item in listDoc)
            {
                var listCH = await _cauHoiRepository.GetListCauHoi_IDDoc(item.ID) as List<CauHoi>;
                list.Add(new DocEntity
                {
                    doc = item,
                    CauHois = listCH
                });
            }
            return list;
        }

        public async Task<string> GetParagraph(int idDeThi)
        {
            return await _docRepository.GetParagraph(idDeThi);
        }
        public async Task<AddResponse> Add(ThemDoanVanRequest r)
        {
           return await _docRepository.ThemDoanVan(r);
        }
        public async Task<AddResponse> Update(SuaDoanVanRequest r)
        {
           return await _docRepository.SuaDoanVan(r);
        }
        public async Task<bool> Delete(XoaDoanVanRequest r)
        {
           return await _docRepository.XoaDoanVan(r);
        }
    }
}
