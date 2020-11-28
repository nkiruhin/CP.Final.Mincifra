using CP.Final.Mincifra.Core.Entities;
using CP.Final.Mincifra.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Xml;

namespace BlueberryCatz.Utils
{
    public class Field
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }

    public class Table
    {
        public string Name { get; set; }
        public string Meta { get; set; }
        public IList<Field> Fields { get; set; }
    }

    public class Relation
    {
        public string From { get; set; }
        public string To { get; set; }
        public int LinkType { get; set; }
    }

    public class Root
    {
        public IList<Table> Tables { get; set; }
        public IList<Relation> Relations { get; set; }
    }
}

namespace CP.Final.Mincifra.Web
{
    public static class SeedData
    {
        public static readonly Entity Node1 = new Entity
        {
            Name = "ФизическоеЛицо",
            CreationDate = DateTime.Now,
            LastEditDate = DateTime.Now,
            ClassName = "",
            Description = "Граждане Российской Федерации, иностранные граждане и лица без гражданства;Налоговый кодекс Российской Федерации (часть первая) от 31.07.1998 N 146-ФЗ (ред. от 27.12.2019) (с изм. и доп., вступ. в силу с 01.01.2020)"
        };
        public static readonly Entity Node2 = new Entity
        {
            Name = "МедицинскаяОрганизация",
            CreationDate = DateTime.Now,
            LastEditDate = DateTime.Now,
            ClassName = "",
            Description = "Юридическое лицо независимо от организационно-правовой формы, осуществляющее в качестве основного (уставного) вида деятельности медицинскую деятельность на основании лицензии, выданной в порядке, установленном законодательством Российской Федерации о лицензировании отдельных видов деятельности.;Федеральный закон от 21.11.2011 N 323-ФЗ (ред. от 01.04.2020) \"Об основах охраны здоровья граждан в Российской Федерации\""
        };
        public static readonly Entity Node3 = new Entity
        {
            Name = "ЮридическоеЛицо",
            CreationDate = DateTime.Now,
            LastEditDate = DateTime.Now,
            ClassName = "",
            Description = "Юридическим лицом признается организация, которая имеет обособленное имущество и отвечает им по своим обязательствам, может от своего имени приобретать и осуществлять гражданские права и нести гражданские обязанности, быть истцом и ответчиком в суде;Гражданский кодекс Российской Федерации (часть первая) от 30.11.1994 N 51-ФЗ (ред. от 16.12.2019)"
        };
        public static readonly Entity Node4 = new Entity
        {
            Name = "МедицинскийРаботник",
            CreationDate = DateTime.Now,
            LastEditDate = DateTime.Now,
            ClassName = "",
            Description = "Физическое лицо, которое имеет медицинское или иное образование, работает в медицинской организации и в трудовые (должностные) обязанности которого входит осуществление медицинской деятельности, либо физическое лицо, которое является индивидуальным предпринимателем, непосредственно осуществляющим медицинскую деятельность;Федеральный закон от 21.11.2011 N 323-ФЗ (ред. от 27.12.2019, с изм. от 13.01.2020) \"Об основах охраны здоровья граждан в Российской Федерации\" (с изм. и доп., вступ. в силу с 08.01.2020)"
        };

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var dbContext = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());
            return;
            PopulateTestData(dbContext);
        }
        public static void PopulateTestData(AppDbContext dbContext)
        {
            foreach (var item in dbContext.Entities) dbContext.Remove(item);
            dbContext.SaveChanges();
            BlueberryCatz.Utils.Root root = JsonSerializer.Deserialize<BlueberryCatz.Utils.Root>(System.IO.File.ReadAllText(@"C:\Users\79678\go\src\own\owl-parse\content1.json"));
            foreach (var x in root.Tables)
            {
                var entity = new Entity
                {
                    Name = x.Name,
                    CreationDate = DateTime.Now,
                    LastEditDate = DateTime.Now,
                    ClassName = "",
                    Description = x.Meta,
                    MetaDatas = new List<MetaData>()
                };
                foreach (var f in x.Fields)
                {
                    entity.MetaDatas.Add(new MetaData
                    {
                        Key = f.Name,
                        Type = f.Type,
                        Value = ""
                    });
                }
                dbContext.Entities.Add(entity);
            }
            dbContext.SaveChanges();
            foreach (var l in root.Relations)
            {
                var from = dbContext.Entities.Where(x => x.Name == l.From).FirstOrDefault();
                var to = dbContext.Entities.Where(x => x.Name == l.To).FirstOrDefault();
                LinkType lt = (LinkType)l.LinkType;
                if (from != null && to != null)
                {
                    dbContext.Links.Add(new Link
                    {
                        FromEntityId = from.Id,
                        ToEntityId = to.Id,
                        Type = lt
                    });
                }
            }
            dbContext.SaveChanges();
        }
    }
}
