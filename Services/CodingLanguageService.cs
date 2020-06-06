using Data;
using Models.CodingLanguage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CodingLanguageService
    {
        private readonly Guid _userId;
        private readonly ApplicationDbContext _ctx = new ApplicationDbContext();

        public CodingLanguageService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCodingLanguage(CodingLanguageCreate codingLanguageCreate)
        {
            var entity = new CodingLanguage()
            {
                CodingLanguageName = codingLanguageCreate.CodingLanguageName
            };

            _ctx.CodingLanguages.Add(entity);
            return _ctx.SaveChanges() == 1;
        }

        public List<CodingLanguageListItem> GetCodingLanguages()
        {
            var query = _ctx.CodingLanguages.Select(e => new CodingLanguageListItem
            {
                CodingLanguageId = e.CodingLanguageId,
                CodingLanguageName = e.CodingLanguageName
            });

            return query.ToList();
        }

        public bool CodingLanguageDelete(int codingLangaugeId)
        {
            var entity = _ctx.CodingLanguages.Single(j => j.CodingLanguageId == codingLangaugeId);
            _ctx.CodingLanguages.Remove(entity);
            return _ctx.SaveChanges() == 1;
        }
    }
}
