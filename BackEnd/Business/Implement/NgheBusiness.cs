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
    public class NgheBusiness : INgheBusiness
    {
        private readonly INgheRepository _ngheRepository;
        private readonly ICauHoiRepository _cauHoiRepository;

        public NgheBusiness(INgheRepository ngheRepository,ICauHoiRepository cauHoiRepository)
        {
            _ngheRepository = ngheRepository;
            _cauHoiRepository = cauHoiRepository;
        }

        public async Task<IEnumerable<NgheEntity>> GetDSNghe_CauHoi(int maTopic)
        {
            List<NgheEntity> list = new List<NgheEntity>();
            GetListFileNgheRequest r = new GetListFileNgheRequest();
            r.idTopic=maTopic;
            var listNghe = await _ngheRepository.LayDSFileNghe(r);
            foreach (var item in listNghe)
            {
                var listCH = await _cauHoiRepository.GetListCauHoi_IDNghe(item.ID) as List<CauHoi>;
                list.Add(new NgheEntity
                {
                    nghe = item,
                    CauHois = listCH
                });
            }
            return list;
        }

        public async Task<string> GetMusic(int idDeThi)
        {
             return await _ngheRepository.GetMusic(idDeThi);
        }
        public async Task<int> Add(ThemFileNgheRequest r)
        {
           return await _ngheRepository.ThemFileNghe(r);
        }
        public async Task<int> Update(SuaFileNgheRequest r)
        {
           return await _ngheRepository.SuaFileNghe(r);
        }
        public async Task<bool> Delete(XoaFileNgheRequest r)
        {
           return await _ngheRepository.XoaFileNghe(r);
        }
    }
}
