using Data;
using Models.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CodingLanguageService
    {
        public CodingLanguageService() 
        {
            
        }

        public bool CreateCodingLanguage(LanguageCreate model)
        {
            var entity =
                new CodingLanguage()
                {
                    LanguageId = model.LanguageId,
                    LanguageName = model.LanguageName,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.CodingLanguages.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<LanguageListItem> GetAllCodingLanguages()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .CodingLanguages
                        .Select(
                            e =>
                                new LanguageListItem
                                {
                                    LanguageId = e.LanguageId,
                                    LanguageName = e.LanguageName
                                }
                        );

                return query.ToArray();
            }
        }

        public bool UpdateCodingLanguage(LanguageEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CodingLanguages
                        .Single(e => e.LanguageId == model.LanguageId);

                entity.LanguageId = model.LanguageId;
                entity.LanguageName = model.LanguageName;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCodingLanguage(int codingLanguageID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CodingLanguages
                        .Single(e => e.LanguageId == codingLanguageID);

                ctx.CodingLanguages.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
