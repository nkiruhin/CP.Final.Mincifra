namespace CP.Final.Mincifra.Web.ApiModels
{
    public class MetadataDto
    {
        public long Id { get; set; }
        public string Table_name { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string Icon { get; set; } = string.Empty;
        public string Form_type { get; set; } = string.Empty;
        public string Type { get; set; }
        public bool Required { get; set; } = true;
        public int Primary { get; set; } = 1;
        public bool Is_foreign_key { get; set; } = false;
        public bool Auto_increment { get; set; } = false;
    }
}
